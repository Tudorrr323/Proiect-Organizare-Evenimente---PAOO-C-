using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente
{
    public partial class SignUpForm : Form
    {
        private readonly AuthService _auth = new();

        /// <summary>Email-ul cu care s-a creat contul (pentru a-l prefilla in Form1).</summary>
        public string EmailInregistrat { get; private set; } = string.Empty;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object? sender, EventArgs e)
        {
            rdoClient.Checked = true;
            ToggleManagerFields();
            dtpBday.MaxDate = DateTime.Today;
            dtpBday.Value = DateTime.Today.AddYears(-20);
        }

        private void rdoClient_CheckedChanged(object? sender, EventArgs e) => ToggleManagerFields();
        private void rdoManager_CheckedChanged(object? sender, EventArgs e) => ToggleManagerFields();

        private void ToggleManagerFields()
        {
            bool isManager = rdoManager.Checked;
            lblCompanie.Visible = isManager;
            txtCompanie.Visible = isManager;
        }

        private void btnInregistrare_Click(object? sender, EventArgs e)
        {
            lblError.Visible = false;

            // ----- validari -----
            if (string.IsNullOrWhiteSpace(txtPrenume.Text)) { ShowError("Prenumele este obligatoriu."); return; }
            if (!Validators.IsEmail(txtEmail.Text)) { ShowError("Email invalid."); return; }
            if (!Validators.IsParolaValida(txtParola.Text, 4)) { ShowError("Parola trebuie sa aiba minim 4 caractere."); return; }
            if (txtParola.Text != txtConfirma.Text) { ShowError("Parolele nu coincid."); return; }
            if (!string.IsNullOrWhiteSpace(txtTelefon.Text) && !Validators.IsTelefon(txtTelefon.Text))
            { ShowError("Numar de telefon invalid."); return; }
            if (rdoManager.Checked && string.IsNullOrWhiteSpace(txtCompanie.Text))
            { ShowError("Manager-ul trebuie sa specifice compania."); return; }

            try
            {
                var rol = rdoManager.Checked ? RolUtilizator.Manager : RolUtilizator.Client;
                _auth.Register(
                    prenume:  txtPrenume.Text.Trim(),
                    nume:     string.IsNullOrWhiteSpace(txtNume.Text) ? null : txtNume.Text.Trim(),
                    email:    txtEmail.Text.Trim(),
                    parola:   txtParola.Text,
                    telefon:  string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim(),
                    bday:     dtpBday.Value.Date,
                    rol:      rol,
                    companie: rol == RolUtilizator.Manager ? txtCompanie.Text.Trim() : null);

                EmailInregistrat = txtEmail.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Eroare la inregistrare: " + ex.Message);
            }
        }

        private void btnAnuleaza_Click(object? sender, EventArgs e)
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
