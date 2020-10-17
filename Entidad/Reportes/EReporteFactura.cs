using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.Reportes
{
    public class EReporteFactura
    {
        public int IdVenta { get; set; }
        public string Trabajador { get; set; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string NumDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoComprobante { get; set; }
        public string Serie { get; set; }
        public string Correlativo { get; set; }
        public decimal Igv { get; set; }
        public string Articulo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalParcial { get; set; }
    }
}
