using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    /// <summary>
    /// Card vizual pentru un Eveniment: poster + titlu + data + oras + tip.
    /// </summary>
    public partial class EvenimentCard : UserControl
    {
        private long _idEvent;
        private bool _hovering;
        private static readonly Color HoverColor = Color.FromArgb(225, 232, 250);

        public event Action<long>? Selected;

        public EvenimentCard()
        {
            InitializeComponent();
            // Atasam handlerele pe toate copiii ca sa pastram hover-ul stabil
            // (MouseEnter pe parent fires Leave cand mouse intra pe child).
            AttachInteractionRecursive(this);
        }

        public void Setup(Eveniment ev)
        {
            _idEvent = ev.IdEvent;
            lblNume.Text = ev.Nume;
            lblData.Text = ev.Data.HasValue ? ev.Data.Value.ToString("dd MMM yyyy, HH:mm") : "Data nedefinita";
            lblOras.Text = string.IsNullOrWhiteSpace(ev.Oras) ? "Online" : "📍 " + ev.Oras;
            lblTip.Text = ev.Tip == TipEveniment.Virtual ? "💻 Virtual" : "🎟 Fizic";
            lblTip.BackColor = ev.Tip == TipEveniment.Virtual
                ? Color.FromArgb(49, 112, 249)
                : Color.FromArgb(229, 57, 53);

            // Tag EXPIRAT daca data evenimentului a trecut deja
            bool expirat = ev.Data.HasValue && ev.Data.Value < DateTime.Now;
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
            var path = ImageStorage.PathFor(ev.CaleImagine);
            if (path != null && System.IO.File.Exists(path))
            {
                try { picPoster.Image = Image.FromFile(path); }
                catch { /* fallback null */ }
            }
        }

        private void AttachInteractionRecursive(Control c)
        {
            c.Click += (s, e) => Selected?.Invoke(_idEvent);
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
            BackColor = on ? HoverColor : Color.White;
        }

        // Cand mouse iese dintr-un child pentru a intra in alt child al cardului,
        // primim Leave imediat urmat de Enter. Verificam pozitia reala dupa
        // ce s-au procesat toate evenimentele.
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
