namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    /// <summary>
    /// DTO pentru afisare in DataGridView: bilet din cos cu detalii eveniment + bilet.
    /// Un join intre Cos_Bilet, Bilet, Evenimente.
    ///
    /// IMPORTANT: ordinea proprietatilor mai jos = ordinea coloanelor in DataGridView
    /// (cand AutoGenerateColumns=true). Coloanele tehnice (Id*) sunt la final si ascunse de UI.
    /// </summary>
    public class BiletDinCos
    {
        // ----- Coloane afisate -----
        public string EvenimentNume { get; set; }
        public DateTime? EvenimentData { get; set; }
        public string? EvenimentOras { get; set; }
        public string TipBilet { get; set; }
        public long Cantitate { get; set; }
        public double PretTotal { get; set; }
        public DateTime? DataComanda { get; set; }       // c.created_at - cand a fost facuta comanda

        // ----- Coloane ascunse in UI -----
        public string LocEveniment { get; set; }
        public double Pret { get; set; }
        public string? EvenimentLocatie { get; set; }
        public string? EvenimentImgPath { get; set; }    // pentru afisare in carduri
        public long IdCosBilet { get; set; }
        public long IdCos { get; set; }
        public long IdBilet { get; set; }

        public BiletDinCos(long idCosBilet, long idCos, long idBilet, string tipBilet, string locEveniment,
                           long cantitate, double pret, double pretTotal,
                           string evenimentNume, DateTime? evenimentData,
                           string? evenimentLocatie, string? evenimentOras,
                           DateTime? dataComanda = null, string? evenimentImgPath = null)
        {
            IdCosBilet = idCosBilet;
            IdCos = idCos;
            IdBilet = idBilet;
            TipBilet = tipBilet;
            LocEveniment = locEveniment;
            Cantitate = cantitate;
            Pret = pret;
            PretTotal = pretTotal;
            EvenimentNume = evenimentNume;
            EvenimentData = evenimentData;
            EvenimentLocatie = evenimentLocatie;
            EvenimentOras = evenimentOras;
            DataComanda = dataComanda;
            EvenimentImgPath = evenimentImgPath;
        }
    }
}
