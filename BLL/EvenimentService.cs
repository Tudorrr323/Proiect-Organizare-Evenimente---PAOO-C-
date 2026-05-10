using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.BLL
{
    public class EvenimentService
    {
        private readonly EvenimentRepository _events = new();
        private readonly BiletRepository _bilete = new();

        public List<Eveniment> GetUpcoming(int limit = 12) => _events.GetUpcoming(limit);
        public Eveniment? GetById(long id) => _events.GetById(id);
        public List<Eveniment> Search(string? nume, string? organizator, string? oras, TipEveniment? tip,
                                       DateTime? dataMin = null, DateTime? dataMax = null)
            => _events.Search(nume, organizator, oras, tip, dataMin, dataMax);
        public List<Eveniment> GetVirtuale() => _events.GetVirtual();
        public List<Eveniment> GetByOrganizator(long idUser) => _events.GetByOrganizator(idUser);
        public List<string> GetOrganisers() => _events.GetOrganisers();
        public List<Bilet> GetBilete(long idEvent) => _bilete.GetForEvent(idEvent);

        public long CreeazaEveniment(Eveniment e) => _events.Insert(e);
        public void ActualizeazaEveniment(Eveniment e) => _events.Update(e);
        public void StergeEveniment(long id) => _events.Delete(id);

        public long AdaugaBilet(long idEvent, string denumire, double pret, string? loc, string? descriere)
            => _bilete.Insert(denumire, pret, loc, descriere, idEvent);

        public void ActualizeazaBilet(long idBilet, string denumire, double pret, string? loc, string? descriere)
            => _bilete.Update(idBilet, denumire, pret, loc, descriere);

        public void StergeBilet(long idBilet) => _bilete.Delete(idBilet);
    }
}
