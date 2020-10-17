using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;
using System.Globalization;

namespace CapaNegocio
{
    public class NVenta
    {
        //Campos
        private DVenta venta = new DVenta();
        public readonly StringBuilder builder = new StringBuilder(); 

        public List<EVenta> MostrarVenta()
        {
            return venta.Mostrar();
        }

        public List<EVenta> BuscarEntreFechasVenta(DateTime fecInicial, DateTime fecFinal)
        {
            return venta.BuscarEntreFechas(fecInicial, fecFinal);
        }

        public int RegistrarVenta(EVenta entidad)
        {
            if (Validar(entidad)) return venta.Registrar(entidad);
            else return 0;
        }

        public bool EliminarVenta(int idVenta)
        {
            return venta.Eliminar(idVenta);
        }

        public bool DisminuirStockPorVenta(int idDetIngreso, int cantidad)
        {
            return venta.DisminuirStock(idDetIngreso, cantidad);
        }

        private bool Validar(EVenta entidad)
        {
            builder.Clear();

            if (string.IsNullOrEmpty(entidad.Serie)) builder.Append("Ingrese la serie");
            if (string.IsNullOrEmpty(entidad.Correlativo)) builder.Append("\nIngrese el correlativo");
            if (entidad.Igv < 0) builder.Append("\nIngrese un IGV válido");

            return builder.Length == 0;
        }

        //Mostrar artículos para la venta
        public List<EArticuloParaVenta> MostrarArticuloParaVenta()
        {
            return venta.MostrarArticulosParaVenta();
        }

        public List<EArticuloParaVenta> BuscarArticuloPorNombre(string nombre)
        {
            return venta.BuscarArticuloPorNombre(nombre);
        }

        public List<EArticuloParaVenta> BuscarArticuloPorCodigo(string codigo)
        {
            return venta.BuscarArticuloPorCodigo(codigo);
        }
    }
}
