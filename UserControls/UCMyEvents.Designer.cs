namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCMyEvents
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Label lblNrEvenimente;
        private Button btnRefresh;
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
            lblNrEvenimente = new Label();
            btnRefresh = new Button();
            pageBar = new PageBar();
            flowEvenimente = new FlowLayoutPanel();
            SuspendLayout();
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(30, 25);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(700, 40);
            lblTitlu.Text = "Evenimentele mele";
            //
            // lblNrEvenimente
            //
            lblNrEvenimente.Font = new Font("Segoe UI", 10F);
            lblNrEvenimente.ForeColor = Color.Gray;
            lblNrEvenimente.Location = new Point(32, 70);
            lblNrEvenimente.Name = "lblNrEvenimente";
            lblNrEvenimente.Size = new Size(700, 22);
            lblNrEvenimente.Text = "...";
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
            // flowEvenimente (mijloc)
            //
            flowEvenimente.AutoScroll = true;
            flowEvenimente.AutoScrollMargin = new Size(0, 60);
            flowEvenimente.BackColor = Color.FromArgb(246, 246, 246);
            flowEvenimente.Location = new Point(20, 100);
            flowEvenimente.Name = "flowEvenimente";
            flowEvenimente.Padding = new Padding(10);
            flowEvenimente.Size = new Size(920, 510);
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
            // UCMyEvents
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(flowEvenimente);
            Controls.Add(pageBar);
            Controls.Add(btnRefresh);
            Controls.Add(lblNrEvenimente);
            Controls.Add(lblTitlu);
            Name = "UCMyEvents";
            Size = new Size(960, 680);
            Load += UCMyEvents_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
