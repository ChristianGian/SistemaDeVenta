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
    public partial class FormVistaProveedor : Form
    {
        //Campos
        private readonly NProveedor proveedor = new NProveedor();

        public FormVistaProveedor()
        {
            InitializeComponent();
        }

        private void FormVistaProveedor_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
            InicializarComboBox();
        }

        private void MostrarProveedores()
        {
            var lista = proveedor.MostrarProveedor();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvProveedores.AutoGenerateColumns = false;
                dgvProveedores.DataSource = lista;

                dgvProveedores.Columns[0].DataPropertyName = "IdProveedor";
                dgvProveedores.Columns[1].DataPropertyName = "RazonSocial";
                dgvProveedores.Columns[2].DataPropertyName = "SectorComercial";
                dgvProveedores.Columns[3].DataPropertyName = "TipoDocumento";
                dgvProveedores.Columns[4].DataPropertyName = "NumDocumento";
                dgvProveedores.Columns[5].DataPropertyName = "Direccion";
                dgvProveedores.Columns[6].DataPropertyName = "Telefono";
                dgvProveedores.Columns[7].DataPropertyName = "Email";
                dgvProveedores.Columns[8].DataPropertyName = "Url";

            }
            else
            {
                MessageBox.Show("No hay registros de Proveedores", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoBuscado = txtBuscar.Text;

            if (textoBuscado != "")
            {
                if (cmbBurcarPor.SelectedIndex == 0)
                {
                    var lista = proveedor.BuscarNumDocumentoProveedor(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvProveedores.AutoGenerateColumns = false;
                    dgvProveedores.DataSource = lista;

                    dgvProveedores.Columns[0].DataPropertyName = "IdProveedor";
                    dgvProveedores.Columns[1].DataPropertyName = "RazonSocial";
                    dgvProveedores.Columns[2].DataPropertyName = "SectorComercial";
                    dgvProveedores.Columns[3].DataPropertyName = "TipoDocumento";
                    dgvProveedores.Columns[4].DataPropertyName = "NumDocumento";
                    dgvProveedores.Columns[5].DataPropertyName = "Direccion";
                    dgvProveedores.Columns[6].DataPropertyName = "Telefono";
                    dgvProveedores.Columns[7].DataPropertyName = "Email";
                    dgvProveedores.Columns[8].DataPropertyName = "Url";
                }
                else
                {
                    var lista = proveedor.BuscarRazonSocialProveedor(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvProveedores.AutoGenerateColumns = false;
                    dgvProveedores.DataSource = lista;

                    dgvProveedores.Columns[0].DataPropertyName = "IdProveedor";
                    dgvProveedores.Columns[1].DataPropertyName = "RazonSocial";
                    dgvProveedores.Columns[2].DataPropertyName = "SectorComercial";
                    dgvProveedores.Columns[3].DataPropertyName = "TipoDocumento";
                    dgvProveedores.Columns[4].DataPropertyName = "NumDocumento";
                    dgvProveedores.Columns[5].DataPropertyName = "Direccion";
                    dgvProveedores.Columns[6].DataPropertyName = "Telefono";
                    dgvProveedores.Columns[7].DataPropertyName = "Email";
                    dgvProveedores.Columns[8].DataPropertyName = "Url";
                }
            }
            else
            {
                MostrarProveedores();
            }
        }

        private void InicializarComboBox()
        {
            cmbBurcarPor.SelectedIndex = 0;
        }

        private void DgvProveedores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormHijos.FormIngreso formIngreso = Owner as FormHijos.FormIngreso;

            formIngreso.lblIdProveedor.Text = dgvProveedores.CurrentRow.Cells[0].Value.ToString();
            formIngreso.txtProveedor.Text = dgvProveedores.CurrentRow.Cells[1].Value.ToString();

            this.Close();
        }
    }
}
