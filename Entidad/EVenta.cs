using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EVenta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public int IdTrabajador { get; set; }
        public string Trabajador { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public decimal Igv { get; set; }
        public decimal Total{ get; set; }

    }
}
