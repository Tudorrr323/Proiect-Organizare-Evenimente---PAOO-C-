using Npgsql;
using NpgsqlTypes;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    public class EvenimentRepository
    {
        private const string SelectColumns =
            @"id_event, name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user, is_suspended";

        // Filtru aplicat in toate query-urile pentru utilizatori non-admin
        private const string ActiveOnly = " AND is_suspended = false ";

        public List<Eveniment> GetUpcoming(int limit = 12)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Evenimente""
                   WHERE date >= NOW() {ActiveOnly}
                   ORDER BY date ASC LIMIT @lim;", conn);
            cmd.Parameters.AddWithValue("lim", limit);
            return ReadAll(cmd);
        }

        public Eveniment? GetById(long id)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Evenimente"" WHERE id_event = @id;", conn);
            cmd.Parameters.AddWithValue("id", id);
            var list = ReadAll(cmd);
            return list.Count == 0 ? null : list[0];
        }

        public List<Eveniment> Search(string? nume, string? organizator, string? oras, TipEveniment? tip,
                                       DateTime? dataMin = null, DateTime? dataMax = null)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Evenimente""
                   WHERE (@n::text IS NULL OR name      ILIKE '%' || @n || '%')
                     AND (@o::text IS NULL OR organiser ILIKE '%' || @o || '%')
                     AND (@c::text IS NULL OR city      ILIKE '%' || @c || '%')
                     AND (@t::text IS NULL OR type = @t)
                     AND (@dmin::timestamptz IS NULL OR date >= @dmin)
                     AND (@dmax::timestamptz IS NULL OR date <= @dmax)
                     {ActiveOnly}
                   ORDER BY date ASC;", conn);
            cmd.Parameters.Add("n", NpgsqlDbType.Text).Value = (object?)nume ?? DBNull.Value;
            cmd.Parameters.Add("o", NpgsqlDbType.Text).Value = (object?)organizator ?? DBNull.Value;
            cmd.Parameters.Add("c", NpgsqlDbType.Text).Value = (object?)oras ?? DBNull.Value;
            cmd.Parameters.Add("t", NpgsqlDbType.Text).Value = tip.HasValue ? (object)tip.Value.ToDbString() : DBNull.Value;
            cmd.Parameters.Add("dmin", NpgsqlDbType.TimestampTz).Value = (object?)dataMin ?? DBNull.Value;
            cmd.Parameters.Add("dmax", NpgsqlDbType.TimestampTz).Value = (object?)dataMax ?? DBNull.Value;
            return ReadAll(cmd);
        }

        public List<Eveniment> GetByOrganizator(long idUser)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Evenimente""
                   WHERE id_user = @u ORDER BY date DESC;", conn);
            cmd.Parameters.AddWithValue("u", idUser);
            return ReadAll(cmd);
        }

        public List<Eveniment> GetVirtual()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Evenimente""
                   WHERE type = 'virtual' {ActiveOnly}
                   ORDER BY date ASC;", conn);
            return ReadAll(cmd);
        }

        public List<string> GetOrganisers()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT DISTINCT organiser FROM public.""Evenimente""
                  WHERE organiser IS NOT NULL ORDER BY organiser;", conn);
            using var r = cmd.ExecuteReader();
            var list = new List<string>();
            while (r.Read()) list.Add(r.GetString(0));
            return list;
        }

        /// <summary>
        /// Listare TOATA fara filtru is_suspended. Folosit doar din Admin Dashboard.
        /// </summary>
        public List<Eveniment> GetAllForAdmin()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Evenimente"" ORDER BY id_event;", conn);
            return ReadAll(cmd);
        }

        public long Insert(Eveniment e)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO public.""Evenimente""
                  (name, description, location, date, organiser, imgpath, city, type, stoc_bilete, id_user)
                  VALUES (@n, @d, @l, @dt, @org, @img, @c, @t, @s, @u)
                  RETURNING id_event;", conn);
            cmd.Parameters.AddWithValue("n", e.Nume);
            cmd.Parameters.AddWithValue("d", (object?)e.Descriere ?? DBNull.Value);
            cmd.Parameters.AddWithValue("l", (object?)e.Locatie ?? DBNull.Value);
            cmd.Parameters.AddWithValue("dt", (object?)e.Data ?? DBNull.Value);
            cmd.Parameters.AddWithValue("org", (object?)e.Organizator ?? DBNull.Value);
            cmd.Parameters.AddWithValue("img", (object?)e.CaleImagine ?? DBNull.Value);
            cmd.Parameters.AddWithValue("c", (object?)e.Oras ?? DBNull.Value);
            cmd.Parameters.AddWithValue("t", e.Tip.ToDbString());
            cmd.Parameters.AddWithValue("s", (object?)e.StocBilete ?? DBNull.Value);
            cmd.Parameters.AddWithValue("u", (object?)e.IdUserOrganizator ?? DBNull.Value);
            return (long)cmd.ExecuteScalar()!;
        }

        public void Update(Eveniment e)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Evenimente""
                  SET name = @n, description = @d, location = @l, date = @dt,
                      organiser = @org, imgpath = @img, city = @c,
                      type = @t, stoc_bilete = @s
                  WHERE id_event = @id;", conn);
            cmd.Parameters.AddWithValue("n", e.Nume);
            cmd.Parameters.AddWithValue("d", (object?)e.Descriere ?? DBNull.Value);
            cmd.Parameters.AddWithValue("l", (object?)e.Locatie ?? DBNull.Value);
            cmd.Parameters.AddWithValue("dt", (object?)e.Data ?? DBNull.Value);
            cmd.Parameters.AddWithValue("org", (object?)e.Organizator ?? DBNull.Value);
            cmd.Parameters.AddWithValue("img", (object?)e.CaleImagine ?? DBNull.Value);
            cmd.Parameters.AddWithValue("c", (object?)e.Oras ?? DBNull.Value);
            cmd.Parameters.AddWithValue("t", e.Tip.ToDbString());
            cmd.Parameters.AddWithValue("s", (object?)e.StocBilete ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id", e.IdEvent);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Suspenda sau reactiveaza un eveniment. Folosit doar din Admin Dashboard.</summary>
        public void SetSuspended(long idEvent, bool suspended)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Evenimente"" SET is_suspended = @s WHERE id_event = @id;", conn);
            cmd.Parameters.AddWithValue("s", suspended);
            cmd.Parameters.AddWithValue("id", idEvent);
            cmd.ExecuteNonQuery();
        }

        public void Delete(long idEvent)
        {
            using var conn = DbConnectionFactory.Open();
            // Stergem intai biletele asociate (Cos_Bilet va ramane cu id_bilet orfan, dar LEFT JOIN scoate "?")
            using (var cmd1 = new NpgsqlCommand(
                @"DELETE FROM public.""Bilet"" WHERE id_event = @id;", conn))
            {
                cmd1.Parameters.AddWithValue("id", idEvent);
                cmd1.ExecuteNonQuery();
            }
            using (var cmd2 = new NpgsqlCommand(
                @"DELETE FROM public.""Evenimente"" WHERE id_event = @id;", conn))
            {
                cmd2.Parameters.AddWithValue("id", idEvent);
                cmd2.ExecuteNonQuery();
            }
        }

        // ---- mapping ----
        private static List<Eveniment> ReadAll(NpgsqlCommand cmd)
        {
            using var r = cmd.ExecuteReader();
            var list = new List<Eveniment>();
            while (r.Read()) list.Add(Map(r));
            return list;
        }

        private static Eveniment Map(NpgsqlDataReader r)
        {
            return new Eveniment(
                idEvent: r.GetInt64(0),
                nume:    r.GetString(1),
                descriere:   r.IsDBNull(2) ? null : r.GetString(2),
                locatie:     r.IsDBNull(3) ? null : r.GetString(3),
                data:        r.IsDBNull(4) ? null : r.GetDateTime(4),
                organizator: r.IsDBNull(5) ? null : r.GetString(5),
                caleImagine: r.IsDBNull(6) ? null : r.GetString(6),
                oras:        r.IsDBNull(7) ? null : r.GetString(7),
                tip:         TipEvenimentExtensions.FromDbString(r.IsDBNull(8) ? null : r.GetString(8)),
                stocBilete:  r.IsDBNull(9) ? null : r.GetFieldValue<decimal>(9),
                idUserOrganizator: r.IsDBNull(10) ? null : r.GetInt64(10),
                esteSuspendat: !r.IsDBNull(11) && r.GetBoolean(11));
        }
    }
}
