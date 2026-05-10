namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class PageBar
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnPrev;
        private Button btnNext;
        private Label lblInfo;
        private Label lblSize;
        private ComboBox cboSize;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnPrev = new Button();
            btnNext = new Button();
            lblInfo = new Label();
            lblSize = new Label();
            cboSize = new ComboBox();
            SuspendLayout();
            //
            // btnPrev
            //
            btnPrev.FlatAppearance.BorderColor = Color.FromArgb(49, 112, 249);
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrev.ForeColor = Color.FromArgb(49, 112, 249);
            btnPrev.Location = new Point(10, 5);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(45, 32);
            btnPrev.Text = "‹";
            btnPrev.UseVisualStyleBackColor = true;
            //
            // lblInfo
            //
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.ForeColor = Color.FromArgb(33, 41, 73);
            lblInfo.Location = new Point(60, 8);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(360, 26);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // btnNext
            //
            btnNext.FlatAppearance.BorderColor = Color.FromArgb(49, 112, 249);
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(49, 112, 249);
            btnNext.Location = new Point(425, 5);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(45, 32);
            btnNext.Text = "›";
            btnNext.UseVisualStyleBackColor = true;
            //
            // lblSize
            //
            lblSize.Font = new Font("Segoe UI", 9.5F);
            lblSize.ForeColor = Color.DimGray;
            lblSize.Location = new Point(680, 11);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(80, 22);
            lblSize.Text = "Per pagina:";
            lblSize.TextAlign = ContentAlignment.MiddleRight;
            lblSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //
            // cboSize
            //
            cboSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSize.Font = new Font("Segoe UI", 10F);
            cboSize.Location = new Point(770, 8);
            cboSize.Name = "cboSize";
            cboSize.Size = new Size(75, 27);
            cboSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            //
            // PageBar
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(cboSize);
            Controls.Add(lblSize);
            Controls.Add(btnNext);
            Controls.Add(lblInfo);
            Controls.Add(btnPrev);
            Name = "PageBar";
            Size = new Size(860, 42);
            ResumeLayout(false);
        }

        #endregion
    }
}
