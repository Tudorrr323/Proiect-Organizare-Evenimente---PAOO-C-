using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCVirtualEvents : UserControl
    {
        private const string TOATE = "(toti)";
        private readonly EvenimentService _service = new();
        private List<Eveniment> _rezultate = new();

        public UCVirtualEvents()
        {
            InitializeComponent();
            pageBar.PageChanged += AfiseazaPagina;
        }

        private void UCVirtualEvents_Load(object? sender, EventArgs e)
        {
            try
            {
                var organizatori = new List<string> { TOATE };
                organizatori.AddRange(_service.GetOrganisers());
                cboOrganizator.DataSource = organizatori;

                Cauta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la initializare: " + ex.Message);
            }
        }

        private void btnCauta_Click(object? sender, EventArgs e) => Cauta();
        private void btnReseteaza_Click(object? sender, EventArgs e)
        {
            txtCautare.Clear();
            cboOrganizator.SelectedIndex = 0;
            dtpDataMin.Checked = false;
            dtpDataMax.Checked = false;
            Cauta();
        }

        private void txtCautare_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Cauta();
            }
        }

        private void Cauta()
        {
            try
            {
                string? nume = string.IsNullOrWhiteSpace(txtCautare.Text) ? null : txtCautare.Text.Trim();
                string? organizator = cboOrganizator.SelectedItem as string == TOATE ? null : cboOrganizator.SelectedItem as string;

                DateTime? dataMin = dtpDataMin.Checked ? dtpDataMin.Value.Date : null;
                DateTime? dataMax = dtpDataMax.Checked ? dtpDataMax.Value.Date.AddDays(1).AddSeconds(-1) : null;

                _rezultate = _service.Search(nume, organizator, null, TipEveniment.Virtual, dataMin, dataMax);
                pageBar.Reset();
                pageBar.SetTotal(_rezultate.Count);

                lblNrEvenimente.Text = _rezultate.Count == 0
                    ? "Nu sunt evenimente virtuale care sa corespunda."
                    : $"{_rezultate.Count} evenimente virtuale gasite";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la cautare: " + ex.Message);
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
