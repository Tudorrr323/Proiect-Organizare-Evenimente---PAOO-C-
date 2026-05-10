namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCComandaDetalii
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnInapoi;
        private Label lblTitlu;
        private Label lblData;
        private Label lblSubtitlu;
        private FlowLayoutPanel flowItems;

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
            lblTitlu = new Label();
            lblData = new Label();
            lblSubtitlu = new Label();
            flowItems = new FlowLayoutPanel();
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
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(150, 15);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(700, 35);
            lblTitlu.Text = "Comanda";
            //
            // lblData
            //
            lblData.Font = new Font("Segoe UI", 10F);
            lblData.ForeColor = Color.Gray;
            lblData.Location = new Point(152, 50);
            lblData.Name = "lblData";
            lblData.Size = new Size(700, 22);
            //
            // lblSubtitlu
            //
            lblSubtitlu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSubtitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblSubtitlu.Location = new Point(152, 75);
            lblSubtitlu.Name = "lblSubtitlu";
            lblSubtitlu.Size = new Size(700, 22);
            lblSubtitlu.Text = "...";
            //
            // flowItems
            //
            flowItems.AutoScroll = true;
            flowItems.BackColor = Color.FromArgb(246, 246, 246);
            flowItems.FlowDirection = FlowDirection.TopDown;
            flowItems.Location = new Point(20, 105);
            flowItems.Name = "flowItems";
            flowItems.Padding = new Padding(10);
            flowItems.Size = new Size(920, 555);
            flowItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowItems.WrapContents = false;
            //
            // UCComandaDetalii
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(flowItems);
            Controls.Add(lblSubtitlu);
            Controls.Add(lblData);
            Controls.Add(lblTitlu);
            Controls.Add(btnInapoi);
            Name = "UCComandaDetalii";
            Size = new Size(960, 680);
            Load += UCComandaDetalii_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
