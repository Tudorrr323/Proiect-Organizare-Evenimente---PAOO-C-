namespace Proiect_PAOO_Organizare_Evenimente
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panSidebar;
        private Panel panBtnDetail;
        private PictureBox picLogo;
        private Label lblWelcome;
        private Button btnHome;
        private Button btnDiscover;
        private Button btnMyTickets;
        private Button btnCart;
        private Button btnVirtual;
        private Button btnCreateEvents;
        private Button btnMyEvents;
        private Button btnAdmin;
        private Button btnProfile;
        private Button btnLogout;
        private Panel panelContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panSidebar = new Panel();
            panBtnDetail = new Panel();
            picLogo = new PictureBox();
            lblWelcome = new Label();
            btnHome = new Button();
            btnDiscover = new Button();
            btnMyTickets = new Button();
            btnCart = new Button();
            btnVirtual = new Button();
            btnCreateEvents = new Button();
            btnMyEvents = new Button();
            btnAdmin = new Button();
            btnProfile = new Button();
            btnLogout = new Button();
            panelContainer = new Panel();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panSidebar.SuspendLayout();
            SuspendLayout();
            //
            // panSidebar
            //
            panSidebar.BackColor = Color.FromArgb(33, 41, 73);
            panSidebar.Controls.Add(panBtnDetail);
            panSidebar.Controls.Add(btnLogout);
            panSidebar.Controls.Add(btnProfile);
            panSidebar.Controls.Add(btnAdmin);
            panSidebar.Controls.Add(btnMyEvents);
            panSidebar.Controls.Add(btnCreateEvents);
            panSidebar.Controls.Add(btnVirtual);
            panSidebar.Controls.Add(btnCart);
            panSidebar.Controls.Add(btnMyTickets);
            panSidebar.Controls.Add(btnDiscover);
            panSidebar.Controls.Add(btnHome);
            panSidebar.Controls.Add(lblWelcome);
            panSidebar.Controls.Add(picLogo);
            panSidebar.Dock = DockStyle.Left;
            panSidebar.Location = new Point(0, 0);
            panSidebar.Name = "panSidebar";
            panSidebar.Size = new Size(220, 700);
            panSidebar.TabIndex = 0;
            //
            // panBtnDetail
            //
            panBtnDetail.BackColor = Color.FromArgb(229, 57, 53);
            panBtnDetail.Location = new Point(0, 130);
            panBtnDetail.Name = "panBtnDetail";
            panBtnDetail.Size = new Size(5, 50);
            panBtnDetail.TabIndex = 0;
            //
            // picLogo
            //
            picLogo.Location = new Point(10, 18);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(200, 55);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabStop = false;
            picLogo.BackColor = Color.FromArgb(33, 41, 73); // navy = aceeasi culoare cu sidebar
            //
            // lblWelcome
            //
            lblWelcome.Font = new Font("Segoe UI", 9.5F);
            lblWelcome.ForeColor = Color.LightGray;
            lblWelcome.Location = new Point(0, 70);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(220, 25);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Buna!";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnHome
            //
            ConfigSidebarButton(btnHome, "  Acasa", 130);
            btnHome.Click += btnHome_Click;
            //
            // btnDiscover
            //
            ConfigSidebarButton(btnDiscover, "  Descopera evenimente", 180);
            btnDiscover.Click += btnDiscover_Click;
            //
            // btnMyTickets
            //
            ConfigSidebarButton(btnMyTickets, "  Biletele mele", 230);
            btnMyTickets.Click += btnMyTickets_Click;
            //
            // btnCart
            //
            ConfigSidebarButton(btnCart, "  Cosul meu", 280);
            btnCart.Click += btnCart_Click;
            //
            // btnVirtual
            //
            ConfigSidebarButton(btnVirtual, "  Evenimente virtuale", 330);
            btnVirtual.Click += btnVirtual_Click;
            //
            // btnCreateEvents
            //
            ConfigSidebarButton(btnCreateEvents, "  Creeaza eveniment", 380);
            btnCreateEvents.Click += btnCreateEvents_Click;
            //
            // btnMyEvents
            //
            ConfigSidebarButton(btnMyEvents, "  Evenimentele mele", 430);
            btnMyEvents.Click += btnMyEvents_Click;
            //
            // btnAdmin (vizibil doar pentru rol admin)
            //
            ConfigSidebarButton(btnAdmin, "  Admin Dashboard", 430);
            btnAdmin.Click += btnAdmin_Click;
            //
            // btnProfile
            //
            ConfigSidebarButton(btnProfile, "  Profilul meu", 480);
            btnProfile.Click += btnProfile_Click;
            //
            // btnLogout
            //
            btnLogout.BackColor = Color.FromArgb(33, 41, 73);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 57, 53); // rosu plin la hover
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(183, 28, 28);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(229, 57, 53);
            btnLogout.Location = new Point(0, 630);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(220, 50);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "  Delogare";
            btnLogout.TextAlign = ContentAlignment.MiddleCenter;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            //
            // panelContainer
            //
            panelContainer.BackColor = Color.FromArgb(246, 246, 246);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(220, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(980, 700);
            panelContainer.TabIndex = 1;
            //
            // MainMenu
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelContainer);
            Controls.Add(panSidebar);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(900, 600);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ticketa";
            Load += MainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panSidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Helper - configurare comuna pentru toate butoanele din sidebar
        private void ConfigSidebarButton(Button b, string text, int top)
        {
            b.BackColor = Color.FromArgb(33, 41, 73);
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115); // un albastru mai deschis pentru contrast cu textul alb
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53); // rosu accent la apasare
            b.FlatStyle = FlatStyle.Flat;
            b.Font = new Font("Segoe UI", 11F);
            b.ForeColor = Color.White;
            b.Location = new Point(0, top);
            b.Name = "btn" + text.Trim().Replace(" ", "");
            b.Size = new Size(220, 50);
            b.Text = text;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.UseVisualStyleBackColor = false;
        }

        #endregion
    }
}
