using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.BLL
{
    public class CartService
    {
        private readonly CosRepository _cos = new();
        private readonly BiletRepository _bilete = new();

        /// <summary>Cosul activ al utilizatorului (creat la nevoie).</summary>
        public Cos GetSauCreeazaCosActiv(long idUser)
        {
            var c = _cos.GetActive(idUser);
            if (c != null) return c;
            var idNou = _cos.CreateNew(idUser);
            return _cos.GetById(idNou);
        }

        /// <summary>Adauga un bilet in cosul activ. Recalculeaza totalurile cosului.</summary>
        public void AdaugaInCos(long idUser, long idBilet, long cantitate)
        {
            if (cantitate < 1) throw new ArgumentException("Cantitate minima 1.");
            var bilet = _bilete.GetById(idBilet) ?? throw new InvalidOperationException("Bilet inexistent.");
            var pret = bilet.Pret ?? 0;

            var cos = GetSauCreeazaCosActiv(idUser);
            _cos.InsertItem(cos.IdCos, idBilet, cantitate, pret);
            RecalculeazaCos(cos.IdCos);
        }

        public void StergeItem(long idCos, long idCosBilet)
        {
            _cos.DeleteItem(idCosBilet);
            RecalculeazaCos(idCos);
        }

        public List<CosBilet> GetItems(long idCos) => _cos.GetItems(idCos);

        public List<BiletDinCos> GetItemsCuDetalii(long idCos) => _cos.GetItemsCuDetalii(idCos);

        /// <summary>Toate biletele platite (flat) ale utilizatorului - pentru UCMyTickets.</summary>
        public List<BiletDinCos> GetIstoricBileteFlat(long idUser) => _cos.GetIstoricBileteFlat(idUser);

        public Cos? GetActiveCart(long idUser) => _cos.GetActive(idUser);

        public Cos GetCart(long idCos) => _cos.GetById(idCos);

        /// <summary>Finalizeaza comanda - marcheaza cosul ca platit.</summary>
        public void Checkout(long idCos) => _cos.MarkPaid(idCos);

        /// <summary>Comenzile platite ale utilizatorului.</summary>
        public List<Cos> GetIstoric(long idUser) => _cos.GetMyOrders(idUser);

        /// <summary>
        /// Recalculeaza cantitatea + pretul cosului din itemii sai (corecteaza date stale).
        /// </summary>
        public void RecalculeazaCos(long idCos)
        {
            var items = _cos.GetItems(idCos);
            long totalCant = 0;
            double totalPret = 0;
            foreach (var it in items)
            {
                totalCant += it.Cantitate ?? 0;
                totalPret += it.PretTotal ?? 0;
            }
            _cos.UpdateTotaluri(idCos, totalCant, totalPret);
        }
    }
}
