using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCProfile : UserControl
    {
        private readonly AuthService _auth = new();

        public UCProfile()
        {
            InitializeComponent();
        }

        private void UCProfile_Load(object? sender, EventArgs e)
        {
            if (!SessionManager.EsteAutentificat || SessionManager.UtilizatorCurent == null)
            {
                lblTitlu.Text = "Trebuie sa fii autentificat.";
                panForm.Visible = false;
                return;
            }

            var u = SessionManager.UtilizatorCurent;
            txtPrenume.Text = u.Prenume;
            txtNume.Text = u.Nume ?? "";
            txtEmail.Text = u.Email ?? "";
            txtTelefon.Text = u.Telefon ?? "";
            if (u.DataNasterii.HasValue)
            {
                dtpBday.Value = u.DataNasterii.Value;
                chkAreBday.Checked = true;
            }
            else
            {
                chkAreBday.Checked = false;
                dtpBday.Enabled = false;
            }

            // Companie - vizibil doar pentru manager. Daca nu e manager, Email se extinde la full width.
            bool isManager = u is Manager;
            lblCompanie.Visible = isManager;
            txtCompanie.Visible = isManager;
            if (u is Manager m)
                txtCompanie.Text = m.Companie ?? "";
            else
                txtEmail.Width = 880;     // full width pentru clienti

            lblRol.Text = "Rol cont: " + u.Rol;
        }

        private void chkAreBday_CheckedChanged(object? sender, EventArgs e)
            => dtpBday.Enabled = chkAreBday.Checked;

        private void btnSalveaza_Click(object? sender, EventArgs e)
        {
            lblErrorProfile.Visible = false;
            try
            {
                _auth.UpdateProfil(
                    prenume:  txtPrenume.Text,
                    nume:     string.IsNullOrWhiteSpace(txtNume.Text) ? null : txtNume.Text,
                    email:    txtEmail.Text,
                    telefon:  string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text,
                    bday:     chkAreBday.Checked ? dtpBday.Value.Date : null,
                    companie: SessionManager.EsteManager
                                  ? (string.IsNullOrWhiteSpace(txtCompanie.Text) ? null : txtCompanie.Text)
                                  : null);

                MessageBox.Show("Datele au fost salvate.",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblErrorProfile.Text = ex.Message;
                lblErrorProfile.Visible = true;
            }
        }

        private void btnSchimbaParola_Click(object? sender, EventArgs e)
        {
            lblErrorParola.Visible = false;
            if (string.IsNullOrEmpty(txtParolaVeche.Text))
            {
                ShowErrorParola("Introdu parola veche."); return;
            }
            if (txtParolaNoua.Text != txtParolaConfirma.Text)
            {
                ShowErrorParola("Parolele noi nu coincid."); return;
            }
            try
            {
                _auth.SchimbaParola(txtParolaVeche.Text, txtParolaNoua.Text);
                MessageBox.Show("Parola a fost schimbata cu succes.",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtParolaVeche.Clear();
                txtParolaNoua.Clear();
                txtParolaConfirma.Clear();
            }
            catch (Exception ex)
            {
                ShowErrorParola(ex.Message);
            }
        }

        private void ShowErrorParola(string msg)
        {
            lblErrorParola.Text = msg;
            lblErrorParola.Visible = true;
        }
    }
}
