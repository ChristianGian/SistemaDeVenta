using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NPresentacion
    {
        private DPresentacion presentacion = new DPresentacion();
        public readonly StringBuilder builder = new StringBuilder();

        public List<EPresentacion> MostrarPresentacion()
        {
            return presentacion.Mostrar();
        }

        public List<EPresentacion> BuscarPresentacion(string nombre)
        {
            return presentacion.Buscar(nombre);
        }

        public bool RegistrarPresentacion(EPresentacion entidad)
        {
            if (Validar(entidad)) return presentacion.Registrar(entidad);
            else return false;
        }

        public bool EditarPresentacion(EPresentacion entidad)
        {
            if (Validar(entidad)) return presentacion.Editar(entidad);
            else return false;
        }

        public bool EliminarPresentacion(int idPresentacion)
        {
            return presentacion.Eliminar(idPresentacion);
        }

        private bool Validar(EPresentacion entidad)
        {
            builder.Clear();

            if (string.IsNullOrEmpty(entidad.Nombre)) builder.Append("Ingrese el nombre");
            return builder.Length == 0;
        }
    }
}
