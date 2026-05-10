using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente
{
    /// <summary>
    /// Form modal pentru add/edit bilet (categorie de bilet) - folosit din UCEditEvent.
    /// </summary>
    public partial class BiletEditForm : Form
    {
        public string Denumire => txtDenumire.Text.Trim();
        public double Pret { get; private set; }
        public string? Loc => string.IsNullOrWhiteSpace(txtLoc.Text) ? null : txtLoc.Text.Trim();
        public string? Descriere => string.IsNullOrWhiteSpace(txtDescriere.Text) ? null : txtDescriere.Text.Trim();

        public BiletEditForm(Bilet? existing = null)
        {
            InitializeComponent();
            if (existing != null)
            {
                Text = "Editare categorie bilet";
                lblTitlu.Text = "Editeaza categoria de bilet";
                txtDenumire.Text = existing.Denumire;
                txtPret.Text = (existing.Pret ?? 0).ToString("0.##");
                txtLoc.Text = existing.LocEveniment ?? "";
                txtDescriere.Text = existing.Descriere ?? "";
            }
        }

        private void btnOK_Click(object? sender, EventArgs e)
        {
            lblError.Visible = false;
            if (string.IsNullOrWhiteSpace(txtDenumire.Text))
            {
                ShowError("Denumirea este obligatorie."); return;
            }
            if (!Parsing.TryParseDouble(txtPret.Text, out double pret) || pret < 0)
            {
                ShowError("Pretul trebuie sa fie un numar >= 0."); return;
            }
            Pret = pret;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }
    }
}
