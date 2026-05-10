namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public class Cos
    {
        public long IdCos { get; set; }
        public bool EsteCumparat { get; set; }
        public long? Cantitate { get; set; }
        public double? Pret { get; set; }
        public DateTime? CreatLa { get; set; }
        public long? IdUser { get; set; }

        public List<CosBilet> Items { get; set; } = new();

        public Cos(long idCos, bool esteCumparat, long? cantitate, double? pret, DateTime? creatLa, long? idUser)
        {
            IdCos = idCos;
            EsteCumparat = esteCumparat;
            Cantitate = cantitate;
            Pret = pret;
            CreatLa = creatLa;
            IdUser = idUser;
        }

        public override string ToString()
            => $"Cos #{IdCos} | {Cantitate} bilete | total {Pret:0.##} RON | {(EsteCumparat ? "platit" : "activ")}";
    }
}
