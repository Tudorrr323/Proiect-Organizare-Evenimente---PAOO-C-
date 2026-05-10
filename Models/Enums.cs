namespace Proiect_PAOO_Organizare_Evenimente.Models
{
    public enum TipEveniment
    {
        Fizic,
        Virtual
    }

    public enum RolUtilizator
    {
        Client,
        Manager,
        Admin
    }

    public static class TipEvenimentExtensions
    {
        public static string ToDbString(this TipEveniment t) => t switch
        {
            TipEveniment.Fizic => "fizic",
            TipEveniment.Virtual => "virtual",
            _ => "fizic"
        };

        public static TipEveniment FromDbString(string? s) => s?.ToLowerInvariant() switch
        {
            "virtual" => TipEveniment.Virtual,
            _ => TipEveniment.Fizic
        };
    }

    public static class RolUtilizatorExtensions
    {
        public static string ToDbString(this RolUtilizator r) => r switch
        {
            RolUtilizator.Manager => "manager",
            RolUtilizator.Admin   => "admin",
            _                     => "user"
        };

        public static RolUtilizator FromDbString(string? s) => s?.ToLowerInvariant() switch
        {
            "manager" => RolUtilizator.Manager,
            "admin"   => RolUtilizator.Admin,
            _         => RolUtilizator.Client
        };
    }
}
