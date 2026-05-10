namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class EvenimentCard
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picPoster;
        private Label lblNume;
        private Label lblData;
        private Label lblOras;
        private Label lblTip;
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
            lblTip = new Label();
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
            picPoster.Size = new Size(280, 170);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabStop = false;
            //
            // lblTip - badge in colt sus stanga peste poster
            //
            lblTip.BackColor = Color.FromArgb(229, 57, 53);
            lblTip.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTip.ForeColor = Color.White;
            lblTip.Location = new Point(8, 8);
            lblTip.Name = "lblTip";
            lblTip.Padding = new Padding(8, 3, 8, 3);
            lblTip.Size = new Size(75, 22);
            lblTip.TextAlign = ContentAlignment.MiddleCenter;
            picPoster.Controls.Add(lblTip);
            //
            // lblExpirat - badge in colt sus dreapta peste poster (vizibil daca data evenimentului e in trecut)
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
            lblNume.Location = new Point(12, 180);
            lblNume.Name = "lblNume";
            lblNume.Size = new Size(256, 50);
            //
            // lblData
            //
            lblData.AutoEllipsis = true;
            lblData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblData.ForeColor = Color.FromArgb(229, 57, 53);
            lblData.Location = new Point(12, 235);
            lblData.Name = "lblData";
            lblData.Size = new Size(256, 22);
            //
            // lblOras
            //
            lblOras.AutoEllipsis = true;
            lblOras.Font = new Font("Segoe UI", 9F);
            lblOras.ForeColor = Color.DimGray;
            lblOras.Location = new Point(12, 260);
            lblOras.Name = "lblOras";
            lblOras.Size = new Size(256, 22);
            //
            // EvenimentCard
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblOras);
            Controls.Add(lblData);
            Controls.Add(lblNume);
            Controls.Add(picPoster);
            Margin = new Padding(8);
            Name = "EvenimentCard";
            Size = new Size(280, 290);
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
