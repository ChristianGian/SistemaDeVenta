using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Reportes;
using Entidad.Reportes;

namespace CapaNegocio.Reportes
{
    public class NReporteFactura
    {
        private DReporteFactura factura = new DReporteFactura();

        public List<EReporteFactura> MostrarVentas(int idVenta)
        {
            return factura.Mostrar(idVenta);
        }
    }
}
