using System.Text;

namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public abstract class Utilizator : Persoana
    {
        public long IdUser { get; set; }
        public string? Parola { get; set; }
        public DateTime? DataInregistrare { get; set; }
        public bool EsteSuspendat { get; set; }

        protected Utilizator(long idUser, string prenume, string? nume, string? email, string? telefon,
                             DateTime? dataNasterii, string? parola, DateTime? dataInregistrare,
                             bool esteSuspendat = false)
            : base(prenume, nume, email, telefon, dataNasterii)
        {
            IdUser = idUser;
            Parola = parola;
            DataInregistrare = dataInregistrare;
            EsteSuspendat = esteSuspendat;
        }

        public abstract RolUtilizator Rol { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append($", Rol: {Rol}");
            return sb.ToString();
        }
    }
}
