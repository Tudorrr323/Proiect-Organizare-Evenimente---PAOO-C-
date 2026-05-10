using Proiect_PAOO_Organizare_Evenimente.BLL;
using Proiect_PAOO_Organizare_Evenimente.Helpers;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.UserControls
{
    /// <summary>
    /// Detalii pentru o comanda anume: lista bilete + buton descarcare PDF per bilet.
    /// </summary>
    public partial class UCComandaDetalii : UserControl
    {
        private readonly CartService _service = new();
        private readonly long _idCos;
        private List<BiletDinCos> _bilete = new();

        public UCComandaDetalii(long idCos)
        {
            _idCos = idCos;
            InitializeComponent();
        }

        private void UCComandaDetalii_Load(object? sender, EventArgs e)
        {
            try
            {
                _bilete = _service.GetItemsCuDetalii(_idCos);
                lblTitlu.Text = $"Comanda #{_idCos}";
                lblSubtitlu.Text = _bilete.Count == 0
                    ? "Comanda nu are bilete."
                    : $"{_bilete.Count} categorii | {_bilete.Sum(b => b.Cantitate)} bilete | Total {_bilete.Sum(b => b.PretTotal):0.##} RON";

                var dataComanda = _bilete.FirstOrDefault()?.DataComanda;
                lblData.Text = dataComanda.HasValue
                    ? "Data cumparare: " + dataComanda.Value.ToString("dd MMM yyyy, HH:mm")
                    : "";

                AfiseazaItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la incarcare comanda: " + ex.Message);
            }
        }

        private void AfiseazaItems()
        {
            flowItems.SuspendLayout();
            flowItems.Controls.Clear();
            foreach (var b in _bilete)
            {
                var row = CreeazaRand(b);
                flowItems.Controls.Add(row);
            }
            flowItems.ResumeLayout();
        }

        private Panel CreeazaRand(BiletDinCos b)
        {
            var pan = new Panel
            {
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(880, 110),
                Margin = new Padding(0, 0, 0, 10)
            };

            // Poza eveniment
            var pic = new PictureBox
            {
                BackColor = Color.WhiteSmoke,
                Location = new Point(10, 10),
                Size = new Size(140, 90),
                SizeMode = PictureBoxSizeMode.Zoom
            };
            var imgPath = ImageStorage.PathFor(b.EvenimentImgPath);
            if (imgPath != null && System.IO.File.Exists(imgPath))
            {
                try { pic.Image = Image.FromFile(imgPath); } catch { }
            }
            pan.Controls.Add(pic);

            // Detalii text
            var lblNume = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 41, 73),
                Location = new Point(165, 8),
                Size = new Size(450, 25),
                Text = b.EvenimentNume
            };
            pan.Controls.Add(lblNume);

            var lblData = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(229, 57, 53),
                Location = new Point(165, 35),
                Size = new Size(450, 20),
                Text = b.EvenimentData.HasValue
                    ? "📅 " + b.EvenimentData.Value.ToString("dd MMM yyyy, HH:mm")
                    : "📅 -"
            };
            pan.Controls.Add(lblData);

            var lblDetalii = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.DimGray,
                Location = new Point(165, 57),
                Size = new Size(450, 20),
                Text = $"🎟 {b.TipBilet} • {b.LocEveniment ?? "-"}"
            };
            pan.Controls.Add(lblDetalii);

            var lblCantitate = new Label
            {
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(165, 80),
                Size = new Size(450, 20),
                Text = $"{b.Cantitate} bucati × {b.Pret:0.##} RON  =  {b.PretTotal:0.##} RON"
            };
            pan.Controls.Add(lblCantitate);

            // Buton descarca PDF
            var btnPdf = new Button
            {
                BackColor = Color.FromArgb(49, 112, 249),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(680, 30),
                Size = new Size(180, 50),
                Text = "DESCARCA BILET PDF",
                UseVisualStyleBackColor = false
            };
            btnPdf.FlatAppearance.BorderSize = 0;
            btnPdf.Click += (s, e) => DescarcaPdf(b);
            pan.Controls.Add(btnPdf);

            return pan;
        }

        private void DescarcaPdf(BiletDinCos b)
        {
            if (SessionManager.UtilizatorCurent == null) return;

            var safeName = string.Concat(b.EvenimentNume.Split(System.IO.Path.GetInvalidFileNameChars()))
                              .Replace(' ', '_');
            using var dlg = new SaveFileDialog
            {
                Title = "Salveaza bilet PDF",
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"Bilet_{safeName}_cos{b.IdCos}.pdf"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            try
            {
                var bytes = PdfBilet.Genereaza(b, SessionManager.UtilizatorCurent);
                System.IO.File.WriteAllBytes(dlg.FileName, bytes);

                var deschide = MessageBox.Show(
                    "Bilet salvat cu succes! Vrei sa-l deschizi?",
                    "Succes", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (deschide == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = dlg.FileName,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la generare PDF: " + ex.Message);
            }
        }

        private void btnInapoi_Click(object? sender, EventArgs e)
        {
            if (Navigator.CanGoBack) Navigator.Back();
        }
    }
}
