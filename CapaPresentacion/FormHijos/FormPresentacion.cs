using CapaNegocio;
using CapaPresentacion.Reportes;
using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.FormHijos
{
    public partial class FormPresentacion : Form
    {
        //Campos
        private readonly NPresentacion presentacion = new NPresentacion();
        private EPresentacion entidad;
        private bool editar = false;

        public FormPresentacion()
        {
            InitializeComponent();
        }

        private void FormPresentacion_Load(object sender, EventArgs e)
        {
            MostrarPresentacion();
            Deshabilitar();
        }

        private void MostrarPresentacion()
        {
            var lista = presentacion.MostrarPresentacion();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            dgvPresentaciones.AutoGenerateColumns = false;
            dgvPresentaciones.DataSource = lista;

            dgvPresentaciones.Columns[0].DataPropertyName = "IdPresentacion";
            dgvPresentaciones.Columns[1].DataPropertyName = "Nombre";
            dgvPresentaciones.Columns[2].DataPropertyName = "Descripcion";

            if (lista.Count == 0)
                MessageBox.Show("No hay registros de Presentaciones", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;

            if (nombre != "")
            {
                var lista = presentacion.BuscarPresentacion(nombre);

                dgvPresentaciones.AutoGenerateColumns = false;
                dgvPresentaciones.DataSource = lista;

                dgvPresentaciones.Columns[0].DataPropertyName = "IdPresentacion";
                dgvPresentaciones.Columns[1].DataPropertyName = "Nombre";
                dgvPresentaciones.Columns[2].DataPropertyName = "Descripcion";
            }
            else
            {
                MostrarPresentacion();
            }
        }

        private void Limpiar()
        {
            txtIdPresentacion.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void Habilitar()
        {
            txtIdPresentacion.Enabled = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Deshabilitar()
        {
            txtIdPresentacion.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
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
                if (entidad == null) entidad = new EPresentacion();

                entidad.Nombre = txtNombre.Text.Trim();
                entidad.Descripcion = txtDescripcion.Text.Trim();

                if (editar)
                {
                    entidad.IdPresentacion = Convert.ToInt32(txtIdPresentacion.Text);

                    if (presentacion.EditarPresentacion(entidad))
                    {
                        MessageBox.Show("¡Presentación editada con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarPresentacion();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                        editar = false;
                    }
                }
                else
                {
                    if (presentacion.RegistrarPresentacion(entidad))
                    {
                        MessageBox.Show("¡Presentación registrada con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarPresentacion();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                    }
                }

                if (presentacion.builder.Length != 0)
                {
                    MessageBox.Show(presentacion.builder.ToString(), "Para continuar...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvPresentaciones.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar esta Presentación?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idCategoria = dgvPresentaciones.CurrentRow.Cells[0].Value.ToString();
                    if (presentacion.EliminarPresentacion(Convert.ToInt32(idCategoria)))
                        MostrarPresentacion();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReportePresentaciones reportePresentaciones = new FormReportePresentaciones();
            reportePresentaciones.ShowDialog();
        }

        private void dgvPresentaciones_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editar = true;
            Habilitar();
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;

            txtIdPresentacion.Text = dgvPresentaciones.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvPresentaciones.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgvPresentaciones.CurrentRow.Cells[2].Value.ToString();
        }

        
    }
}
