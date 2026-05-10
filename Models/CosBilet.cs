namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public class CosBilet
    {
        public long IdCosBilet { get; set; }
        public long IdCos { get; set; }
        public long? IdBilet { get; set; }
        public long? Cantitate { get; set; }
        public double? Pret { get; set; }
        public double? PretTotal { get; set; }

        public CosBilet(long idCosBilet, long idCos, long? idBilet, long? cantitate, double? pret, double? pretTotal)
        {
            IdCosBilet = idCosBilet;
            IdCos = idCos;
            IdBilet = idBilet;
            Cantitate = cantitate;
            Pret = pret;
            PretTotal = pretTotal;
        }
    }
}
