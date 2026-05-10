namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class BiletCumparatCard
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picPoster;
        private Label lblNume;
        private Label lblData;
        private Label lblOras;
        private Label lblTipBilet;
        private Label lblCantitate;
        private Label lblTotal;
        private Label lblDataComanda;
        private Label lblExpirat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picPoster = new PictureBox();
            lblNume = new Label();
            lblData = new Label();
            lblOras = new Label();
            lblTipBilet = new Label();
            lblCantitate = new Label();
            lblTotal = new Label();
            lblDataComanda = new Label();
            lblExpirat = new Label();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            //
            // picPoster
            //
            picPoster.BackColor = Color.WhiteSmoke;
            picPoster.Dock = DockStyle.Top;
            picPoster.Location = new Point(0, 0);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(280, 165);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabStop = false;
            //
            // lblExpirat - badge in colt sus dreapta peste poster
            //
            lblExpirat.BackColor = Color.FromArgb(108, 117, 125);
            lblExpirat.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblExpirat.ForeColor = Color.White;
            lblExpirat.Location = new Point(195, 8);
            lblExpirat.Name = "lblExpirat";
            lblExpirat.Padding = new Padding(8, 3, 8, 3);
            lblExpirat.Size = new Size(75, 22);
            lblExpirat.Text = "EXPIRAT";
            lblExpirat.TextAlign = ContentAlignment.MiddleCenter;
            lblExpirat.Visible = false;
            picPoster.Controls.Add(lblExpirat);
            //
            // lblNume
            //
            lblNume.AutoEllipsis = true;
            lblNume.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNume.ForeColor = Color.FromArgb(33, 41, 73);
            lblNume.Location = new Point(12, 175);
            lblNume.Name = "lblNume";
            lblNume.Size = new Size(256, 45);
            //
            // lblData
            //
            lblData.AutoEllipsis = true;
            lblData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblData.ForeColor = Color.FromArgb(229, 57, 53);
            lblData.Location = new Point(12, 225);
            lblData.Name = "lblData";
            lblData.Size = new Size(256, 22);
            //
            // lblOras
            //
            lblOras.AutoEllipsis = true;
            lblOras.Font = new Font("Segoe UI", 9F);
            lblOras.ForeColor = Color.DimGray;
            lblOras.Location = new Point(12, 248);
            lblOras.Name = "lblOras";
            lblOras.Size = new Size(256, 22);
            //
            // lblTipBilet
            //
            lblTipBilet.AutoEllipsis = true;
            lblTipBilet.Font = new Font("Segoe UI", 9F);
            lblTipBilet.ForeColor = Color.Black;
            lblTipBilet.Location = new Point(12, 275);
            lblTipBilet.Name = "lblTipBilet";
            lblTipBilet.Size = new Size(256, 22);
            //
            // lblCantitate
            //
            lblCantitate.Font = new Font("Segoe UI", 9F);
            lblCantitate.ForeColor = Color.Black;
            lblCantitate.Location = new Point(12, 305);
            lblCantitate.Name = "lblCantitate";
            lblCantitate.Size = new Size(120, 22);
            //
            // lblTotal
            //
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(5, 150, 105);
            lblTotal.Location = new Point(140, 302);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(128, 25);
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblDataComanda
            //
            lblDataComanda.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDataComanda.ForeColor = Color.Gray;
            lblDataComanda.Location = new Point(12, 330);
            lblDataComanda.Name = "lblDataComanda";
            lblDataComanda.Size = new Size(256, 22);
            //
            // BiletCumparatCard
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblDataComanda);
            Controls.Add(lblTotal);
            Controls.Add(lblCantitate);
            Controls.Add(lblTipBilet);
            Controls.Add(lblOras);
            Controls.Add(lblData);
            Controls.Add(lblNume);
            Controls.Add(picPoster);
            Margin = new Padding(8);
            Name = "BiletCumparatCard";
            Size = new Size(280, 360);
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
