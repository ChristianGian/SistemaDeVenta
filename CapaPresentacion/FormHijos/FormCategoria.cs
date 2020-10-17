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
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using CapaPresentacion.Reportes;

namespace CapaPresentacion.FormHijos
{
    public partial class FormCategoria : Form
    {
        //Campos
        private readonly NCategoria categoria = new NCategoria();
        private ECategoria entidad;
        private bool editar = false;

        public FormCategoria()
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            MostrarCategoria();
            Deshabilitar();
        }

        private void MostrarCategoria()
        {
            var lista = categoria.MostrarCategoria();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            dgvCategorias.AutoGenerateColumns = false;
            dgvCategorias.DataSource = lista;

            dgvCategorias.Columns[0].DataPropertyName = "IdCategoria";
            dgvCategorias.Columns[1].DataPropertyName = "Nombre";
            dgvCategorias.Columns[2].DataPropertyName = "Descripcion";

            if (lista.Count == 0)
                MessageBox.Show("No hay registros de Categorías", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;

            if (nombre != "")
            {
                var lista = categoria.BuscarCategoria(nombre);
                lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                dgvCategorias.AutoGenerateColumns = false;
                dgvCategorias.DataSource = lista;

                dgvCategorias.Columns[0].DataPropertyName = "IdCategoria";
                dgvCategorias.Columns[1].DataPropertyName = "Nombre";
                dgvCategorias.Columns[2].DataPropertyName = "Descripcion";
            }
            else
            {
                MostrarCategoria();
            }
        }

        private void Limpiar()
        {
            txtIdCategoria.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void Habilitar()
        {
            txtIdCategoria.Enabled = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }


        private void Deshabilitar()
        {
            txtIdCategoria.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
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
                if (entidad == null) entidad = new ECategoria();

                entidad.Nombre = txtNombre.Text.Trim();
                entidad.Descripcion = txtDescripcion.Text.Trim();

                if (editar)
                {
                    entidad.IdCategoria = Convert.ToInt32(txtIdCategoria.Text);

                    if (categoria.EditarCategoria(entidad))
                    {
                        MessageBox.Show("¡Categoría editada con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCategoria();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                        editar = false;
                    }
                }
                else
                {
                    if (categoria.RegistrarCategoria(entidad))
                    {
                        MessageBox.Show("¡Categoría registrada con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarCategoria();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                    }
                }

                if (categoria.builder.Length != 0)
                {
                    MessageBox.Show(categoria.builder.ToString(), "Para continuar...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar esta Categoría?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idCategoria = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
                    if (categoria.EliminarCategoria(Convert.ToInt32(idCategoria)))
                        MostrarCategoria();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteCategorias reporteCategorias = new FormReporteCategorias();
            reporteCategorias.ShowDialog();
        }

        private void DgvCategorias_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editar = true;
            Habilitar();
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;

            txtIdCategoria.Text = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = dgvCategorias.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
