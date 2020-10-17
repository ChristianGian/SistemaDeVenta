using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteTrabajadores : Form
    {
        public FormReporteTrabajadores()
        {
            InitializeComponent();
        }

        private void FormReporteTrabajadores_Load(object sender, EventArgs e)
        {
            GetTrabajadores();
        }

        private void GetTrabajadores()
        {
            try
            {
                NTrabajador trabajador = new NTrabajador();
                var lista = trabajador.MostrarTrabajador();

                ETrabajadorBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de trabajadores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
