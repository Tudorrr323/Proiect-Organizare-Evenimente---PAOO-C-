using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCDiscoverEvents : UserControl
    {
        private const string TOATE = "(toate)";
        private readonly EvenimentService _service = new();
        private readonly OrasRepository _orasRepo = new();
        private List<Eveniment> _rezultate = new();

        public UCDiscoverEvents()
        {
            InitializeComponent();
            pageBar.PageChanged += AfiseazaPagina;
        }

        private void UCDiscoverEvents_Load(object? sender, EventArgs e)
        {
            try
            {
                var organizatori = new List<string> { TOATE };
                organizatori.AddRange(_service.GetOrganisers());
                cboOrganizator.DataSource = organizatori;

                var orase = new List<string> { TOATE };
                orase.AddRange(_orasRepo.GetAll().Select(o => o.Nume));
                cboOras.DataSource = orase;

                cboTip.Items.Clear();
                cboTip.Items.AddRange(new[] { TOATE, "Fizic", "Virtual" });
                cboTip.SelectedIndex = 0;

                Cauta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la initializare filtre: " + ex.Message);
            }
        }

        private void btnCauta_Click(object? sender, EventArgs e) => Cauta();
        private void btnReseteaza_Click(object? sender, EventArgs e)
        {
            txtCautare.Clear();
            cboOrganizator.SelectedIndex = 0;
            cboOras.SelectedIndex = 0;
            cboTip.SelectedIndex = 0;
            dtpDataMin.Checked = false;
            dtpDataMax.Checked = false;
            Cauta();
        }

        private void Cauta()
        {
            try
            {
                string? nume = string.IsNullOrWhiteSpace(txtCautare.Text) ? null : txtCautare.Text.Trim();
                string? organizator = cboOrganizator.SelectedItem as string == TOATE ? null : cboOrganizator.SelectedItem as string;
                string? oras = cboOras.SelectedItem as string == TOATE ? null : cboOras.SelectedItem as string;
                TipEveniment? tip = (cboTip.SelectedItem as string) switch
                {
                    "Fizic" => TipEveniment.Fizic,
                    "Virtual" => TipEveniment.Virtual,
                    _ => null
                };

                DateTime? dataMin = dtpDataMin.Checked ? dtpDataMin.Value.Date : null;
                DateTime? dataMax = dtpDataMax.Checked ? dtpDataMax.Value.Date.AddDays(1).AddSeconds(-1) : null;

                _rezultate = _service.Search(nume, organizator, oras, tip, dataMin, dataMax);
                pageBar.Reset();
                pageBar.SetTotal(_rezultate.Count);

                lblRezultate.Text = $"{_rezultate.Count} evenimente gasite";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la cautare: " + ex.Message);
            }
        }

        private void txtCautare_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Cauta();
            }
        }

        private void AfiseazaPagina()
        {
            flowEvenimente.SuspendLayout();
            flowEvenimente.Controls.Clear();
            foreach (var ev in pageBar.Slice(_rezultate))
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
