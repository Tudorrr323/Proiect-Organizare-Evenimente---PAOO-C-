namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public class Eveniment
    {
        public long IdEvent { get; set; }
        public string Nume { get; set; }
        public string? Descriere { get; set; }
        public string? Locatie { get; set; }
        public DateTime? Data { get; set; }
        public string? Organizator { get; set; }
        public string? CaleImagine { get; set; }   // doar nume fisier (relativ la /Images)
        public string? Oras { get; set; }
        public TipEveniment Tip { get; set; }
        public decimal? StocBilete { get; set; }
        public long? IdUserOrganizator { get; set; }
        public bool EsteSuspendat { get; set; }

        public Eveniment(long idEvent, string nume, string? descriere, string? locatie, DateTime? data,
                         string? organizator, string? caleImagine, string? oras, TipEveniment tip,
                         decimal? stocBilete, long? idUserOrganizator, bool esteSuspendat = false)
        {
            IdEvent = idEvent;
            Nume = nume;
            Descriere = descriere;
            Locatie = locatie;
            Data = data;
            Organizator = organizator;
            CaleImagine = caleImagine;
            Oras = oras;
            Tip = tip;
            StocBilete = stocBilete;
            IdUserOrganizator = idUserOrganizator;
            EsteSuspendat = esteSuspendat;
        }

        public override string ToString()
            => $"{Nume} | {Organizator} | {Oras} | {Data:yyyy-MM-dd HH:mm} | {Tip}";
    }
}
