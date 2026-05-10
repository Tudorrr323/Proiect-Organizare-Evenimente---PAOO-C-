using Npgsql;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    public class UserRepository
    {
        private const string SelectColumns =
            @"id_user, fname, lname, email, password, phone_number, bday, role, company, creation_date, is_suspended";

        public Utilizator? GetByEmail(string email)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Users"" WHERE email = @e LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("e", email);

            using var r = cmd.ExecuteReader();
            return r.Read() ? Map(r) : null;
        }

        public Utilizator? GetById(long idUser)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Users"" WHERE id_user = @id LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("id", idUser);

            using var r = cmd.ExecuteReader();
            return r.Read() ? Map(r) : null;
        }

        /// <summary>Listare completa pentru Admin Dashboard.</summary>
        public List<Utilizator> GetAll()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                $@"SELECT {SelectColumns} FROM public.""Users"" ORDER BY id_user;", conn);
            using var r = cmd.ExecuteReader();
            var list = new List<Utilizator>();
            while (r.Read()) list.Add(Map(r));
            return list;
        }

        public long Insert(string prenume, string? nume, string email, string parolaHash,
                           string? telefon, DateTime? bday, RolUtilizator rol, string? companie)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO public.""Users"" (fname, lname, email, password, phone_number, bday, role, company, creation_date)
                  VALUES (@f, @l, @e, @p, @ph, @b, @r, @c, NOW())
                  RETURNING id_user;", conn);
            cmd.Parameters.AddWithValue("f", prenume);
            cmd.Parameters.AddWithValue("l", (object?)nume ?? DBNull.Value);
            cmd.Parameters.AddWithValue("e", email);
            cmd.Parameters.AddWithValue("p", parolaHash);
            cmd.Parameters.AddWithValue("ph", (object?)telefon ?? DBNull.Value);
            cmd.Parameters.AddWithValue("b", (object?)bday ?? DBNull.Value);
            cmd.Parameters.AddWithValue("r", rol.ToDbString());
            cmd.Parameters.AddWithValue("c", (object?)companie ?? DBNull.Value);

            return (long)cmd.ExecuteScalar()!;
        }

        public void UpdateParola(long idUser, string parolaHash)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Users"" SET password = @p WHERE id_user = @id;", conn);
            cmd.Parameters.AddWithValue("p", parolaHash);
            cmd.Parameters.AddWithValue("id", idUser);
            cmd.ExecuteNonQuery();
        }

        public void UpdateProfil(long idUser, string prenume, string? nume, string email,
                                  string? telefon, DateTime? bday, string? companie)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Users""
                  SET fname = @f, lname = @l, email = @e, phone_number = @ph, bday = @b, company = @c
                  WHERE id_user = @id;", conn);
            cmd.Parameters.AddWithValue("f", prenume);
            cmd.Parameters.AddWithValue("l", (object?)nume ?? DBNull.Value);
            cmd.Parameters.AddWithValue("e", email);
            cmd.Parameters.AddWithValue("ph", (object?)telefon ?? DBNull.Value);
            cmd.Parameters.AddWithValue("b", (object?)bday ?? DBNull.Value);
            cmd.Parameters.AddWithValue("c", (object?)companie ?? DBNull.Value);
            cmd.Parameters.AddWithValue("id", idUser);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Schimba rolul (admin/manager/user). Folosit doar din Admin Dashboard.</summary>
        public void UpdateRol(long idUser, RolUtilizator rol)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Users"" SET role = @r WHERE id_user = @id;", conn);
            cmd.Parameters.AddWithValue("r", rol.ToDbString());
            cmd.Parameters.AddWithValue("id", idUser);
            cmd.ExecuteNonQuery();
        }

        /// <summary>Suspenda sau reactiveaza un cont. Folosit doar din Admin Dashboard.</summary>
        public void SetSuspended(long idUser, bool suspended)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"UPDATE public.""Users"" SET is_suspended = @s WHERE id_user = @id;", conn);
            cmd.Parameters.AddWithValue("s", suspended);
            cmd.Parameters.AddWithValue("id", idUser);
            cmd.ExecuteNonQuery();
        }

        public bool EmailExists(string email)
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT 1 FROM public.""Users"" WHERE email = @e LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("e", email);
            return cmd.ExecuteScalar() != null;
        }

        // ---- mapping ----
        private static Utilizator Map(NpgsqlDataReader r)
        {
            long id = r.GetInt64(0);
            string fname = r.GetString(1);
            string? lname = r.IsDBNull(2) ? null : r.GetString(2);
            string? email = r.IsDBNull(3) ? null : r.GetString(3);
            string? parola = r.IsDBNull(4) ? null : r.GetString(4);
            string? phone = r.IsDBNull(5) ? null : r.GetString(5);
            DateTime? bday = r.IsDBNull(6) ? null : r.GetDateTime(6);
            string? rol = r.IsDBNull(7) ? null : r.GetString(7);
            string? company = r.IsDBNull(8) ? null : r.GetString(8);
            DateTime? created = r.IsDBNull(9) ? null : r.GetDateTime(9);
            bool suspended = !r.IsDBNull(10) && r.GetBoolean(10);

            Utilizator u = RolUtilizatorExtensions.FromDbString(rol) switch
            {
                RolUtilizator.Admin   => new Admin(id, fname, lname, email, phone, bday, parola, created),
                RolUtilizator.Manager => new Manager(id, fname, lname, email, phone, bday, parola, created, company),
                _                     => new Client(id, fname, lname, email, phone, bday, parola, created),
            };
            u.EsteSuspendat = suspended;
            return u;
        }
    }
}
