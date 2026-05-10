using Npgsql;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    /// <summary>
    /// Query-uri de statistici pentru Admin Dashboard (charts).
    /// </summary>
    public class AdminStatsRepository
    {
        public record StatRow(string Label, double Value);

        /// <summary>Numar de evenimente pe tip (fizic vs virtual), exclude suspendate.</summary>
        public List<StatRow> EvenimentePeTip()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT COALESCE(type,'?') AS t, COUNT(*) FROM public.""Evenimente""
                  WHERE is_suspended = false
                  GROUP BY type ORDER BY t;", conn);
            using var r = cmd.ExecuteReader();
            var list = new List<StatRow>();
            while (r.Read()) list.Add(new StatRow(r.GetString(0), r.GetInt64(1)));
            return list;
        }

        /// <summary>Numar de utilizatori pe rol (user/manager/admin), include suspendati.</summary>
        public List<StatRow> UtilizatoriPeRol()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT COALESCE(role,'user') AS r, COUNT(*) FROM public.""Users""
                  GROUP BY role ORDER BY r;", conn);
            using var r2 = cmd.ExecuteReader();
            var list = new List<StatRow>();
            while (r2.Read()) list.Add(new StatRow(r2.GetString(0), r2.GetInt64(1)));
            return list;
        }

        /// <summary>Top 5 evenimente dupa numarul de bilete vandute (din comenzi platite).</summary>
        public List<StatRow> Top5EvenimenteDupaBilete()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT e.name, SUM(cb.cantitate)::bigint AS bilete_vandute
                  FROM public.""Cos_Bilet"" cb
                  JOIN public.""Bilet"" b ON b.id_bilet = cb.id_bilet
                  JOIN public.""Evenimente"" e ON e.id_event = b.id_event
                  JOIN public.""Cos"" c ON c.id_cos = cb.id_cos
                  WHERE c.""isBought"" = true
                  GROUP BY e.id_event, e.name
                  ORDER BY bilete_vandute DESC NULLS LAST
                  LIMIT 5;", conn);
            using var r = cmd.ExecuteReader();
            var list = new List<StatRow>();
            while (r.Read()) list.Add(new StatRow(r.GetString(0), r.IsDBNull(1) ? 0 : r.GetInt64(1)));
            return list;
        }

        /// <summary>Total venit per luna (ultimele 6 luni) din comenzi platite.</summary>
        public List<StatRow> VenitPeLuna()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT TO_CHAR(date_trunc('month', COALESCE(c.paid_at, c.created_at)), 'YYYY-MM') AS luna,
                         COALESCE(SUM(c.pret),0) AS venit
                  FROM public.""Cos"" c
                  WHERE c.""isBought"" = true
                    AND COALESCE(c.paid_at, c.created_at) >= NOW() - INTERVAL '6 months'
                  GROUP BY luna
                  ORDER BY luna;", conn);
            using var r = cmd.ExecuteReader();
            var list = new List<StatRow>();
            while (r.Read()) list.Add(new StatRow(r.GetString(0), r.IsDBNull(1) ? 0 : (double)r.GetDouble(1)));
            return list;
        }

        public record DashboardKpi(int TotalUseri, int UseriSuspendati,
                                    int TotalEvenimente, int EvenimenteSuspendate,
                                    long BileteVandute, double VenitTotal);

        /// <summary>KPI-uri pentru cartonase header.</summary>
        public DashboardKpi GetKpi()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT
                    (SELECT COUNT(*) FROM public.""Users"")::int                    AS total_users,
                    (SELECT COUNT(*) FROM public.""Users"" WHERE is_suspended)::int AS users_susp,
                    (SELECT COUNT(*) FROM public.""Evenimente"")::int               AS total_events,
                    (SELECT COUNT(*) FROM public.""Evenimente"" WHERE is_suspended)::int AS events_susp,
                    (SELECT COALESCE(SUM(cb.cantitate),0) FROM public.""Cos_Bilet"" cb
                     JOIN public.""Cos"" c ON c.id_cos = cb.id_cos WHERE c.""isBought"" = true)::bigint AS bilete,
                    (SELECT COALESCE(SUM(pret),0) FROM public.""Cos"" WHERE ""isBought"" = true)::float8 AS venit;",
                conn);
            using var r = cmd.ExecuteReader();
            r.Read();
            return new DashboardKpi(
                TotalUseri:           r.GetInt32(0),
                UseriSuspendati:      r.GetInt32(1),
                TotalEvenimente:      r.GetInt32(2),
                EvenimenteSuspendate: r.GetInt32(3),
                BileteVandute:        r.GetInt64(4),
                VenitTotal:           r.GetDouble(5));
        }
    }
}
