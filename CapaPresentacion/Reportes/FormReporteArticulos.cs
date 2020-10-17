using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteArticulos : Form
    {
        public FormReporteArticulos()
        {
            InitializeComponent();
        }

        private void FormReporteArticulos_Load(object sender, EventArgs e)
        {
            GetArticulos();
        }

        private void GetArticulos()
        {
            try
            {
                NArticulo articulo = new NArticulo();
                var lista = articulo.MostrarArticulo();

                EArticuloBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de artículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
