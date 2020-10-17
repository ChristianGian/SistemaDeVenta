using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class NCliente
    {
        private DCliente cliente = new DCliente();
        public readonly StringBuilder builder = new StringBuilder();

        public List<ECliente> MostrarCliente()
        {
            return cliente.Mostrar();
        }

        public List<ECliente> BuscarApellidoCliente(string apellido)
        {
            return cliente.BuscarApellido(apellido);
        }

        public List<ECliente> BuscarNumDocumentoCliente(string numDocumento)
        {
            return cliente.BuscarNumDocumento(numDocumento);
        }

        public bool RegistrarCliente(ECliente entidad)
        {
            if (Validar(entidad)) return cliente.Registrar(entidad);
            return false;
        }

        public bool EditarCliente(ECliente entidad)
        {
            if (Validar(entidad)) return cliente.Editar(entidad);
            else return false;
        }

        public bool EliminarCliente(int idCliente)
        {
            return cliente.Eliminar(idCliente);
        }

        private bool Validar(ECliente entidad)
        {
            builder.Clear();

            if (string.IsNullOrEmpty(entidad.Nombre)) builder.Append("Ingrese el nombre");
            if (entidad.NumDocumento.Length != 8) builder.Append("\nIngrese un N° de documento válido");
            if (entidad.Telefono.Length > 0 && entidad.Telefono.Length < 9) builder.Append("\nIngrese un teléfono válido");

            return builder.Length == 0;
        }
    }
}
