using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCMyEvents : UserControl
    {
        private readonly EvenimentService _service = new();
        private List<Eveniment> _all = new();

        public UCMyEvents()
        {
            InitializeComponent();
            pageBar.PageChanged += AfiseazaPagina;
        }

        private void UCMyEvents_Load(object? sender, EventArgs e)
        {
            if (!SessionManager.EsteManager || SessionManager.UtilizatorCurent == null)
            {
                lblTitlu.Text = "Doar manager poate vedea aceasta pagina.";
                return;
            }
            ReincarcaEvenimente();
        }

        private void btnRefresh_Click(object? sender, EventArgs e) => ReincarcaEvenimente();

        private void ReincarcaEvenimente()
        {
            try
            {
                _all = _service.GetByOrganizator(SessionManager.UtilizatorCurent!.IdUser);
                pageBar.Reset();
                pageBar.SetTotal(_all.Count);
                lblNrEvenimente.Text = _all.Count == 0
                    ? "Nu ai creat inca niciun eveniment."
                    : $"{_all.Count} evenimente create (click pe card pentru editare)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare evenimente: " + ex.Message);
            }
        }

        private void AfiseazaPagina()
        {
            flowEvenimente.SuspendLayout();
            flowEvenimente.Controls.Clear();
            foreach (var ev in pageBar.Slice(_all))
            {
                var card = new EvenimentCard();
                card.Setup(ev);
                card.Selected += id => Navigator.Show(new UCEditEvent(id));
                flowEvenimente.Controls.Add(card);
            }
            FlowSpacer.AddBottomSpacer(flowEvenimente);
            flowEvenimente.ResumeLayout();
        }
    }
}
