using System;
using capaEntidad;
using System.Windows.Forms;

namespace capaNegocio
{
    public class CNCliente
    {
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

            return Resultado;
        }
    }
}
