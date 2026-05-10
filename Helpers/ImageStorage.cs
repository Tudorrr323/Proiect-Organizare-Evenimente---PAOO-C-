using System.Configuration;
using System.IO;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Gestioneaza folderul de imagini al evenimentelor (inlocuieste Supabase Storage).
    /// Salvam doar numele fisierului in DB; folderul absolut este rezolvat aici.
    /// </summary>
    public static class ImageStorage
    {
        private static readonly string _folderRelativ =
            ConfigurationManager.AppSettings["ImagesFolder"] ?? "Images";

        /// <summary>Calea absoluta a folderului Images (langa executabil).</summary>
        public static string Folder
        {
            get
            {
                var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _folderRelativ);
                Directory.CreateDirectory(dir);
                return dir;
            }
        }

        /// <summary>Cale absoluta catre o imagine. null daca <paramref name="fileName"/> e gol.</summary>
        public static string? PathFor(string? fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;
            return Path.Combine(Folder, fileName);
        }

        /// <summary>True daca fisierul exista efectiv pe disc.</summary>
        public static bool Exists(string? fileName)
        {
            var p = PathFor(fileName);
            return p != null && File.Exists(p);
        }

        /// <summary>
        /// Copiaza un fisier sursa in folderul Images si intoarce noul nume (cu extensie).
        /// Genereaza nume unic daca exista deja.
        /// </summary>
        public static string Save(string sourcePath)
        {
            var name = Path.GetFileName(sourcePath);
            var dest = Path.Combine(Folder, name);
            int i = 1;
            while (File.Exists(dest))
            {
                var noExt = Path.GetFileNameWithoutExtension(name);
                var ext = Path.GetExtension(name);
                dest = Path.Combine(Folder, $"{noExt}_{i}{ext}");
                i++;
            }
            File.Copy(sourcePath, dest, false);
            return Path.GetFileName(dest);
        }
    }
}
