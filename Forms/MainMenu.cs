using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.UserControls;

namespace Proiect_PAOO_Organizare_Evenimente
{
    /// <summary>
    /// Shell-ul principal al aplicatiei. Sidebar in stanga + panelContainer central.
    /// Pattern preluat din proiectul model McLaughingHospital (MainMenu).
    /// </summary>
    public partial class MainMenu : Form
    {
        private readonly ManageUC _manage = new();

        public MainMenu()
        {
            InitializeComponent();
            IncarcaLogo();
        }

        private void IncarcaLogo()
        {
            // Sidebar e navy → recolorez pixelii inchisi (text negru) in alb
            try { picLogo.Image = LogoLoader.Load("logo2.png", darkToWhite: true); } catch { }
        }

        private void MainMenu_Load(object? sender, EventArgs e)
        {
            if (!SessionManager.EsteAutentificat)
            {
                MessageBox.Show("Trebuie sa fii autentificat.", "Acces interzis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();
                return;
            }

            // Inregistreaza panelContainer la Navigator (pentru navigare din interiorul UC-urilor)
            Navigator.Register(panelContainer);

            // Hover pe Logout: text alb cand mouse-ul e peste, rosu altfel (ca sa nu fie rosu pe rosu)
            btnLogout.MouseEnter += (s, e) => btnLogout.ForeColor = Color.White;
            btnLogout.MouseLeave += (s, e) => btnLogout.ForeColor = Color.FromArgb(229, 57, 53);

            // Vizibilitate butoane in functie de rol
            // Manager: Create + MyEvents | Admin: Admin Dashboard | Client: doar Home/Discover/etc.
            btnCreateEvents.Visible = SessionManager.EsteManager;
            btnMyEvents.Visible = SessionManager.EsteManager;
            btnAdmin.Visible = SessionManager.EsteAdmin;

            // Repozitionare butoane pentru a evita gap-ul (lipim butoanele direct sub Virtual)
            // Client:  Profile  la 380
            // Manager: Create=380, MyEvents=430, Profile=480
            // Admin:   Admin=380, Profile=430
            if (SessionManager.EsteAdmin)
            {
                btnAdmin.Top = 380;
                btnProfile.Top = 430;
            }
            else if (SessionManager.EsteManager)
            {
                btnProfile.Top = 480;
            }
            else
            {
                btnProfile.Top = 380;
            }

            lblWelcome.Text = $"Buna, {SessionManager.UtilizatorCurent!.Prenume}!";

            // Pagina initiala = Home
            ShowPage(btnHome, new UCHome());
        }

        private void ShowPage(Button btnSelectat, UserControl uc)
        {
            panBtnDetail.Height = btnSelectat.Height;
            panBtnDetail.Top = btnSelectat.Top;
            Navigator.Reset();          // sterge istoria - butonul de sidebar e o navigare "primara"
            _manage.DisplayControl(uc, panelContainer);
        }

        private void btnHome_Click(object? sender, EventArgs e)
            => ShowPage(btnHome, new UCHome());

        private void btnDiscover_Click(object? sender, EventArgs e)
            => ShowPage(btnDiscover, new UCDiscoverEvents());

        private void btnMyTickets_Click(object? sender, EventArgs e)
            => ShowPage(btnMyTickets, new UCMyTickets());

        private void btnCart_Click(object? sender, EventArgs e)
            => ShowPage(btnCart, new UCCart());

        private void btnVirtual_Click(object? sender, EventArgs e)
            => ShowPage(btnVirtual, new UCVirtualEvents());

        private void btnCreateEvents_Click(object? sender, EventArgs e)
            => ShowPage(btnCreateEvents, new UCCreateEvent());

        private void btnMyEvents_Click(object? sender, EventArgs e)
            => ShowPage(btnMyEvents, new UCMyEvents());

        private void btnAdmin_Click(object? sender, EventArgs e)
            => ShowPage(btnAdmin, new UCAdminDashboard());

        private void btnProfile_Click(object? sender, EventArgs e)
            => ShowPage(btnProfile, new UCProfile());

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            SessionManager.Logout();
            Close();
        }
    }
}
