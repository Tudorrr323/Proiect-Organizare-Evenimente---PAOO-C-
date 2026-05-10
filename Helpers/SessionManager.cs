using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Inlocuieste localStorage din Retool. Static, viu pe durata aplicatiei.
    /// </summary>
    public static class SessionManager
    {
        public static Utilizator? UtilizatorCurent { get; private set; }
        public static long? IdCosActiv { get; set; }   // pentru flow-ul de cumparare bilete

        public static bool EsteAutentificat => UtilizatorCurent != null;
        public static bool EsteManager => UtilizatorCurent is Manager;
        public static bool EsteAdmin   => UtilizatorCurent is Admin;

        public static void Login(Utilizator u)
        {
            UtilizatorCurent = u;
            IdCosActiv = null;
        }

        public static void Logout()
        {
            UtilizatorCurent = null;
            IdCosActiv = null;
        }
    }
}
