using CapaNegocio;
using CapaPresentacion.Reportes;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.FormHijos
{
    public partial class FormTrabajador : Form
    {
        //Campos
        private readonly NTrabajador trabajador = new NTrabajador();
        private ETrabajador entidad;
        private bool editar = false;

        public FormTrabajador()
        {
            InitializeComponent();
        }

        private void FormTrabajador_Load(object sender, EventArgs e)
        {
            MostrarTrabajador();
            InicializarComboBox();
            Deshabilitar();
        }

        private void MostrarTrabajador()
        {
            var lista = trabajador.MostrarTrabajador();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            dgvTrabajadores.AutoGenerateColumns = false;
            dgvTrabajadores.DataSource = lista;

            dgvTrabajadores.Columns[0].DataPropertyName = "IdTrabajador";
            dgvTrabajadores.Columns[1].DataPropertyName = "Nombre";
            dgvTrabajadores.Columns[2].DataPropertyName = "Apellidos";
            dgvTrabajadores.Columns[3].DataPropertyName = "Genero";
            dgvTrabajadores.Columns[4].DataPropertyName = "FecNacimiento";
            dgvTrabajadores.Columns[5].DataPropertyName = "NumDocumento";
            dgvTrabajadores.Columns[6].DataPropertyName = "Direccion";
            dgvTrabajadores.Columns[7].DataPropertyName = "Telefono";
            dgvTrabajadores.Columns[8].DataPropertyName = "Email";
            dgvTrabajadores.Columns[9].DataPropertyName = "Acceso";
            dgvTrabajadores.Columns[10].DataPropertyName = "Username";
            dgvTrabajadores.Columns[11].DataPropertyName = "Password";
            dgvTrabajadores.Columns[12].DataPropertyName = "Estado";

            if (lista.Count == 0)
                MessageBox.Show("No hay registros de Trabajadores", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoBuscado = txtBuscar.Text;

            if (textoBuscado != "")
            {
                if (cmbBurcarPor.SelectedIndex == 0)
                {
                    var lista = trabajador.BuscarNumDocumentoTrabajador(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvTrabajadores.AutoGenerateColumns = false;
                    dgvTrabajadores.DataSource = lista;

                    dgvTrabajadores.Columns[0].DataPropertyName = "IdTrabajador";
                    dgvTrabajadores.Columns[1].DataPropertyName = "Nombre";
                    dgvTrabajadores.Columns[2].DataPropertyName = "Apellidos";
                    dgvTrabajadores.Columns[3].DataPropertyName = "Genero";
                    dgvTrabajadores.Columns[4].DataPropertyName = "FecNacimiento";
                    dgvTrabajadores.Columns[5].DataPropertyName = "NumDocumento";
                    dgvTrabajadores.Columns[6].DataPropertyName = "Direccion";
                    dgvTrabajadores.Columns[7].DataPropertyName = "Telefono";
                    dgvTrabajadores.Columns[8].DataPropertyName = "Email";
                    dgvTrabajadores.Columns[9].DataPropertyName = "Acceso";
                    dgvTrabajadores.Columns[10].DataPropertyName = "Username";
                    dgvTrabajadores.Columns[11].DataPropertyName = "Password";
                    dgvTrabajadores.Columns[12].DataPropertyName = "Estado";
                }
                else
                {
                    var lista = trabajador.BuscarApellidoTrabajador(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvTrabajadores.AutoGenerateColumns = false;
                    dgvTrabajadores.DataSource = lista;

                    dgvTrabajadores.Columns[0].DataPropertyName = "IdTrabajador";
                    dgvTrabajadores.Columns[1].DataPropertyName = "Nombre";
                    dgvTrabajadores.Columns[2].DataPropertyName = "Apellidos";
                    dgvTrabajadores.Columns[3].DataPropertyName = "Genero";
                    dgvTrabajadores.Columns[4].DataPropertyName = "FecNacimiento";
                    dgvTrabajadores.Columns[5].DataPropertyName = "NumDocumento";
                    dgvTrabajadores.Columns[6].DataPropertyName = "Direccion";
                    dgvTrabajadores.Columns[7].DataPropertyName = "Telefono";
                    dgvTrabajadores.Columns[8].DataPropertyName = "Email";
                    dgvTrabajadores.Columns[9].DataPropertyName = "Acceso";
                    dgvTrabajadores.Columns[10].DataPropertyName = "Username";
                    dgvTrabajadores.Columns[11].DataPropertyName = "Password";
                    dgvTrabajadores.Columns[12].DataPropertyName = "Estado";
                }
            }
            else
            {
                MostrarTrabajador();
            }
        }

        private void Limpiar()
        {
            txtIdTrabajador.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            cmbGenero.SelectedIndex = 0;
            dtpFecNac.Value = DateTime.Now;
            txtNumDoc.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbAcceso.SelectedIndex = 0;
            txtUsername.Clear();
            txtPassword.Clear();
            cmbEstado.SelectedIndex = 0;
        }

        private void Habilitar()
        {
            txtIdTrabajador.Enabled = true;
            txtNombre.Enabled = true;
            txtApellidos.Enabled = true;
            cmbGenero.Enabled = true;
            dtpFecNac.Enabled = true;
            txtNumDoc.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;
            txtEmail.Enabled = true;
            cmbAcceso.Enabled = true;
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            cmbEstado.Enabled = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        private void Deshabilitar()
        {
            txtIdTrabajador.Enabled = false;
            txtNombre.Enabled = false;
            txtApellidos.Enabled = false;
            cmbGenero.Enabled = false;
            dtpFecNac.Enabled = false;
            txtNumDoc.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            txtEmail.Enabled = false;
            cmbAcceso.Enabled = false;
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            cmbEstado.Enabled = false;

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void InicializarComboBox()
        {
            cmbBurcarPor.SelectedIndex = 0;
            cmbGenero.SelectedIndex = 0;
            cmbAcceso.SelectedIndex = 0;
            cmbEstado.SelectedIndex = 0;
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
                if (entidad == null) entidad = new ETrabajador();

                entidad.Nombre = txtNombre.Text.Trim();
                entidad.Apellidos = txtApellidos.Text.Trim();
                entidad.Genero = cmbGenero.Text;
                entidad.FecNacimiento = dtpFecNac.Value;
                entidad.NumDocumento = txtNumDoc.Text.Trim();
                entidad.Direccion = txtDireccion.Text.Trim();
                entidad.Telefono = txtTelefono.Text.Trim();
                entidad.Email = txtEmail.Text.Trim();
                entidad.Acceso = cmbAcceso.Text.Trim();
                entidad.Username = txtUsername.Text.Trim();
                entidad.Password = txtPassword.Text.Trim();
                entidad.Estado = cmbEstado.Text;

                if (editar)
                {
                    entidad.IdTrabajador = Convert.ToInt32(txtIdTrabajador.Text);

                    if (trabajador.EditarTrabajador(entidad))
                    {
                        MessageBox.Show("¡Trabajador editado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarTrabajador();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                        editar = false;
                    }
                }
                else
                {
                    if (trabajador.RegistrarTrabajador(entidad))
                    {
                        MessageBox.Show("¡Trabajador registrado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarTrabajador();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                    }
                }

                if (trabajador.builder.Length != 0)
                {
                    MessageBox.Show(trabajador.builder.ToString(), "Para continuar...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvTrabajadores.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este Trabajador?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idTrabajador = dgvTrabajadores.CurrentRow.Cells[0].Value.ToString();
                    if (trabajador.EliminarTrabajador(Convert.ToInt32(idTrabajador)))
                        MostrarTrabajador();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteTrabajadores reporteTrabajadores = new FormReporteTrabajadores();
            reporteTrabajadores.ShowDialog();
        }

        private void DgvTrabajadores_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            editar = true;
            Habilitar();
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;

            txtIdTrabajador.Text = dgvTrabajadores.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvTrabajadores.CurrentRow.Cells[1].Value.ToString();
            txtApellidos.Text = dgvTrabajadores.CurrentRow.Cells[2].Value.ToString();
            cmbGenero.Text = dgvTrabajadores.CurrentRow.Cells[3].Value.ToString();
            dtpFecNac.Text = dgvTrabajadores.CurrentRow.Cells[4].Value.ToString();
            txtNumDoc.Text = dgvTrabajadores.CurrentRow.Cells[5].Value.ToString();
            txtDireccion.Text = dgvTrabajadores.CurrentRow.Cells[6].Value.ToString();
            txtTelefono.Text = dgvTrabajadores.CurrentRow.Cells[7].Value.ToString();
            txtEmail.Text = dgvTrabajadores.CurrentRow.Cells[8].Value.ToString();
            cmbAcceso.Text = dgvTrabajadores.CurrentRow.Cells[9].Value.ToString();
            txtUsername.Text = dgvTrabajadores.CurrentRow.Cells[10].Value.ToString();
            txtPassword.Text = dgvTrabajadores.CurrentRow.Cells[11].Value.ToString();
            cmbEstado.Text = dgvTrabajadores.CurrentRow.Cells[12].Value.ToString();
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
