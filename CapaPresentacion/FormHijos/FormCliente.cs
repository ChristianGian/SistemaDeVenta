using System;
using CapaNegocio;
using CapaPresentacion.Reportes;
using Entidad;
using System.Windows.Forms;

namespace CapaPresentacion.FormHijos
{
    public partial class FormCliente : Form
    {
        //Campos
        private readonly NCliente cliente = new NCliente();
        private ECliente entidad;
        private bool editar = false;

        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            MostrarCliente();
            InicializarComboBox();
            Deshabilitar();
        }

        private void MostrarCliente()
        {
            var lista = cliente.MostrarCliente();
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

            if (lista.Count == 0)
                MessageBox.Show("No hay registros de Clientes", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Limpiar()
        {
            txtIdCliente.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            cmbGenero.SelectedIndex = 0;
            dtpFecNac.Value = DateTime.Now;
            cmbTipoDoc.SelectedIndex = 0;
            txtNumDoc.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        private void Habilitar()
        {
            txtIdCliente.Enabled = true;
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            cmbGenero.Enabled = true;
            dtpFecNac.Enabled = true;
            cmbTipoDoc.Enabled = true;
            txtNumDoc.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        private void Deshabilitar()
        {
            txtIdCliente.Enabled = false;
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            cmbGenero.Enabled = false;
            dtpFecNac.Enabled = false;
            cmbTipoDoc.Enabled = false;
            txtNumDoc.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void InicializarComboBox()
        {
            cmbGenero.SelectedIndex = 0;
            cmbTipoDoc.SelectedIndex = 0;
            cmbBurcarPor.SelectedIndex = 0;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            txtNombre.Focus();
            editar = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (entidad == null) entidad = new ECliente();

                entidad.Nombre = txtNombre.Text.Trim();
                entidad.Apellidos = txtApellidos.Text.Trim();
                entidad.Genero = cmbGenero.Text;
                entidad.FecNacimiento = dtpFecNac.Value;
                entidad.TipoDocumento = cmbTipoDoc.Text;
                entidad.NumDocumento = txtNumDoc.Text.Trim();
                entidad.Direccion = txtDireccion.Text.Trim();
                entidad.Telefono = txtTelefono.Text.Trim();
                entidad.Email = txtEmail.Text.Trim();

                if (editar)
                {
                    entidad.IdCliente = Convert.ToInt32(txtIdCliente.Text);

                    if (cliente.EditarCliente(entidad))
                    {
                        MessageBox.Show("¡Cliente editado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCliente();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                        editar = false;
                    }
                }
                else
                {
                    if (cliente.RegistrarCliente(entidad))
                    {
                        MessageBox.Show("¡Cliente registrado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCliente();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                    }
                }

                if (cliente.builder.Length != 0)
                {
                    MessageBox.Show(cliente.builder.ToString(), "Para continuar...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvClientes.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este Cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idCliente = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                    if (cliente.EliminarCliente(Convert.ToInt32(idCliente)))
                        MostrarCliente();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteCliente reporteCliente = new FormReporteCliente();
            reporteCliente.ShowDialog();
        }

        private void DgvClientes_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            editar = true;
            Habilitar();
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;

            txtIdCliente.Text = dgvClientes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtApellidos.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
            cmbGenero.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
            dtpFecNac.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
            cmbTipoDoc.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
            txtNumDoc.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
            txtDireccion.Text = dgvClientes.CurrentRow.Cells[7].Value.ToString();
            txtTelefono.Text = dgvClientes.CurrentRow.Cells[8].Value.ToString();
            txtEmail.Text = dgvClientes.CurrentRow.Cells[9].Value.ToString();
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
