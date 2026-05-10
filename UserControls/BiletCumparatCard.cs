using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    /// <summary>
    /// Card pentru un bilet cumparat: poster eveniment + detalii bilet + cantitate + total + data comanda.
    /// Folosit in UCMyTickets.
    /// </summary>
    public partial class BiletCumparatCard : UserControl
    {
        private long _idCos;
        private bool _hovering;

        /// <summary>Click pe card -> deschide detaliile comenzii (idCos).</summary>
        public event Action<long>? ComandaSelectata;

        public BiletCumparatCard()
        {
            InitializeComponent();
            AttachInteractionRecursive(this);
        }

        public void Setup(BiletDinCos b, string? imgFile)
        {
            _idCos = b.IdCos;
            lblNume.Text = b.EvenimentNume;
            lblData.Text = b.EvenimentData.HasValue
                ? "📅 " + b.EvenimentData.Value.ToString("dd MMM yyyy, HH:mm")
                : "📅 Data nedefinita";
            lblOras.Text = string.IsNullOrWhiteSpace(b.EvenimentOras) ? "Online" : "📍 " + b.EvenimentOras;
            lblTipBilet.Text = "🎟 " + b.TipBilet;
            lblCantitate.Text = $"{b.Cantitate} bucati";
            lblTotal.Text = $"{b.PretTotal:0.##} RON";
            lblDataComanda.Text = b.DataComanda.HasValue
                ? "Cumparat: " + b.DataComanda.Value.ToString("dd MMM yyyy")
                : "Cumparat: -";

            // Tag EXPIRAT daca evenimentul a trecut
            bool expirat = b.EvenimentData.HasValue && b.EvenimentData.Value < DateTime.Now;
            lblExpirat.Visible = expirat;
            if (expirat)
            {
                lblNume.ForeColor = Color.Gray;
                lblData.ForeColor = Color.Gray;
            }
            else
            {
                lblNume.ForeColor = Color.FromArgb(33, 41, 73);
                lblData.ForeColor = Color.FromArgb(229, 57, 53);
            }

            picPoster.Image?.Dispose();
            picPoster.Image = null;
            var path = ImageStorage.PathFor(imgFile);
            if (path != null && System.IO.File.Exists(path))
            {
                try { picPoster.Image = Image.FromFile(path); }
                catch { }
            }
        }

        private void AttachInteractionRecursive(Control c)
        {
            c.Click += (s, e) => ComandaSelectata?.Invoke(_idCos);
            c.MouseEnter += (s, e) => SetHover(true);
            c.MouseLeave += (s, e) => CheckLeaveAfterPaint();
            c.Cursor = Cursors.Hand;
            foreach (Control child in c.Controls)
                AttachInteractionRecursive(child);
        }

        private void SetHover(bool on)
        {
            if (_hovering == on) return;
            _hovering = on;
            BackColor = on ? Color.FromArgb(225, 232, 250) : Color.White;
        }

        private void CheckLeaveAfterPaint()
        {
            if (!IsHandleCreated) return;
            BeginInvoke((Action)(() =>
            {
                var pt = PointToClient(Cursor.Position);
                SetHover(ClientRectangle.Contains(pt));
            }));
        }
    }
}
