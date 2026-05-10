using System.Text;

namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public abstract class Persoana
    {
        public string Prenume { get; set; }
        public string? Nume { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public DateTime? DataNasterii { get; set; }

        protected Persoana(string prenume, string? nume, string? email, string? telefon, DateTime? dataNasterii)
        {
            Prenume = prenume;
            Nume = nume;
            Email = email;
            Telefon = telefon;
            DataNasterii = dataNasterii;
        }

        public string NumeComplet => string.IsNullOrWhiteSpace(Nume) ? Prenume : $"{Prenume} {Nume}";

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{NumeComplet}");
            if (!string.IsNullOrWhiteSpace(Email)) sb.Append($", Email: {Email}");
            if (!string.IsNullOrWhiteSpace(Telefon)) sb.Append($", Tel: {Telefon}");
            return sb.ToString();
        }
    }
}
