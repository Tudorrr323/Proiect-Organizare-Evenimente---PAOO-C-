using System.Windows.Forms;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Helper pentru swap UserControl in panel central.
    /// Pattern preluat din proiectul model McLaughingHospital.
    /// </summary>
    public class ManageUC
    {
        public void DisplayControl(Control uc, Panel pnl)
        {
            pnl.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnl.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
