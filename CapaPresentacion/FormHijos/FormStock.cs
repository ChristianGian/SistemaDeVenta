using CapaNegocio;
using CapaPresentacion.Reportes;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.FormHijos
{
    public partial class FormStock : Form
    {
        //Campos
        private readonly NStock stock = new NStock();

        public FormStock()
        {
            InitializeComponent();
        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            MostrarStockArticulos();
        }

        private void MostrarStockArticulos()
        {
            var lista = stock.ConsultarStock();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvArticulos.AutoGenerateColumns = false;
                dgvArticulos.DataSource = lista;

                dgvArticulos.Columns[0].DataPropertyName = "Codigo";
                dgvArticulos.Columns[1].DataPropertyName = "Articulo";
                dgvArticulos.Columns[2].DataPropertyName = "Categoria";
                dgvArticulos.Columns[3].DataPropertyName = "StockInicial";
                dgvArticulos.Columns[4].DataPropertyName = "StockActual";
                dgvArticulos.Columns[5].DataPropertyName = "CantidadVentas";
            }
            else
            {
                MessageBox.Show("No hay registros de Artículos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteStock reporteStock = new FormReporteStock();
            reporteStock.ShowDialog();
        }
    }
}
