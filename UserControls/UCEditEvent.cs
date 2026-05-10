using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    /// <summary>
    /// Editare eveniment + gestionare bilete + stergere eveniment. Doar pentru manageri.
    /// </summary>
    public partial class UCEditEvent : UserControl
    {
        private readonly EvenimentService _evService = new();
        private readonly OrasRepository _orasRepo = new();
        private readonly long _idEvent;
        private Eveniment? _ev;
        private string? _imagineSursaNoua;        // calea sursa selectata (daca utilizator a schimbat poza)

        public UCEditEvent(long idEvent)
        {
            _idEvent = idEvent;
            InitializeComponent();
        }

        private void UCEditEvent_Load(object? sender, EventArgs e)
        {
            if (!SessionManager.EsteManager && !SessionManager.EsteAdmin)
            {
                MessageBox.Show("Doar manager sau admin poate edita evenimente.", "Acces interzis",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Navigator.Back();
                return;
            }

            try
            {
                _ev = _evService.GetById(_idEvent);
                if (_ev == null)
                {
                    MessageBox.Show("Evenimentul nu a fost gasit.");
                    Navigator.Back();
                    return;
                }

                cboOras.DataSource = _orasRepo.GetAll();
                cboOras.DisplayMember = "Nume";

                // Populam fields
                lblTitlu.Text = $"Editeaza: {_ev.Nume}";
                txtNume.Text = _ev.Nume;
                txtOrganizator.Text = _ev.Organizator ?? "";
                if (!string.IsNullOrWhiteSpace(_ev.Oras))
                {
                    var idx = cboOras.FindString(_ev.Oras);
                    if (idx >= 0) cboOras.SelectedIndex = idx;
                }
                txtLocatie.Text = _ev.Locatie ?? "";
                if (_ev.Data.HasValue)
                {
                    dtpData.Value = _ev.Data.Value.Date;
                    dtpOra.Value = _ev.Data.Value;
                }
                dtpOra.Format = DateTimePickerFormat.Custom;
                dtpOra.CustomFormat = "HH:mm";
                dtpOra.ShowUpDown = true;
                txtDescriere.Text = _ev.Descriere ?? "";
                rdoFizic.Checked = _ev.Tip == TipEveniment.Fizic;
                rdoVirtual.Checked = _ev.Tip == TipEveniment.Virtual;
                txtStoc.Text = _ev.StocBilete?.ToString("0") ?? "100";

                lblImagineNume.Text = _ev.CaleImagine ?? "Nicio imagine";
                IncarcaPreview(_ev.CaleImagine);

                ReincarcaBilete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare: " + ex.Message);
            }
        }

        private void IncarcaPreview(string? fileName)
        {
            picPreview.Image?.Dispose();
            picPreview.Image = null;
            var p = ImageStorage.PathFor(fileName);
            if (p != null && System.IO.File.Exists(p))
            {
                try { picPreview.Image = Image.FromFile(p); } catch { }
            }
        }

        private void ReincarcaBilete()
        {
            var bilete = _evService.GetBilete(_idEvent);
            dgvBilete.DataSource = null;
            dgvBilete.DataSource = bilete;
            StyleDGV();
            ConfigureazaColoaneBilete();
            lblNrBilete.Text = bilete.Count == 0
                ? "Nicio categorie de bilet inca."
                : $"{bilete.Count} categorii de bilet";
        }

        private void btnAlegeImagine_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Alege imagine eveniment",
                Filter = "Imagini (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _imagineSursaNoua = dlg.FileName;
            try { picPreview.Image = Image.FromFile(_imagineSursaNoua); }
            catch { picPreview.Image = null; }
            lblImagineNume.Text = System.IO.Path.GetFileName(_imagineSursaNoua);
        }

        private void btnSalveaza_Click(object? sender, EventArgs e)
        {
            if (_ev == null) return;
            lblError.Visible = false;

            // Validari
            if (string.IsNullOrWhiteSpace(txtNume.Text)) { ShowError("Numele e obligatoriu."); return; }
            if (string.IsNullOrWhiteSpace(txtDescriere.Text)) { ShowError("Descrierea e obligatorie."); return; }
            if (string.IsNullOrWhiteSpace(txtLocatie.Text)) { ShowError("Locatia e obligatorie."); return; }
            if (string.IsNullOrWhiteSpace(txtOrganizator.Text)) { ShowError("Organizatorul e obligatoriu."); return; }
            if (cboOras.SelectedItem is not Oras oras) { ShowError("Selecteaza un oras."); return; }
            if (!Parsing.TryParseInt(txtStoc.Text, out int stoc) || stoc < 1)
            { ShowError("Stocul trebuie sa fie un numar > 0."); return; }

            try
            {
                var dt = dtpData.Value.Date.Add(dtpOra.Value.TimeOfDay);

                // Imagine - daca s-a ales una noua, copiaza in /Images
                string? imgFile = _ev.CaleImagine;
                if (!string.IsNullOrEmpty(_imagineSursaNoua) && System.IO.File.Exists(_imagineSursaNoua))
                    imgFile = ImageStorage.Save(_imagineSursaNoua);

                _ev.Nume = txtNume.Text.Trim();
                _ev.Descriere = txtDescriere.Text.Trim();
                _ev.Locatie = txtLocatie.Text.Trim();
                _ev.Data = dt;
                _ev.Organizator = txtOrganizator.Text.Trim();
                _ev.CaleImagine = imgFile;
                _ev.Oras = oras.Nume;
                _ev.Tip = rdoVirtual.Checked ? TipEveniment.Virtual : TipEveniment.Fizic;
                _ev.StocBilete = stoc;

                _evService.ActualizeazaEveniment(_ev);
                _imagineSursaNoua = null;

                MessageBox.Show("Modificari salvate cu succes.",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Eroare la salvare: " + ex.Message);
            }
        }

        private void btnStergeEveniment_Click(object? sender, EventArgs e)
        {
            if (_ev == null) return;

            var confirm = MessageBox.Show(
                $"Esti sigur ca vrei sa stergi evenimentul \"{_ev.Nume}\"?\n\n" +
                "Toate categoriile de bilete asociate vor fi sterse. Aceasta actiune nu poate fi anulata.",
                "Confirmare stergere",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _evService.StergeEveniment(_idEvent);
                MessageBox.Show("Eveniment sters.", "Sters",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Navigator.Back();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la stergere: " + ex.Message);
            }
        }

        // ---- Bilete actions ----

        private void btnAdaugaBilet_Click(object? sender, EventArgs e)
        {
            using var dlg = new BiletEditForm();
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            try
            {
                _evService.AdaugaBilet(_idEvent, dlg.Denumire, dlg.Pret, dlg.Loc, dlg.Descriere);
                ReincarcaBilete();
            }
            catch (Exception ex) { MessageBox.Show("Eroare: " + ex.Message); }
        }

        private void btnEditeazaBilet_Click(object? sender, EventArgs e)
        {
            if (dgvBilete.SelectedRows.Count == 0) return;
            if (dgvBilete.SelectedRows[0].DataBoundItem is not Bilet b) return;

            using var dlg = new BiletEditForm(b);
            if (dlg.ShowDialog(FindForm()) != DialogResult.OK) return;
            try
            {
                _evService.ActualizeazaBilet(b.IdBilet, dlg.Denumire, dlg.Pret, dlg.Loc, dlg.Descriere);
                ReincarcaBilete();
            }
            catch (Exception ex) { MessageBox.Show("Eroare: " + ex.Message); }
        }

        private void btnStergeBilet_Click(object? sender, EventArgs e)
        {
            if (dgvBilete.SelectedRows.Count == 0) return;
            if (dgvBilete.SelectedRows[0].DataBoundItem is not Bilet b) return;

            var confirm = MessageBox.Show(
                $"Stergi categoria \"{b.Denumire}\"?",
                "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _evService.StergeBilet(b.IdBilet);
                ReincarcaBilete();
            }
            catch (Exception ex) { MessageBox.Show("Eroare: " + ex.Message); }
        }

        private void btnInapoi_Click(object? sender, EventArgs e)
        {
            if (Navigator.CanGoBack) Navigator.Back();
        }

        // ---- Stilizare ----
        private void ConfigureazaColoaneBilete()
        {
            HideCol("IdBilet"); HideCol("IdEvent");
            RenameCol("Denumire", "Categorie bilet");
            RenameCol("Pret", "Pret RON");
            RenameCol("LocEveniment", "Loc / Sectiune");
            RenameCol("Descriere", "Descriere");
        }

        private void StyleDGV()
        {
            dgvBilete.BorderStyle = BorderStyle.None;
            dgvBilete.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgvBilete.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBilete.DefaultCellStyle.SelectionBackColor = Color.FromArgb(49, 112, 249);
            dgvBilete.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvBilete.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvBilete.EnableHeadersVisualStyles = false;
            dgvBilete.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBilete.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvBilete.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 41, 73);
            dgvBilete.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBilete.ColumnHeadersHeight = 35;
            dgvBilete.RowTemplate.Height = 30;
        }

        private void HideCol(string n) { if (dgvBilete.Columns[n] != null) dgvBilete.Columns[n]!.Visible = false; }
        private void RenameCol(string n, string h) { if (dgvBilete.Columns[n] != null) dgvBilete.Columns[n]!.HeaderText = h; }
        private void ShowError(string m) { lblError.Text = m; lblError.Visible = true; }
    }
}
