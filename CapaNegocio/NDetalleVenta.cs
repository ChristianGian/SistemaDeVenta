using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalleVenta
    {
        //Campos
        private DDetalleVenta detalleVenta = new DDetalleVenta();
        public readonly StringBuilder builder = new StringBuilder();

        public List<EDetalleVenta> MostrarDetalleVenta(int idVenta)
        {
            return detalleVenta.Mostrar(idVenta);
        }

        public bool RegistrarDetalleVenta(EDetalleVenta entidad)
        {
            if (Validar(entidad)) return detalleVenta.Registrar(entidad);
            else return false;
        }

        private bool Validar(EDetalleVenta entidad)
        {
            builder.Clear();

            if (entidad.Cantidad < 0) builder.Append("Ingrese una cantidad válida");
            if (entidad.PrecioVenta < 0) builder.Append("\nIngrese un precio de venta válido");
            if (entidad.Descuento < 0) builder.Append("\nIngrese un descuento válido");

            return builder.Length == 0;
        }
    }
}
