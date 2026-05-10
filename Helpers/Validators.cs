using System.Text.RegularExpressions;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    public static class Validators
    {
        // Pattern din proiectul model McLaughingHospital (UCEmployees.cs)
        private static readonly Regex EmailRegex = new(
            @"^[a-zA-Z][\w\.\-]{1,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.\-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$",
            RegexOptions.Compiled);

        public static bool IsEmail(string? s)
            => !string.IsNullOrWhiteSpace(s) && EmailRegex.IsMatch(s);

        public static bool IsTelefon(string? s)
            => !string.IsNullOrWhiteSpace(s) && Regex.IsMatch(s, @"^\+?[\d\s\-]{7,20}$");

        public static bool IsParolaValida(string? s, int minLen = 4)
            => !string.IsNullOrEmpty(s) && s.Length >= minLen;
    }
}
