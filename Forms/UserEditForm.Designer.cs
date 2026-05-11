namespace Proiect_PAOO_Organizare_Evenimente.Forms
{
    partial class UserEditForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitlu;
        private Label lblPrenume;
        private TextBox txtPrenume;
        private Label lblNume;
        private TextBox txtNume;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefon;
        private TextBox txtTelefon;
        private Label lblBday;
        private CheckBox chkBday;
        private DateTimePicker dtpBday;
        private Label lblCompanie;
        private TextBox txtCompanie;
        private Label lblError;
        private Button btnSalveaza;
        private Button btnAnuleaza;

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
            lblPrenume = new Label();
            txtPrenume = new TextBox();
            lblNume = new Label();
            txtNume = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblBday = new Label();
            chkBday = new CheckBox();
            dtpBday = new DateTimePicker();
            lblCompanie = new Label();
            txtCompanie = new TextBox();
            lblError = new Label();
            btnSalveaza = new Button();
            btnAnuleaza = new Button();
            SuspendLayout();
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(20, 15);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(390, 30);
            lblTitlu.Text = "Editare cont";
            //
            // lblPrenume
            //
            lblPrenume.Font = new Font("Segoe UI", 9.5F);
            lblPrenume.ForeColor = Color.FromArgb(60, 60, 60);
            lblPrenume.Location = new Point(20, 60);
            lblPrenume.Name = "lblPrenume";
            lblPrenume.Size = new Size(120, 22);
            lblPrenume.Text = "Prenume:";
            //
            // txtPrenume
            //
            txtPrenume.Font = new Font("Segoe UI", 9.5F);
            txtPrenume.Location = new Point(150, 58);
            txtPrenume.Name = "txtPrenume";
            txtPrenume.Size = new Size(260, 25);
            //
            // lblNume
            //
            lblNume.Font = new Font("Segoe UI", 9.5F);
            lblNume.ForeColor = Color.FromArgb(60, 60, 60);
            lblNume.Location = new Point(20, 92);
            lblNume.Name = "lblNume";
            lblNume.Size = new Size(120, 22);
            lblNume.Text = "Nume:";
            //
            // txtNume
            //
            txtNume.Font = new Font("Segoe UI", 9.5F);
            txtNume.Location = new Point(150, 90);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(260, 25);
            //
            // lblEmail
            //
            lblEmail.Font = new Font("Segoe UI", 9.5F);
            lblEmail.ForeColor = Color.FromArgb(60, 60, 60);
            lblEmail.Location = new Point(20, 124);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(120, 22);
            lblEmail.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.Location = new Point(150, 122);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(260, 25);
            //
            // lblTelefon
            //
            lblTelefon.Font = new Font("Segoe UI", 9.5F);
            lblTelefon.ForeColor = Color.FromArgb(60, 60, 60);
            lblTelefon.Location = new Point(20, 156);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(120, 22);
            lblTelefon.Text = "Telefon:";
            //
            // txtTelefon
            //
            txtTelefon.Font = new Font("Segoe UI", 9.5F);
            txtTelefon.Location = new Point(150, 154);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(260, 25);
            //
            // lblBday
            //
            lblBday.Font = new Font("Segoe UI", 9.5F);
            lblBday.ForeColor = Color.FromArgb(60, 60, 60);
            lblBday.Location = new Point(20, 188);
            lblBday.Name = "lblBday";
            lblBday.Size = new Size(120, 22);
            lblBday.Text = "Data nasterii:";
            //
            // chkBday
            //
            chkBday.Font = new Font("Segoe UI", 9F);
            chkBday.Location = new Point(150, 186);
            chkBday.Name = "chkBday";
            chkBday.Size = new Size(80, 25);
            chkBday.Text = "Are data";
            chkBday.CheckedChanged += chkBday_CheckedChanged;
            //
            // dtpBday
            //
            dtpBday.Font = new Font("Segoe UI", 9.5F);
            dtpBday.Format = DateTimePickerFormat.Short;
            dtpBday.Location = new Point(235, 186);
            dtpBday.Name = "dtpBday";
            dtpBday.Size = new Size(175, 25);
            //
            // lblCompanie
            //
            lblCompanie.Font = new Font("Segoe UI", 9.5F);
            lblCompanie.ForeColor = Color.FromArgb(60, 60, 60);
            lblCompanie.Location = new Point(20, 220);
            lblCompanie.Name = "lblCompanie";
            lblCompanie.Size = new Size(120, 22);
            lblCompanie.Text = "Companie:";
            //
            // txtCompanie
            //
            txtCompanie.Font = new Font("Segoe UI", 9.5F);
            txtCompanie.Location = new Point(150, 218);
            txtCompanie.Name = "txtCompanie";
            txtCompanie.Size = new Size(260, 25);
            //
            // lblError
            //
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(20, 260);
            lblError.Name = "lblError";
            lblError.Size = new Size(390, 22);
            lblError.Visible = false;
            //
            // btnSalveaza
            //
            btnSalveaza.BackColor = Color.FromArgb(49, 112, 249);
            btnSalveaza.FlatAppearance.BorderSize = 0;
            btnSalveaza.FlatStyle = FlatStyle.Flat;
            btnSalveaza.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSalveaza.ForeColor = Color.White;
            btnSalveaza.Location = new Point(150, 288);
            btnSalveaza.Name = "btnSalveaza";
            btnSalveaza.Size = new Size(130, 38);
            btnSalveaza.Text = "Salveaza";
            btnSalveaza.UseVisualStyleBackColor = false;
            btnSalveaza.Click += BtnSalveaza_Click;
            //
            // btnAnuleaza
            //
            btnAnuleaza.BackColor = Color.FromArgb(120, 120, 120);
            btnAnuleaza.DialogResult = DialogResult.Cancel;
            btnAnuleaza.FlatAppearance.BorderSize = 0;
            btnAnuleaza.FlatStyle = FlatStyle.Flat;
            btnAnuleaza.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAnuleaza.ForeColor = Color.White;
            btnAnuleaza.Location = new Point(290, 288);
            btnAnuleaza.Name = "btnAnuleaza";
            btnAnuleaza.Size = new Size(120, 38);
            btnAnuleaza.Text = "Anuleaza";
            btnAnuleaza.UseVisualStyleBackColor = false;
            //
            // UserEditForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnAnuleaza;
            ClientSize = new Size(424, 421);
            Controls.Add(btnAnuleaza);
            Controls.Add(btnSalveaza);
            Controls.Add(lblError);
            Controls.Add(txtCompanie);
            Controls.Add(lblCompanie);
            Controls.Add(dtpBday);
            Controls.Add(chkBday);
            Controls.Add(lblBday);
            Controls.Add(txtTelefon);
            Controls.Add(lblTelefon);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtNume);
            Controls.Add(lblNume);
            Controls.Add(txtPrenume);
            Controls.Add(lblPrenume);
            Controls.Add(lblTitlu);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editare date utilizator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
