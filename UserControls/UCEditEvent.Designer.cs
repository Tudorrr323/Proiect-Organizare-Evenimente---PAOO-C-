namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCEditEvent
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnInapoi;
        private Label lblTitlu;

        private Panel panForm;
        private Label lblSectEv;
        private Label lblNume;
        private TextBox txtNume;
        private Label lblOrganizator;
        private TextBox txtOrganizator;
        private Label lblOras;
        private ComboBox cboOras;
        private Label lblLocatie;
        private TextBox txtLocatie;
        private Label lblData;
        private DateTimePicker dtpData;
        private Label lblOra;
        private DateTimePicker dtpOra;
        private Label lblDescriere;
        private TextBox txtDescriere;
        private Label lblTip;
        private RadioButton rdoFizic;
        private RadioButton rdoVirtual;
        private Label lblStoc;
        private TextBox txtStoc;
        private Label lblImagine;
        private Button btnAlegeImagine;
        private Label lblImagineNume;
        private PictureBox picPreview;

        private Label lblSectBilete;
        private Label lblNrBilete;
        private DataGridView dgvBilete;
        private Button btnAdaugaBilet;
        private Button btnEditeazaBilet;
        private Button btnStergeBilet;

        private Panel panFooter;
        private Label lblError;
        private Button btnStergeEveniment;
        private Button btnSalveaza;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnInapoi = new Button();
            lblTitlu = new Label();
            panForm = new Panel();
            lblSectEv = new Label();
            lblNume = new Label();
            txtNume = new TextBox();
            lblOrganizator = new Label();
            txtOrganizator = new TextBox();
            lblOras = new Label();
            cboOras = new ComboBox();
            lblLocatie = new Label();
            txtLocatie = new TextBox();
            lblData = new Label();
            dtpData = new DateTimePicker();
            lblOra = new Label();
            dtpOra = new DateTimePicker();
            lblDescriere = new Label();
            txtDescriere = new TextBox();
            lblTip = new Label();
            rdoFizic = new RadioButton();
            rdoVirtual = new RadioButton();
            lblStoc = new Label();
            txtStoc = new TextBox();
            lblImagine = new Label();
            btnAlegeImagine = new Button();
            lblImagineNume = new Label();
            picPreview = new PictureBox();
            lblSectBilete = new Label();
            lblNrBilete = new Label();
            dgvBilete = new DataGridView();
            btnAdaugaBilet = new Button();
            btnEditeazaBilet = new Button();
            btnStergeBilet = new Button();
            panFooter = new Panel();
            lblError = new Label();
            btnStergeEveniment = new Button();
            btnSalveaza = new Button();

            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBilete).BeginInit();
            panForm.SuspendLayout();
            panFooter.SuspendLayout();
            SuspendLayout();

            //
            // btnInapoi
            //
            btnInapoi.FlatAppearance.BorderSize = 0;
            btnInapoi.FlatStyle = FlatStyle.Flat;
            btnInapoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnInapoi.ForeColor = Color.FromArgb(49, 112, 249);
            btnInapoi.Location = new Point(20, 15);
            btnInapoi.Name = "btnInapoi";
            btnInapoi.Size = new Size(110, 30);
            btnInapoi.Text = "← Inapoi";
            btnInapoi.UseVisualStyleBackColor = true;
            btnInapoi.Click += btnInapoi_Click;
            //
            // lblTitlu
            //
            lblTitlu.AutoEllipsis = true;
            lblTitlu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(140, 15);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(800, 35);
            lblTitlu.Text = "Editeaza eveniment";

            //
            // panForm (scrollable, contine campurile evenimentului + sectiunea bilete)
            //
            panForm.AutoScroll = true;
            panForm.BackColor = Color.Transparent;
            panForm.Location = new Point(20, 55);
            panForm.Name = "panForm";
            panForm.Size = new Size(920, 555);
            panForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Sectiune detalii eveniment
            ConfigSection(lblSectEv, "Detalii eveniment", 10, 0);

            // Stanga
            ConfigLabel(lblNume, "Nume *", 10, 40);
            ConfigText(txtNume, 10, 65, 420);

            ConfigLabel(lblOrganizator, "Organizator *", 10, 100);
            ConfigText(txtOrganizator, 10, 125, 420);

            ConfigLabel(lblOras, "Oras *", 10, 160);
            cboOras.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOras.Font = new Font("Segoe UI", 10F);
            cboOras.Location = new Point(10, 185);
            cboOras.Name = "cboOras";
            cboOras.Size = new Size(420, 27);

            ConfigLabel(lblLocatie, "Locatie / Adresa *", 10, 220);
            ConfigText(txtLocatie, 10, 245, 420);

            ConfigLabel(lblData, "Data *", 10, 280);
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Font = new Font("Segoe UI", 10F);
            dtpData.Location = new Point(10, 305);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 27);

            ConfigLabel(lblOra, "Ora *", 230, 280);
            dtpOra.Font = new Font("Segoe UI", 10F);
            dtpOra.Location = new Point(230, 305);
            dtpOra.Name = "dtpOra";
            dtpOra.Size = new Size(200, 27);

            ConfigLabel(lblDescriere, "Descriere *", 10, 340);
            txtDescriere.BorderStyle = BorderStyle.FixedSingle;
            txtDescriere.Font = new Font("Segoe UI", 10F);
            txtDescriere.Location = new Point(10, 365);
            txtDescriere.Multiline = true;
            txtDescriere.Name = "txtDescriere";
            txtDescriere.ScrollBars = ScrollBars.Vertical;
            txtDescriere.Size = new Size(420, 90);

            // Dreapta
            ConfigLabel(lblTip, "Tip *", 470, 40);
            rdoFizic.AutoSize = true;
            rdoFizic.Font = new Font("Segoe UI", 10F);
            rdoFizic.Location = new Point(470, 65);
            rdoFizic.Name = "rdoFizic";
            rdoFizic.Text = "Fizic";

            rdoVirtual.AutoSize = true;
            rdoVirtual.Font = new Font("Segoe UI", 10F);
            rdoVirtual.Location = new Point(560, 65);
            rdoVirtual.Name = "rdoVirtual";
            rdoVirtual.Text = "Virtual";

            ConfigLabel(lblStoc, "Stoc bilete *", 470, 100);
            ConfigText(txtStoc, 470, 125, 200);

            ConfigLabel(lblImagine, "Imagine poster", 470, 160);
            btnAlegeImagine.FlatAppearance.BorderColor = Color.FromArgb(49, 112, 249);
            btnAlegeImagine.FlatStyle = FlatStyle.Flat;
            btnAlegeImagine.Font = new Font("Segoe UI", 9.5F);
            btnAlegeImagine.ForeColor = Color.FromArgb(49, 112, 249);
            btnAlegeImagine.Location = new Point(470, 185);
            btnAlegeImagine.Name = "btnAlegeImagine";
            btnAlegeImagine.Size = new Size(160, 32);
            btnAlegeImagine.Text = "Schimba imagine...";
            btnAlegeImagine.UseVisualStyleBackColor = true;
            btnAlegeImagine.Click += btnAlegeImagine_Click;

            lblImagineNume.AutoEllipsis = true;
            lblImagineNume.Font = new Font("Segoe UI", 9F);
            lblImagineNume.ForeColor = Color.Gray;
            lblImagineNume.Location = new Point(640, 192);
            lblImagineNume.Name = "lblImagineNume";
            lblImagineNume.Size = new Size(260, 22);
            lblImagineNume.Text = "...";

            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.BackColor = Color.WhiteSmoke;
            picPreview.Location = new Point(470, 230);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(420, 225);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;

            // Sectiune bilete
            ConfigSection(lblSectBilete, "Categorii de bilete", 10, 480);
            lblNrBilete.Font = new Font("Segoe UI", 9F);
            lblNrBilete.ForeColor = Color.Gray;
            lblNrBilete.Location = new Point(12, 510);
            lblNrBilete.Name = "lblNrBilete";
            lblNrBilete.Size = new Size(400, 20);
            lblNrBilete.Text = "...";

            dgvBilete.AllowUserToAddRows = false;
            dgvBilete.AllowUserToDeleteRows = false;
            dgvBilete.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBilete.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvBilete.Location = new Point(10, 535);
            dgvBilete.MultiSelect = false;
            dgvBilete.Name = "dgvBilete";
            dgvBilete.ReadOnly = true;
            dgvBilete.RowHeadersVisible = false;
            dgvBilete.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBilete.Size = new Size(880, 200);

            // Butoane bilete (sub DGV)
            btnAdaugaBilet.BackColor = Color.FromArgb(5, 150, 105);
            btnAdaugaBilet.FlatAppearance.BorderSize = 0;
            btnAdaugaBilet.FlatStyle = FlatStyle.Flat;
            btnAdaugaBilet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdaugaBilet.ForeColor = Color.White;
            btnAdaugaBilet.Location = new Point(10, 745);
            btnAdaugaBilet.Name = "btnAdaugaBilet";
            btnAdaugaBilet.Size = new Size(180, 36);
            btnAdaugaBilet.Text = "+ Adauga categorie";
            btnAdaugaBilet.UseVisualStyleBackColor = false;
            btnAdaugaBilet.Click += btnAdaugaBilet_Click;

            btnEditeazaBilet.FlatAppearance.BorderColor = Color.FromArgb(49, 112, 249);
            btnEditeazaBilet.FlatStyle = FlatStyle.Flat;
            btnEditeazaBilet.Font = new Font("Segoe UI", 10F);
            btnEditeazaBilet.ForeColor = Color.FromArgb(49, 112, 249);
            btnEditeazaBilet.Location = new Point(200, 745);
            btnEditeazaBilet.Name = "btnEditeazaBilet";
            btnEditeazaBilet.Size = new Size(160, 36);
            btnEditeazaBilet.Text = "Editeaza selectat";
            btnEditeazaBilet.UseVisualStyleBackColor = true;
            btnEditeazaBilet.Click += btnEditeazaBilet_Click;

            btnStergeBilet.FlatAppearance.BorderColor = Color.FromArgb(229, 57, 53);
            btnStergeBilet.FlatStyle = FlatStyle.Flat;
            btnStergeBilet.Font = new Font("Segoe UI", 10F);
            btnStergeBilet.ForeColor = Color.FromArgb(229, 57, 53);
            btnStergeBilet.Location = new Point(370, 745);
            btnStergeBilet.Name = "btnStergeBilet";
            btnStergeBilet.Size = new Size(160, 36);
            btnStergeBilet.Text = "Sterge selectat";
            btnStergeBilet.UseVisualStyleBackColor = true;
            btnStergeBilet.Click += btnStergeBilet_Click;

            // Add la panForm (Z order)
            panForm.Controls.Add(btnStergeBilet);
            panForm.Controls.Add(btnEditeazaBilet);
            panForm.Controls.Add(btnAdaugaBilet);
            panForm.Controls.Add(dgvBilete);
            panForm.Controls.Add(lblNrBilete);
            panForm.Controls.Add(lblSectBilete);

            panForm.Controls.Add(picPreview);
            panForm.Controls.Add(lblImagineNume);
            panForm.Controls.Add(btnAlegeImagine);
            panForm.Controls.Add(lblImagine);
            panForm.Controls.Add(txtStoc);
            panForm.Controls.Add(lblStoc);
            panForm.Controls.Add(rdoVirtual);
            panForm.Controls.Add(rdoFizic);
            panForm.Controls.Add(lblTip);

            panForm.Controls.Add(txtDescriere);
            panForm.Controls.Add(lblDescriere);
            panForm.Controls.Add(dtpOra);
            panForm.Controls.Add(lblOra);
            panForm.Controls.Add(dtpData);
            panForm.Controls.Add(lblData);
            panForm.Controls.Add(txtLocatie);
            panForm.Controls.Add(lblLocatie);
            panForm.Controls.Add(cboOras);
            panForm.Controls.Add(lblOras);
            panForm.Controls.Add(txtOrganizator);
            panForm.Controls.Add(lblOrganizator);
            panForm.Controls.Add(txtNume);
            panForm.Controls.Add(lblNume);
            panForm.Controls.Add(lblSectEv);

            //
            // panFooter
            //
            panFooter.BackColor = Color.Transparent;
            panFooter.Location = new Point(20, 615);
            panFooter.Name = "panFooter";
            panFooter.Size = new Size(920, 55);
            panFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblError.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(0, 12);
            lblError.Name = "lblError";
            lblError.Size = new Size(450, 30);
            lblError.Visible = false;

            btnStergeEveniment.FlatAppearance.BorderColor = Color.FromArgb(229, 57, 53);
            btnStergeEveniment.FlatStyle = FlatStyle.Flat;
            btnStergeEveniment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnStergeEveniment.ForeColor = Color.FromArgb(229, 57, 53);
            btnStergeEveniment.Location = new Point(490, 5);
            btnStergeEveniment.Name = "btnStergeEveniment";
            btnStergeEveniment.Size = new Size(190, 45);
            btnStergeEveniment.Text = "STERGE EVENIMENT";
            btnStergeEveniment.UseVisualStyleBackColor = true;
            btnStergeEveniment.Click += btnStergeEveniment_Click;
            btnStergeEveniment.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnSalveaza.BackColor = Color.FromArgb(229, 57, 53);
            btnSalveaza.FlatAppearance.BorderSize = 0;
            btnSalveaza.FlatStyle = FlatStyle.Flat;
            btnSalveaza.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalveaza.ForeColor = Color.White;
            btnSalveaza.Location = new Point(700, 5);
            btnSalveaza.Name = "btnSalveaza";
            btnSalveaza.Size = new Size(220, 45);
            btnSalveaza.Text = "SALVEAZA MODIFICARILE";
            btnSalveaza.UseVisualStyleBackColor = false;
            btnSalveaza.Click += btnSalveaza_Click;
            btnSalveaza.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            panFooter.Controls.Add(btnSalveaza);
            panFooter.Controls.Add(btnStergeEveniment);
            panFooter.Controls.Add(lblError);

            //
            // UCEditEvent
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(panFooter);
            Controls.Add(panForm);
            Controls.Add(lblTitlu);
            Controls.Add(btnInapoi);
            Name = "UCEditEvent";
            Size = new Size(960, 680);
            Load += UCEditEvent_Load;

            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBilete).EndInit();
            panForm.ResumeLayout(false);
            panForm.PerformLayout();
            panFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigSection(Label l, string text, int x, int y)
        {
            l.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            l.ForeColor = Color.FromArgb(33, 41, 73);
            l.Location = new Point(x, y);
            l.Size = new Size(680, 28);
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
