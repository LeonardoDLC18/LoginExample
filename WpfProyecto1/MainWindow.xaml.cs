using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfProyecto1.Clases;

namespace WpfProyecto1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Conexion conexion;
        public MainWindow()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contra = txtContraseña.Text;

            // Abrir una conexión utilizando la clase de conexión
            using (MySqlConnection connection = conexion.Conectar())
            {
                // Verificar que la conexión no sea nula
                if (connection != null)
                {
                    // Ejemplo de consulta SELECT
                    string consultaSql = $"SELECT * FROM Usuarios WHERE usuario= '{usuario}' AND contra='{contra}'";

                    // Crear un comando SQL utilizando la consulta y la conexión
                    using (MySqlCommand command = new MySqlCommand(consultaSql, connection))
                    {
                        // Ejecutar la consulta y obtener un lector de datos
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Se inició SESION");
                            }
                            else
                            {
                                MessageBox.Show("NO se inició SESION");
                            }
                        }
                    }
                }
            }

            // Desconectar al salir del bloque using para liberar recursos
            conexion.Desconectar();
        }
    }
}
