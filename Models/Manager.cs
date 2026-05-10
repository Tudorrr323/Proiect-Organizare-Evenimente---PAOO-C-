using System.Text;

namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public class Manager : Utilizator
    {
        public string? Companie { get; set; }

        public Manager(long idUser, string prenume, string? nume, string? email, string? telefon,
                       DateTime? dataNasterii, string? parola, DateTime? dataInregistrare, string? companie)
            : base(idUser, prenume, nume, email, telefon, dataNasterii, parola, dataInregistrare)
        {
            Companie = companie;
        }

        public override RolUtilizator Rol => RolUtilizator.Manager;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            if (!string.IsNullOrWhiteSpace(Companie)) sb.Append($", Companie: {Companie}");
            return sb.ToString();
        }
    }
}
