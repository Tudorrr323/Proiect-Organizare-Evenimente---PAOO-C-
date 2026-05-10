using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    /// <summary>
    /// Card pentru o pozitie din cosul activ. Are buton Sterge.
    /// </summary>
    public partial class CartItemCard : UserControl
    {
        private long _idCosBilet;

        public event Action<long>? StergeRequested;

        public CartItemCard()
        {
            InitializeComponent();
            btnSterge.Click += (s, e) => StergeRequested?.Invoke(_idCosBilet);
        }

        public void Setup(BiletDinCos b)
        {
            _idCosBilet = b.IdCosBilet;
            lblNume.Text = b.EvenimentNume;
            lblData.Text = b.EvenimentData.HasValue
                ? "📅 " + b.EvenimentData.Value.ToString("dd MMM yyyy, HH:mm")
                : "📅 -";
            lblOras.Text = string.IsNullOrWhiteSpace(b.EvenimentOras) ? "Online" : "📍 " + b.EvenimentOras;
            lblTipBilet.Text = "🎟 " + b.TipBilet;
            lblCantitate.Text = $"{b.Cantitate} bucati × {b.Pret:0.##} RON";
            lblTotal.Text = $"{b.PretTotal:0.##} RON";

            picPoster.Image?.Dispose();
            picPoster.Image = null;
            var path = ImageStorage.PathFor(b.EvenimentImgPath);
            if (path != null && System.IO.File.Exists(path))
            {
                try { picPoster.Image = Image.FromFile(path); }
                catch { }
            }
        }
    }
}
