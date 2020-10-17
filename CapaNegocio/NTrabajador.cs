using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;
using System.Runtime.InteropServices.ComTypes;

namespace CapaNegocio
{
    public class NTrabajador
    {
        private DTrabajador trabajador = new DTrabajador();
        public readonly StringBuilder builder = new StringBuilder();

        public List<ETrabajador> MostrarTrabajador()
        {
            return trabajador.Mostrar();
        }

        public List<ETrabajador> BuscarApellidoTrabajador(string apellido)
        {
            return trabajador.BuscarApellido(apellido);
        }

        public List<ETrabajador> BuscarNumDocumentoTrabajador(string numDocumento)
        {
            return trabajador.BuscarNumDocumento(numDocumento);
        }

        public bool RegistrarTrabajador(ETrabajador entidad)
        {
            if (Validar(entidad)) return trabajador.Registrar(entidad);
            return false;
        }

        public bool EditarTrabajador(ETrabajador entidad)
        {
            if (Validar(entidad)) return trabajador.Editar(entidad);
            else return false;
        }

        public bool EliminarTrabajador(int idTrabajador)
        {
            return trabajador.Eliminar(idTrabajador);
        }

        private bool Validar(ETrabajador entidad)
        {
            builder.Clear();

            if (string.IsNullOrEmpty(entidad.Nombre)) builder.Append("Ingrese el nombre");
            if (string.IsNullOrEmpty(entidad.Apellidos)) builder.Append("\nIngrese el apellido");
            if (entidad.NumDocumento.Length != 8) builder.Append("\nIngrese un N° de documento válido");
            if (entidad.Telefono.Length > 0 && entidad.Telefono.Length < 9) builder.Append("\nIngrese un teléfono válido");
            if (string.IsNullOrEmpty(entidad.Username)) builder.Append("\nIngrese el Nombre de usuario");
            if (string.IsNullOrEmpty(entidad.Password)) builder.Append("\nIngrese la contraseña");

            return builder.Length == 0;
        }
    }
}
