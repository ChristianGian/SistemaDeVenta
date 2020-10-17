using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteCategorias : Form
    {
        public FormReporteCategorias()
        {
            InitializeComponent();
        }

        private void FormReporteCategorias_Load(object sender, EventArgs e)
        {
            GetCategorias();
        }

        private void GetCategorias()
        {
            try
            {
                NCategoria categoria = new NCategoria();
                var lista = categoria.MostrarCategoria();

                ECategoriaBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de categorías", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
