using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;

namespace Proiect_PAOO_Organizare_Evenimente
{
    /// <summary>
    /// Ecran de login. Pattern preluat din proiectul model McLaughingHospital (Form1).
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly AuthService _auth = new();

        public Form1()
        {
            InitializeComponent();
            IncarcaLogo();
        }

        private void IncarcaLogo()
        {
            // Login form are bg alb -> textul negru se vede direct, nu recolorez
            try { picLogo.Image = LogoLoader.Load("logo2.png", darkToWhite: false); } catch { }
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            lblError.Visible = false;

            if (!Validators.IsEmail(txtEmail.Text))
            {
                ShowError("Email invalid.");
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                ShowError("Introdu parola.");
                return;
            }

            try
            {
                var u = _auth.Login(txtEmail.Text.Trim(), txtPassword.Text);
                if (u == null)
                {
                    ShowError("Email sau parola incorecte.");
                    txtPassword.Clear();
                    return;
                }

                Hide();
                using var mm = new MainMenu();
                mm.ShowDialog();          // blocheaza pana la logout/inchidere
                Show();
                txtPassword.Clear();
            }
            catch (ContSuspendatException)
            {
                MessageBox.Show(
                    "Contul tau a fost suspendat.\n\nTe rugam sa contactezi administratorul pentru reactivare.",
                    "Cont suspendat",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ShowError("Cont suspendat - contacteaza administratorul.");
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                ShowError("Eroare conexiune: " + ex.Message);
            }
        }

        private void btnSignUp_Click(object? sender, EventArgs e)
        {
            using var sf = new SignUpForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                txtEmail.Text = sf.EmailInregistrat;
                txtPassword.Focus();
                ShowError("Cont creat cu succes! Logheaza-te acum.");
                lblError.ForeColor = Color.FromArgb(5, 150, 105); // verde
            }
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.ForeColor = Color.FromArgb(229, 57, 53); // resetam la rosu
            lblError.Visible = true;
        }
    }
}
