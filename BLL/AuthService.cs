using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.BLL
{
    /// <summary>
    /// Aruncata cand un cont suspendat incearca sa se logheze. Login Form-ul prinde exceptia
    /// si afiseaza mesajul de notificare administrator.
    /// </summary>
    public class ContSuspendatException : Exception
    {
        public ContSuspendatException()
            : base("Contul tau a fost suspendat. Te rugam sa contactezi administratorul.") { }
    }

    public class AuthService
    {
        private readonly UserRepository _users = new();
        private readonly PasswordHash _hasher = new();

        /// <summary>
        /// Verifica credentialele si autentifica utilizatorul. Daca parola din DB e plain text,
        /// o transforma in hash BCrypt la prima logare reusita ("lazy upgrade").
        /// Arunca <see cref="ContSuspendatException"/> daca contul este suspendat.
        /// </summary>
        public Utilizator? Login(string email, string parola)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(parola)) return null;

            var u = _users.GetByEmail(email.Trim());
            if (u == null || string.IsNullOrEmpty(u.Parola)) return null;

            bool match;
            if (_hasher.EsteHashBCrypt(u.Parola))
            {
                match = _hasher.Verifica(parola, u.Parola);
            }
            else
            {
                // Parola stocata in clar (din backup) -> compara direct, apoi upgradeaza
                match = u.Parola == parola;
                if (match)
                {
                    var newHash = _hasher.Passhash(parola);
                    _users.UpdateParola(u.IdUser, newHash);
                    u.Parola = newHash;
                }
            }

            if (!match) return null;

            // Daca contul este suspendat, blocam login-ul DUPA verificarea credentialelor
            // (ca sa nu spunem atacatorului ca emailul exista cu/fara parola)
            if (u.EsteSuspendat) throw new ContSuspendatException();

            SessionManager.Login(u);
            return u;
        }

        /// <summary>
        /// Inregistreaza un cont nou. Intoarce id-ul nou. Arunca <see cref="InvalidOperationException"/>
        /// daca email-ul exista deja.
        /// </summary>
        public long Register(string prenume, string? nume, string email, string parola, string? telefon,
                             DateTime? bday, RolUtilizator rol, string? companie)
        {
            if (_users.EmailExists(email))
                throw new InvalidOperationException("Exista deja un cont cu acest email.");

            var hash = _hasher.Passhash(parola);
            return _users.Insert(prenume, nume, email.Trim(), hash, telefon, bday, rol, companie);
        }

        /// <summary>
        /// Actualizeaza datele profilului utilizatorului curent. Email-ul trebuie sa fie unic
        /// (verificat doar daca s-a schimbat).
        /// </summary>
        public void UpdateProfil(string prenume, string? nume, string email, string? telefon,
                                  DateTime? bday, string? companie)
        {
            if (SessionManager.UtilizatorCurent == null)
                throw new InvalidOperationException("Nu esti autentificat.");

            var u = SessionManager.UtilizatorCurent;
            if (string.IsNullOrWhiteSpace(prenume))
                throw new InvalidOperationException("Prenumele este obligatoriu.");
            if (!Validators.IsEmail(email))
                throw new InvalidOperationException("Email invalid.");

            // Daca s-a schimbat email-ul, verificam unicitate
            if (!string.Equals(u.Email, email.Trim(), StringComparison.OrdinalIgnoreCase) && _users.EmailExists(email.Trim()))
                throw new InvalidOperationException("Email-ul este deja folosit de alt cont.");

            _users.UpdateProfil(u.IdUser, prenume.Trim(), nume?.Trim(), email.Trim(), telefon?.Trim(), bday, companie?.Trim());

            // Sincronizam SessionManager cu noile valori
            u.Prenume = prenume.Trim();
            u.Nume = nume?.Trim();
            u.Email = email.Trim();
            u.Telefon = telefon?.Trim();
            u.DataNasterii = bday;
            if (u is Manager m) m.Companie = companie?.Trim();
        }

        /// <summary>
        /// Schimba parola utilizatorului curent. Verifica parola veche, hash-uieste cea noua.
        /// </summary>
        public void SchimbaParola(string parolaVeche, string parolaNoua)
        {
            if (SessionManager.UtilizatorCurent == null)
                throw new InvalidOperationException("Nu esti autentificat.");
            if (!Validators.IsParolaValida(parolaNoua, 4))
                throw new InvalidOperationException("Parola noua trebuie sa aiba minim 4 caractere.");

            var u = SessionManager.UtilizatorCurent;
            if (string.IsNullOrEmpty(u.Parola))
                throw new InvalidOperationException("Cont fara parola - foloseste resetare.");

            bool match = _hasher.EsteHashBCrypt(u.Parola)
                ? _hasher.Verifica(parolaVeche, u.Parola)
                : u.Parola == parolaVeche;

            if (!match)
                throw new InvalidOperationException("Parola veche incorecta.");

            var hashNou = _hasher.Passhash(parolaNoua);
            _users.UpdateParola(u.IdUser, hashNou);
            u.Parola = hashNou;
        }
    }
}
