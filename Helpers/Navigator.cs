using System.Windows.Forms;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Permite navigarea intre UC-uri din interiorul altor UC-uri (ex: click pe un eveniment in Home).
    /// MainMenu se inregistreaza la Load; orice UC poate apela <see cref="Show"/> sau <see cref="Back"/>.
    /// </summary>
    public static class Navigator
    {
        private static Panel? _container;
        private static readonly Stack<UserControl> _history = new();

        public static void Register(Panel container) => _container = container;

        public static void Show(UserControl uc)
        {
            if (_container == null) throw new InvalidOperationException("Navigator nu a fost inregistrat. Apeleaza Register() din MainMenu_Load.");
            if (_container.Controls.Count > 0)
            {
                var prev = _container.Controls[0];
                if (prev is UserControl pu) _history.Push(pu);
            }
            _container.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            _container.Controls.Add(uc);
            uc.BringToFront();
        }

        public static bool CanGoBack => _history.Count > 0;

        public static void Back()
        {
            if (!CanGoBack || _container == null) return;
            var uc = _history.Pop();
            _container.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            _container.Controls.Add(uc);
            uc.BringToFront();
        }

        public static void Reset()
        {
            _history.Clear();
            _container?.Controls.Clear();
        }
    }
}
