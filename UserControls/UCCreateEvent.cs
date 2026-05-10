using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.DAL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCCreateEvent : UserControl
    {
        private readonly EvenimentService _evService = new();
        private readonly BiletRepository _biletRepo = new();
        private readonly OrasRepository _orasRepo = new();

        private string? _imagineFisier;        // calea sursa selectata local de manager

        public UCCreateEvent()
        {
            InitializeComponent();
        }

        private void UCCreateEvent_Load(object? sender, EventArgs e)
        {
            // Acces doar pentru manageri
            if (!SessionManager.EsteManager || SessionManager.UtilizatorCurent is not Manager mgr)
            {
                lblTitlu.Text = "Doar manager poate crea evenimente.";
                panForm.Visible = false;
                return;
            }

            // Populam combobox-uri
            cboOras.DataSource = _orasRepo.GetAll();
            cboOras.DisplayMember = "Nume";
            cboOras.ValueMember = "IdOras";

            // Pre-fill organizator cu compania managerului
            if (!string.IsNullOrWhiteSpace(mgr.Companie))
                txtOrganizator.Text = mgr.Companie;

            rdoFizic.Checked = true;
            dtpData.MinDate = DateTime.Today;
            dtpData.Value = DateTime.Today.AddDays(7);
            dtpOra.Format = DateTimePickerFormat.Custom;
            dtpOra.CustomFormat = "HH:mm";
            dtpOra.ShowUpDown = true;
            dtpOra.Value = DateTime.Today.AddHours(20);
        }

        private void btnAlegeImagine_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Title = "Alege imagine eveniment",
                Filter = "Imagini (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            _imagineFisier = dlg.FileName;
            try { picPreview.Image = Image.FromFile(_imagineFisier); }
            catch { picPreview.Image = null; }
            lblImagineNume.Text = System.IO.Path.GetFileName(_imagineFisier);
        }

        private void btnSalveaza_Click(object? sender, EventArgs e)
        {
            lblError.Visible = false;

            // ----- validari eveniment -----
            if (string.IsNullOrWhiteSpace(txtNume.Text)) { ShowError("Numele evenimentului e obligatoriu."); return; }
            if (string.IsNullOrWhiteSpace(txtDescriere.Text)) { ShowError("Descrierea e obligatorie."); return; }
            if (string.IsNullOrWhiteSpace(txtLocatie.Text)) { ShowError("Locatia e obligatorie."); return; }
            if (string.IsNullOrWhiteSpace(txtOrganizator.Text)) { ShowError("Organizatorul e obligatoriu."); return; }
            if (cboOras.SelectedItem is not Oras oras) { ShowError("Selecteaza un oras."); return; }
            if (!Parsing.TryParseInt(txtStoc.Text, out int stoc) || stoc < 1)
            { ShowError("Stocul de bilete trebuie sa fie un numar > 0."); return; }

            // ----- validari bilet -----
            if (string.IsNullOrWhiteSpace(txtBiletDenumire.Text)) { ShowError("Denumirea categoriei de bilet e obligatorie."); return; }
            if (!Parsing.TryParseDouble(txtBiletPret.Text, out double biletPret) || biletPret < 0)
            { ShowError("Pretul biletului trebuie sa fie un numar >= 0."); return; }

            try
            {
                // ---- combinam data + ora ----
                var dt = dtpData.Value.Date.Add(dtpOra.Value.TimeOfDay);

                // ---- imagine: copiem in /Images/ daca a ales ----
                string? imgFile = null;
                if (!string.IsNullOrEmpty(_imagineFisier) && System.IO.File.Exists(_imagineFisier))
                    imgFile = ImageStorage.Save(_imagineFisier);

                var ev = new Eveniment(
                    idEvent:           0,           // SERIAL — e ignorat la INSERT
                    nume:              txtNume.Text.Trim(),
                    descriere:         txtDescriere.Text.Trim(),
                    locatie:           txtLocatie.Text.Trim(),
                    data:              dt,
                    organizator:       txtOrganizator.Text.Trim(),
                    caleImagine:       imgFile,
                    oras:              oras.Nume,
                    tip:               rdoVirtual.Checked ? TipEveniment.Virtual : TipEveniment.Fizic,
                    stocBilete:        stoc,
                    idUserOrganizator: SessionManager.UtilizatorCurent!.IdUser);

                long idNou = _evService.CreeazaEveniment(ev);

                // Insert bilet primar
                _biletRepo.Insert(
                    denumire:  txtBiletDenumire.Text.Trim(),
                    pret:      biletPret,
                    loc:       string.IsNullOrWhiteSpace(txtBiletLoc.Text) ? null : txtBiletLoc.Text.Trim(),
                    descriere: string.IsNullOrWhiteSpace(txtBiletDescriere.Text) ? null : txtBiletDescriere.Text.Trim(),
                    idEvent:   idNou);

                MessageBox.Show($"Eveniment creat cu succes! ID = {idNou}",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                ShowError("Eroare la salvare: " + ex.Message);
            }
        }

        private void ResetForm()
        {
            txtNume.Clear();
            txtDescriere.Clear();
            txtLocatie.Clear();
            txtStoc.Text = "100";
            txtBiletDenumire.Clear();
            txtBiletPret.Clear();
            txtBiletLoc.Clear();
            txtBiletDescriere.Clear();
            picPreview.Image?.Dispose();
            picPreview.Image = null;
            _imagineFisier = null;
            lblImagineNume.Text = "Nicio imagine aleasa";
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }
    }
}
