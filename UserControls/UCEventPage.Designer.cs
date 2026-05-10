namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCEventPage
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnInapoi;
        private PictureBox picPoster;
        private Label lblExpirat;
        private Label lblNume;
        private Label lblData;
        private Label lblLocatie;
        private Label lblOras;
        private Label lblOrganizator;
        private Label lblTip;
        private Label lblDescriere;
        private Label lblBileteTitlu;
        private DataGridView dgvBilete;
        private Label lblCantitate;
        private NumericUpDown numCantitate;
        private Label lblPretTotalText;
        private Label lblPretTotal;
        private Button btnAddCart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnInapoi = new Button();
            picPoster = new PictureBox();
            lblExpirat = new Label();
            lblNume = new Label();
            lblData = new Label();
            lblLocatie = new Label();
            lblOras = new Label();
            lblOrganizator = new Label();
            lblTip = new Label();
            lblDescriere = new Label();
            lblBileteTitlu = new Label();
            dgvBilete = new DataGridView();
            lblCantitate = new Label();
            numCantitate = new NumericUpDown();
            lblPretTotalText = new Label();
            lblPretTotal = new Label();
            btnAddCart = new Button();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBilete).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantitate).BeginInit();
            SuspendLayout();
            //
            // btnInapoi
            //
            btnInapoi.FlatAppearance.BorderSize = 0;
            btnInapoi.FlatStyle = FlatStyle.Flat;
            btnInapoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInapoi.ForeColor = Color.FromArgb(49, 112, 249);
            btnInapoi.Location = new Point(20, 15);
            btnInapoi.Name = "btnInapoi";
            btnInapoi.Size = new Size(110, 30);
            btnInapoi.Text = "← Inapoi";
            btnInapoi.UseVisualStyleBackColor = true;
            btnInapoi.Click += btnInapoi_Click;
            //
            // picPoster
            //
            picPoster.BorderStyle = BorderStyle.FixedSingle;
            picPoster.Location = new Point(20, 55);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(360, 240);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.BackColor = Color.WhiteSmoke;
            //
            // lblExpirat - badge in colt poster
            //
            lblExpirat.BackColor = Color.FromArgb(108, 117, 125);
            lblExpirat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblExpirat.ForeColor = Color.White;
            lblExpirat.Location = new Point(260, 12);
            lblExpirat.Name = "lblExpirat";
            lblExpirat.Padding = new Padding(10, 4, 10, 4);
            lblExpirat.Size = new Size(95, 28);
            lblExpirat.Text = "EXPIRAT";
            lblExpirat.TextAlign = ContentAlignment.MiddleCenter;
            lblExpirat.Visible = false;
            picPoster.Controls.Add(lblExpirat);
            //
            // lblNume
            //
            lblNume.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblNume.ForeColor = Color.FromArgb(33, 41, 73);
            lblNume.Location = new Point(400, 55);
            lblNume.Name = "lblNume";
            lblNume.Size = new Size(540, 60);
            lblNume.Text = "...";
            //
            // lblData
            //
            lblData.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblData.ForeColor = Color.FromArgb(229, 57, 53);
            lblData.Location = new Point(400, 125);
            lblData.Name = "lblData";
            lblData.Size = new Size(540, 22);
            lblData.Text = "...";
            //
            // lblLocatie
            //
            lblLocatie.Font = new Font("Segoe UI", 10F);
            lblLocatie.ForeColor = Color.DimGray;
            lblLocatie.Location = new Point(400, 155);
            lblLocatie.Name = "lblLocatie";
            lblLocatie.Size = new Size(540, 22);
            //
            // lblOras
            //
            lblOras.Font = new Font("Segoe UI", 10F);
            lblOras.ForeColor = Color.DimGray;
            lblOras.Location = new Point(400, 180);
            lblOras.Name = "lblOras";
            lblOras.Size = new Size(540, 22);
            //
            // lblOrganizator
            //
            lblOrganizator.Font = new Font("Segoe UI", 10F);
            lblOrganizator.ForeColor = Color.DimGray;
            lblOrganizator.Location = new Point(400, 205);
            lblOrganizator.Name = "lblOrganizator";
            lblOrganizator.Size = new Size(540, 22);
            //
            // lblTip
            //
            lblTip.Font = new Font("Segoe UI", 10F);
            lblTip.ForeColor = Color.DimGray;
            lblTip.Location = new Point(400, 230);
            lblTip.Name = "lblTip";
            lblTip.Size = new Size(540, 22);
            //
            // lblDescriere
            //
            lblDescriere.Font = new Font("Segoe UI", 10F);
            lblDescriere.ForeColor = Color.Black;
            lblDescriere.Location = new Point(20, 310);
            lblDescriere.Name = "lblDescriere";
            lblDescriere.Size = new Size(920, 80);
            //
            // lblBileteTitlu
            //
            lblBileteTitlu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBileteTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblBileteTitlu.Location = new Point(20, 400);
            lblBileteTitlu.Name = "lblBileteTitlu";
            lblBileteTitlu.Size = new Size(400, 30);
            lblBileteTitlu.Text = "Bilete disponibile";
            //
            // dgvBilete
            //
            dgvBilete.AllowUserToAddRows = false;
            dgvBilete.AllowUserToDeleteRows = false;
            dgvBilete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBilete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvBilete.Location = new Point(20, 435);
            dgvBilete.MultiSelect = false;
            dgvBilete.Name = "dgvBilete";
            dgvBilete.ReadOnly = true;
            dgvBilete.RowHeadersVisible = false;
            dgvBilete.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilete.Size = new Size(620, 180);
            dgvBilete.SelectionChanged += dgvBilete_SelectionChanged;
            //
            // lblCantitate
            //
            lblCantitate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCantitate.Location = new Point(660, 435);
            lblCantitate.Name = "lblCantitate";
            lblCantitate.Size = new Size(280, 22);
            lblCantitate.Text = "Cantitate:";
            //
            // numCantitate
            //
            numCantitate.Font = new Font("Segoe UI", 11F);
            numCantitate.Location = new Point(660, 460);
            numCantitate.Maximum = 10;
            numCantitate.Minimum = 1;
            numCantitate.Name = "numCantitate";
            numCantitate.Size = new Size(280, 27);
            numCantitate.Value = 1;
            numCantitate.ValueChanged += numCantitate_ValueChanged;
            //
            // lblPretTotalText
            //
            lblPretTotalText.Font = new Font("Segoe UI", 10F);
            lblPretTotalText.ForeColor = Color.DimGray;
            lblPretTotalText.Location = new Point(660, 500);
            lblPretTotalText.Name = "lblPretTotalText";
            lblPretTotalText.Size = new Size(280, 22);
            lblPretTotalText.Text = "Total:";
            //
            // lblPretTotal
            //
            lblPretTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPretTotal.ForeColor = Color.FromArgb(229, 57, 53);
            lblPretTotal.Location = new Point(660, 520);
            lblPretTotal.Name = "lblPretTotal";
            lblPretTotal.Size = new Size(280, 35);
            lblPretTotal.Text = "0 RON";
            //
            // btnAddCart
            //
            btnAddCart.BackColor = Color.FromArgb(229, 57, 53);
            btnAddCart.FlatAppearance.BorderSize = 0;
            btnAddCart.FlatStyle = FlatStyle.Flat;
            btnAddCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddCart.ForeColor = Color.White;
            btnAddCart.Location = new Point(660, 570);
            btnAddCart.Name = "btnAddCart";
            btnAddCart.Size = new Size(280, 45);
            btnAddCart.Text = "ADAUGA IN COS";
            btnAddCart.UseVisualStyleBackColor = false;
            btnAddCart.Click += btnAddCart_Click;
            //
            // UCEventPage
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(btnAddCart);
            Controls.Add(lblPretTotal);
            Controls.Add(lblPretTotalText);
            Controls.Add(numCantitate);
            Controls.Add(lblCantitate);
            Controls.Add(dgvBilete);
            Controls.Add(lblBileteTitlu);
            Controls.Add(lblDescriere);
            Controls.Add(lblTip);
            Controls.Add(lblOrganizator);
            Controls.Add(lblOras);
            Controls.Add(lblLocatie);
            Controls.Add(lblData);
            Controls.Add(lblNume);
            Controls.Add(picPoster);
            Controls.Add(btnInapoi);
            Name = "UCEventPage";
            Size = new Size(960, 680);
            Load += UCEventPage_Load;
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBilete).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantitate).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
