using Npgsql;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    public class CosRepository
    {
        public Cos? GetActive(long idUser)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT id_cos, ""isBought"", cantitate, pret, created_at, id_user
                  FROM public.""Cos""
                  WHERE id_user = @u AND ""isBought"" = false
                  ORDER BY created_at DESC LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("u", idUser);

            using var r = cmd.ExecuteReader();
            return r.Read() ? Map(r) : null;
        }

        public Cos GetById(long idCos)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT id_cos, ""isBought"", cantitate, pret, created_at, id_user
                  FROM public.""Cos"" WHERE id_cos = @id;", conn);
            cmd.Parameters.AddWithValue("id", idCos);

            using var r = cmd.ExecuteReader();
            if (!r.Read()) throw new InvalidOperationException($"Cosul {idCos} nu exista");
            return Map(r);
        }

        public List<Cos> GetMyOrders(long idUser)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT id_cos, ""isBought"", cantitate, pret, created_at, id_user
                  FROM public.""Cos""
                  WHERE id_user = @u AND ""isBought"" = true
                  ORDER BY created_at DESC;", conn);
            cmd.Parameters.AddWithValue("u", idUser);

            using var r = cmd.ExecuteReader();
            var list = new List<Cos>();
            while (r.Read()) list.Add(Map(r));
            return list;
        }

        public long CreateNew(long idUser)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO public.""Cos"" (""isBought"", cantitate, pret, created_at, id_user)
                  VALUES (false, 0, 0, NOW(), @u) RETURNING id_cos;", conn);
            cmd.Parameters.AddWithValue("u", idUser);
            return (long)cmd.ExecuteScalar()!;
        }

        public void UpdateTotaluri(long idCos, long cantitate, double pret)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Cos"" SET cantitate = @c, pret = @p WHERE id_cos = @id;", conn);
            cmd.Parameters.AddWithValue("c", cantitate);
            cmd.Parameters.AddWithValue("p", pret);
            cmd.Parameters.AddWithValue("id", idCos);
            cmd.ExecuteNonQuery();
        }

        public void MarkPaid(long idCos)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Cos"" SET ""isBought"" = true, paid_at = NOW() WHERE id_cos = @id;", conn);
            cmd.Parameters.AddWithValue("id", idCos);
            cmd.ExecuteNonQuery();
        }

        // ---- Cos_Bilet ----
        public List<CosBilet> GetItems(long idCos)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT id_cos_bilet, id_cos, id_bilet, cantitate, pret, pret_total
                  FROM public.""Cos_Bilet"" WHERE id_cos = @c;", conn);
            cmd.Parameters.AddWithValue("c", idCos);

            using var r = cmd.ExecuteReader();
            var list = new List<CosBilet>();
            while (r.Read())
            {
                list.Add(new CosBilet(
                    idCosBilet: r.GetInt64(0),
                    idCos:      r.GetInt64(1),
                    idBilet:    r.IsDBNull(2) ? null : r.GetInt64(2),
                    cantitate:  r.IsDBNull(3) ? null : r.GetInt64(3),
                    pret:       r.IsDBNull(4) ? null : r.GetDouble(4),
                    pretTotal:  r.IsDBNull(5) ? null : r.GetDouble(5)));
            }
            return list;
        }

        public long InsertItem(long idCos, long idBilet, long cantitate, double pret)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO public.""Cos_Bilet"" (id_cos, id_bilet, cantitate, pret, pret_total)
                  VALUES (@c, @b, @cant, @p, @pt) RETURNING id_cos_bilet;", conn);
            cmd.Parameters.AddWithValue("c", idCos);
            cmd.Parameters.AddWithValue("b", idBilet);
            cmd.Parameters.AddWithValue("cant", cantitate);
            cmd.Parameters.AddWithValue("p", pret);
            cmd.Parameters.AddWithValue("pt", pret * cantitate);
            return (long)cmd.ExecuteScalar()!;
        }

        public void DeleteItem(long idCosBilet)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"DELETE FROM public.""Cos_Bilet"" WHERE id_cos_bilet = @id;", conn);
            cmd.Parameters.AddWithValue("id", idCosBilet);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Toate biletele cumparate (din comenzile platite) ale unui utilizator, cu detalii eveniment + data comanda.
        /// Pentru UCMyTickets - afisare flat istoric.
        /// </summary>
        public List<BiletDinCos> GetIstoricBileteFlat(long idUser)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT cb.id_cos_bilet, cb.id_cos, cb.id_bilet,
                         b.denumire, b.loc_eveniment,
                         cb.cantitate, cb.pret, cb.pret_total,
                         e.name, e.date, e.location, e.city,
                         COALESCE(c.paid_at, c.created_at) AS data_comanda,
                         e.imgpath
                  FROM public.""Cos"" c
                  JOIN public.""Cos_Bilet"" cb ON cb.id_cos = c.id_cos
                  LEFT JOIN public.""Bilet"" b ON b.id_bilet = cb.id_bilet
                  LEFT JOIN public.""Evenimente"" e ON e.id_event = b.id_event
                  WHERE c.id_user = @u AND c.""isBought"" = true
                  ORDER BY COALESCE(c.paid_at, c.created_at) DESC, cb.id_cos_bilet;", conn);
            cmd.Parameters.AddWithValue("u", idUser);

            using var r = cmd.ExecuteReader();
            var list = new List<BiletDinCos>();
            while (r.Read())
            {
                list.Add(new BiletDinCos(
                    idCosBilet:       r.GetInt64(0),
                    idCos:            r.GetInt64(1),
                    idBilet:          r.IsDBNull(2) ? 0 : r.GetInt64(2),
                    tipBilet:         r.IsDBNull(3) ? "?" : r.GetString(3),
                    locEveniment:     r.IsDBNull(4) ? "" : r.GetString(4),
                    cantitate:        r.IsDBNull(5) ? 0 : r.GetInt64(5),
                    pret:             r.IsDBNull(6) ? 0 : r.GetDouble(6),
                    pretTotal:        r.IsDBNull(7) ? 0 : r.GetDouble(7),
                    evenimentNume:    r.IsDBNull(8) ? "?" : r.GetString(8),
                    evenimentData:    r.IsDBNull(9) ? null : r.GetDateTime(9),
                    evenimentLocatie: r.IsDBNull(10) ? null : r.GetString(10),
                    evenimentOras:    r.IsDBNull(11) ? null : r.GetString(11),
                    dataComanda:      r.IsDBNull(12) ? null : r.GetDateTime(12),
                    evenimentImgPath: r.IsDBNull(13) ? null : r.GetString(13)));
            }
            return list;
        }

        /// <summary>
        /// Itemii unui cos cu detalii eveniment + bilet (JOIN). Pentru afisare in UCCart / UCComandaDetalii.
        /// </summary>
        public List<BiletDinCos> GetItemsCuDetalii(long idCos)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT cb.id_cos_bilet, cb.id_cos, cb.id_bilet,
                         b.denumire, b.loc_eveniment,
                         cb.cantitate, cb.pret, cb.pret_total,
                         e.name, e.date, e.location, e.city, e.imgpath,
                         COALESCE(c.paid_at, c.created_at) AS data_comanda
                  FROM public.""Cos_Bilet"" cb
                  LEFT JOIN public.""Bilet"" b ON b.id_bilet = cb.id_bilet
                  LEFT JOIN public.""Evenimente"" e ON e.id_event = b.id_event
                  LEFT JOIN public.""Cos"" c ON c.id_cos = cb.id_cos
                  WHERE cb.id_cos = @c
                  ORDER BY cb.id_cos_bilet;", conn);
            cmd.Parameters.AddWithValue("c", idCos);

            using var r = cmd.ExecuteReader();
            var list = new List<BiletDinCos>();
            while (r.Read())
            {
                list.Add(new BiletDinCos(
                    idCosBilet:       r.GetInt64(0),
                    idCos:            r.GetInt64(1),
                    idBilet:          r.IsDBNull(2) ? 0 : r.GetInt64(2),
                    tipBilet:         r.IsDBNull(3) ? "?" : r.GetString(3),
                    locEveniment:     r.IsDBNull(4) ? "" : r.GetString(4),
                    cantitate:        r.IsDBNull(5) ? 0 : r.GetInt64(5),
                    pret:             r.IsDBNull(6) ? 0 : r.GetDouble(6),
                    pretTotal:        r.IsDBNull(7) ? 0 : r.GetDouble(7),
                    evenimentNume:    r.IsDBNull(8) ? "?" : r.GetString(8),
                    evenimentData:    r.IsDBNull(9) ? null : r.GetDateTime(9),
                    evenimentLocatie: r.IsDBNull(10) ? null : r.GetString(10),
                    evenimentOras:    r.IsDBNull(11) ? null : r.GetString(11),
                    dataComanda:      r.IsDBNull(13) ? null : r.GetDateTime(13),
                    evenimentImgPath: r.IsDBNull(12) ? null : r.GetString(12)));
            }
            return list;
        }

        // ---- mapping ----
        private static Cos Map(NpgsqlDataReader r) => new(
            idCos:        r.GetInt64(0),
            esteCumparat: r.GetBoolean(1),
            cantitate:    r.IsDBNull(2) ? null : r.GetInt64(2),
            pret:         r.IsDBNull(3) ? null : r.GetDouble(3),
            creatLa:      r.IsDBNull(4) ? null : r.GetDateTime(4),
            idUser:       r.IsDBNull(5) ? null : r.GetInt64(5));
    }
}
