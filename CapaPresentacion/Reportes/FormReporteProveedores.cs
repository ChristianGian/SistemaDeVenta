using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteProveedores : Form
    {
        public FormReporteProveedores()
        {
            InitializeComponent();
        }

        private void FormReporteProveedores_Load(object sender, EventArgs e)
        {
            GetProveedores();
        }

        private void GetProveedores()
        {
            try
            {
                NProveedor proveedor = new NProveedor();
                var lista = proveedor.MostrarProveedor();

                EProveedorBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de proveedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
