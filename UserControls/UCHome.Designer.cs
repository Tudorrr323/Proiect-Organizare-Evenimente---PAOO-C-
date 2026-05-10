namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCHome
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
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
            lblNrEvenimente = new Label();
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
            lblTitlu.Size = new Size(800, 40);
            lblTitlu.Text = "Evenimente apropiate";
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
            // flowEvenimente (in mijloc - ocupa restul spatiului)
            //
            flowEvenimente.AutoScroll = true;
            flowEvenimente.AutoScrollMargin = new Size(0, 60);    // garanteaza scroll-ul ultimei linii
            flowEvenimente.BackColor = Color.FromArgb(246, 246, 246);
            flowEvenimente.Location = new Point(20, 100);
            flowEvenimente.Name = "flowEvenimente";
            flowEvenimente.Padding = new Padding(10);
            flowEvenimente.Size = new Size(920, 510);
            flowEvenimente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowEvenimente.WrapContents = true;
            //
            // pageBar (jos sub flow)
            //
            pageBar.Location = new Point(30, 620);
            pageBar.Name = "pageBar";
            pageBar.Size = new Size(900, 42);
            pageBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //
            // UCHome
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(flowEvenimente);
            Controls.Add(pageBar);
            Controls.Add(lblNrEvenimente);
            Controls.Add(lblTitlu);
            Name = "UCHome";
            Size = new Size(960, 680);
            Load += UCHome_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
