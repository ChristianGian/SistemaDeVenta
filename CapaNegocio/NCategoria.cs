using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using CapaDatos;

namespace CapaNegocio
{
    public class NCategoria
    {
        private DCategoria categoria = new DCategoria();
        public readonly StringBuilder builder = new StringBuilder();

        public List<ECategoria> MostrarCategoria()
        {
            return categoria.Mostrar();
        }

        public List<ECategoria> BuscarCategoria(string nombre)
        {
            return categoria.Buscar(nombre);
        }

        public bool RegistrarCategoria(ECategoria entidad)
        {
            if (Validar(entidad)) return categoria.Registrar(entidad);
            return false;
        }

        public bool EditarCategoria(ECategoria entidad)
        {
            if (Validar(entidad)) return categoria.Editar(entidad);
            else return false;
        }

        public bool EliminarCategoria(int idCategoria)
        {
            return categoria.Eliminar(idCategoria);
        }

        private bool Validar(ECategoria entidad)
        {
            builder.Clear();

            if (string.IsNullOrEmpty(entidad.Nombre)) builder.Append("Ingrese el nombre");

            return builder.Length == 0;
        }
    }
}
