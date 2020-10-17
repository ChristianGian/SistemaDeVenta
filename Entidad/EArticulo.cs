using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EArticulo
    {
        public int IdArticulo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public int IdPresentacion { get; set; }
        public string Presentacion { get; set; }
    }
}
