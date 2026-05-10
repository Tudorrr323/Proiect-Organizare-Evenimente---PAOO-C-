using Npgsql;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    /// <summary>
    /// Auto-migrari de schema rulate la pornire. Idempotente (folosesc IF NOT EXISTS).
    /// </summary>
    public static class DbInit
    {
        public static void EnsureSchema()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"ALTER TABLE public.""Cos""
                  ADD COLUMN IF NOT EXISTS paid_at timestamp with time zone;", conn);
            cmd.ExecuteNonQuery();
        }
    }
}
