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
            // panForm
            //
            panForm.AutoScroll = true;
            panForm.BackColor = Color.Transparent;
            panForm.Location = new Point(30, 75);
            panForm.Name = "panForm";
            panForm.Size = new Size(900, 530);
            panForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //
            // lblSectEv
            //
            lblSectEv.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSectEv.ForeColor = Color.FromArgb(33, 41, 73);
            lblSectEv.Location = new Point(0, 0);
            lblSectEv.Name = "lblSectEv";
            lblSectEv.Size = new Size(680, 28);
            lblSectEv.Text = "Detalii eveniment";
            //
            // lblNume
            //
            lblNume.AutoSize = true;
            lblNume.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNume.Location = new Point(0, 40);
            lblNume.Name = "lblNume";
            lblNume.Text = "Nume *";
            //
            // txtNume
            //
            txtNume.BorderStyle = BorderStyle.FixedSingle;
            txtNume.Font = new Font("Segoe UI", 10F);
            txtNume.Location = new Point(0, 65);
            txtNume.Name = "txtNume";
            txtNume.Size = new Size(420, 27);
            //
            // lblOrganizator
            //
            lblOrganizator.AutoSize = true;
            lblOrganizator.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblOrganizator.Location = new Point(0, 100);
            lblOrganizator.Name = "lblOrganizator";
            lblOrganizator.Text = "Organizator *";
            //
            // txtOrganizator
            //
            txtOrganizator.BorderStyle = BorderStyle.FixedSingle;
            txtOrganizator.Font = new Font("Segoe UI", 10F);
            txtOrganizator.Location = new Point(0, 125);
            txtOrganizator.Name = "txtOrganizator";
            txtOrganizator.Size = new Size(420, 27);
            //
            // lblOras
            //
            lblOras.AutoSize = true;
            lblOras.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblOras.Location = new Point(0, 160);
            lblOras.Name = "lblOras";
            lblOras.Text = "Oras *";
            //
            // cboOras
            //
            cboOras.DropDownStyle = ComboBoxStyle.DropDownList;
            cboOras.Font = new Font("Segoe UI", 10F);
            cboOras.Location = new Point(0, 185);
            cboOras.Name = "cboOras";
            cboOras.Size = new Size(420, 27);
            //
            // lblLocatie
            //
            lblLocatie.AutoSize = true;
            lblLocatie.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLocatie.Location = new Point(0, 220);
            lblLocatie.Name = "lblLocatie";
            lblLocatie.Text = "Locatie / Adresa *";
            //
            // txtLocatie
            //
            txtLocatie.BorderStyle = BorderStyle.FixedSingle;
            txtLocatie.Font = new Font("Segoe UI", 10F);
            txtLocatie.Location = new Point(0, 245);
            txtLocatie.Name = "txtLocatie";
            txtLocatie.Size = new Size(420, 27);
            //
            // lblData
            //
            lblData.AutoSize = true;
            lblData.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblData.Location = new Point(0, 280);
            lblData.Name = "lblData";
            lblData.Text = "Data *";
            //
            // dtpData
            //
            dtpData.Font = new Font("Segoe UI", 10F);
            dtpData.Format = DateTimePickerFormat.Short;
            dtpData.Location = new Point(0, 305);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 27);
            //
            // lblOra
            //
            lblOra.AutoSize = true;
            lblOra.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblOra.Location = new Point(220, 280);
            lblOra.Name = "lblOra";
            lblOra.Text = "Ora *";
            //
            // dtpOra
            //
            dtpOra.Font = new Font("Segoe UI", 10F);
            dtpOra.Location = new Point(220, 305);
            dtpOra.Name = "dtpOra";
            dtpOra.Size = new Size(200, 27);
            //
            // lblDescriere
            //
            lblDescriere.AutoSize = true;
            lblDescriere.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDescriere.Location = new Point(0, 340);
            lblDescriere.Name = "lblDescriere";
            lblDescriere.Text = "Descriere *";
            //
            // txtDescriere
            //
            txtDescriere.BorderStyle = BorderStyle.FixedSingle;
            txtDescriere.Font = new Font("Segoe UI", 10F);
            txtDescriere.Location = new Point(0, 365);
            txtDescriere.Multiline = true;
            txtDescriere.Name = "txtDescriere";
            txtDescriere.ScrollBars = ScrollBars.Vertical;
            txtDescriere.Size = new Size(420, 90);
            //
            // lblTip
            //
            lblTip.AutoSize = true;
            lblTip.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTip.Location = new Point(460, 40);
            lblTip.Name = "lblTip";
            lblTip.Text = "Tip *";
            //
            // rdoFizic
            //
            rdoFizic.AutoSize = true;
            rdoFizic.Font = new Font("Segoe UI", 10F);
            rdoFizic.Location = new Point(460, 65);
            rdoFizic.Name = "rdoFizic";
            rdoFizic.Text = "Fizic";
            //
            // rdoVirtual
            //
            rdoVirtual.AutoSize = true;
            rdoVirtual.Font = new Font("Segoe UI", 10F);
            rdoVirtual.Location = new Point(550, 65);
            rdoVirtual.Name = "rdoVirtual";
            rdoVirtual.Text = "Virtual";
            //
            // lblStoc
            //
            lblStoc.AutoSize = true;
            lblStoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblStoc.Location = new Point(460, 100);
            lblStoc.Name = "lblStoc";
            lblStoc.Text = "Stoc bilete *";
            //
            // txtStoc
            //
            txtStoc.BorderStyle = BorderStyle.FixedSingle;
            txtStoc.Font = new Font("Segoe UI", 10F);
            txtStoc.Location = new Point(460, 125);
            txtStoc.Name = "txtStoc";
            txtStoc.Size = new Size(200, 27);
            txtStoc.Text = "100";
            //
            // lblImagine
            //
            lblImagine.AutoSize = true;
            lblImagine.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblImagine.Location = new Point(460, 160);
            lblImagine.Name = "lblImagine";
            lblImagine.Text = "Imagine poster";
            //
            // btnAlegeImagine
            //
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
            //
            // lblImagineNume
            //
            lblImagineNume.AutoEllipsis = true;
            lblImagineNume.Font = new Font("Segoe UI", 9F);
            lblImagineNume.ForeColor = Color.Gray;
            lblImagineNume.Location = new Point(630, 192);
            lblImagineNume.Name = "lblImagineNume";
            lblImagineNume.Size = new Size(220, 22);
            lblImagineNume.Text = "Nicio imagine aleasa";
            //
            // picPreview
            //
            picPreview.BackColor = Color.WhiteSmoke;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(460, 230);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(390, 225);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabStop = false;
            //
            // lblSectBilet
            //
            lblSectBilet.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblSectBilet.ForeColor = Color.FromArgb(33, 41, 73);
            lblSectBilet.Location = new Point(0, 480);
            lblSectBilet.Name = "lblSectBilet";
            lblSectBilet.Size = new Size(680, 28);
            lblSectBilet.Text = "Categorie bilet (cel putin una)";
            //
            // lblBiletDenumire
            //
            lblBiletDenumire.AutoSize = true;
            lblBiletDenumire.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBiletDenumire.Location = new Point(0, 520);
            lblBiletDenumire.Name = "lblBiletDenumire";
            lblBiletDenumire.Text = "Denumire *";
            //
            // txtBiletDenumire
            //
            txtBiletDenumire.BorderStyle = BorderStyle.FixedSingle;
            txtBiletDenumire.Font = new Font("Segoe UI", 10F);
            txtBiletDenumire.Location = new Point(0, 545);
            txtBiletDenumire.Name = "txtBiletDenumire";
            txtBiletDenumire.Size = new Size(280, 27);
            //
            // lblBiletPret
            //
            lblBiletPret.AutoSize = true;
            lblBiletPret.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBiletPret.Location = new Point(300, 520);
            lblBiletPret.Name = "lblBiletPret";
            lblBiletPret.Text = "Pret (RON) *";
            //
            // txtBiletPret
            //
            txtBiletPret.BorderStyle = BorderStyle.FixedSingle;
            txtBiletPret.Font = new Font("Segoe UI", 10F);
            txtBiletPret.Location = new Point(300, 545);
            txtBiletPret.Name = "txtBiletPret";
            txtBiletPret.Size = new Size(130, 27);
            //
            // lblBiletLoc
            //
            lblBiletLoc.AutoSize = true;
            lblBiletLoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBiletLoc.Location = new Point(460, 520);
            lblBiletLoc.Name = "lblBiletLoc";
            lblBiletLoc.Text = "Loc / Sectiune";
            //
            // txtBiletLoc
            //
            txtBiletLoc.BorderStyle = BorderStyle.FixedSingle;
            txtBiletLoc.Font = new Font("Segoe UI", 10F);
            txtBiletLoc.Location = new Point(460, 545);
            txtBiletLoc.Name = "txtBiletLoc";
            txtBiletLoc.Size = new Size(390, 27);
            //
            // lblBiletDescriere
            //
            lblBiletDescriere.AutoSize = true;
            lblBiletDescriere.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBiletDescriere.Location = new Point(0, 580);
            lblBiletDescriere.Name = "lblBiletDescriere";
            lblBiletDescriere.Text = "Descriere bilet";
            //
            // txtBiletDescriere
            //
            txtBiletDescriere.BorderStyle = BorderStyle.FixedSingle;
            txtBiletDescriere.Font = new Font("Segoe UI", 10F);
            txtBiletDescriere.Location = new Point(0, 605);
            txtBiletDescriere.Multiline = true;
            txtBiletDescriere.Name = "txtBiletDescriere";
            txtBiletDescriere.ScrollBars = ScrollBars.Vertical;
            txtBiletDescriere.Size = new Size(850, 90);
            //
            // panForm controls
            //
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
            // panFooter
            //
            panFooter.BackColor = Color.Transparent;
            panFooter.Location = new Point(30, 615);
            panFooter.Name = "panFooter";
            panFooter.Size = new Size(900, 55);
            panFooter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //
            // lblError
            //
            lblError.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblError.ForeColor = Color.FromArgb(229, 57, 53);
            lblError.Location = new Point(0, 12);
            lblError.Name = "lblError";
            lblError.Size = new Size(680, 30);
            lblError.Visible = false;
            //
            // btnSalveaza
            //
            btnSalveaza.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            //
            // panFooter controls
            //
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

        #endregion
    }
}
