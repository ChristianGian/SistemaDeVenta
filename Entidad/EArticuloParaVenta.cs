using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EArticuloParaVenta
    {
        public int IdDetIngreso { get; set; }
        public string Codigo { get; set; }
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public string Categoria { get; set; }
        public string Presentacion { get; set; }
        public int StockActual { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
