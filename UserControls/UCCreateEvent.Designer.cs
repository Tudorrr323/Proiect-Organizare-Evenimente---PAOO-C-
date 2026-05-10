namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    partial class UCCreateEvent
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitlu;
        private Panel panForm;
        private Panel panFooter;

        // Eveniment - coloana stanga
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

        // Eveniment - coloana dreapta
        private Label lblTip;
        private RadioButton rdoFizic;
        private RadioButton rdoVirtual;
        private Label lblStoc;
        private TextBox txtStoc;
        private Label lblImagine;
        private Button btnAlegeImagine;
        private Label lblImagineNume;
        private PictureBox picPreview;

        // Bilet primar
        private Label lblSectBilet;
        private Label lblBiletDenumire;
        private TextBox txtBiletDenumire;
        private Label lblBiletPret;
        private TextBox txtBiletPret;
        private Label lblBiletLoc;
        private TextBox txtBiletLoc;
        private Label lblBiletDescriere;
        private TextBox txtBiletDescriere;

        // Footer (la nivel UC, mereu vizibil)
        private Label lblError;
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
            lblTitlu = new Label();
            panForm = new Panel();
            panFooter = new Panel();

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

            lblSectBilet = new Label();
            lblBiletDenumire = new Label();
            txtBiletDenumire = new TextBox();
            lblBiletPret = new Label();
            txtBiletPret = new TextBox();
            lblBiletLoc = new Label();
            txtBiletLoc = new TextBox();
            lblBiletDescriere = new Label();
            txtBiletDescriere = new TextBox();

            lblError = new Label();
            btnSalveaza = new Button();

            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            panForm.SuspendLayout();
            panFooter.SuspendLayout();
            SuspendLayout();

            //
            // lblTitlu
            //
            lblTitlu.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitlu.ForeColor = Color.FromArgb(33, 41, 73);
            lblTitlu.Location = new Point(30, 25);
            lblTitlu.Name = "lblTitlu";
            lblTitlu.Size = new Size(900, 40);
            lblTitlu.Text = "Creeaza eveniment nou";

            //
            // panForm (zona scrollabila pentru toate campurile)
            //
            panForm.AutoScroll = true;
            panForm.BackColor = Color.Transparent;
            panForm.Location = new Point(30, 75);
            panForm.Name = "panForm";
            panForm.Size = new Size(900, 530);
            panForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // ----- Sectiune Detalii Eveniment -----
            ConfigSection(lblSectEv, "Detalii eveniment", 0, 0);

            // Stanga
            ConfigLabel(lblNume, "Nume *", 0, 40);
            ConfigText(txtNume, 0, 65, 420);

            ConfigLabel(lblOrganizator, "Organizator *", 0, 100);
            ConfigText(txtOrganizator, 0, 125, 420);

            ConfigLabel(lblOras, "Oras *", 0, 160);
            cboOras.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOras.Font = new Font("Segoe UI", 10F);
            cboOras.Location = new Point(0, 185);
            cboOras.Name = "cboOras";
            cboOras.Size = new Size(420, 27);

            ConfigLabel(lblLocatie, "Locatie / Adresa *", 0, 220);
            ConfigText(txtLocatie, 0, 245, 420);

            ConfigLabel(lblData, "Data *", 0, 280);
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Font = new Font("Segoe UI", 10F);
            dtpData.Location = new Point(0, 305);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 27);

            ConfigLabel(lblOra, "Ora *", 220, 280);
            dtpOra.Font = new Font("Segoe UI", 10F);
            dtpOra.Location = new Point(220, 305);
            dtpOra.Name = "dtpOra";
            dtpOra.Size = new Size(200, 27);

            ConfigLabel(lblDescriere, "Descriere *", 0, 340);
            ConfigMultiline(txtDescriere, 0, 365, 420, 90);

            // Dreapta (incepe la x=460)
            ConfigLabel(lblTip, "Tip *", 460, 40);
            rdoFizic.AutoSize = true;
            rdoFizic.Font = new Font("Segoe UI", 10F);
            rdoFizic.Location = new Point(460, 65);
            rdoFizic.Name = "rdoFizic";
            rdoFizic.Text = "Fizic";

            rdoVirtual.AutoSize = true;
            rdoVirtual.Font = new Font("Segoe UI", 10F);
            rdoVirtual.Location = new Point(550, 65);
            rdoVirtual.Name = "rdoVirtual";
            rdoVirtual.Text = "Virtual";

            ConfigLabel(lblStoc, "Stoc bilete *", 460, 100);
            ConfigText(txtStoc, 460, 125, 200);
            txtStoc.Text = "100";

            ConfigLabel(lblImagine, "Imagine poster", 460, 160);
            btnAlegeImagine.FlatAppearance.BorderColor = Color.FromArgb(49, 112, 249);
            btnAlegeImagine.FlatStyle = FlatStyle.Flat;
            btnAlegeImagine.Font = new Font("Segoe UI", 9.5F);
            btnAlegeImagine.ForeColor = Color.FromArgb(49, 112, 249);
            btnAlegeImagine.Location = new Point(460, 185);
            btnAlegeImagine.Name = "btnAlegeImagine";
            btnAlegeImagine.Size = new Size(160, 32);
            btnAlegeImagine.Text = "Selecteaza imagine...";
            btnAlegeImagine.UseVisualStyleBackColor = true;
            btnAlegeImagine.Click += btnAlegeImagine_Click;

            lblImagineNume.AutoEllipsis = true;
            lblImagineNume.Font = new Font("Segoe UI", 9F);
            lblImagineNume.ForeColor = Color.Gray;
            lblImagineNume.Location = new Point(630, 192);
            lblImagineNume.Name = "lblImagineNume";
            lblImagineNume.Size = new Size(220, 22);
            lblImagineNume.Text = "Nicio imagine aleasa";

            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.BackColor = Color.WhiteSmoke;
            picPreview.Location = new Point(460, 230);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(390, 225);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;

            //
            // ----- Sectiune Bilet primar -----
            //
            ConfigSection(lblSectBilet, "Categorie bilet (cel putin una)", 0, 480);

            ConfigLabel(lblBiletDenumire, "Denumire *", 0, 520);
            ConfigText(txtBiletDenumire, 0, 545, 280);

            ConfigLabel(lblBiletPret, "Pret (RON) *", 300, 520);
            ConfigText(txtBiletPret, 300, 545, 130);

            ConfigLabel(lblBiletLoc, "Loc / Sectiune", 460, 520);
            ConfigText(txtBiletLoc, 460, 545, 390);

            ConfigLabel(lblBiletDescriere, "Descriere bilet", 0, 580);
            ConfigMultiline(txtBiletDescriere, 0, 605, 850, 90);

            // Add controls la panForm (in ordine inversa pentru z-order)
            panForm.Controls.Add(txtBiletDescriere);
            panForm.Controls.Add(lblBiletDescriere);
            panForm.Controls.Add(txtBiletLoc);
            panForm.Controls.Add(lblBiletLoc);
            panForm.Controls.Add(txtBiletPret);
            panForm.Controls.Add(lblBiletPret);
            panForm.Controls.Add(txtBiletDenumire);
            panForm.Controls.Add(lblBiletDenumire);
            panForm.Controls.Add(lblSectBilet);

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
            // panFooter (mereu vizibil, sub panForm)
            //
            panFooter.BackColor = Color.Transparent;
            panFooter.Location = new Point(30, 615);
            panFooter.Name = "panFooter";
            panFooter.Size = new Size(900, 55);
            panFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            lblError.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(0, 12);
            lblError.Name = "lblError";
            lblError.Size = new Size(680, 30);
            lblError.Visible = false;

            btnSalveaza.BackColor = Color.FromArgb(229, 57, 53);
            btnSalveaza.FlatAppearance.BorderSize = 0;
            btnSalveaza.FlatStyle = FlatStyle.Flat;
            btnSalveaza.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalveaza.ForeColor = Color.White;
            btnSalveaza.Location = new Point(700, 5);
            btnSalveaza.Name = "btnSalveaza";
            btnSalveaza.Size = new Size(200, 45);
            btnSalveaza.Text = "SALVEAZA EVENIMENT";
            btnSalveaza.UseVisualStyleBackColor = false;
            btnSalveaza.Click += btnSalveaza_Click;
            btnSalveaza.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            panFooter.Controls.Add(btnSalveaza);
            panFooter.Controls.Add(lblError);

            //
            // UCCreateEvent
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 246, 246);
            Controls.Add(panFooter);
            Controls.Add(panForm);
            Controls.Add(lblTitlu);
            Name = "UCCreateEvent";
            Size = new Size(960, 680);
            Load += UCCreateEvent_Load;

            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            panForm.ResumeLayout(false);
            panForm.PerformLayout();
            panFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Helpers
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

        private static void ConfigMultiline(TextBox t, int x, int y, int width, int height)
        {
            t.BorderStyle = BorderStyle.FixedSingle;
            t.Font = new Font("Segoe UI", 10F);
            t.Location = new Point(x, y);
            t.Multiline = true;
            t.ScrollBars = ScrollBars.Vertical;
            t.Size = new Size(width, height);
        }

        #endregion
    }
}
