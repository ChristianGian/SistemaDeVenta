using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NArticulo
    {
        private DArticulo articulo = new DArticulo();
        public readonly StringBuilder builder = new StringBuilder();

        public List<EArticulo> MostrarArticulo()
        {
            return articulo.Mostrar();
        }

        public List<EArticulo> BuscarArticulo(string nombre)
        {
            return articulo.Buscar(nombre);
        }

        public bool RegistrarArticulo(EArticulo entidad)
        {
            if (Validar(entidad)) return articulo.Registrar(entidad);
            return false;
        }

        public bool EditarArticulo(EArticulo entidad)
        {
            if (Validar(entidad)) return articulo.Editar(entidad);
            else return false;
        }

        public bool EliminarArticulo(int idCategoria)
        {
            return articulo.Eliminar(idCategoria);
        }

        private bool Validar(EArticulo entidad)
        {
            builder.Clear();

            if (string.IsNullOrEmpty(entidad.Codigo)) builder.Append("Ingrese el código");
            if (string.IsNullOrEmpty(entidad.Nombre)) builder.Append("\nIngrese el nombre");
            if (entidad.IdCategoria == 0) builder.Append("\nSeleccione una categoría");
            if (entidad.IdPresentacion == 0) builder.Append("\nSeleccione una presentación");

            return builder.Length == 0;
        }
    }
}
