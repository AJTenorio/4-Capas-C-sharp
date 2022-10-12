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
            LimpiarPantalla();
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
            bool Resultado;
            CECliente cECliente = new CECliente();
            cECliente.Id = (int)txtId.Value;
            cECliente.Nombre = txtNombre.Text; 
            cECliente.Apellido = txtApellido.Text;
            cECliente.Foto = picFoto.ImageLocation; ;

            Resultado = CNCliente.ValidarDatos(cECliente);
            if (Resultado == false)
            {
                return;
            }
            if(cECliente.Id == 0)
            {
                CNCliente.CrearCliente(cECliente);
            }
            else
            {
                CNCliente.EditarCliente(cECliente);
            }
            CargarDatos();
            LimpiarPantalla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0) return;
            if (MessageBox.Show("Deseas eliminar el registro?","Titulo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CECliente cE = new CECliente();
                cE.Id = (int)txtId.Value;
                CNCliente.EliminarCliente(cE);
                CargarDatos();
                LimpiarPantalla();
            }
        }

        private void frClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            gridDatos.DataSource = CNCliente.ObtenerDatos().Tables["tbl"];
        }

        private void LimpiarPantalla()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtId.Value = 0;
            picFoto.Image = null;
        }

        private void gridDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)gridDatos.CurrentRow.Cells["id"].Value;
            txtNombre.Text = gridDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = gridDatos.CurrentRow.Cells["Apellido"].Value.ToString();
            picFoto.Load(gridDatos.CurrentRow.Cells["Foto"].Value.ToString());
        }
    }
}
