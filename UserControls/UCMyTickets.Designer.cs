namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCMyTickets
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Label lblNrBilete;
        private Button btnRefresh;
        private PageBar pageBar;
        private FlowLayoutPanel flowBilete;

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
            lblNrBilete = new Label();
            btnRefresh = new Button();
            pageBar = new PageBar();
            flowBilete = new FlowLayoutPanel();
            SuspendLayout();
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(30, 25);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(700, 40);
            lblTitlu.Text = "Biletele mele";
            //
            // lblNrBilete
            //
            lblNrBilete.Font = new Font("Segoe UI", 10F);
            lblNrBilete.ForeColor = Color.Gray;
            lblNrBilete.Location = new Point(32, 70);
            lblNrBilete.Name = "lblNrBilete";
            lblNrBilete.Size = new Size(700, 22);
            lblNrBilete.Text = "...";
            //
            // btnRefresh
            //
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(49, 112, 249);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(49, 112, 249);
            btnRefresh.Location = new Point(820, 30);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 35);
            btnRefresh.Text = "Reincarca";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //
            // flowBilete (mijloc)
            //
            flowBilete.AutoScroll = true;
            flowBilete.AutoScrollMargin = new Size(0, 60);
            flowBilete.BackColor = Color.FromArgb(246, 246, 246);
            flowBilete.Location = new Point(20, 100);
            flowBilete.Name = "flowBilete";
            flowBilete.Padding = new Padding(10);
            flowBilete.Size = new Size(920, 510);
            flowBilete.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowBilete.WrapContents = true;
            //
            // pageBar (jos)
            //
            pageBar.Location = new Point(30, 620);
            pageBar.Name = "pageBar";
            pageBar.Size = new Size(900, 42);
            pageBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //
            // UCMyTickets
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(flowBilete);
            Controls.Add(pageBar);
            Controls.Add(btnRefresh);
            Controls.Add(lblNrBilete);
            Controls.Add(lblTitlu);
            Name = "UCMyTickets";
            Size = new Size(960, 680);
            Load += UCMyTickets_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
