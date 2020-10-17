using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DStock
    {
        public List<EStock> ConsultarStock()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EStock>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ConsultarStock";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EStock()
                            {
                                Codigo = drd.GetString(drd.GetOrdinal("Codigo")),
                                Articulo = drd.GetString(drd.GetOrdinal("Articulo")),
                                Categoria = drd.GetString(drd.GetOrdinal("Categoria")),
                                StockInicial = drd.GetInt32(drd.GetOrdinal("StockInicial")),
                                StockActual = drd.GetInt32(drd.GetOrdinal("StockActual")),
                                CantidadVentas = drd.GetInt32(drd.GetOrdinal("CantidadVentas"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar stock de artículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }
    }
}
