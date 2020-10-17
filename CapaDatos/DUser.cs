using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidad.Cache;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using Microsoft.Win32;
using System.Runtime.Remoting;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DUser
    {
        public bool Login(string username, string password)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            bool res = false;

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "Login";

                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var drd = cmd.ExecuteReader();

                        if (drd.HasRows)
                        {
                            while (drd.Read())
                            {
                                UserCache.IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador"));
                                UserCache.Nombre = drd.GetString(drd.GetOrdinal("Nombre"));
                                UserCache.Apellidos = drd.GetString(drd.GetOrdinal("Apellidos"));
                                UserCache.Acceso = drd.GetString(drd.GetOrdinal("Acceso"));
                                UserCache.Email = drd.GetString(drd.GetOrdinal("Email"));
                                UserCache.Estado = drd.GetString(drd.GetOrdinal("Estado"));
                            }
                            res = true;
                        }else
                        {
                            res = false;
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return res;
        }
    }
}
