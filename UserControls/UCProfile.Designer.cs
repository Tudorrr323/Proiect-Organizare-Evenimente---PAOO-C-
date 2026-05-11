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
            panForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panForm.AutoScroll = true;
            panForm.BackColor = Color.Transparent;
            panForm.Location = new Point(30, 100);
            panForm.Name = "panForm";
            panForm.Size = new Size(900, 555);
            //
            // lblSectProfil
            //
            lblSectProfil.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSectProfil.ForeColor = Color.FromArgb(33, 41, 73);
            lblSectProfil.Location = new Point(0, 0);
            lblSectProfil.Name = "lblSectProfil";
            lblSectProfil.Size = new Size(880, 28);
            lblSectProfil.Text = "Date personale";
            //
            // lblPrenume
            //
            lblPrenume.AutoSize = true;
            lblPrenume.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPrenume.Location = new Point(0, 40);
            lblPrenume.Name = "lblPrenume";
            lblPrenume.Text = "Prenume *";
            //
            // txtPrenume
            //
            txtPrenume.BorderStyle = BorderStyle.FixedSingle;
            txtPrenume.Font = new Font("Segoe UI", 10F);
            txtPrenume.Location = new Point(0, 65);
            txtPrenume.Name = "txtPrenume";
            txtPrenume.Size = new Size(432, 27);
            //
            // lblNume
            //
            lblNume.AutoSize = true;
            lblNume.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNume.Location = new Point(448, 40);
            lblNume.Name = "lblNume";
            lblNume.Text = "Nume";
            //
            // txtNume
            //
            txtNume.BorderStyle = BorderStyle.FixedSingle;
            txtNume.Font = new Font("Segoe UI", 10F);
            txtNume.Location = new Point(448, 65);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(432, 27);
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEmail.Location = new Point(0, 105);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email *";
            //
            // txtEmail
            //
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(0, 130);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(432, 27);
            //
            // lblCompanie
            //
            lblCompanie.AutoSize = true;
            lblCompanie.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCompanie.Location = new Point(448, 105);
            lblCompanie.Name = "lblCompanie";
            lblCompanie.Text = "Companie";
            //
            // txtCompanie
            //
            txtCompanie.BorderStyle = BorderStyle.FixedSingle;
            txtCompanie.Font = new Font("Segoe UI", 10F);
            txtCompanie.Location = new Point(448, 130);
            txtCompanie.Name = "txtCompanie";
            txtCompanie.Size = new Size(432, 27);
            //
            // lblTelefon
            //
            lblTelefon.AutoSize = true;
            lblTelefon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTelefon.Location = new Point(0, 170);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Text = "Telefon";
            //
            // txtTelefon
            //
            txtTelefon.BorderStyle = BorderStyle.FixedSingle;
            txtTelefon.Font = new Font("Segoe UI", 10F);
            txtTelefon.Location = new Point(0, 195);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(432, 27);
            //
            // lblBday
            //
            lblBday.AutoSize = true;
            lblBday.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBday.Location = new Point(448, 170);
            lblBday.Name = "lblBday";
            lblBday.Text = "Data nasterii";
            //
            // chkAreBday
            //
            chkAreBday.AutoSize = true;
            chkAreBday.Font = new Font("Segoe UI", 9.5F);
            chkAreBday.Location = new Point(448, 198);
            chkAreBday.Name = "chkAreBday";
            chkAreBday.Text = "Setata";
            chkAreBday.CheckedChanged += chkAreBday_CheckedChanged;
            //
            // dtpBday
            //
            dtpBday.Font = new Font("Segoe UI", 10F);
            dtpBday.Format = DateTimePickerFormat.Short;
            dtpBday.Location = new Point(538, 195);
            dtpBday.Name = "dtpBday";
            dtpBday.Size = new Size(342, 27);
            //
            // lblErrorProfile
            //
            lblErrorProfile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblErrorProfile.ForeColor = Color.FromArgb(229, 57, 53);
            lblErrorProfile.Location = new Point(0, 240);
            lblErrorProfile.Name = "lblErrorProfile";
            lblErrorProfile.Size = new Size(880, 22);
            lblErrorProfile.Visible = false;
            //
            // btnSalveaza
            //
            btnSalveaza.BackColor = Color.FromArgb(229, 57, 53);
            btnSalveaza.FlatAppearance.BorderSize = 0;
            btnSalveaza.FlatStyle = FlatStyle.Flat;
            btnSalveaza.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalveaza.ForeColor = Color.White;
            btnSalveaza.Location = new Point(0, 270);
            btnSalveaza.Name = "btnSalveaza";
            btnSalveaza.Size = new Size(880, 45);
            btnSalveaza.Text = "SALVEAZA MODIFICARILE";
            btnSalveaza.UseVisualStyleBackColor = false;
            btnSalveaza.Click += btnSalveaza_Click;
            //
            // lblSectParola
            //
            lblSectParola.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSectParola.ForeColor = Color.FromArgb(33, 41, 73);
            lblSectParola.Location = new Point(0, 345);
            lblSectParola.Name = "lblSectParola";
            lblSectParola.Size = new Size(880, 28);
            lblSectParola.Text = "Schimba parola";
            //
            // lblParolaVeche
            //
            lblParolaVeche.AutoSize = true;
            lblParolaVeche.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblParolaVeche.Location = new Point(0, 385);
            lblParolaVeche.Name = "lblParolaVeche";
            lblParolaVeche.Text = "Parola veche *";
            //
            // txtParolaVeche
            //
            txtParolaVeche.BorderStyle = BorderStyle.FixedSingle;
            txtParolaVeche.Font = new Font("Segoe UI", 10F);
            txtParolaVeche.Location = new Point(0, 410);
            txtParolaVeche.Name = "txtParolaVeche";
            txtParolaVeche.PasswordChar = '*';
            txtParolaVeche.Size = new Size(286, 27);
            //
            // lblParolaNoua
            //
            lblParolaNoua.AutoSize = true;
            lblParolaNoua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblParolaNoua.Location = new Point(297, 385);
            lblParolaNoua.Name = "lblParolaNoua";
            lblParolaNoua.Text = "Parola noua *";
            //
            // txtParolaNoua
            //
            txtParolaNoua.BorderStyle = BorderStyle.FixedSingle;
            txtParolaNoua.Font = new Font("Segoe UI", 10F);
            txtParolaNoua.Location = new Point(297, 410);
            txtParolaNoua.Name = "txtParolaNoua";
            txtParolaNoua.PasswordChar = '*';
            txtParolaNoua.Size = new Size(286, 27);
            //
            // lblParolaConfirma
            //
            lblParolaConfirma.AutoSize = true;
            lblParolaConfirma.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblParolaConfirma.Location = new Point(594, 385);
            lblParolaConfirma.Name = "lblParolaConfirma";
            lblParolaConfirma.Text = "Confirma parola noua *";
            //
            // txtParolaConfirma
            //
            txtParolaConfirma.BorderStyle = BorderStyle.FixedSingle;
            txtParolaConfirma.Font = new Font("Segoe UI", 10F);
            txtParolaConfirma.Location = new Point(594, 410);
            txtParolaConfirma.Name = "txtParolaConfirma";
            txtParolaConfirma.PasswordChar = '*';
            txtParolaConfirma.Size = new Size(286, 27);
            //
            // lblErrorParola
            //
            lblErrorParola.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblErrorParola.ForeColor = Color.FromArgb(229, 57, 53);
            lblErrorParola.Location = new Point(0, 450);
            lblErrorParola.Name = "lblErrorParola";
            lblErrorParola.Size = new Size(880, 22);
            lblErrorParola.Visible = false;
            //
            // btnSchimbaParola
            //
            btnSchimbaParola.BackColor = Color.FromArgb(49, 112, 249);
            btnSchimbaParola.FlatAppearance.BorderSize = 0;
            btnSchimbaParola.FlatStyle = FlatStyle.Flat;
            btnSchimbaParola.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSchimbaParola.ForeColor = Color.White;
            btnSchimbaParola.Location = new Point(0, 480);
            btnSchimbaParola.Name = "btnSchimbaParola";
            btnSchimbaParola.Size = new Size(880, 45);
            btnSchimbaParola.Text = "SCHIMBA PAROLA";
            btnSchimbaParola.UseVisualStyleBackColor = false;
            btnSchimbaParola.Click += btnSchimbaParola_Click;
            //
            // panForm controls
            //
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

        #endregion
    }
}
