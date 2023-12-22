using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WpfProyecto1.Clases
{
    public class Conexion
    {

        private readonly string nombreDB = "logeodb";
        private readonly string usuarioDB = "bbdad0w85pf32sdb36g4";
        private readonly string contraDB = "pscale_pw_6fEQAq0cqRR2UaNSUAAGip6R8gfMzUkARiZTvb3ngwN";
        private readonly string server = "aws.connect.psdb.cloud";
        private readonly string sslMode = "VerifyFull"; // Cambiar según la configuración de la base de datos
        private readonly string connectionString;

        private MySqlConnection cx;

        public Conexion()
        {
            connectionString = $"Server={server};Database={nombreDB};" +
                $"User ID={usuarioDB};Password={contraDB};SslMode={sslMode}";
        }

        public MySqlConnection Conectar()
        {
            try
            {
                cx = new MySqlConnection(connectionString);
                cx.Open();
                Console.WriteLine("Se conectó");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se conectó");
                Console.WriteLine(ex.Message);
            }
            return cx;
        }

        public void Desconectar()
        {
            try
            {
                cx.Close();
                Console.WriteLine("Se desconectó");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
