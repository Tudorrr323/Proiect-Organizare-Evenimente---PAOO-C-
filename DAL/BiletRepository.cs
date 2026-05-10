using Npgsql;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    public class BiletRepository
    {
        public List<Bilet> GetForEvent(long idEvent)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT id_bilet, denumire, pret, loc_eveniment, description, id_event
                  FROM public.""Bilet"" WHERE id_event = @e ORDER BY pret;", conn);
            cmd.Parameters.AddWithValue("e", idEvent);

            using var r = cmd.ExecuteReader();
            var list = new List<Bilet>();
            while (r.Read())
            {
                list.Add(new Bilet(
                    idBilet:      r.GetInt64(0),
                    denumire:     r.GetString(1),
                    pret:         r.IsDBNull(2) ? null : r.GetDouble(2),
                    locEveniment: r.IsDBNull(3) ? null : r.GetString(3),
                    descriere:    r.IsDBNull(4) ? null : r.GetString(4),
                    idEvent:      r.GetInt64(5)));
            }
            return list;
        }

        public Bilet? GetById(long idBilet)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT id_bilet, denumire, pret, loc_eveniment, description, id_event
                  FROM public.""Bilet"" WHERE id_bilet = @id LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("id", idBilet);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) return null;
            return new Bilet(
                idBilet:      r.GetInt64(0),
                denumire:     r.GetString(1),
                pret:         r.IsDBNull(2) ? null : r.GetDouble(2),
                locEveniment: r.IsDBNull(3) ? null : r.GetString(3),
                descriere:    r.IsDBNull(4) ? null : r.GetString(4),
                idEvent:      r.GetInt64(5));
        }

        public long Insert(string denumire, double pret, string? loc, string? descriere, long idEvent)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO public.""Bilet"" (denumire, pret, loc_eveniment, description, id_event)
                  VALUES (@d, @p, @l, @des, @e) RETURNING id_bilet;", conn);
            cmd.Parameters.AddWithValue("d", denumire);
            cmd.Parameters.AddWithValue("p", pret);
            cmd.Parameters.AddWithValue("l", (object?)loc ?? DBNull.Value);
            cmd.Parameters.AddWithValue("des", (object?)descriere ?? DBNull.Value);
            cmd.Parameters.AddWithValue("e", idEvent);
            return (long)cmd.ExecuteScalar()!;
        }

        public void Update(long idBilet, string denumire, double pret, string? loc, string? descriere)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Bilet""
                  SET denumire = @d, pret = @p, loc_eveniment = @l, description = @des
                  WHERE id_bilet = @id;", conn);
            cmd.Parameters.AddWithValue("d", denumire);
            cmd.Parameters.AddWithValue("p", pret);
            cmd.Parameters.AddWithValue("l", (object?)loc ?? DBNull.Value);
            cmd.Parameters.AddWithValue("des", (object?)descriere ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id", idBilet);
            cmd.ExecuteNonQuery();
        }

        public void Delete(long idBilet)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"DELETE FROM public.""Bilet"" WHERE id_bilet = @id;", conn);
            cmd.Parameters.AddWithValue("id", idBilet);
            cmd.ExecuteNonQuery();
        }
    }
}
