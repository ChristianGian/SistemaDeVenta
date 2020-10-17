using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        private DProveedor proveedor = new DProveedor();
        public readonly StringBuilder builder = new StringBuilder();

        public List<EProveedor> MostrarProveedor()
        {
            return proveedor.Mostrar();
        }

        public List<EProveedor> BuscarRazonSocialProveedor(string razonSocial)
        {
            return proveedor.BuscarRazonSocial(razonSocial);
        }

        public List<EProveedor> BuscarNumDocumentoProveedor(string numDocumento)
        {
            return proveedor.BuscarNumDocumento(numDocumento);
        }

        public bool RegistrarProveedor(EProveedor entidad)
        {
            if (Validar(entidad)) return proveedor.Registrar(entidad);
            return false;
        }

        public bool EditarProveedor(EProveedor entidad)
        {
            if (Validar(entidad)) return proveedor.Editar(entidad);
            else return false;
        }

        public bool EliminarProveedor(int idProveedor)
        {
            return proveedor.Eliminar(idProveedor);
        }

        private bool Validar(EProveedor entidad)
        {
            builder.Clear();

            if (string.IsNullOrEmpty(entidad.RazonSocial)) builder.Append("Ingrese la Razón social");
            if (string.IsNullOrEmpty(entidad.SectorComercial)) builder.Append("\nIngrese el Sector comercial");
            if (string.IsNullOrEmpty(entidad.NumDocumento)) builder.Append("\nIngrese el N° de documento");

            return builder.Length == 0;
        }
    }
}
