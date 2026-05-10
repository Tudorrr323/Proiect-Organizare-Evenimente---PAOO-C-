namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class CartItemCard
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox picPoster;
        private Label lblNume;
        private Label lblData;
        private Label lblOras;
        private Label lblTipBilet;
        private Label lblCantitate;
        private Label lblTotal;
        private Button btnSterge;

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
            btnSterge = new Button();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            //
            // picPoster
            //
            picPoster.BackColor = Color.WhiteSmoke;
            picPoster.Dock = DockStyle.Top;
            picPoster.Location = new Point(0, 0);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(280, 160);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabStop = false;
            //
            // lblNume
            //
            lblNume.AutoEllipsis = true;
            lblNume.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNume.ForeColor = Color.FromArgb(33, 41, 73);
            lblNume.Location = new Point(12, 168);
            lblNume.Name = "lblNume";
            lblNume.Size = new Size(256, 45);
            //
            // lblData
            //
            lblData.AutoEllipsis = true;
            lblData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblData.ForeColor = Color.FromArgb(229, 57, 53);
            lblData.Location = new Point(12, 215);
            lblData.Name = "lblData";
            lblData.Size = new Size(256, 22);
            //
            // lblOras
            //
            lblOras.AutoEllipsis = true;
            lblOras.Font = new Font("Segoe UI", 9F);
            lblOras.ForeColor = Color.DimGray;
            lblOras.Location = new Point(12, 240);
            lblOras.Name = "lblOras";
            lblOras.Size = new Size(256, 22);
            //
            // lblTipBilet
            //
            lblTipBilet.AutoEllipsis = true;
            lblTipBilet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipBilet.ForeColor = Color.Black;
            lblTipBilet.Location = new Point(12, 265);
            lblTipBilet.Name = "lblTipBilet";
            lblTipBilet.Size = new Size(256, 22);
            //
            // lblCantitate
            //
            lblCantitate.Font = new Font("Segoe UI", 9F);
            lblCantitate.ForeColor = Color.DimGray;
            lblCantitate.Location = new Point(12, 287);
            lblCantitate.Name = "lblCantitate";
            lblCantitate.Size = new Size(256, 22);
            //
            // lblTotal
            //
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(5, 150, 105);
            lblTotal.Location = new Point(12, 312);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(160, 30);
            //
            // btnSterge
            //
            btnSterge.FlatAppearance.BorderColor = Color.FromArgb(229, 57, 53);
            btnSterge.FlatStyle = FlatStyle.Flat;
            btnSterge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSterge.ForeColor = Color.FromArgb(229, 57, 53);
            btnSterge.Location = new Point(180, 314);
            btnSterge.Name = "btnSterge";
            btnSterge.Size = new Size(88, 30);
            btnSterge.Text = "Sterge";
            btnSterge.UseVisualStyleBackColor = true;
            //
            // CartItemCard
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnSterge);
            Controls.Add(lblTotal);
            Controls.Add(lblCantitate);
            Controls.Add(lblTipBilet);
            Controls.Add(lblOras);
            Controls.Add(lblData);
            Controls.Add(lblNume);
            Controls.Add(picPoster);
            Margin = new Padding(8);
            Name = "CartItemCard";
            Size = new Size(280, 350);
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
