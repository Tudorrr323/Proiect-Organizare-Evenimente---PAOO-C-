using System.Drawing.Imaging;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Incarca logo-ul aplicatiei din folderul Images, cu optiunea de a recolora pixelii inchisi
    /// (text negru) in alb pentru a fi vizibil pe fundalul navy al sidebar-ului.
    /// </summary>
    public static class LogoLoader
    {
        public static Image? Load(string fileName, bool darkToWhite)
        {
            var path = ImageStorage.PathFor(fileName);
            if (path == null || !System.IO.File.Exists(path)) return null;

            using var src = (Bitmap)Image.FromFile(path);
            if (!darkToWhite)
                return new Bitmap(src);  // copie ca sa nu blocam fisierul

            return RecolorDarkToWhite(src);
        }

        // Iteram pixelii cu LockBits (rapid) si transformam pixelii ne-transparenti si inchisi in alb
        private static Bitmap RecolorDarkToWhite(Bitmap src)
        {
            var dst = new Bitmap(src.Width, src.Height, PixelFormat.Format32bppArgb);

            var srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            var dstData = dst.LockBits(new Rectangle(0, 0, dst.Width, dst.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            int byteCount = srcData.Stride * src.Height;
            byte[] buffer = new byte[byteCount];
            System.Runtime.InteropServices.Marshal.Copy(srcData.Scan0, buffer, 0, byteCount);

            // Format BGRA: [B, G, R, A]
            for (int i = 0; i < byteCount; i += 4)
            {
                byte b = buffer[i];
                byte g = buffer[i + 1];
                byte r = buffer[i + 2];
                byte a = buffer[i + 3];

                if (a == 0) continue;                    // pixel transparent - skip

                int sum = r + g + b;
                if (sum < 320)                            // pixel inchis (negru, gri inchis) -> alb
                {
                    buffer[i]     = 255;
                    buffer[i + 1] = 255;
                    buffer[i + 2] = 255;
                    // alpha pastrat
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, dstData.Scan0, byteCount);
            src.UnlockBits(srcData);
            dst.UnlockBits(dstData);
            return dst;
        }
    }
}
