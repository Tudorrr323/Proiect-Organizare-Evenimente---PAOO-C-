namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public class Bilet
    {
        public long IdBilet { get; set; }
        public string Denumire { get; set; }
        public double? Pret { get; set; }
        public string? LocEveniment { get; set; }
        public string? Descriere { get; set; }
        public long IdEvent { get; set; }

        public Bilet(long idBilet, string denumire, double? pret, string? locEveniment, string? descriere, long idEvent)
        {
            IdBilet = idBilet;
            Denumire = denumire;
            Pret = pret;
            LocEveniment = locEveniment;
            Descriere = descriere;
            IdEvent = idEvent;
        }

        public override string ToString()
            => $"{Denumire} - {Pret:0.##} RON ({LocEveniment})";
    }
}
