namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCVirtualEvents
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Panel panFiltre;
        private Label lblCautare;
        private TextBox txtCautare;
        private Label lblOrganizator;
        private ComboBox cboOrganizator;
        private Label lblPerioada;
        private DateTimePicker dtpDataMin;
        private Label lblPerioadaSep;
        private DateTimePicker dtpDataMax;
        private Button btnCauta;
        private Button btnReseteaza;
        private Label lblNrEvenimente;
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
            lblPerioada = new Label();
            dtpDataMin = new DateTimePicker();
            lblPerioadaSep = new Label();
            dtpDataMax = new DateTimePicker();
            btnCauta = new Button();
            btnReseteaza = new Button();
            lblNrEvenimente = new Label();
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
            lblTitlu.Text = "Evenimente virtuale";
            //
            // panFiltre
            //
            panFiltre.BackColor = Color.White;
            panFiltre.BorderStyle = BorderStyle.FixedSingle;
            panFiltre.Location = new Point(30, 75);
            panFiltre.Name = "panFiltre";
            panFiltre.Size = new Size(900, 140);
            panFiltre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            lblCautare.AutoSize = true;
            lblCautare.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCautare.Location = new Point(20, 12);
            lblCautare.Name = "lblCautare";
            lblCautare.Text = "Cauta dupa nume";
            txtCautare.BorderStyle = BorderStyle.FixedSingle;
            txtCautare.Font = new Font("Segoe UI", 10F);
            txtCautare.Location = new Point(20, 37);
            txtCautare.Name = "txtCautare";
            txtCautare.PlaceholderText = "ex: Festival";
            txtCautare.Size = new Size(320, 27);
            txtCautare.KeyDown += txtCautare_KeyDown;

            lblOrganizator.AutoSize = true;
            lblOrganizator.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblOrganizator.Location = new Point(360, 12);
            lblOrganizator.Name = "lblOrganizator";
            lblOrganizator.Text = "Organizator";
            cboOrganizator.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOrganizator.Font = new Font("Segoe UI", 10F);
            cboOrganizator.Location = new Point(360, 37);
            cboOrganizator.Name = "cboOrganizator";
            cboOrganizator.Size = new Size(260, 27);

            //
            // ----- Rand 2: Perioada -----
            //
            lblPerioada.AutoSize = true;
            lblPerioada.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPerioada.Location = new Point(20, 75);
            lblPerioada.Name = "lblPerioada";
            lblPerioada.Text = "Perioada (bifeaza pentru a activa)";

            dtpDataMin.Format = DateTimePickerFormat.Short;
            dtpDataMin.Font = new Font("Segoe UI", 10F);
            dtpDataMin.Location = new Point(20, 100);
            dtpDataMin.Name = "dtpDataMin";
            dtpDataMin.ShowCheckBox = true;
            dtpDataMin.Checked = false;
            dtpDataMin.Size = new Size(180, 27);

            lblPerioadaSep.AutoSize = true;
            lblPerioadaSep.Font = new Font("Segoe UI", 11F);
            lblPerioadaSep.Location = new Point(210, 104);
            lblPerioadaSep.Text = "→";

            dtpDataMax.Format = DateTimePickerFormat.Short;
            dtpDataMax.Font = new Font("Segoe UI", 10F);
            dtpDataMax.Location = new Point(240, 100);
            dtpDataMax.Name = "dtpDataMax";
            dtpDataMax.ShowCheckBox = true;
            dtpDataMax.Checked = false;
            dtpDataMax.Size = new Size(180, 27);

            //
            // Butoane (pe acelasi rand cu datepickers, in dreapta)
            //
            btnCauta.BackColor = Color.FromArgb(229, 57, 53);
            btnCauta.FlatAppearance.BorderSize = 0;
            btnCauta.FlatStyle = FlatStyle.Flat;
            btnCauta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCauta.ForeColor = Color.White;
            btnCauta.Location = new Point(640, 100);
            btnCauta.Name = "btnCauta";
            btnCauta.Size = new Size(110, 32);
            btnCauta.Text = "CAUTA";
            btnCauta.UseVisualStyleBackColor = false;
            btnCauta.Click += btnCauta_Click;

            btnReseteaza.FlatAppearance.BorderColor = Color.Gray;
            btnReseteaza.FlatStyle = FlatStyle.Flat;
            btnReseteaza.Font = new Font("Segoe UI", 10F);
            btnReseteaza.ForeColor = Color.Gray;
            btnReseteaza.Location = new Point(760, 100);
            btnReseteaza.Name = "btnReseteaza";
            btnReseteaza.Size = new Size(120, 32);
            btnReseteaza.Text = "Reseteaza";
            btnReseteaza.UseVisualStyleBackColor = true;
            btnReseteaza.Click += btnReseteaza_Click;

            panFiltre.Controls.Add(btnReseteaza);
            panFiltre.Controls.Add(btnCauta);
            panFiltre.Controls.Add(dtpDataMax);
            panFiltre.Controls.Add(lblPerioadaSep);
            panFiltre.Controls.Add(dtpDataMin);
            panFiltre.Controls.Add(lblPerioada);
            panFiltre.Controls.Add(cboOrganizator);
            panFiltre.Controls.Add(lblOrganizator);
            panFiltre.Controls.Add(txtCautare);
            panFiltre.Controls.Add(lblCautare);
            //
            // lblNrEvenimente
            //
            lblNrEvenimente.Font = new Font("Segoe UI", 10F);
            lblNrEvenimente.ForeColor = Color.Gray;
            lblNrEvenimente.Location = new Point(32, 225);
            lblNrEvenimente.Name = "lblNrEvenimente";
            lblNrEvenimente.Size = new Size(700, 22);
            lblNrEvenimente.Text = "...";
            //
            // flowEvenimente (mijloc)
            //
            flowEvenimente.AutoScroll = true;
            flowEvenimente.AutoScrollMargin = new Size(0, 60);
            flowEvenimente.BackColor = Color.FromArgb(246, 246, 246);
            flowEvenimente.Location = new Point(20, 255);
            flowEvenimente.Name = "flowEvenimente";
            flowEvenimente.Padding = new Padding(10);
            flowEvenimente.Size = new Size(920, 355);
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
            // UCVirtualEvents
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(flowEvenimente);
            Controls.Add(pageBar);
            Controls.Add(lblNrEvenimente);
            Controls.Add(panFiltre);
            Controls.Add(lblTitlu);
            Name = "UCVirtualEvents";
            Size = new Size(960, 680);
            Load += UCVirtualEvents_Load;
            panFiltre.ResumeLayout(false);
            panFiltre.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
