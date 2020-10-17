using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReportePresentaciones : Form
    {
        public FormReportePresentaciones()
        {
            InitializeComponent();
        }

        private void FormReportePresentaciones_Load(object sender, EventArgs e)
        {
            GetPresentaciones();
        }

        private void GetPresentaciones()
        {
            try
            {
                NPresentacion presentacion = new NPresentacion();
                var lista = presentacion.MostrarPresentacion();

                EPresentacionBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de presentaciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
