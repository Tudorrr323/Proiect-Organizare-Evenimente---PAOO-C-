using System.Globalization;
using Proiect_PAOO_Organizare_Evenimente.DAL;

namespace Proiect_PAOO_Organizare_Evenimente
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Permite DateTime cu Kind=Unspecified pentru timestamptz (DateTimePicker returneaza
            // DateTime fara timezone). Acest switch trebuie setat INAINTE de orice conexiune Npgsql.
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Setam cultura RO global - toate ToString fara culture explicit folosesc luni RO
            // ("ian", "feb", "mar"...). Parsare numere - folosim Helpers.Parsing.TryParseDouble
            // care accepta atat "." cat si "," ca separator zecimal.
            var ro = new CultureInfo("ro-RO");
            CultureInfo.DefaultThreadCurrentCulture = ro;
            CultureInfo.DefaultThreadCurrentUICulture = ro;
            Thread.CurrentThread.CurrentCulture = ro;
            Thread.CurrentThread.CurrentUICulture = ro;

            ApplicationConfiguration.Initialize();

            // Auto-migrari de schema (idempotente). Adauga coloane noi daca lipsesc.
            try
            {
                DbInit.EnsureSchema();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nu am putut conecta la baza de date sau aplica migrarile schema.\n\n" + ex.Message,
                    "Eroare DB",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Form1());
        }
    }
}
