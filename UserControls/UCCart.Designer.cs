namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCCart
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Label lblStatus;
        private FlowLayoutPanel flowItems;
        private Panel panFooter;
        private Label lblTotalText;
        private Label lblTotal;
        private Button btnPlateste;

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
            lblStatus = new Label();
            flowItems = new FlowLayoutPanel();
            panFooter = new Panel();
            lblTotalText = new Label();
            lblTotal = new Label();
            btnPlateste = new Button();
            panFooter.SuspendLayout();
            SuspendLayout();
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(30, 25);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(700, 40);
            lblTitlu.Text = "Cosul meu";
            //
            // lblStatus
            //
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(32, 70);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(700, 22);
            lblStatus.Text = "...";
            //
            // flowItems
            //
            flowItems.AutoScroll = true;
            flowItems.BackColor = Color.FromArgb(246, 246, 246);
            flowItems.Location = new Point(20, 100);
            flowItems.Name = "flowItems";
            flowItems.Padding = new Padding(10);
            flowItems.Size = new Size(920, 480);
            flowItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowItems.WrapContents = true;
            //
            // panFooter
            //
            panFooter.BackColor = Color.White;
            panFooter.BorderStyle = BorderStyle.FixedSingle;
            panFooter.Location = new Point(20, 595);
            panFooter.Name = "panFooter";
            panFooter.Size = new Size(920, 65);
            panFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //
            // lblTotalText
            //
            lblTotalText.Font = new Font("Segoe UI", 11F);
            lblTotalText.ForeColor = Color.DimGray;
            lblTotalText.Location = new Point(20, 22);
            lblTotalText.Name = "lblTotalText";
            lblTotalText.Size = new Size(80, 25);
            lblTotalText.Text = "Total:";
            //
            // lblTotal
            //
            lblTotal.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(229, 57, 53);
            lblTotal.Location = new Point(100, 12);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(280, 40);
            lblTotal.Text = "0 RON";
            //
            // btnPlateste
            //
            btnPlateste.BackColor = Color.FromArgb(5, 150, 105);
            btnPlateste.FlatAppearance.BorderSize = 0;
            btnPlateste.FlatStyle = FlatStyle.Flat;
            btnPlateste.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPlateste.ForeColor = Color.White;
            btnPlateste.Location = new Point(720, 12);
            btnPlateste.Name = "btnPlateste";
            btnPlateste.Size = new Size(180, 42);
            btnPlateste.Text = "PLATESTE";
            btnPlateste.UseVisualStyleBackColor = false;
            btnPlateste.Click += btnPlateste_Click;
            btnPlateste.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            panFooter.Controls.Add(btnPlateste);
            panFooter.Controls.Add(lblTotal);
            panFooter.Controls.Add(lblTotalText);
            //
            // UCCart
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(panFooter);
            Controls.Add(flowItems);
            Controls.Add(lblStatus);
            Controls.Add(lblTitlu);
            Name = "UCCart";
            Size = new Size(960, 680);
            Load += UCCart_Load;
            panFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
