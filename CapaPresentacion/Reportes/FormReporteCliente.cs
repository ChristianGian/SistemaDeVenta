using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteCliente : Form
    {
        public FormReporteCliente()
        {
            InitializeComponent();
        }

        private void FormReporteCliente_Load(object sender, EventArgs e)
        {
            GetClientes();
        }

        private void GetClientes()
        {
            try
            {
                NCliente cliente = new NCliente();
                var lista = cliente.MostrarCliente();

                EClienteBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
