using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using CapaNegocio;

namespace CapaPresentacion.FormVistas
{
    public partial class FormVistaCliente : Form
    {
        //Campos
        private readonly NCliente cliente = new NCliente();

        public FormVistaCliente()
        {
            InitializeComponent();
        }

        private void FormVistaCliente_Load(object sender, EventArgs e)
        {
            cmbBurcarPor.SelectedIndex = 0;
            MostrarCliente();
        }

        private void MostrarCliente()
        {
            var lista = cliente.MostrarCliente();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvClientes.AutoGenerateColumns = false;
                dgvClientes.DataSource = lista;

                dgvClientes.Columns[0].DataPropertyName = "IdCliente";
                dgvClientes.Columns[1].DataPropertyName = "Nombre";
                dgvClientes.Columns[2].DataPropertyName = "Apellidos";
                dgvClientes.Columns[3].DataPropertyName = "Genero";
                dgvClientes.Columns[4].DataPropertyName = "FecNacimiento";
                dgvClientes.Columns[5].DataPropertyName = "TipoDocumento";
                dgvClientes.Columns[6].DataPropertyName = "NumDocumento";
                dgvClientes.Columns[7].DataPropertyName = "Direccion";
                dgvClientes.Columns[8].DataPropertyName = "Telefono";
                dgvClientes.Columns[9].DataPropertyName = "Email";

            }
            else
            {
                MessageBox.Show("No hay registros de Clientes", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoBuscado = txtBuscar.Text;

            if (textoBuscado != "")
            {
                if (cmbBurcarPor.SelectedIndex == 0)
                {
                    var lista = cliente.BuscarNumDocumentoCliente(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvClientes.AutoGenerateColumns = false;
                    dgvClientes.DataSource = lista;

                    dgvClientes.Columns[0].DataPropertyName = "IdCliente";
                    dgvClientes.Columns[1].DataPropertyName = "Nombre";
                    dgvClientes.Columns[2].DataPropertyName = "Apellidos";
                    dgvClientes.Columns[3].DataPropertyName = "Genero";
                    dgvClientes.Columns[4].DataPropertyName = "FecNacimiento";
                    dgvClientes.Columns[5].DataPropertyName = "TipoDocumento";
                    dgvClientes.Columns[6].DataPropertyName = "NumDocumento";
                    dgvClientes.Columns[7].DataPropertyName = "Direccion";
                    dgvClientes.Columns[8].DataPropertyName = "Telefono";
                    dgvClientes.Columns[9].DataPropertyName = "Email";
                }
                else
                {
                    var lista = cliente.BuscarApellidoCliente(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvClientes.AutoGenerateColumns = false;
                    dgvClientes.DataSource = lista;

                    dgvClientes.Columns[0].DataPropertyName = "IdCliente";
                    dgvClientes.Columns[1].DataPropertyName = "Nombre";
                    dgvClientes.Columns[2].DataPropertyName = "Apellidos";
                    dgvClientes.Columns[3].DataPropertyName = "Genero";
                    dgvClientes.Columns[4].DataPropertyName = "FecNacimiento";
                    dgvClientes.Columns[5].DataPropertyName = "TipoDocumento";
                    dgvClientes.Columns[6].DataPropertyName = "NumDocumento";
                    dgvClientes.Columns[7].DataPropertyName = "Direccion";
                    dgvClientes.Columns[8].DataPropertyName = "Telefono";
                    dgvClientes.Columns[9].DataPropertyName = "Email";
                }
            }
            else
            {
                MostrarCliente();
            }
        }

        private void DgvClientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormHijos.FormVenta formVenta = Owner as FormHijos.FormVenta;

            formVenta.lblIdCliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            formVenta.txtCliente.Text = $"{dgvClientes.CurrentRow.Cells[1].Value} {dgvClientes.CurrentRow.Cells[2].Value}";
            this.Close();
        }
    }
}
