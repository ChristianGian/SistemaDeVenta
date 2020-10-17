using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EStock
    {
        public string Codigo { get; set; }
        public string Articulo { get; set; }
        public string Categoria { get; set; }
        public int StockInicial { get; set; }
        public int StockActual { get; set; }
        public int CantidadVentas { get; set; }
    }
}
