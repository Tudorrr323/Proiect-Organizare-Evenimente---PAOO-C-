using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCEventPage : UserControl
    {
        private readonly EvenimentService _evService = new();
        private readonly CartService _cartService = new();
        private readonly long _idEvent;
        private Bilet? _biletSelectat;

        public UCEventPage(long idEvent)
        {
            _idEvent = idEvent;
            InitializeComponent();
        }

        private void UCEventPage_Load(object? sender, EventArgs e)
        {
            try
            {
                var ev = _evService.GetById(_idEvent);
                if (ev == null)
                {
                    MessageBox.Show("Evenimentul nu a fost gasit.");
                    return;
                }
                AfiseazaEveniment(ev);

                var bilete = _evService.GetBilete(_idEvent);
                dgvBilete.DataSource = bilete;
                StyleDGV();
                if (bilete.Count > 0)
                {
                    dgvBilete.Rows[0].Selected = true;
                    _biletSelectat = bilete[0];
                    ActualizeazaPretTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare: " + ex.Message);
            }
        }

        private void AfiseazaEveniment(Eveniment ev)
        {
            lblNume.Text = ev.Nume;
            lblDescriere.Text = ev.Descriere ?? "";
            lblData.Text = ev.Data.HasValue ? ev.Data.Value.ToString("dd MMMM yyyy, HH:mm") : "Data nedefinita";
            lblLocatie.Text = "📍 " + (ev.Locatie ?? "-");
            lblOrganizator.Text = "🎤 Organizator: " + (ev.Organizator ?? "-");
            lblOras.Text = "🏙 " + (ev.Oras ?? "-");
            lblTip.Text = ev.Tip == TipEveniment.Virtual ? "💻 Eveniment virtual" : "🎟 Eveniment fizic";

            // Daca evenimentul a trecut: badge EXPIRAT + dezactivare cumparare
            bool expirat = ev.Data.HasValue && ev.Data.Value < DateTime.Now;
            lblExpirat.Visible = expirat;
            if (expirat)
            {
                lblNume.ForeColor = Color.Gray;
                lblData.ForeColor = Color.Gray;
                btnAddCart.Enabled = false;
                btnAddCart.BackColor = Color.LightGray;
                btnAddCart.Text = "EVENIMENT EXPIRAT";
                numCantitate.Enabled = false;
            }
            else
            {
                lblNume.ForeColor = Color.FromArgb(33, 41, 73);
                lblData.ForeColor = Color.FromArgb(229, 57, 53);
            }

            // Imagine
            var imgPath = ImageStorage.PathFor(ev.CaleImagine);
            if (imgPath != null && System.IO.File.Exists(imgPath))
            {
                try { picPoster.Image = Image.FromFile(imgPath); }
                catch { picPoster.Image = null; }
            }
            else
            {
                picPoster.Image = null;
            }
        }

        private void dgvBilete_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvBilete.SelectedRows.Count == 0) return;
            _biletSelectat = dgvBilete.SelectedRows[0].DataBoundItem as Bilet;
            ActualizeazaPretTotal();
        }

        private void numCantitate_ValueChanged(object? sender, EventArgs e) => ActualizeazaPretTotal();

        private void ActualizeazaPretTotal()
        {
            if (_biletSelectat == null) { lblPretTotal.Text = "0 RON"; return; }
            var total = (_biletSelectat.Pret ?? 0) * (double)numCantitate.Value;
            lblPretTotal.Text = $"{total:0.##} RON";
        }

        private void btnAddCart_Click(object? sender, EventArgs e)
        {
            if (!SessionManager.EsteAutentificat || SessionManager.UtilizatorCurent == null)
            {
                MessageBox.Show("Trebuie sa fii autentificat.", "Atentie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_biletSelectat == null)
            {
                MessageBox.Show("Selecteaza un bilet din lista.", "Atentie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _cartService.AdaugaInCos(
                    SessionManager.UtilizatorCurent.IdUser,
                    _biletSelectat.IdBilet,
                    (long)numCantitate.Value);
                MessageBox.Show($"Adaugat in cos: {numCantitate.Value} x {_biletSelectat.Denumire}",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void btnInapoi_Click(object? sender, EventArgs e)
        {
            if (Navigator.CanGoBack) Navigator.Back();
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

            // Ascundem coloane tehnice
            HideCol("IdBilet"); HideCol("IdEvent"); HideCol("Descriere");

            // Header-e RO
            RenameCol("Denumire", "Categorie bilet");
            RenameCol("Pret", "Pret RON");
            RenameCol("LocEveniment", "Loc / sectiune");
        }

        private void HideCol(string name)
        {
            if (dgvBilete.Columns[name] != null) dgvBilete.Columns[name]!.Visible = false;
        }

        private void RenameCol(string name, string header)
        {
            if (dgvBilete.Columns[name] != null) dgvBilete.Columns[name]!.HeaderText = header;
        }
    }
}
