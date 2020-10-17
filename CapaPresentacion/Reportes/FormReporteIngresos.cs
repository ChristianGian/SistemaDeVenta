using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteIngresos : Form
    {
        public FormReporteIngresos()
        {
            InitializeComponent();
        }

        private void FormReporteIngresos_Load(object sender, EventArgs e)
        {
            GetIngresos();
        }

        private void GetIngresos()
        {
            try
            {
                NIngreso ingreso = new NIngreso();
                var lista = ingreso.MostrarIngreso();

                EIngresoBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de ingresos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
