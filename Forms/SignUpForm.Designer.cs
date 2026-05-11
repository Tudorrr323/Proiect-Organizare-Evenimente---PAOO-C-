namespace Proiect_PAOO_Organizare_Evenimente
{
    partial class SignUpForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Label lblSubtitlu;

        private Label lblPrenume;
        private TextBox txtPrenume;
        private Label lblNume;
        private TextBox txtNume;

        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefon;
        private TextBox txtTelefon;

        private Label lblParola;
        private TextBox txtParola;
        private Label lblConfirma;
        private TextBox txtConfirma;

        private Label lblRol;
        private RadioButton rdoClient;
        private RadioButton rdoManager;
        private Label lblCompanie;
        private TextBox txtCompanie;

        private Label lblBday;
        private DateTimePicker dtpBday;

        private Label lblError;
        private Button btnInregistrare;
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
            lblSubtitlu = new Label();
            lblPrenume = new Label();
            txtPrenume = new TextBox();
            lblNume = new Label();
            txtNume = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblParola = new Label();
            txtParola = new TextBox();
            lblConfirma = new Label();
            txtConfirma = new TextBox();
            lblRol = new Label();
            rdoClient = new RadioButton();
            rdoManager = new RadioButton();
            lblCompanie = new Label();
            txtCompanie = new TextBox();
            lblBday = new Label();
            dtpBday = new DateTimePicker();
            lblError = new Label();
            btnInregistrare = new Button();
            btnAnuleaza = new Button();
            SuspendLayout();
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(49, 112, 249);
            lblTitlu.Location = new Point(40, 20);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(540, 40);
            lblTitlu.Text = "Creeaza cont nou";
            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblSubtitlu
            //
            lblSubtitlu.Font = new Font("Segoe UI", 10F);
            lblSubtitlu.ForeColor = Color.Gray;
            lblSubtitlu.Location = new Point(40, 60);
            lblSubtitlu.Name = "lblSubtitlu";
            lblSubtitlu.Size = new Size(540, 22);
            lblSubtitlu.Text = "Completeaza datele tale pentru cont nou";
            lblSubtitlu.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblPrenume
            //
            lblPrenume.AutoSize = true;
            lblPrenume.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPrenume.Location = new Point(40, 100);
            lblPrenume.Name = "lblPrenume";
            lblPrenume.Text = "Prenume *";
            //
            // txtPrenume
            //
            txtPrenume.BorderStyle = BorderStyle.FixedSingle;
            txtPrenume.Font = new Font("Segoe UI", 10.5F);
            txtPrenume.Location = new Point(40, 125);
            txtPrenume.Name = "txtPrenume";
            txtPrenume.Size = new Size(263, 27);
            //
            // lblNume
            //
            lblNume.AutoSize = true;
            lblNume.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNume.Location = new Point(317, 100);
            lblNume.Name = "lblNume";
            lblNume.Text = "Nume";
            //
            // txtNume
            //
            txtNume.BorderStyle = BorderStyle.FixedSingle;
            txtNume.Font = new Font("Segoe UI", 10.5F);
            txtNume.Location = new Point(317, 125);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(263, 27);
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(40, 165);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email *";
            //
            // txtEmail
            //
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10.5F);
            txtEmail.Location = new Point(40, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(263, 27);
            //
            // lblTelefon
            //
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTelefon.Location = new Point(317, 165);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Text = "Telefon";
            //
            // txtTelefon
            //
            txtTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtTelefon.Font = new Font("Segoe UI", 10.5F);
            txtTelefon.Location = new Point(317, 190);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(263, 27);
            //
            // lblParola
            //
            lblParola.AutoSize = true;
            lblParola.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblParola.Location = new Point(40, 230);
            lblParola.Name = "lblParola";
            lblParola.Text = "Parola *";
            //
            // txtParola
            //
            txtParola.BorderStyle = BorderStyle.FixedSingle;
            txtParola.Font = new Font("Segoe UI", 10.5F);
            txtParola.Location = new Point(40, 255);
            txtParola.Name = "txtParola";
            txtParola.PasswordChar = '*';
            txtParola.Size = new Size(263, 27);
            //
            // lblConfirma
            //
            lblConfirma.AutoSize = true;
            lblConfirma.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblConfirma.Location = new Point(317, 230);
            lblConfirma.Name = "lblConfirma";
            lblConfirma.Text = "Confirma parola *";
            //
            // txtConfirma
            //
            txtConfirma.BorderStyle = BorderStyle.FixedSingle;
            txtConfirma.Font = new Font("Segoe UI", 10.5F);
            txtConfirma.Location = new Point(317, 255);
            txtConfirma.Name = "txtConfirma";
            txtConfirma.PasswordChar = '*';
            txtConfirma.Size = new Size(263, 27);
            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRol.Location = new Point(40, 295);
            lblRol.Name = "lblRol";
            lblRol.Text = "Rol *";
            //
            // rdoClient
            //
            rdoClient.AutoSize = true;
            rdoClient.Font = new Font("Segoe UI", 10F);
            rdoClient.Location = new Point(40, 320);
            rdoClient.Name = "rdoClient";
            rdoClient.Text = "Client";
            rdoClient.CheckedChanged += rdoClient_CheckedChanged;
            //
            // rdoManager
            //
            rdoManager.AutoSize = true;
            rdoManager.Font = new Font("Segoe UI", 10F);
            rdoManager.Location = new Point(140, 320);
            rdoManager.Name = "rdoManager";
            rdoManager.Text = "Manager";
            rdoManager.CheckedChanged += rdoManager_CheckedChanged;
            //
            // lblCompanie
            //
            lblCompanie.AutoSize = true;
            lblCompanie.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCompanie.Location = new Point(317, 295);
            lblCompanie.Name = "lblCompanie";
            lblCompanie.Text = "Companie *";
            //
            // txtCompanie
            //
            txtCompanie.BorderStyle = BorderStyle.FixedSingle;
            txtCompanie.Font = new Font("Segoe UI", 10.5F);
            txtCompanie.Location = new Point(317, 319);
            txtCompanie.Name = "txtCompanie";
            txtCompanie.Size = new Size(263, 27);
            //
            // lblBday
            //
            lblBday.AutoSize = true;
            lblBday.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBday.Location = new Point(40, 360);
            lblBday.Name = "lblBday";
            lblBday.Text = "Data nasterii";
            //
            // dtpBday
            //
            dtpBday.Font = new Font("Segoe UI", 10F);
            dtpBday.Format = DateTimePickerFormat.Short;
            dtpBday.Location = new Point(40, 385);
            dtpBday.Name = "dtpBday";
            dtpBday.Size = new Size(540, 27);
            //
            // lblError
            //
            lblError.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(40, 425);
            lblError.Name = "lblError";
            lblError.Size = new Size(540, 22);
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;
            //
            // btnInregistrare
            //
            btnInregistrare.BackColor = Color.FromArgb(229, 57, 53);
            btnInregistrare.FlatAppearance.BorderSize = 0;
            btnInregistrare.FlatStyle = FlatStyle.Flat;
            btnInregistrare.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInregistrare.ForeColor = Color.White;
            btnInregistrare.Location = new Point(40, 460);
            btnInregistrare.Name = "btnInregistrare";
            btnInregistrare.Size = new Size(360, 45);
            btnInregistrare.Text = "INREGISTREAZA-MA";
            btnInregistrare.UseVisualStyleBackColor = false;
            btnInregistrare.Click += btnInregistrare_Click;
            //
            // btnAnuleaza
            //
            btnAnuleaza.FlatAppearance.BorderColor = Color.Gray;
            btnAnuleaza.FlatStyle = FlatStyle.Flat;
            btnAnuleaza.Font = new Font("Segoe UI", 11F);
            btnAnuleaza.ForeColor = Color.Gray;
            btnAnuleaza.Location = new Point(410, 460);
            btnAnuleaza.Name = "btnAnuleaza";
            btnAnuleaza.Size = new Size(170, 45);
            btnAnuleaza.Text = "Anuleaza";
            btnAnuleaza.UseVisualStyleBackColor = true;
            btnAnuleaza.Click += btnAnuleaza_Click;
            //
            // SignUpForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(620, 530);
            Controls.Add(btnAnuleaza);
            Controls.Add(btnInregistrare);
            Controls.Add(lblError);
            Controls.Add(dtpBday);
            Controls.Add(lblBday);
            Controls.Add(txtCompanie);
            Controls.Add(lblCompanie);
            Controls.Add(rdoManager);
            Controls.Add(rdoClient);
            Controls.Add(lblRol);
            Controls.Add(txtConfirma);
            Controls.Add(lblConfirma);
            Controls.Add(txtParola);
            Controls.Add(lblParola);
            Controls.Add(txtTelefon);
            Controls.Add(lblTelefon);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtNume);
            Controls.Add(lblNume);
            Controls.Add(txtPrenume);
            Controls.Add(lblPrenume);
            Controls.Add(lblSubtitlu);
            Controls.Add(lblTitlu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SignUpForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ticketa - Inregistrare";
            Load += SignUpForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
