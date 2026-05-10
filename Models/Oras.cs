namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public class Oras
    {
        public long IdOras { get; set; }
        public string Nume { get; set; }

        public Oras(long idOras, string nume)
        {
            IdOras = idOras;
            Nume = nume;
        }

        public override string ToString() => Nume;
    }
}
