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
            btnHome.BackColor = Color.FromArgb(33, 41, 73);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnHome.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 11F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(0, 130);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(220, 50);
            btnHome.Text = "  Acasa";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            //
            // btnDiscover
            //
            btnDiscover.BackColor = Color.FromArgb(33, 41, 73);
            btnDiscover.FlatAppearance.BorderSize = 0;
            btnDiscover.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnDiscover.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnDiscover.FlatStyle = FlatStyle.Flat;
            btnDiscover.Font = new Font("Segoe UI", 11F);
            btnDiscover.ForeColor = Color.White;
            btnDiscover.Location = new Point(0, 180);
            btnDiscover.Name = "btnDiscover";
            btnDiscover.Size = new Size(220, 50);
            btnDiscover.Text = "  Descopera evenimente";
            btnDiscover.TextAlign = ContentAlignment.MiddleLeft;
            btnDiscover.UseVisualStyleBackColor = false;
            btnDiscover.Click += btnDiscover_Click;
            //
            // btnMyTickets
            //
            btnMyTickets.BackColor = Color.FromArgb(33, 41, 73);
            btnMyTickets.FlatAppearance.BorderSize = 0;
            btnMyTickets.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnMyTickets.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnMyTickets.FlatStyle = FlatStyle.Flat;
            btnMyTickets.Font = new Font("Segoe UI", 11F);
            btnMyTickets.ForeColor = Color.White;
            btnMyTickets.Location = new Point(0, 230);
            btnMyTickets.Name = "btnMyTickets";
            btnMyTickets.Size = new Size(220, 50);
            btnMyTickets.Text = "  Biletele mele";
            btnMyTickets.TextAlign = ContentAlignment.MiddleLeft;
            btnMyTickets.UseVisualStyleBackColor = false;
            btnMyTickets.Click += btnMyTickets_Click;
            //
            // btnCart
            //
            btnCart.BackColor = Color.FromArgb(33, 41, 73);
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnCart.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Segoe UI", 11F);
            btnCart.ForeColor = Color.White;
            btnCart.Location = new Point(0, 280);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(220, 50);
            btnCart.Text = "  Cosul meu";
            btnCart.TextAlign = ContentAlignment.MiddleLeft;
            btnCart.UseVisualStyleBackColor = false;
            btnCart.Click += btnCart_Click;
            //
            // btnVirtual
            //
            btnVirtual.BackColor = Color.FromArgb(33, 41, 73);
            btnVirtual.FlatAppearance.BorderSize = 0;
            btnVirtual.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnVirtual.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnVirtual.FlatStyle = FlatStyle.Flat;
            btnVirtual.Font = new Font("Segoe UI", 11F);
            btnVirtual.ForeColor = Color.White;
            btnVirtual.Location = new Point(0, 330);
            btnVirtual.Name = "btnVirtual";
            btnVirtual.Size = new Size(220, 50);
            btnVirtual.Text = "  Evenimente virtuale";
            btnVirtual.TextAlign = ContentAlignment.MiddleLeft;
            btnVirtual.UseVisualStyleBackColor = false;
            btnVirtual.Click += btnVirtual_Click;
            //
            // btnCreateEvents
            //
            btnCreateEvents.BackColor = Color.FromArgb(33, 41, 73);
            btnCreateEvents.FlatAppearance.BorderSize = 0;
            btnCreateEvents.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnCreateEvents.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnCreateEvents.FlatStyle = FlatStyle.Flat;
            btnCreateEvents.Font = new Font("Segoe UI", 11F);
            btnCreateEvents.ForeColor = Color.White;
            btnCreateEvents.Location = new Point(0, 380);
            btnCreateEvents.Name = "btnCreateEvents";
            btnCreateEvents.Size = new Size(220, 50);
            btnCreateEvents.Text = "  Creeaza eveniment";
            btnCreateEvents.TextAlign = ContentAlignment.MiddleLeft;
            btnCreateEvents.UseVisualStyleBackColor = false;
            btnCreateEvents.Click += btnCreateEvents_Click;
            //
            // btnMyEvents
            //
            btnMyEvents.BackColor = Color.FromArgb(33, 41, 73);
            btnMyEvents.FlatAppearance.BorderSize = 0;
            btnMyEvents.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnMyEvents.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnMyEvents.FlatStyle = FlatStyle.Flat;
            btnMyEvents.Font = new Font("Segoe UI", 11F);
            btnMyEvents.ForeColor = Color.White;
            btnMyEvents.Location = new Point(0, 430);
            btnMyEvents.Name = "btnMyEvents";
            btnMyEvents.Size = new Size(220, 50);
            btnMyEvents.Text = "  Evenimentele mele";
            btnMyEvents.TextAlign = ContentAlignment.MiddleLeft;
            btnMyEvents.UseVisualStyleBackColor = false;
            btnMyEvents.Click += btnMyEvents_Click;
            //
            // btnAdmin (vizibil doar pentru rol admin)
            //
            btnAdmin.BackColor = Color.FromArgb(33, 41, 73);
            btnAdmin.FlatAppearance.BorderSize = 0;
            btnAdmin.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnAdmin.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnAdmin.FlatStyle = FlatStyle.Flat;
            btnAdmin.Font = new Font("Segoe UI", 11F);
            btnAdmin.ForeColor = Color.White;
            btnAdmin.Location = new Point(0, 430);
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(220, 50);
            btnAdmin.Text = "  Admin Dashboard";
            btnAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btnAdmin.UseVisualStyleBackColor = false;
            btnAdmin.Click += btnAdmin_Click;
            //
            // btnProfile
            //
            btnProfile.BackColor = Color.FromArgb(33, 41, 73);
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 70, 115);
            btnProfile.FlatAppearance.MouseDownBackColor = Color.FromArgb(229, 57, 53);
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 11F);
            btnProfile.ForeColor = Color.White;
            btnProfile.Location = new Point(0, 480);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(220, 50);
            btnProfile.Text = "  Profilul meu";
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = false;
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

        #endregion
    }
}
