using Npgsql;
using Proiect_PAOO_Organizare_Evenimente.Models;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    public class OrasRepository
    {
        public List<Oras> GetAll()
        {
            using var conn = DbConnectionFactory.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT id_oras, nume FROM public.""Orase"" ORDER BY nume;", conn);

            using var r = cmd.ExecuteReader();
            var list = new List<Oras>();
            while (r.Read()) list.Add(new Oras(r.GetInt64(0), r.GetString(1)));
            return list;
        }
    }
}
