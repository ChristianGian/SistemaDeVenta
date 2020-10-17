using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad.Cache;
using CapaDatos;

namespace CapaNegocio
{
    public class NUser
    {
        private DUser user = new DUser();
        
        public bool LoginUser(string username, string password)
        {
            return user.Login(username, password);
        }
    }
}
