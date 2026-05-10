using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    public partial class UCCart : UserControl
    {
        private readonly CartService _service = new();
        private Cos? _cos;

        public UCCart()
        {
            InitializeComponent();
        }

        private void UCCart_Load(object? sender, EventArgs e) => ReincarcaCos();

        private void ReincarcaCos()
        {
            if (!SessionManager.EsteAutentificat || SessionManager.UtilizatorCurent == null)
            {
                lblStatus.Text = "Trebuie sa fii autentificat.";
                flowItems.Controls.Clear();
                btnPlateste.Enabled = false;
                return;
            }

            try
            {
                _cos = _service.GetActiveCart(SessionManager.UtilizatorCurent.IdUser);
                if (_cos == null)
                {
                    lblStatus.Text = "Cosul tau este gol.";
                    flowItems.Controls.Clear();
                    lblTotal.Text = "0 RON";
                    btnPlateste.Enabled = false;
                    return;
                }

                _service.RecalculeazaCos(_cos.IdCos);
                _cos = _service.GetCart(_cos.IdCos);

                var items = _service.GetItemsCuDetalii(_cos.IdCos);
                AfiseazaCarduri(items);

                double totalLive = items.Sum(i => i.PretTotal);
                long cantLive = items.Sum(i => i.Cantitate);
                lblTotal.Text = $"{totalLive:0.##} RON";
                btnPlateste.Enabled = items.Count > 0;
                lblStatus.Text = items.Count == 0
                    ? "Cosul tau este gol."
                    : $"{items.Count} pozitii in cos | {cantLive} bilete";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare cos: " + ex.Message);
            }
        }

        private void AfiseazaCarduri(List<BiletDinCos> items)
        {
            flowItems.SuspendLayout();
            flowItems.Controls.Clear();
            foreach (var b in items)
            {
                var card = new CartItemCard();
                card.Setup(b);
                card.StergeRequested += idCb => StergeItem(b);
                flowItems.Controls.Add(card);
            }
            flowItems.ResumeLayout();
        }

        private void StergeItem(BiletDinCos b)
        {
            if (_cos == null) return;
            var confirm = MessageBox.Show(
                $"Stergi {b.Cantitate} x {b.TipBilet} de la \"{b.EvenimentNume}\"?",
                "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                _service.StergeItem(_cos.IdCos, b.IdCosBilet);
                ReincarcaCos();
            }
            catch (Exception ex) { MessageBox.Show("Eroare: " + ex.Message); }
        }

        private void btnPlateste_Click(object? sender, EventArgs e)
        {
            if (_cos == null) return;
            var total = _cos.Pret ?? 0;
            var confirm = MessageBox.Show(
                $"Confirmi plata pentru {total:0.##} RON?",
                "Plata", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _service.Checkout(_cos.IdCos);
                MessageBox.Show("Plata efectuata cu succes! Verifica biletele in \"Biletele mele\".",
                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReincarcaCos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la plata: " + ex.Message);
            }
        }
    }
}
