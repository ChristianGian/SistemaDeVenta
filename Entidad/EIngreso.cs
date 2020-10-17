using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EIngreso
    {
        public int IdIngreso { get; set; }
        public int IdTrabajador { get; set; }
        public string Trabajador { get; set; }
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public decimal Igv { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
    }
}
