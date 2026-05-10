using System.Globalization;

namespace Proiect_PAOO_Organizare_Evenimente.Helpers
{
    /// <summary>
    /// Parse helpers tolerate la separator zecimal: accepta atat "12.50" cat si "12,50"
    /// indiferent de cultura curenta (ro-RO foloseste virgula).
    /// </summary>
    public static class Parsing
    {
        public static bool TryParseDouble(string? input, out double value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(input)) return false;
            var normalized = input.Trim().Replace(',', '.');
            return double.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        public static bool TryParseInt(string? input, out int value)
        {
            value = 0;
            if (string.IsNullOrWhiteSpace(input)) return false;
            return int.TryParse(input.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out value);
        }
    }
}
