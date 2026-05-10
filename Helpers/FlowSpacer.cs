using System.Windows.Forms;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Helper pentru forta vizibilitatea ultimei linii in FlowLayoutPanel cu AutoScroll.
    /// AutoScrollMargin singur nu e suficient cand cardurile depasesc viewport-ul considerabil.
    /// </summary>
    public static class FlowSpacer
    {
        public static void AddBottomSpacer(FlowLayoutPanel flow, int height = 80)
        {
            var spacer = new Panel
            {
                Size = new Size(flow.ClientSize.Width - 30, height),
                Margin = new Padding(0),
                BackColor = flow.BackColor
            };
            flow.SetFlowBreak(spacer, true);
            flow.Controls.Add(spacer);
        }
    }
}
