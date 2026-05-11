namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        // Header
        private Label lblTitlu;
        private FlowLayoutPanel flowKpi;
        private Button btnRefresh;

        // Tab control
        private TabControl tabAdmin;
        private TabPage tabUseri;
        private TabPage tabEvenimente;
        private TabPage tabStatistici;

        // Tab Useri
        private DataGridView dgvUseri;
        private Panel panActiuniUseri;
        private Label lblUserSelectat;
        private Button btnSuspendaUser;
        private Button btnActiveazaUser;
        private Button btnEditUser;
        private Label lblRolNou;
        private ComboBox cboRolNou;
        private Button btnAplicaRol;

        // Tab Evenimente
        private DataGridView dgvEvenimente;
        private Panel panActiuniEvenimente;
        private Label lblEvenimentSelectat;
        private Button btnSuspendaEv;
        private Button btnActiveazaEv;
        private Button btnEditeazaEv;

        // Tab Statistici (TableLayoutPanel 2x2)
        private TableLayoutPanel tlpStatistici;
        private Panel panCellTip;
        private Panel panCellRol;
        private Panel panCellTopBilete;
        private Panel panCellVenit;
        private Panel panChartTip;
        private Panel panChartRol;
        private Panel panChartTopBilete;
        private Panel panChartVenit;
        private Label lblChartTip;
        private Label lblChartRol;
        private Label lblChartTopBilete;
        private Label lblChartVenit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblTitlu = new Label();
            flowKpi = new FlowLayoutPanel();
            btnRefresh = new Button();

            tabAdmin = new TabControl();
            tabUseri = new TabPage();
            tabEvenimente = new TabPage();
            tabStatistici = new TabPage();

            dgvUseri = new DataGridView();
            panActiuniUseri = new Panel();
            lblUserSelectat = new Label();
            btnSuspendaUser = new Button();
            btnActiveazaUser = new Button();
            btnEditUser = new Button();
            lblRolNou = new Label();
            cboRolNou = new ComboBox();
            btnAplicaRol = new Button();

            dgvEvenimente = new DataGridView();
            panActiuniEvenimente = new Panel();
            lblEvenimentSelectat = new Label();
            btnSuspendaEv = new Button();
            btnActiveazaEv = new Button();
            btnEditeazaEv = new Button();

            tlpStatistici = new TableLayoutPanel();
            panCellTip = new Panel();
            panCellRol = new Panel();
            panCellTopBilete = new Panel();
            panCellVenit = new Panel();
            panChartTip = new Panel();
            panChartRol = new Panel();
            panChartTopBilete = new Panel();
            panChartVenit = new Panel();
            lblChartTip = new Label();
            lblChartRol = new Label();
            lblChartTopBilete = new Label();
            lblChartVenit = new Label();

            SuspendLayout();

            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(30, 20);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(500, 40);
            lblTitlu.Text = "Admin Dashboard";

            //
            // btnRefresh
            //
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(49, 112, 249);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(49, 112, 249);
            btnRefresh.Location = new Point(820, 25);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 35);
            btnRefresh.Text = "Reincarca";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            //
            // flowKpi
            //
            flowKpi.Location = new Point(20, 65);
            flowKpi.Name = "flowKpi";
            flowKpi.Size = new Size(920, 80);
            flowKpi.FlowDirection = FlowDirection.LeftToRight;
            flowKpi.WrapContents = false;
            flowKpi.AutoScroll = false;
            flowKpi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            //
            // tabAdmin
            //
            tabAdmin.Font = new Font("Segoe UI", 10F);
            tabAdmin.Location = new Point(20, 155);
            tabAdmin.Name = "tabAdmin";
            tabAdmin.Size = new Size(920, 510);
            tabAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabAdmin.Controls.Add(tabUseri);
            tabAdmin.Controls.Add(tabEvenimente);
            tabAdmin.Controls.Add(tabStatistici);

            // ===================================================================
            // tabUseri
            // ===================================================================
            tabUseri.Text = "Utilizatori";
            tabUseri.BackColor = Color.White;
            tabUseri.Padding = new Padding(8);

            //
            // panActiuniUseri (BOTTOM)
            //
            panActiuniUseri.Dock = DockStyle.Bottom;
            panActiuniUseri.Height = 100;
            panActiuniUseri.BackColor = Color.FromArgb(246, 246, 246);
            panActiuniUseri.Padding = new Padding(10, 6, 10, 6);

            // lblUserSelectat - linia 1, latime 870 (panou 920)
            lblUserSelectat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserSelectat.ForeColor = Color.FromArgb(33, 41, 73);
            lblUserSelectat.Location = new Point(15, 8);
            lblUserSelectat.Size = new Size(870, 22);
            lblUserSelectat.Text = "Selecteaza un utilizator din tabel";

            // btnSuspendaUser
            btnSuspendaUser.BackColor = Color.FromArgb(229, 57, 53);
            btnSuspendaUser.FlatStyle = FlatStyle.Flat;
            btnSuspendaUser.FlatAppearance.BorderSize = 0;
            btnSuspendaUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSuspendaUser.ForeColor = Color.White;
            btnSuspendaUser.Location = new Point(15, 38);
            btnSuspendaUser.Size = new Size(140, 38);
            btnSuspendaUser.Text = "Suspenda cont";
            btnSuspendaUser.UseVisualStyleBackColor = false;
            btnSuspendaUser.Click += btnSuspendaUser_Click;

            // btnActiveazaUser - aceeasi pozitie cu Suspenda (vizibilitate exclusiva)
            btnActiveazaUser.BackColor = Color.FromArgb(5, 150, 105);
            btnActiveazaUser.FlatStyle = FlatStyle.Flat;
            btnActiveazaUser.FlatAppearance.BorderSize = 0;
            btnActiveazaUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnActiveazaUser.ForeColor = Color.White;
            btnActiveazaUser.Location = new Point(15, 38);
            btnActiveazaUser.Size = new Size(140, 38);
            btnActiveazaUser.Text = "Reactiveaza";
            btnActiveazaUser.UseVisualStyleBackColor = false;
            btnActiveazaUser.Visible = false;
            btnActiveazaUser.Click += btnActiveazaUser_Click;

            // btnEditUser
            btnEditUser.BackColor = Color.FromArgb(120, 120, 120);
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.FlatAppearance.BorderSize = 0;
            btnEditUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditUser.ForeColor = Color.White;
            btnEditUser.Location = new Point(165, 38);
            btnEditUser.Size = new Size(140, 38);
            btnEditUser.Text = "Editeaza date";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += btnEditUser_Click;

            // lblRolNou - inline cu butoanele, label "Rol nou:" la stanga combobox-ului
            lblRolNou.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRolNou.ForeColor = Color.FromArgb(60, 60, 60);
            lblRolNou.Location = new Point(325, 45);
            lblRolNou.Size = new Size(70, 22);
            lblRolNou.Text = "Rol nou:";
            lblRolNou.TextAlign = ContentAlignment.MiddleLeft;

            // cboRolNou
            cboRolNou.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRolNou.Font = new Font("Segoe UI", 10F);
            cboRolNou.Location = new Point(395, 42);
            cboRolNou.Size = new Size(130, 28);
            cboRolNou.Items.AddRange(new object[] { "user", "manager", "admin" });

            // btnAplicaRol
            btnAplicaRol.BackColor = Color.FromArgb(49, 112, 249);
            btnAplicaRol.FlatStyle = FlatStyle.Flat;
            btnAplicaRol.FlatAppearance.BorderSize = 0;
            btnAplicaRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAplicaRol.ForeColor = Color.White;
            btnAplicaRol.Location = new Point(540, 38);
            btnAplicaRol.Size = new Size(140, 38);
            btnAplicaRol.Text = "Aplica rol";
            btnAplicaRol.UseVisualStyleBackColor = false;
            btnAplicaRol.Click += btnAplicaRol_Click;

            panActiuniUseri.Controls.Add(lblUserSelectat);
            panActiuniUseri.Controls.Add(btnSuspendaUser);
            panActiuniUseri.Controls.Add(btnActiveazaUser);
            panActiuniUseri.Controls.Add(btnEditUser);
            panActiuniUseri.Controls.Add(lblRolNou);
            panActiuniUseri.Controls.Add(cboRolNou);
            panActiuniUseri.Controls.Add(btnAplicaRol);

            //
            // dgvUseri (FILL)
            //
            dgvUseri.Dock = DockStyle.Fill;
            dgvUseri.AllowUserToAddRows = false;
            dgvUseri.AllowUserToDeleteRows = false;
            dgvUseri.AllowUserToResizeRows = false;
            dgvUseri.ReadOnly = true;
            dgvUseri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUseri.MultiSelect = false;
            dgvUseri.RowHeadersVisible = false;
            dgvUseri.AutoGenerateColumns = false;
            dgvUseri.BackgroundColor = Color.White;
            dgvUseri.BorderStyle = BorderStyle.None;
            dgvUseri.SelectionChanged += dgvUseri_SelectionChanged;

            tabUseri.Controls.Add(dgvUseri);
            tabUseri.Controls.Add(panActiuniUseri);

            // ===================================================================
            // tabEvenimente
            // ===================================================================
            tabEvenimente.Text = "Evenimente";
            tabEvenimente.BackColor = Color.White;
            tabEvenimente.Padding = new Padding(8);

            panActiuniEvenimente.Dock = DockStyle.Bottom;
            panActiuniEvenimente.Height = 100;
            panActiuniEvenimente.BackColor = Color.FromArgb(246, 246, 246);
            panActiuniEvenimente.Padding = new Padding(10, 6, 10, 6);

            lblEvenimentSelectat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEvenimentSelectat.ForeColor = Color.FromArgb(33, 41, 73);
            lblEvenimentSelectat.Location = new Point(15, 8);
            lblEvenimentSelectat.Size = new Size(870, 22);
            lblEvenimentSelectat.Text = "Selecteaza un eveniment din tabel";

            btnSuspendaEv.BackColor = Color.FromArgb(229, 57, 53);
            btnSuspendaEv.FlatStyle = FlatStyle.Flat;
            btnSuspendaEv.FlatAppearance.BorderSize = 0;
            btnSuspendaEv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSuspendaEv.ForeColor = Color.White;
            btnSuspendaEv.Location = new Point(15, 40);
            btnSuspendaEv.Size = new Size(170, 38);
            btnSuspendaEv.Text = "Suspenda eveniment";
            btnSuspendaEv.UseVisualStyleBackColor = false;
            btnSuspendaEv.Click += btnSuspendaEv_Click;

            // btnActiveazaEv - aceeasi pozitie cu Suspenda (vizibilitate exclusiva)
            btnActiveazaEv.BackColor = Color.FromArgb(5, 150, 105);
            btnActiveazaEv.FlatStyle = FlatStyle.Flat;
            btnActiveazaEv.FlatAppearance.BorderSize = 0;
            btnActiveazaEv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnActiveazaEv.ForeColor = Color.White;
            btnActiveazaEv.Location = new Point(15, 40);
            btnActiveazaEv.Size = new Size(170, 38);
            btnActiveazaEv.Text = "Reactiveaza";
            btnActiveazaEv.UseVisualStyleBackColor = false;
            btnActiveazaEv.Visible = false;
            btnActiveazaEv.Click += btnActiveazaEv_Click;

            btnEditeazaEv.BackColor = Color.FromArgb(49, 112, 249);
            btnEditeazaEv.FlatStyle = FlatStyle.Flat;
            btnEditeazaEv.FlatAppearance.BorderSize = 0;
            btnEditeazaEv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnEditeazaEv.ForeColor = Color.White;
            btnEditeazaEv.Location = new Point(195, 40);
            btnEditeazaEv.Size = new Size(170, 38);
            btnEditeazaEv.Text = "Editeaza datele";
            btnEditeazaEv.UseVisualStyleBackColor = false;
            btnEditeazaEv.Click += btnEditeazaEv_Click;

            panActiuniEvenimente.Controls.Add(lblEvenimentSelectat);
            panActiuniEvenimente.Controls.Add(btnSuspendaEv);
            panActiuniEvenimente.Controls.Add(btnActiveazaEv);
            panActiuniEvenimente.Controls.Add(btnEditeazaEv);

            dgvEvenimente.Dock = DockStyle.Fill;
            dgvEvenimente.AllowUserToAddRows = false;
            dgvEvenimente.AllowUserToDeleteRows = false;
            dgvEvenimente.AllowUserToResizeRows = false;
            dgvEvenimente.ReadOnly = true;
            dgvEvenimente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvenimente.MultiSelect = false;
            dgvEvenimente.RowHeadersVisible = false;
            dgvEvenimente.AutoGenerateColumns = false;
            dgvEvenimente.BackgroundColor = Color.White;
            dgvEvenimente.BorderStyle = BorderStyle.None;
            dgvEvenimente.SelectionChanged += dgvEvenimente_SelectionChanged;

            tabEvenimente.Controls.Add(dgvEvenimente);
            tabEvenimente.Controls.Add(panActiuniEvenimente);

            // ===================================================================
            // tabStatistici - TableLayoutPanel 2x2 (Dock=Fill)
            // ===================================================================
            tabStatistici.Text = "Statistici";
            tabStatistici.BackColor = Color.White;
            tabStatistici.Padding = new Padding(10);

            tlpStatistici.Dock = DockStyle.Fill;
            tlpStatistici.ColumnCount = 2;
            tlpStatistici.RowCount = 2;
            tlpStatistici.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpStatistici.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpStatistici.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpStatistici.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpStatistici.BackColor = Color.White;

            //
            // Cell (0,0): Evenimente pe tip
            //
            panCellTip.BackColor = Color.White;
            panCellTip.Dock = DockStyle.Fill;
            panCellTip.Margin = new Padding(5);
            panCellTip.Name = "panCellTip";
            lblChartTip.Dock = DockStyle.Top;
            lblChartTip.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartTip.ForeColor = Color.FromArgb(33, 41, 73);
            lblChartTip.Height = 24;
            lblChartTip.Name = "lblChartTip";
            lblChartTip.Text = "Evenimente pe tip";
            panChartTip.BackColor = Color.White;
            panChartTip.BorderStyle = BorderStyle.FixedSingle;
            panChartTip.Dock = DockStyle.Fill;
            panChartTip.Name = "panChartTip";
            panChartTip.Paint += panChartTip_Paint;
            panCellTip.Controls.Add(panChartTip);
            panCellTip.Controls.Add(lblChartTip);
            //
            // Cell (0,1): Utilizatori pe rol
            //
            panCellRol.BackColor = Color.White;
            panCellRol.Dock = DockStyle.Fill;
            panCellRol.Margin = new Padding(5);
            panCellRol.Name = "panCellRol";
            lblChartRol.Dock = DockStyle.Top;
            lblChartRol.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartRol.ForeColor = Color.FromArgb(33, 41, 73);
            lblChartRol.Height = 24;
            lblChartRol.Name = "lblChartRol";
            lblChartRol.Text = "Utilizatori pe rol";
            panChartRol.BackColor = Color.White;
            panChartRol.BorderStyle = BorderStyle.FixedSingle;
            panChartRol.Dock = DockStyle.Fill;
            panChartRol.Name = "panChartRol";
            panChartRol.Paint += panChartRol_Paint;
            panCellRol.Controls.Add(panChartRol);
            panCellRol.Controls.Add(lblChartRol);
            //
            // Cell (1,0): Top 5 evenimente
            //
            panCellTopBilete.BackColor = Color.White;
            panCellTopBilete.Dock = DockStyle.Fill;
            panCellTopBilete.Margin = new Padding(5);
            panCellTopBilete.Name = "panCellTopBilete";
            lblChartTopBilete.Dock = DockStyle.Top;
            lblChartTopBilete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartTopBilete.ForeColor = Color.FromArgb(33, 41, 73);
            lblChartTopBilete.Height = 24;
            lblChartTopBilete.Name = "lblChartTopBilete";
            lblChartTopBilete.Text = "Top 5 evenimente dupa bilete vandute";
            panChartTopBilete.BackColor = Color.White;
            panChartTopBilete.BorderStyle = BorderStyle.FixedSingle;
            panChartTopBilete.Dock = DockStyle.Fill;
            panChartTopBilete.Name = "panChartTopBilete";
            panChartTopBilete.Paint += panChartTopBilete_Paint;
            panCellTopBilete.Controls.Add(panChartTopBilete);
            panCellTopBilete.Controls.Add(lblChartTopBilete);
            //
            // Cell (1,1): Venit pe luna
            //
            panCellVenit.BackColor = Color.White;
            panCellVenit.Dock = DockStyle.Fill;
            panCellVenit.Margin = new Padding(5);
            panCellVenit.Name = "panCellVenit";
            lblChartVenit.Dock = DockStyle.Top;
            lblChartVenit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChartVenit.ForeColor = Color.FromArgb(33, 41, 73);
            lblChartVenit.Height = 24;
            lblChartVenit.Name = "lblChartVenit";
            lblChartVenit.Text = "Venit pe luna (ultimele 6 luni)";
            panChartVenit.BackColor = Color.White;
            panChartVenit.BorderStyle = BorderStyle.FixedSingle;
            panChartVenit.Dock = DockStyle.Fill;
            panChartVenit.Name = "panChartVenit";
            panChartVenit.Paint += panChartVenit_Paint;
            panCellVenit.Controls.Add(panChartVenit);
            panCellVenit.Controls.Add(lblChartVenit);

            tlpStatistici.Controls.Add(panCellTip,       0, 0);
            tlpStatistici.Controls.Add(panCellRol,       1, 0);
            tlpStatistici.Controls.Add(panCellTopBilete, 0, 1);
            tlpStatistici.Controls.Add(panCellVenit,     1, 1);

            tabStatistici.Controls.Add(tlpStatistici);

            //
            // UCAdminDashboard
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(tabAdmin);
            Controls.Add(flowKpi);
            Controls.Add(btnRefresh);
            Controls.Add(lblTitlu);
            Name = "UCAdminDashboard";
            Size = new Size(960, 680);
            Load += UCAdminDashboard_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
