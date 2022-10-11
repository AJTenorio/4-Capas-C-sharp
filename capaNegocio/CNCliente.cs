using System;
using capaEntidad;
using System.Windows.Forms;
using capaDatos;

namespace capaNegocio
{
    public class CNCliente
    {
        CDCliente CDCliente = new CDCliente();
        public bool ValidarDatos(CECliente cECliente)
        {
            bool Resultado = true;
            if (cECliente.Nombre == string.Empty)
            {
                MessageBox.Show("El nombre es Obligatorio");
            }

            if (cECliente.Apellido == string.Empty)
            {
                MessageBox.Show("El apellido es Obligatorio");
            }

            if (cECliente.Foto == null)
            {
                Resultado = false;
                MessageBox.Show("La foto es Obligatoria");
            }

            return Resultado;
        }
        public void pruebaMySql()
        {
            CDCliente.PruebaConexion();
        }
    }
}
