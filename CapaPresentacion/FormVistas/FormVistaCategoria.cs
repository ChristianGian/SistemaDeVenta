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
    public partial class FormVistaCategoria : Form
    {
        //Campos
        private readonly NCategoria categoria = new NCategoria();

        public FormVistaCategoria()
        {
            InitializeComponent();
        }

        private void FormVistaCategoria_Load(object sender, EventArgs e)
        {
            MostrarCategoria();
        }

        private void MostrarCategoria()
        {
            var lista = categoria.MostrarCategoria();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvCategorias.AutoGenerateColumns = false;
                dgvCategorias.DataSource = lista;

                dgvCategorias.Columns[0].DataPropertyName = "IdCategoria";
                dgvCategorias.Columns[1].DataPropertyName = "Nombre";
                dgvCategorias.Columns[2].DataPropertyName = "Descripcion";
            }
            else
            {
                MessageBox.Show("No hay registros de Categorías", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

        private void DgvCategorias_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormHijos.FormArticulo formArticulo = Owner as FormHijos.FormArticulo;

            formArticulo.lblIdCategoria.Text = dgvCategorias.CurrentRow.Cells[0].Value.ToString();
            formArticulo.txtCategoria.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
            this.Close();

        }
    }
}
