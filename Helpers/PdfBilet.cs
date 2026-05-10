using Proiect_PAOO_Organizare_Evenimente.Models;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Generator PDF pentru un bilet electronic, in stil factura cu QR code.
    /// </summary>
    public static class PdfBilet
    {
        static PdfBilet()
        {
            // Licensa Community pentru QuestPDF (free pentru proiect academic)
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public static byte[] Genereaza(BiletDinCos bilet, Utilizator user)
        {
            // QR encoding: identificator unic ce poate fi validat de organizator
            var qrPayload = $"TICKETA|cos:{bilet.IdCos}|cb:{bilet.IdCosBilet}|user:{user.IdUser}|ev:{bilet.EvenimentNume}";
            var qrPng = GenereazaQrPng(qrPayload, 8);

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(t => t.FontSize(10).FontFamily("Segoe UI"));

                    page.Header().Element(ComposeHeader);
                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        col.Spacing(15);
                        col.Item().Element(c => ComposeEvent(c, bilet));
                        col.Item().Element(c => ComposeDetails(c, bilet));
                        col.Item().Element(c => ComposeUser(c, bilet, user));
                        col.Item().PaddingTop(20).AlignCenter().Width(180).Image(qrPng);
                        col.Item().AlignCenter().Text(qrPayload).FontSize(7).FontColor(Colors.Grey.Medium);
                    });
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.Span("Multumim ca alegi ").FontColor(Colors.Grey.Medium);
                        text.Span("Ticketa").Bold().FontColor("#3170F9");
                        text.Span("! Bilet generat la ").FontColor(Colors.Grey.Medium);
                        text.Span(DateTime.Now.ToString("dd MMM yyyy, HH:mm")).Bold().FontColor(Colors.Grey.Medium);
                    });
                });
            }).GeneratePdf();
        }

        private static byte[] GenereazaQrPng(string payload, int pixelsPerModule)
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode(payload, QRCodeGenerator.ECCLevel.M);
            using var qr = new PngByteQRCode(data);
            return qr.GetGraphic(pixelsPerModule);
        }

        private static void ComposeHeader(IContainer container)
        {
            // Incercam sa incarcam logo-ul; daca nu exista, fallback la text
            byte[]? logoBytes = null;
            try
            {
                var logoPath = ImageStorage.PathFor("logo2.png");
                if (logoPath != null && System.IO.File.Exists(logoPath))
                    logoBytes = System.IO.File.ReadAllBytes(logoPath);
            }
            catch { /* fallback la text */ }

            container.Row(row =>
            {
                row.RelativeItem().Column(col =>
                {
                    if (logoBytes != null)
                        col.Item().Width(220).Image(logoBytes);
                    else
                        col.Item().Text("TICKETA").FontSize(28).Bold().FontColor("#212949");
                    col.Item().PaddingTop(4).Text("Bilet electronic").FontSize(11).FontColor(Colors.Grey.Medium);
                });
                row.ConstantItem(160).AlignRight().Column(col =>
                {
                    col.Item().AlignRight().Text("BILET").FontSize(20).Bold().FontColor("#E53935");
                    col.Item().AlignRight().Text(DateTime.Now.ToString("dd MMM yyyy")).FontSize(9).FontColor(Colors.Grey.Medium);
                });
            });
        }

        private static void ComposeEvent(IContainer container, BiletDinCos b)
        {
            container.Column(col =>
            {
                col.Item().Text(b.EvenimentNume).FontSize(22).Bold().FontColor("#212949");
                col.Item().LineHorizontal(2).LineColor("#E53935");
                col.Item().PaddingTop(8).Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Data eveniment").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text(b.EvenimentData?.ToString("dd MMM yyyy, HH:mm") ?? "-").FontSize(13).Bold();
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Locatie").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text(b.EvenimentLocatie ?? b.EvenimentOras ?? "-").FontSize(13).Bold();
                    });
                });
            });
        }

        private static void ComposeDetails(IContainer container, BiletDinCos b)
        {
            container.Background("#F6F6F6").Padding(15).Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Categorie bilet").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text(b.TipBilet).FontSize(12).Bold();
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Loc / Sectiune").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text(b.LocEveniment ?? "-").FontSize(12).Bold();
                    });
                });
                col.Item().PaddingTop(10).Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Cantitate").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text($"{b.Cantitate} bucati").FontSize(12).Bold();
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Pret unitar").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text($"{b.Pret:0.##} RON").FontSize(12).Bold();
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Total achitat").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text($"{b.PretTotal:0.##} RON").FontSize(15).Bold().FontColor("#059669");
                    });
                });
            });
        }

        private static void ComposeUser(IContainer container, BiletDinCos b, Utilizator user)
        {
            container.Column(col =>
            {
                col.Item().Text("Detinator bilet").FontSize(11).Bold().FontColor("#212949");
                col.Item().PaddingTop(5).Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Nume").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text(user.NumeComplet).FontSize(11).Bold();
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Email").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text(user.Email ?? "-").FontSize(11);
                    });
                });
                col.Item().PaddingTop(8).Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Numar comanda").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text($"#{b.IdCos}").FontSize(11).Bold();
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text("Data cumparare").FontSize(8).FontColor(Colors.Grey.Medium);
                        c.Item().Text(b.DataComanda?.ToString("dd MMM yyyy, HH:mm") ?? "-").FontSize(11).Bold();
                    });
                });
            });
        }
    }
}
