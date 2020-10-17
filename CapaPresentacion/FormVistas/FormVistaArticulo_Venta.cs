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
    public partial class FormVistaArticulo_Venta : Form
    {
        //Campos
        private readonly NVenta venta = new NVenta();

        public FormVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        private void FormVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            cmbBurcarPor.SelectedIndex = 0;
            MostrarArticulo();
        }

        private void MostrarArticulo()
        {
            var lista = venta.MostrarArticuloParaVenta();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvArticulos.AutoGenerateColumns = false;
                dgvArticulos.DataSource = lista;

                dgvArticulos.Columns[0].DataPropertyName = "IdDetIngreso";
                dgvArticulos.Columns[1].DataPropertyName = "Codigo";
                dgvArticulos.Columns[2].DataPropertyName = "IdArticulo";
                dgvArticulos.Columns[3].DataPropertyName = "Articulo";
                dgvArticulos.Columns[4].DataPropertyName = "Categoria";
                dgvArticulos.Columns[5].DataPropertyName = "Presentacion";
                dgvArticulos.Columns[6].DataPropertyName = "StockActual";
                dgvArticulos.Columns[7].DataPropertyName = "PrecioCompra";
                dgvArticulos.Columns[8].DataPropertyName = "PrecioVenta";
                dgvArticulos.Columns[9].DataPropertyName = "FechaVencimiento";
            }
            else
            {
                MessageBox.Show("No hay registros de Artículos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string textoBuscado = txtBuscar.Text;

            if (textoBuscado != "")
            {
                if (cmbBurcarPor.SelectedIndex == 0)
                {
                    var lista = venta.BuscarArticuloPorNombre(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvArticulos.AutoGenerateColumns = false;
                    dgvArticulos.DataSource = lista;

                    dgvArticulos.Columns[0].DataPropertyName = "IdDetIngreso";
                    dgvArticulos.Columns[1].DataPropertyName = "Codigo";
                    dgvArticulos.Columns[2].DataPropertyName = "IdArticulo";
                    dgvArticulos.Columns[3].DataPropertyName = "Articulo";
                    dgvArticulos.Columns[4].DataPropertyName = "Categoria";
                    dgvArticulos.Columns[5].DataPropertyName = "Presentacion";
                    dgvArticulos.Columns[6].DataPropertyName = "StockActual";
                    dgvArticulos.Columns[7].DataPropertyName = "PrecioCompra";
                    dgvArticulos.Columns[8].DataPropertyName = "PrecioVenta";
                    dgvArticulos.Columns[9].DataPropertyName = "FechaVencimiento";
                }
                else
                {
                    var lista = venta.BuscarArticuloPorCodigo(textoBuscado);
                    lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                    dgvArticulos.AutoGenerateColumns = false;
                    dgvArticulos.DataSource = lista;

                    dgvArticulos.Columns[0].DataPropertyName = "IdDetIngreso";
                    dgvArticulos.Columns[1].DataPropertyName = "Codigo";
                    dgvArticulos.Columns[2].DataPropertyName = "IdArticulo";
                    dgvArticulos.Columns[3].DataPropertyName = "Articulo";
                    dgvArticulos.Columns[4].DataPropertyName = "Categoria";
                    dgvArticulos.Columns[5].DataPropertyName = "Presentacion";
                    dgvArticulos.Columns[6].DataPropertyName = "StockActual";
                    dgvArticulos.Columns[7].DataPropertyName = "PrecioCompra";
                    dgvArticulos.Columns[8].DataPropertyName = "PrecioVenta";
                    dgvArticulos.Columns[9].DataPropertyName = "FechaVencimiento";
                }
            }
            else
            {
                MostrarArticulo();
            }
        }

        private void DgvArticulos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormHijos.FormVenta formVenta = Owner as FormHijos.FormVenta;

            formVenta.lblIdDetIngreso.Text = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
            formVenta.lblIdArticulo.Text = dgvArticulos.CurrentRow.Cells[2].Value.ToString();
            formVenta.txtArticulo.Text = dgvArticulos.CurrentRow.Cells[3].Value.ToString();
            formVenta.txtStockActual.Text = dgvArticulos.CurrentRow.Cells[6].Value.ToString();
            formVenta.txtPrecioCompra.Text = dgvArticulos.CurrentRow.Cells[7].Value.ToString();
            formVenta.txtPrecioVenta.Text = dgvArticulos.CurrentRow.Cells[8].Value.ToString();
            formVenta.dtpFecVencimiento.Text = dgvArticulos.CurrentRow.Cells[9].Value.ToString();

            this.Close();
        }
    }
}
