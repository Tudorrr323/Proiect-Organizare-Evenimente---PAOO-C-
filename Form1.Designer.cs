namespace Proiect_PAOO_Organizare_Evenimente
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private PictureBox picLogo;
        private Label lblSubtitlu;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnSignUp;
        private Label lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picLogo = new PictureBox();
            lblSubtitlu = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnSignUp = new Button();
            lblError = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            //
            // picLogo
            //
            picLogo.Location = new Point(160, 25);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(280, 70);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabStop = false;
            //
            // lblSubtitlu
            //
            lblSubtitlu.Font = new Font("Segoe UI", 11F);
            lblSubtitlu.ForeColor = Color.Gray;
            lblSubtitlu.Location = new Point(80, 95);
            lblSubtitlu.Name = "lblSubtitlu";
            lblSubtitlu.Size = new Size(440, 25);
            lblSubtitlu.TabIndex = 1;
            lblSubtitlu.Text = "Autentifica-te pentru a continua";
            lblSubtitlu.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(100, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(45, 19);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(100, 175);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "tudor.chirita@gmail.com";
            txtEmail.Size = new Size(400, 27);
            txtEmail.TabIndex = 3;
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.Location = new Point(100, 215);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(54, 19);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Parola";
            //
            // txtPassword
            //
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(100, 240);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(400, 27);
            txtPassword.TabIndex = 5;
            //
            // btnLogin
            //
            btnLogin.BackColor = Color.FromArgb(229, 57, 53);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(100, 295);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(400, 42);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "AUTENTIFICARE";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            //
            // btnSignUp
            //
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Segoe UI", 9.5F);
            btnSignUp.ForeColor = Color.FromArgb(49, 112, 249);
            btnSignUp.Location = new Point(100, 345);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(400, 30);
            btnSignUp.TabIndex = 7;
            btnSignUp.Text = "Nu ai cont? Inregistreaza-te";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            //
            // lblError
            //
            lblError.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(100, 270);
            lblError.Name = "lblError";
            lblError.Size = new Size(400, 22);
            lblError.TabIndex = 9;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = false;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 400);
            Controls.Add(lblError);
            Controls.Add(btnSignUp);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblSubtitlu);
            Controls.Add(picLogo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ticketa - Autentificare";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
