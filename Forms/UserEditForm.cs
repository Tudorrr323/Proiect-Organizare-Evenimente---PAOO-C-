using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.Forms
{
    /// <summary>
    /// Dialog modal pentru editare date user din Admin Dashboard.
    /// Permite modificare prenume, nume, email, telefon, data nasterii, companie.
    /// </summary>
    public partial class UserEditForm : Form
    {
        private readonly UserRepository _repo = new();
        private readonly Utilizator _u;

        public UserEditForm(Utilizator u)
        {
            _u = u;
            InitializeComponent();
            Text = $"Editare date - {_u.NumeComplet}";
            lblTitlu.Text = $"Editare cont #{_u.IdUser}";
            PopuleazaDate();
        }

        private void chkBday_CheckedChanged(object? sender, EventArgs e)
        {
            dtpBday.Enabled = chkBday.Checked;
        }

        private void PopuleazaDate()
        {
            txtPrenume.Text = _u.Prenume ?? "";
            txtNume.Text = _u.Nume ?? "";
            txtEmail.Text = _u.Email ?? "";
            txtTelefon.Text = _u.Telefon ?? "";
            if (_u.DataNasterii.HasValue)
            {
                chkBday.Checked = true;
                dtpBday.Enabled = true;
                dtpBday.Value = _u.DataNasterii.Value;
            }
            else
            {
                chkBday.Checked = false;
                dtpBday.Enabled = false;
            }
            txtCompanie.Text = _u is Manager m ? (m.Companie ?? "") : "";
            txtCompanie.Enabled = _u is Manager;
        }

        private void BtnSalveaza_Click(object? sender, EventArgs e)
        {
            lblError.Visible = false;
            var prenume = txtPrenume.Text.Trim();
            var email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(prenume))
            {
                ShowError("Prenumele este obligatoriu.");
                return;
            }
            if (!Validators.IsEmail(email))
            {
                ShowError("Email invalid.");
                return;
            }
            // Email-ul e unic - verificam doar daca s-a schimbat
            if (!string.Equals(_u.Email, email, StringComparison.OrdinalIgnoreCase) && _repo.EmailExists(email))
            {
                ShowError("Acest email este deja folosit de alt cont.");
                return;
            }

            try
            {
                DateTime? bday = chkBday.Checked ? dtpBday.Value.Date : null;
                string? companie = string.IsNullOrWhiteSpace(txtCompanie.Text) ? null : txtCompanie.Text.Trim();

                _repo.UpdateProfil(_u.IdUser, prenume,
                    string.IsNullOrWhiteSpace(txtNume.Text) ? null : txtNume.Text.Trim(),
                    email,
                    string.IsNullOrWhiteSpace(txtTelefon.Text) ? null : txtTelefon.Text.Trim(),
                    bday, companie);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ShowError("Eroare salvare: " + ex.Message);
            }
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }
    }
}
