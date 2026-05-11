namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCDiscoverEvents
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Panel panFiltre;
        private Label lblCautare;
        private TextBox txtCautare;
        private Label lblOrganizator;
        private ComboBox cboOrganizator;
        private Label lblOras;
        private ComboBox cboOras;
        private Label lblTip;
        private ComboBox cboTip;
        private Label lblPerioada;
        private DateTimePicker dtpDataMin;
        private Label lblPerioadaSep;
        private DateTimePicker dtpDataMax;
        private Button btnCauta;
        private Button btnReseteaza;
        private Label lblRezultate;
        private PageBar pageBar;
        private FlowLayoutPanel flowEvenimente;

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
            panFiltre = new Panel();
            lblCautare = new Label();
            txtCautare = new TextBox();
            lblOrganizator = new Label();
            cboOrganizator = new ComboBox();
            lblOras = new Label();
            cboOras = new ComboBox();
            lblTip = new Label();
            cboTip = new ComboBox();
            lblPerioada = new Label();
            dtpDataMin = new DateTimePicker();
            lblPerioadaSep = new Label();
            dtpDataMax = new DateTimePicker();
            btnCauta = new Button();
            btnReseteaza = new Button();
            lblRezultate = new Label();
            pageBar = new PageBar();
            flowEvenimente = new FlowLayoutPanel();
            panFiltre.SuspendLayout();
            SuspendLayout();
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(30, 25);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(700, 40);
            lblTitlu.Text = "Descopera evenimente";
            //
            // panFiltre - container alb cu filtre
            //
            panFiltre.BackColor = Color.White;
            panFiltre.BorderStyle = BorderStyle.FixedSingle;
            panFiltre.Location = new Point(30, 75);
            panFiltre.Name = "panFiltre";
            panFiltre.Size = new Size(900, 145);
            panFiltre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            //
            // Cautare
            //
            lblCautare.AutoSize = true;
            lblCautare.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCautare.Location = new Point(20, 15);
            lblCautare.Name = "lblCautare";
            lblCautare.Text = "Cauta dupa nume";
            txtCautare.BorderStyle = BorderStyle.FixedSingle;
            txtCautare.Font = new Font("Segoe UI", 10F);
            txtCautare.Location = new Point(20, 40);
            txtCautare.Name = "txtCautare";
            txtCautare.PlaceholderText = "ex: SKILLET";
            txtCautare.Size = new Size(280, 27);
            txtCautare.KeyDown += txtCautare_KeyDown;
            //
            // Organizator
            //
            lblOrganizator.AutoSize = true;
            lblOrganizator.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblOrganizator.Location = new Point(320, 15);
            lblOrganizator.Name = "lblOrganizator";
            lblOrganizator.Text = "Organizator";
            cboOrganizator.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrganizator.Font = new Font("Segoe UI", 10F);
            cboOrganizator.Location = new Point(320, 40);
            cboOrganizator.Name = "cboOrganizator";
            cboOrganizator.Size = new Size(200, 27);
            //
            // Oras
            //
            lblOras.AutoSize = true;
            lblOras.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblOras.Location = new Point(540, 15);
            lblOras.Name = "lblOras";
            lblOras.Text = "Oras";
            cboOras.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOras.Font = new Font("Segoe UI", 10F);
            cboOras.Location = new Point(540, 40);
            cboOras.Name = "cboOras";
            cboOras.Size = new Size(160, 27);
            //
            // Tip
            //
            lblTip.AutoSize = true;
            lblTip.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTip.Location = new Point(720, 15);
            lblTip.Name = "lblTip";
            lblTip.Text = "Tip";
            cboTip.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTip.Font = new Font("Segoe UI", 10F);
            cboTip.Location = new Point(720, 40);
            cboTip.Name = "cboTip";
            cboTip.Size = new Size(150, 27);
            //
            // ----- Rand 2: Perioada (datepickers cu ShowCheckBox) -----
            //
            lblPerioada.AutoSize = true;
            lblPerioada.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPerioada.Location = new Point(20, 80);
            lblPerioada.Name = "lblPerioada";
            lblPerioada.Text = "Perioada (bifeaza pentru a activa)";

            dtpDataMin.Format = DateTimePickerFormat.Short;
            dtpDataMin.Font = new Font("Segoe UI", 10F);
            dtpDataMin.Location = new Point(20, 105);
            dtpDataMin.Name = "dtpDataMin";
            dtpDataMin.ShowCheckBox = true;
            dtpDataMin.Checked = false;
            dtpDataMin.Size = new Size(180, 27);

            lblPerioadaSep.AutoSize = true;
            lblPerioadaSep.Font = new Font("Segoe UI", 11F);
            lblPerioadaSep.Location = new Point(210, 109);
            lblPerioadaSep.Text = "→";

            dtpDataMax.Format = DateTimePickerFormat.Short;
            dtpDataMax.Font = new Font("Segoe UI", 10F);
            dtpDataMax.Location = new Point(240, 105);
            dtpDataMax.Name = "dtpDataMax";
            dtpDataMax.ShowCheckBox = true;
            dtpDataMax.Checked = false;
            dtpDataMax.Size = new Size(180, 27);

            //
            // ----- Butoane filtre PE ACELASI RAND cu Perioada (in dreapta) -----
            //
            btnCauta.BackColor = Color.FromArgb(229, 57, 53);
            btnCauta.FlatAppearance.BorderSize = 0;
            btnCauta.FlatStyle = FlatStyle.Flat;
            btnCauta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCauta.ForeColor = Color.White;
            btnCauta.Location = new Point(450, 102);
            btnCauta.Name = "btnCauta";
            btnCauta.Size = new Size(140, 32);
            btnCauta.Text = "CAUTA";
            btnCauta.UseVisualStyleBackColor = false;
            btnCauta.Click += btnCauta_Click;

            btnReseteaza.FlatAppearance.BorderColor = Color.Gray;
            btnReseteaza.FlatStyle = FlatStyle.Flat;
            btnReseteaza.Font = new Font("Segoe UI", 10F);
            btnReseteaza.ForeColor = Color.Gray;
            btnReseteaza.Location = new Point(600, 102);
            btnReseteaza.Name = "btnReseteaza";
            btnReseteaza.Size = new Size(140, 32);
            btnReseteaza.Text = "Reseteaza filtre";
            btnReseteaza.UseVisualStyleBackColor = true;
            btnReseteaza.Click += btnReseteaza_Click;

            // Add la panel
            panFiltre.Controls.Add(btnReseteaza);
            panFiltre.Controls.Add(btnCauta);
            panFiltre.Controls.Add(dtpDataMax);
            panFiltre.Controls.Add(lblPerioadaSep);
            panFiltre.Controls.Add(dtpDataMin);
            panFiltre.Controls.Add(lblPerioada);
            panFiltre.Controls.Add(cboTip);
            panFiltre.Controls.Add(lblTip);
            panFiltre.Controls.Add(cboOras);
            panFiltre.Controls.Add(lblOras);
            panFiltre.Controls.Add(cboOrganizator);
            panFiltre.Controls.Add(lblOrganizator);
            panFiltre.Controls.Add(txtCautare);
            panFiltre.Controls.Add(lblCautare);
            //
            // lblRezultate
            //
            lblRezultate.Font = new Font("Segoe UI", 10F);
            lblRezultate.ForeColor = Color.Gray;
            lblRezultate.Location = new Point(32, 230);
            lblRezultate.Name = "lblRezultate";
            lblRezultate.Size = new Size(700, 22);
            lblRezultate.Text = "...";
            //
            // flowEvenimente (mijloc)
            //
            flowEvenimente.AutoScroll = true;
            flowEvenimente.AutoScrollMargin = new Size(0, 60);
            flowEvenimente.BackColor = Color.FromArgb(246, 246, 246);
            flowEvenimente.Location = new Point(20, 260);
            flowEvenimente.Name = "flowEvenimente";
            flowEvenimente.Padding = new Padding(10);
            flowEvenimente.Size = new Size(920, 350);
            flowEvenimente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowEvenimente.WrapContents = true;
            //
            // pageBar (jos)
            //
            pageBar.Location = new Point(30, 620);
            pageBar.Name = "pageBar";
            pageBar.Size = new Size(900, 42);
            pageBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //
            // UCDiscoverEvents
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(flowEvenimente);
            Controls.Add(pageBar);
            Controls.Add(lblRezultate);
            Controls.Add(panFiltre);
            Controls.Add(lblTitlu);
            Name = "UCDiscoverEvents";
            Size = new Size(960, 680);
            Load += UCDiscoverEvents_Load;
            panFiltre.ResumeLayout(false);
            panFiltre.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
