using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.Forms
{
    /// <summary>
    /// Dialog modal pentru editare date user din Admin Dashboard.
    /// Permite modificare prenume, nume, email, telefon, data nasterii, companie.
    /// </summary>
    public class UserEditForm : Form
    {
        private readonly UserRepository _repo = new();
        private readonly Utilizator _u;

        private TextBox txtPrenume = null!;
        private TextBox txtNume = null!;
        private TextBox txtEmail = null!;
        private TextBox txtTelefon = null!;
        private DateTimePicker dtpBday = null!;
        private CheckBox chkBday = null!;
        private TextBox txtCompanie = null!;
        private Button btnSalveaza = null!;
        private Button btnAnuleaza = null!;
        private Label lblError = null!;

        public UserEditForm(Utilizator u)
        {
            _u = u;
            InitializeComponent();
            PopuleazaDate();
        }

        private void InitializeComponent()
        {
            Text = $"Editare date - {_u.NumeComplet}";
            Size = new Size(440, 460);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.White;

            var lblTitlu = new Label
            {
                Text = $"Editare cont #{_u.IdUser}",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 41, 73),
                Location = new Point(20, 15),
                Size = new Size(390, 30)
            };

            int y = 60;
            void AddLabel(string text)
            {
                Controls.Add(new Label
                {
                    Text = text,
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(60, 60, 60),
                    Location = new Point(20, y),
                    Size = new Size(120, 22)
                });
            }

            AddLabel("Prenume:");
            txtPrenume = new TextBox { Location = new Point(150, y - 2), Size = new Size(260, 25), Font = new Font("Segoe UI", 9.5F) };
            y += 32;

            AddLabel("Nume:");
            txtNume = new TextBox { Location = new Point(150, y - 2), Size = new Size(260, 25), Font = new Font("Segoe UI", 9.5F) };
            y += 32;

            AddLabel("Email:");
            txtEmail = new TextBox { Location = new Point(150, y - 2), Size = new Size(260, 25), Font = new Font("Segoe UI", 9.5F) };
            y += 32;

            AddLabel("Telefon:");
            txtTelefon = new TextBox { Location = new Point(150, y - 2), Size = new Size(260, 25), Font = new Font("Segoe UI", 9.5F) };
            y += 32;

            AddLabel("Data nasterii:");
            chkBday = new CheckBox
            {
                Text = "Are data",
                Location = new Point(150, y - 2),
                Size = new Size(80, 25),
                Font = new Font("Segoe UI", 9F)
            };
            chkBday.CheckedChanged += (s, e) => dtpBday.Enabled = chkBday.Checked;
            dtpBday = new DateTimePicker
            {
                Location = new Point(235, y - 2),
                Size = new Size(175, 25),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 9.5F)
            };
            y += 32;

            AddLabel("Companie:");
            txtCompanie = new TextBox { Location = new Point(150, y - 2), Size = new Size(260, 25), Font = new Font("Segoe UI", 9.5F) };
            y += 40;

            lblError = new Label
            {
                ForeColor = Color.FromArgb(229, 57, 53),
                Font = new Font("Segoe UI", 9F),
                Location = new Point(20, y),
                Size = new Size(390, 22),
                Visible = false
            };
            y += 28;

            btnSalveaza = new Button
            {
                Text = "Salveaza",
                BackColor = Color.FromArgb(49, 112, 249),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(150, y),
                Size = new Size(130, 38)
            };
            btnSalveaza.FlatAppearance.BorderSize = 0;
            btnSalveaza.Click += BtnSalveaza_Click;

            btnAnuleaza = new Button
            {
                Text = "Anuleaza",
                BackColor = Color.FromArgb(120, 120, 120),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(290, y),
                Size = new Size(120, 38),
                DialogResult = DialogResult.Cancel
            };
            btnAnuleaza.FlatAppearance.BorderSize = 0;

            Controls.Add(lblTitlu);
            Controls.Add(txtPrenume);
            Controls.Add(txtNume);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefon);
            Controls.Add(chkBday);
            Controls.Add(dtpBday);
            Controls.Add(txtCompanie);
            Controls.Add(lblError);
            Controls.Add(btnSalveaza);
            Controls.Add(btnAnuleaza);

            CancelButton = btnAnuleaza;
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
