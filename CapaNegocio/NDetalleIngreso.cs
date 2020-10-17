using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalleIngreso
    {
        //Campos
        private DDetalleIngreso detalleIngreso = new DDetalleIngreso();
        public readonly StringBuilder builder = new StringBuilder();

        public List<EDetalleIngreso> MostrarDetalleIngreso(int idIngreso)
        {
            return detalleIngreso.Mostrar(idIngreso);
        }

        public bool RegistrarDetalleIngreso(EDetalleIngreso entidad)
        {
            if (Validar(entidad)) return detalleIngreso.Registrar(entidad);
            else return false;
        }

        public bool DiminuirStock(int idDetIngreso, int cantidad)
        {
            return detalleIngreso.DisminuiStock(idDetIngreso, cantidad);
        }

        private bool Validar(EDetalleIngreso entidad)
        {
            builder.Clear();

            if (entidad.PrecioCompra <= 0) builder.Append("Ingrese un Precio de compra válido");
            if (entidad.PrecioVenta <= 0) builder.Append("\nIngrese un Precio de venta válido");
            if (entidad.StockInicial < 0) builder.Append("\nIngrese un Stock inicial válido");
            if (entidad.StockActual < 0) builder.Append("\nNo se ha podido ingresar el Stock actual");

            return builder.Length == 0;
        }
    }
}
