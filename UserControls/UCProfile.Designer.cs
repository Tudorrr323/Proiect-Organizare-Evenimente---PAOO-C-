namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCProfile
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Label lblRol;
        private Panel panForm;

        private Label lblSectProfil;
        private Label lblPrenume;
        private TextBox txtPrenume;
        private Label lblNume;
        private TextBox txtNume;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblCompanie;
        private TextBox txtCompanie;
        private Label lblTelefon;
        private TextBox txtTelefon;
        private Label lblBday;
        private CheckBox chkAreBday;
        private DateTimePicker dtpBday;
        private Label lblErrorProfile;
        private Button btnSalveaza;

        private Label lblSectParola;
        private Label lblParolaVeche;
        private TextBox txtParolaVeche;
        private Label lblParolaNoua;
        private TextBox txtParolaNoua;
        private Label lblParolaConfirma;
        private TextBox txtParolaConfirma;
        private Label lblErrorParola;
        private Button btnSchimbaParola;

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
            lblRol = new Label();
            panForm = new Panel();

            lblSectProfil = new Label();
            lblPrenume = new Label();
            txtPrenume = new TextBox();
            lblNume = new Label();
            txtNume = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblCompanie = new Label();
            txtCompanie = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblBday = new Label();
            chkAreBday = new CheckBox();
            dtpBday = new DateTimePicker();
            lblErrorProfile = new Label();
            btnSalveaza = new Button();

            lblSectParola = new Label();
            lblParolaVeche = new Label();
            txtParolaVeche = new TextBox();
            lblParolaNoua = new Label();
            txtParolaNoua = new TextBox();
            lblParolaConfirma = new Label();
            txtParolaConfirma = new TextBox();
            lblErrorParola = new Label();
            btnSchimbaParola = new Button();

            panForm.SuspendLayout();
            SuspendLayout();

            // Constants
            const int FullW = 880;
            const int HalfW = 432;
            const int Col2X = 448;
            const int ThirdW = 286;
            const int Col2X3 = 297;
            const int Col3X3 = 594;
            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(30, 25);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(700, 40);
            lblTitlu.Text = "Profilul meu";
            //
            // lblRol
            //
            lblRol.Font = new Font("Segoe UI", 10F);
            lblRol.ForeColor = Color.Gray;
            lblRol.Location = new Point(32, 70);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(700, 22);
            lblRol.Text = "...";
            //
            // panForm
            //
            panForm.AutoScroll = true;
            panForm.BackColor = Color.Transparent;
            panForm.Location = new Point(30, 100);
            panForm.Name = "panForm";
            panForm.Size = new Size(900, 555);
            panForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ----- Date personale -----
            ConfigSection(lblSectProfil, "Date personale", 0, 0);

            // Rand 1: Prenume + Nume
            ConfigLabel(lblPrenume, "Prenume *", 0, 40);
            ConfigText(txtPrenume, 0, 65, HalfW);

            ConfigLabel(lblNume, "Nume", Col2X, 40);
            ConfigText(txtNume, Col2X, 65, HalfW);

            // Rand 2: Email + Companie (sau Email full daca nu e manager - controlat din .cs)
            ConfigLabel(lblEmail, "Email *", 0, 105);
            ConfigText(txtEmail, 0, 130, HalfW);

            ConfigLabel(lblCompanie, "Companie", Col2X, 105);
            ConfigText(txtCompanie, Col2X, 130, HalfW);

            // Rand 3: Telefon + Data nasterii
            ConfigLabel(lblTelefon, "Telefon", 0, 170);
            ConfigText(txtTelefon, 0, 195, HalfW);

            ConfigLabel(lblBday, "Data nasterii", Col2X, 170);
            chkAreBday.AutoSize = true;
            chkAreBday.Font = new Font("Segoe UI", 9.5F);
            chkAreBday.Location = new Point(Col2X, 198);
            chkAreBday.Name = "chkAreBday";
            chkAreBday.Text = "Setata";
            chkAreBday.CheckedChanged += chkAreBday_CheckedChanged;

            dtpBday.Format = DateTimePickerFormat.Short;
            dtpBday.Font = new Font("Segoe UI", 10F);
            dtpBday.Location = new Point(Col2X + 90, 195);
            dtpBday.Name = "dtpBday";
            dtpBday.Size = new Size(HalfW - 90, 27);

            // Error
            lblErrorProfile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblErrorProfile.ForeColor = Color.FromArgb(229, 57, 53);
            lblErrorProfile.Location = new Point(0, 240);
            lblErrorProfile.Name = "lblErrorProfile";
            lblErrorProfile.Size = new Size(FullW, 22);
            lblErrorProfile.Visible = false;

            // Buton SALVEAZA full width
            btnSalveaza.BackColor = Color.FromArgb(229, 57, 53);
            btnSalveaza.FlatAppearance.BorderSize = 0;
            btnSalveaza.FlatStyle = FlatStyle.Flat;
            btnSalveaza.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalveaza.ForeColor = Color.White;
            btnSalveaza.Location = new Point(0, 270);
            btnSalveaza.Name = "btnSalveaza";
            btnSalveaza.Size = new Size(FullW, 45);
            btnSalveaza.Text = "SALVEAZA MODIFICARILE";
            btnSalveaza.UseVisualStyleBackColor = false;
            btnSalveaza.Click += btnSalveaza_Click;

            // ----- Schimba parola -----
            ConfigSection(lblSectParola, "Schimba parola", 0, 345);

            // Toate 3 pe acelasi rand
            ConfigLabel(lblParolaVeche, "Parola veche *", 0, 385);
            ConfigText(txtParolaVeche, 0, 410, ThirdW);
            txtParolaVeche.PasswordChar = '*';

            ConfigLabel(lblParolaNoua, "Parola noua *", Col2X3, 385);
            ConfigText(txtParolaNoua, Col2X3, 410, ThirdW);
            txtParolaNoua.PasswordChar = '*';

            ConfigLabel(lblParolaConfirma, "Confirma parola noua *", Col3X3, 385);
            ConfigText(txtParolaConfirma, Col3X3, 410, ThirdW);
            txtParolaConfirma.PasswordChar = '*';

            lblErrorParola.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblErrorParola.ForeColor = Color.FromArgb(229, 57, 53);
            lblErrorParola.Location = new Point(0, 450);
            lblErrorParola.Name = "lblErrorParola";
            lblErrorParola.Size = new Size(FullW, 22);
            lblErrorParola.Visible = false;

            btnSchimbaParola.BackColor = Color.FromArgb(49, 112, 249);
            btnSchimbaParola.FlatAppearance.BorderSize = 0;
            btnSchimbaParola.FlatStyle = FlatStyle.Flat;
            btnSchimbaParola.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSchimbaParola.ForeColor = Color.White;
            btnSchimbaParola.Location = new Point(0, 480);
            btnSchimbaParola.Name = "btnSchimbaParola";
            btnSchimbaParola.Size = new Size(FullW, 45);
            btnSchimbaParola.Text = "SCHIMBA PAROLA";
            btnSchimbaParola.UseVisualStyleBackColor = false;
            btnSchimbaParola.Click += btnSchimbaParola_Click;

            // Add la panForm
            panForm.Controls.Add(btnSchimbaParola);
            panForm.Controls.Add(lblErrorParola);
            panForm.Controls.Add(txtParolaConfirma);
            panForm.Controls.Add(lblParolaConfirma);
            panForm.Controls.Add(txtParolaNoua);
            panForm.Controls.Add(lblParolaNoua);
            panForm.Controls.Add(txtParolaVeche);
            panForm.Controls.Add(lblParolaVeche);
            panForm.Controls.Add(lblSectParola);

            panForm.Controls.Add(btnSalveaza);
            panForm.Controls.Add(lblErrorProfile);
            panForm.Controls.Add(dtpBday);
            panForm.Controls.Add(chkAreBday);
            panForm.Controls.Add(lblBday);
            panForm.Controls.Add(txtTelefon);
            panForm.Controls.Add(lblTelefon);
            panForm.Controls.Add(txtCompanie);
            panForm.Controls.Add(lblCompanie);
            panForm.Controls.Add(txtEmail);
            panForm.Controls.Add(lblEmail);
            panForm.Controls.Add(txtNume);
            panForm.Controls.Add(lblNume);
            panForm.Controls.Add(txtPrenume);
            panForm.Controls.Add(lblPrenume);
            panForm.Controls.Add(lblSectProfil);

            //
            // UCProfile
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(panForm);
            Controls.Add(lblRol);
            Controls.Add(lblTitlu);
            Name = "UCProfile";
            Size = new Size(960, 680);
            Load += UCProfile_Load;
            panForm.ResumeLayout(false);
            panForm.PerformLayout();
            ResumeLayout(false);
        }

        private static void ConfigSection(Label l, string text, int x, int y)
        {
            l.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            l.ForeColor = Color.FromArgb(33, 41, 73);
            l.Location = new Point(x, y);
            l.Size = new Size(880, 28);
            l.Text = text;
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
            t.Font = new Font("Segoe UI", 10F);
            t.Location = new Point(x, y);
            t.Size = new Size(width, 27);
        }

        #endregion
    }
}
