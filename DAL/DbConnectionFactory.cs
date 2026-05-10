using System.Configuration;
using Npgsql;

namespace Proiect_PAOO_Organizare_Evenimente.DAL
{
    /// <summary>
    /// Furnizor central de conexiuni Npgsql citite din App.config.
    /// </summary>
    public static class DbConnectionFactory
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["Ticketa"]?.ConnectionString
            ?? throw new InvalidOperationException("Connection string 'Ticketa' nu a fost gasit in App.config");

        public static NpgsqlConnection Open()
        {
            var conn = new NpgsqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
