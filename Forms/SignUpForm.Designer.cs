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

            const int Margin = 40;
            const int FullW = 540;            // ClientWidth 620 - 2*40
            const int HalfW = 263;
            const int Col2X = Margin + HalfW + 14;   // 317

            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(49, 112, 249);
            lblTitlu.Location = new Point(Margin, 20);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(FullW, 40);
            lblTitlu.Text = "Creeaza cont nou";
            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblSubtitlu
            //
            lblSubtitlu.Font = new Font("Segoe UI", 10F);
            lblSubtitlu.ForeColor = Color.Gray;
            lblSubtitlu.Location = new Point(Margin, 60);
            lblSubtitlu.Name = "lblSubtitlu";
            lblSubtitlu.Size = new Size(FullW, 22);
            lblSubtitlu.Text = "Completeaza datele tale pentru cont nou";
            lblSubtitlu.TextAlign = ContentAlignment.MiddleCenter;

            //
            // ----- Rand 1: Prenume + Nume -----
            //
            ConfigLabel(lblPrenume, "Prenume *", Margin, 100);
            ConfigText(txtPrenume, Margin, 125, HalfW);

            ConfigLabel(lblNume, "Nume", Col2X, 100);
            ConfigText(txtNume, Col2X, 125, HalfW);

            //
            // ----- Rand 2: Email + Telefon -----
            //
            ConfigLabel(lblEmail, "Email *", Margin, 165);
            ConfigText(txtEmail, Margin, 190, HalfW);

            ConfigLabel(lblTelefon, "Telefon", Col2X, 165);
            ConfigText(txtTelefon, Col2X, 190, HalfW);

            //
            // ----- Rand 3: Parola + Confirma -----
            //
            ConfigLabel(lblParola, "Parola *", Margin, 230);
            ConfigText(txtParola, Margin, 255, HalfW);
            txtParola.PasswordChar = '*';

            ConfigLabel(lblConfirma, "Confirma parola *", Col2X, 230);
            ConfigText(txtConfirma, Col2X, 255, HalfW);
            txtConfirma.PasswordChar = '*';

            //
            // ----- Rand 4: Rol (radio) + Companie -----
            //
            ConfigLabel(lblRol, "Rol *", Margin, 295);
            rdoClient.AutoSize = true;
            rdoClient.Font = new Font("Segoe UI", 10F);
            rdoClient.Location = new Point(Margin, 320);
            rdoClient.Name = "rdoClient";
            rdoClient.Text = "Client";
            rdoClient.CheckedChanged += rdoClient_CheckedChanged;

            rdoManager.AutoSize = true;
            rdoManager.Font = new Font("Segoe UI", 10F);
            rdoManager.Location = new Point(Margin + 100, 320);
            rdoManager.Name = "rdoManager";
            rdoManager.Text = "Manager";
            rdoManager.CheckedChanged += rdoManager_CheckedChanged;

            ConfigLabel(lblCompanie, "Companie *", Col2X, 295);
            ConfigText(txtCompanie, Col2X, 319, HalfW);

            //
            // ----- Rand 5: Data nasterii FULL WIDTH -----
            //
            ConfigLabel(lblBday, "Data nasterii", Margin, 360);
            dtpBday.Format = DateTimePickerFormat.Short;
            dtpBday.Font = new Font("Segoe UI", 10F);
            dtpBday.Location = new Point(Margin, 385);
            dtpBday.Name = "dtpBday";
            dtpBday.Size = new Size(FullW, 27);

            //
            // lblError
            //
            lblError.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(Margin, 425);
            lblError.Name = "lblError";
            lblError.Size = new Size(FullW, 22);
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;

            //
            // Butoane jos
            //
            btnInregistrare.BackColor = Color.FromArgb(229, 57, 53);
            btnInregistrare.FlatAppearance.BorderSize = 0;
            btnInregistrare.FlatStyle = FlatStyle.Flat;
            btnInregistrare.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnInregistrare.ForeColor = Color.White;
            btnInregistrare.Location = new Point(Margin, 460);
            btnInregistrare.Name = "btnInregistrare";
            btnInregistrare.Size = new Size(360, 45);
            btnInregistrare.Text = "INREGISTREAZA-MA";
            btnInregistrare.UseVisualStyleBackColor = false;
            btnInregistrare.Click += btnInregistrare_Click;

            btnAnuleaza.FlatAppearance.BorderColor = Color.Gray;
            btnAnuleaza.FlatStyle = FlatStyle.Flat;
            btnAnuleaza.Font = new Font("Segoe UI", 11F);
            btnAnuleaza.ForeColor = Color.Gray;
            btnAnuleaza.Location = new Point(Margin + 370, 460);
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

        private static void ConfigLabel(Label l, string text, int x, int y)
        {
            l.AutoSize = true;
            l.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            l.Location = new Point(x, y);
            l.Text = text;
        }

        private static void ConfigText(TextBox t, int x, int y, int width)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Font = new Font("Segoe UI", 10.5F);
            t.Location = new Point(x, y);
            t.Size = new Size(width, 27);
        }

        #endregion
    }
}
