using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using Entidad;

namespace CapaNegocio
{
    public class NStock
    {
        //Campos
        private DStock stock = new DStock();

        public List<EStock> ConsultarStock()
        {
            return stock.ConsultarStock();
        }
    }
}
