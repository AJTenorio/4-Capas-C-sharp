using System;
using MySql.Data.MySqlClient;
using capaEntidad;
using System.Windows.Forms;

namespace capaDatos
{
    public class CDCliente
    {
        string CadenaConexion = "Server=localhost;User=root;Password=123456;Port=3306;database=4capas_c_sharp";

        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            try
            {
                mySqlConnection.Open();
            }
            catch(Exception ex) {
                MessageBox.Show("Error al conectarse" + ex.Message);
            }
            MessageBox.Show("Conectado");
        }
    }
}
