namespace Proiect_PAOO_Organizare_Evenimente
{
    partial class BiletEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Label lblDenumire;
        private TextBox txtDenumire;
        private Label lblPret;
        private TextBox txtPret;
        private Label lblLoc;
        private TextBox txtLoc;
        private Label lblDescriere;
        private TextBox txtDescriere;
        private Label lblError;
        private Button btnOK;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitlu = new Label();
            lblDenumire = new Label();
            txtDenumire = new TextBox();
            lblPret = new Label();
            txtPret = new TextBox();
            lblLoc = new Label();
            txtLoc = new TextBox();
            lblDescriere = new Label();
            txtDescriere = new TextBox();
            lblError = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(20, 15);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(460, 30);
            lblTitlu.Text = "Adauga categorie bilet";
            //
            // lblDenumire
            //
            lblDenumire.AutoSize = true;
            lblDenumire.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDenumire.Location = new Point(20, 60);
            lblDenumire.Name = "lblDenumire";
            lblDenumire.Text = "Denumire *";
            //
            // txtDenumire
            //
            txtDenumire.BorderStyle = BorderStyle.FixedSingle;
            txtDenumire.Font = new Font("Segoe UI", 10F);
            txtDenumire.Location = new Point(20, 85);
            txtDenumire.Name = "txtDenumire";
            txtDenumire.Size = new Size(280, 27);
            //
            // lblPret
            //
            lblPret.AutoSize = true;
            lblPret.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPret.Location = new Point(320, 60);
            lblPret.Name = "lblPret";
            lblPret.Text = "Pret RON *";
            //
            // txtPret
            //
            txtPret.BorderStyle = BorderStyle.FixedSingle;
            txtPret.Font = new Font("Segoe UI", 10F);
            txtPret.Location = new Point(320, 85);
            txtPret.Name = "txtPret";
            txtPret.Size = new Size(160, 27);
            //
            // lblLoc
            //
            lblLoc.AutoSize = true;
            lblLoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLoc.Location = new Point(20, 125);
            lblLoc.Name = "lblLoc";
            lblLoc.Text = "Loc / Sectiune";
            //
            // txtLoc
            //
            txtLoc.BorderStyle = BorderStyle.FixedSingle;
            txtLoc.Font = new Font("Segoe UI", 10F);
            txtLoc.Location = new Point(20, 150);
            txtLoc.Name = "txtLoc";
            txtLoc.Size = new Size(460, 27);
            //
            // lblDescriere
            //
            lblDescriere.AutoSize = true;
            lblDescriere.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDescriere.Location = new Point(20, 190);
            lblDescriere.Name = "lblDescriere";
            lblDescriere.Text = "Descriere";
            //
            // txtDescriere
            //
            txtDescriere.BorderStyle = BorderStyle.FixedSingle;
            txtDescriere.Font = new Font("Segoe UI", 10F);
            txtDescriere.Location = new Point(20, 215);
            txtDescriere.Multiline = true;
            txtDescriere.Name = "txtDescriere";
            txtDescriere.ScrollBars = ScrollBars.Vertical;
            txtDescriere.Size = new Size(460, 80);
            //
            // lblError
            //
            lblError.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(20, 305);
            lblError.Name = "lblError";
            lblError.Size = new Size(460, 22);
            lblError.Visible = false;
            //
            // btnOK
            //
            btnOK.BackColor = Color.FromArgb(229, 57, 53);
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(280, 340);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 36);
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = false;
            btnOK.Click += btnOK_Click;
            //
            // btnCancel
            //
            btnCancel.FlatAppearance.BorderColor = Color.Gray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.ForeColor = Color.Gray;
            btnCancel.Location = new Point(390, 340);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 36);
            btnCancel.Text = "Anuleaza";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            //
            // BiletEditForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 395);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lblError);
            Controls.Add(txtDescriere);
            Controls.Add(lblDescriere);
            Controls.Add(txtLoc);
            Controls.Add(lblLoc);
            Controls.Add(txtPret);
            Controls.Add(lblPret);
            Controls.Add(txtDenumire);
            Controls.Add(lblDenumire);
            Controls.Add(lblTitlu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BiletEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Adauga categorie bilet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
