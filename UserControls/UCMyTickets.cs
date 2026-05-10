using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCMyTickets : UserControl
    {
        private readonly CartService _service = new();
        private List<BiletDinCos> _all = new();

        public UCMyTickets()
        {
            InitializeComponent();
            pageBar.PageChanged += AfiseazaPagina;
        }

        private void UCMyTickets_Load(object? sender, EventArgs e) => ReincarcaBilete();
        private void btnRefresh_Click(object? sender, EventArgs e) => ReincarcaBilete();

        private void ReincarcaBilete()
        {
            if (!SessionManager.EsteAutentificat || SessionManager.UtilizatorCurent == null)
            {
                lblTitlu.Text = "Trebuie sa fii autentificat.";
                return;
            }

            try
            {
                _all = _service.GetIstoricBileteFlat(SessionManager.UtilizatorCurent.IdUser);
                pageBar.Reset();
                pageBar.SetTotal(_all.Count);

                lblNrBilete.Text = _all.Count == 0
                    ? "Nu ai inca bilete cumparate."
                    : $"{_all.Count} pozitii in {_all.Select(b => b.IdCos).Distinct().Count()} comenzi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare bilete: " + ex.Message);
            }
        }

        private void AfiseazaPagina()
        {
            flowBilete.SuspendLayout();
            flowBilete.Controls.Clear();
            foreach (var b in pageBar.Slice(_all))
            {
                var card = new BiletCumparatCard();
                card.Setup(b, b.EvenimentImgPath);
                card.ComandaSelectata += idCos => Navigator.Show(new UCComandaDetalii(idCos));
                flowBilete.Controls.Add(card);
            }
            FlowSpacer.AddBottomSpacer(flowBilete);
            flowBilete.ResumeLayout();
        }
    }
}
