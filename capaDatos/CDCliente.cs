using System;
using MySql.Data.MySqlClient;
using capaEntidad;
using System.Windows.Forms;
using System.Data;

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
            mySqlConnection.Close();
            MessageBox.Show("Conectado");
        }

        public void Crear(CECliente cliente )
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            //string Query = "INSERT INTO `clientes` (`Id`, `Nombre`, `Apellido`, `Foto`) VALUES ('" + cliente.Id + "', '" + cliente.Nombre + "', '" + cliente.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cliente.Foto) + "')";
            string Query = "INSERT INTO `clientes` (`Nombre`, `Apellido`, `Foto`) VALUES ('" + cliente.Nombre + "', '" + cliente.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cliente.Foto) + "')";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Creado ");
        }

        public void Editar(CECliente cliente)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            //string Query = "INSERT INTO `clientes` (`Id`, `Nombre`, `Apellido`, `Foto`) VALUES ('" + cliente.Id + "', '" + cliente.Nombre + "', '" + cliente.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cliente.Foto) + "')";
            string Query = "UPDATE `clientes` SET `Nombre` = '" + cliente.Nombre + "', `Apellido` = '" + cliente.Apellido + "', `Foto` = '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cliente.Foto) + "' WHERE `Id` = " + cliente.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Actualizado ");
        }

        public void Eliminar(CECliente cliente)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            //string Query = "INSERT INTO `clientes` (`Id`, `Nombre`, `Apellido`, `Foto`) VALUES ('" + cliente.Id + "', '" + cliente.Nombre + "', '" + cliente.Apellido + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cliente.Foto) + "')";
            string Query = "DELETE FROM clientes WHERE `Id` = " + cliente.Id + ";";
            MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Eliminado ");
        }
        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `clientes`LIMIT 1000;";
            MySqlDataAdapter adapter;
            DataSet dataSet = new DataSet();

            adapter = new MySqlDataAdapter(Query, mySqlConnection);
            adapter.Fill(dataSet, "tbl");

            return dataSet;
        }
    }
}
