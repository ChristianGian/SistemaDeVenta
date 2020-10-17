using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;
using System.Runtime.Remoting;

namespace CapaNegocio
{
    public class NIngreso
    {
        //Campos
        private DIngreso ingreso = new DIngreso();
        public readonly StringBuilder builder = new StringBuilder();

        public List<EIngreso> MostrarIngreso()
        {
            return ingreso.Mostrar();
        }

        public List<EIngreso> MostrarEntreFechasIngreso(DateTime fecInicial, DateTime fecFinal)
        {
            return ingreso.MostrarEntreFechas(fecInicial, fecFinal);
        }

        public int RegistrarIngreso(EIngreso entidad)
        {
            if (Validar(entidad)) return ingreso.Registrar(entidad);
            else return 0;
        }

        public bool Anular(int idIngreso)
        {
            return ingreso.Anular(idIngreso);
        }

        private bool Validar(EIngreso entidad)
        {
            builder.Clear();

            if (entidad.IdProveedor <= 0) builder.Append("Seleccione un proveedor");
            if (string.IsNullOrEmpty(entidad.Serie)) builder.Append("\nIngrese la serie");
            if (string.IsNullOrEmpty(entidad.Correlativo)) builder.Append("\nIngrese el correlativo");
            if (entidad.Igv < 0) builder.Append("\nIngrese un IGV válido");

            return builder.Length == 0;
        }
    }
}
