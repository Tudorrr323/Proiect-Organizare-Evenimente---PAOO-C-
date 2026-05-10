using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCHome : UserControl
    {
        private readonly EvenimentService _service = new();
        private List<Eveniment> _all = new();

        public UCHome()
        {
            InitializeComponent();
        }

        private void UCHome_Load(object? sender, EventArgs e)
        {
            try
            {
                _all = _service.GetUpcoming(200);
                pageBar.PageChanged += AfiseazaPagina;
                pageBar.SetTotal(_all.Count);
                lblNrEvenimente.Text = $"{_all.Count} evenimente apropiate (click pe card pentru detalii)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare evenimente: " + ex.Message,
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                card.Selected += id => Navigator.Show(new UCEventPage(id));
                flowEvenimente.Controls.Add(card);
            }
            FlowSpacer.AddBottomSpacer(flowEvenimente);
            flowEvenimente.ResumeLayout();
        }
    }
}
