using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frClientes : Form
    {

        CNCliente CNCliente = new CNCliente();

        public frClientes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtId.Value = 0;
            picFoto.Image = null;
        }

        private void lnkSeleccionar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ofdFoto.FileName = string.Empty;
            
            if (ofdFoto.ShowDialog()==DialogResult.OK)
            {
                picFoto.Load(ofdFoto.FileName);
            }
            ofdFoto.FileName = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CECliente cECliente = new CECliente();
            cECliente.Id = (int)txtId.Value;
            cECliente.Nombre = txtNombre.Text; 
            cECliente.Apellido = txtApellido.Text;
            cECliente.Foto = picFoto.ImageLocation; ;

            CNCliente.ValidarDatos(cECliente);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void frClientes_Load(object sender, EventArgs e)
        {

        }
    }
}
