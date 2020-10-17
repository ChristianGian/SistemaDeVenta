using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteVenta : Form
    {
        public FormReporteVenta()
        {
            InitializeComponent();
        }

        private void FormReporteVenta_Load(object sender, EventArgs e)
        {
            GetVenta();
        }

        private void GetVenta()
        {
            try
            {
                NVenta venta = new NVenta();
                var lista = venta.MostrarVenta();
                EVentaBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
