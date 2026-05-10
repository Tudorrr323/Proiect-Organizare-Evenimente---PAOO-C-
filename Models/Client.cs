namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public class Client : Utilizator
    {
        public Client(long idUser, string prenume, string? nume, string? email, string? telefon,
                      DateTime? dataNasterii, string? parola, DateTime? dataInregistrare)
            : base(idUser, prenume, nume, email, telefon, dataNasterii, parola, dataInregistrare)
        {
        }

        public override RolUtilizator Rol => RolUtilizator.Client;
    }
}
