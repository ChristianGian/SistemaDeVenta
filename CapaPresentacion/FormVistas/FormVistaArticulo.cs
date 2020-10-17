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
    public partial class FormVistaArticulo : Form
    {
        //Campos
        private readonly NArticulo articulo = new NArticulo();

        public FormVistaArticulo()
        {
            InitializeComponent();
        }

        private void FormVistaArticulo_Load(object sender, EventArgs e)
        {
            MostrarArticulo();
        }

        private void MostrarArticulo()
        {
            var lista = articulo.MostrarArticulo();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvArticulos.AutoGenerateColumns = false;
                dgvArticulos.DataSource = lista;

                dgvArticulos.Columns[0].DataPropertyName = "IdArticulo";
                dgvArticulos.Columns[1].DataPropertyName = "Codigo";
                dgvArticulos.Columns[2].DataPropertyName = "Nombre";
                dgvArticulos.Columns[3].DataPropertyName = "Descripcion";
                dgvArticulos.Columns[4].DataPropertyName = "Imagen";
                dgvArticulos.Columns[5].DataPropertyName = "IdCategoria";
                dgvArticulos.Columns[6].DataPropertyName = "Categoria";
                dgvArticulos.Columns[7].DataPropertyName = "IdPresentacion";
                dgvArticulos.Columns[8].DataPropertyName = "Presentacion";
            }
            else
            {
                MessageBox.Show("No hay registros de Artículos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;

            if (nombre != "")
            {
                var lista = articulo.BuscarArticulo(nombre);
                lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                dgvArticulos.AutoGenerateColumns = false;
                dgvArticulos.DataSource = lista;

                dgvArticulos.Columns[0].DataPropertyName = "IdArticulo";
                dgvArticulos.Columns[1].DataPropertyName = "Codigo";
                dgvArticulos.Columns[2].DataPropertyName = "Nombre";
                dgvArticulos.Columns[3].DataPropertyName = "Descripcion";
                dgvArticulos.Columns[4].DataPropertyName = "Imagen";
                dgvArticulos.Columns[5].DataPropertyName = "IdCategoria";
                dgvArticulos.Columns[6].DataPropertyName = "Categoria";
                dgvArticulos.Columns[7].DataPropertyName = "IdPresentacion";
                dgvArticulos.Columns[8].DataPropertyName = "Presentacion";
            }
            else
            {
                MostrarArticulo();
            }
        }

        private void DgvArticulos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormHijos.FormIngreso formIngreso = Owner as FormHijos.FormIngreso;

            formIngreso.lblIdArticulo.Text = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
            formIngreso.txtArticulo.Text = dgvArticulos.CurrentRow.Cells[2].Value.ToString();

            this.Close();
        }
    }
}
