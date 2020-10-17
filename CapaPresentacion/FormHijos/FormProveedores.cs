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
using CapaPresentacion.Reportes;

namespace CapaPresentacion.FormHijos
{
    public partial class FormProveedores : Form
    {
        //Campos
        private readonly NProveedor proveedor = new NProveedor();
        private EProveedor entidad;
        private bool editar = false;

        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
            InicializarComboBox();
            Deshabilitar();
        }

        private void MostrarProveedores()
        {
            var lista = proveedor.MostrarProveedor();
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

            if (lista.Count == 0)
                MessageBox.Show("No hay registros de Proveedores", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void Limpiar()
        {
            txtIdProveedor.Clear();
            txtRazonSocial.Clear();
            cmbSectorComercial.SelectedIndex = 0;
            cmbTipoDoc.SelectedIndex = 0;
            txtNumDoc.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtUrl.Clear();
        }

        private void Habilitar()
        {
            txtIdProveedor.Enabled = true;
            txtRazonSocial.Enabled = true;
            cmbSectorComercial.Enabled = true;
            cmbTipoDoc.Enabled = true;
            txtNumDoc.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            txtUrl.Enabled = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        private void Deshabilitar()
        {
            txtIdProveedor.Enabled = false;
            txtRazonSocial.Enabled = false;
            cmbSectorComercial.Enabled = false;
            cmbTipoDoc.Enabled = false;
            txtNumDoc.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            txtUrl.Enabled = false;

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void InicializarComboBox()
        {
            cmbBurcarPor.SelectedIndex = 0;
            cmbSectorComercial.SelectedIndex = 0;
            cmbTipoDoc.SelectedIndex = 0;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            txtRazonSocial.Focus();
            editar = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (entidad == null) entidad = new EProveedor();

                entidad.RazonSocial = txtRazonSocial.Text.Trim();
                entidad.SectorComercial = cmbSectorComercial.Text;
                entidad.TipoDocumento = cmbTipoDoc.Text;
                entidad.NumDocumento = txtNumDoc.Text.Trim();
                entidad.Direccion = txtDireccion.Text.Trim();
                entidad.Telefono = txtTelefono.Text.Trim();
                entidad.Email = txtEmail.Text.Trim();
                entidad.Url = txtUrl.Text.Trim();

                if (editar)
                {
                    entidad.IdProveedor = Convert.ToInt32(txtIdProveedor.Text);

                    if (proveedor.EditarProveedor(entidad))
                    {
                        MessageBox.Show("¡Proveedor editado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProveedores();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                        editar = false;
                    }
                }
                else
                {
                    if (proveedor.RegistrarProveedor(entidad))
                    {
                        MessageBox.Show("¡Proveedor registrado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarProveedores();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                    }
                }

                if (proveedor.builder.Length != 0)
                {
                    MessageBox.Show(proveedor.builder.ToString(), "Para continuar...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnNuevo.Enabled = true;
            editar = false;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este Proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idProveedor = dgvProveedores.CurrentRow.Cells[0].Value.ToString();
                    if (proveedor.EliminarProveedor(Convert.ToInt32(idProveedor)))
                        MostrarProveedores();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteProveedores reporteProveedores = new FormReporteProveedores();
            reporteProveedores.ShowDialog();
        }

        private void DgvProveedores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editar = true;
            Habilitar();
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;

            txtIdProveedor.Text = dgvProveedores.CurrentRow.Cells[0].Value.ToString();
            txtRazonSocial.Text = dgvProveedores.CurrentRow.Cells[1].Value.ToString();
            cmbSectorComercial.Text = dgvProveedores.CurrentRow.Cells[2].Value.ToString();
            cmbTipoDoc.Text = dgvProveedores.CurrentRow.Cells[3].Value.ToString();
            txtNumDoc.Text = dgvProveedores.CurrentRow.Cells[4].Value.ToString();
            txtDireccion.Text = dgvProveedores.CurrentRow.Cells[5].Value.ToString();
            txtTelefono.Text = dgvProveedores.CurrentRow.Cells[6].Value.ToString();
            txtEmail.Text = dgvProveedores.CurrentRow.Cells[7].Value.ToString();
            txtUrl.Text = dgvProveedores.CurrentRow.Cells[8].Value.ToString();
        }

        private void TxtNumDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (!Validaciones.EsEmail(txtEmail.Text))
            {
                MessageBox.Show("Email no válido, el email debe tener el formato: nombre@dominio.com.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEmail.SelectAll();
                txtEmail.Focus();
            }
        }
    }
}
