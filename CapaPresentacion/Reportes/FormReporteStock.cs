using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteStock : Form
    {
        public FormReporteStock()
        {
            InitializeComponent();
        }

        private void FormReporteStock_Load(object sender, EventArgs e)
        {
            GetStock();
        }

        private void GetStock()
        {
            try
            {
                NStock stock = new NStock();
                var lista = stock.ConsultarStock();
                EStockBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
