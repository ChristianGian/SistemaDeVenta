using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EDetalleVenta
    {
        public int IdDetVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdDetIngreso { get; set; }
        public string Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
    }
}
