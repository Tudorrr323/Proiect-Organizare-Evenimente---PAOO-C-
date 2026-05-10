namespace Proiect_PAOO_Organizare_Evenimente.BLL
{
    /// <summary>
    /// Hash-uire parole. Numele de clasa pastrat din proiectul model McLaughingHospital,
    /// dar implementarea foloseste BCrypt (mai sigur decat SHA1).
    /// </summary>
    public class PasswordHash
    {
        private const int WorkFactor = 11;

        /// <summary>Hash BCrypt cu salt aleator. Format: "$2a$11$..." (60 caractere).</summary>
        public string Passhash(string parola)
            => BCrypt.Net.BCrypt.HashPassword(parola, WorkFactor);

        /// <summary>True daca <paramref name="parola"/> in clar verifica <paramref name="hash"/>.</summary>
        public bool Verifica(string parola, string hash)
        {
            try { return BCrypt.Net.BCrypt.Verify(parola, hash); }
            catch { return false; }
        }

        /// <summary>True daca <paramref name="stocata"/> arata a hash BCrypt (start cu $2).</summary>
        public bool EsteHashBCrypt(string? stocata)
            => !string.IsNullOrEmpty(stocata) && stocata.StartsWith("$2");
    }
}
