using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio.Reportes;
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion.Reportes
{
    public partial class FormReporteFactura : Form
    {

        //Campos
        public int IdVenta { get; set; }

        public FormReporteFactura()
        {
            InitializeComponent();
        }

        private void FormReporteFactura_Load(object sender, EventArgs e)
        {
            GetFactura(IdVenta);
        }

        private void GetFactura(int idVenta)
        {
            try
            {
                NReporteFactura factura = new NReporteFactura();
                var lista = factura.MostrarVentas(idVenta); 

                EReporteFacturaBindingSource.DataSource = lista;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error - Obtener datos de Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
