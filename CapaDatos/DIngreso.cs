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
    public class DIngreso
    {
        public List<EIngreso> Mostrar()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EIngreso>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarIngresos";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EIngreso()
                            {
                                IdIngreso = drd.GetInt32(drd.GetOrdinal("IdIngreso")),
                                IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador")),
                                Trabajador = drd.GetString(drd.GetOrdinal("Trabajador")),
                                IdProveedor = drd.GetInt32(drd.GetOrdinal("IdProveedor")),
                                Proveedor = drd.GetString(drd.GetOrdinal("Proveedor")),
                                Fecha = drd.GetDateTime(drd.GetOrdinal("Fecha")),
                                TipoComprobante = drd.GetString(drd.GetOrdinal("TipoComprobante")),
                                Serie = drd.GetString(drd.GetOrdinal("Serie")),
                                Correlativo = drd.GetString(drd.GetOrdinal("Correlativo")),
                                Igv = drd.GetDecimal(drd.GetOrdinal("Igv")),
                                Estado = drd.GetString(drd.GetOrdinal("Estado")),
                                Total = drd.GetDecimal(drd.GetOrdinal("Total"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<EIngreso> MostrarEntreFechas(DateTime fecInicial, DateTime fecFinal)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EIngreso>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarIngresosEntreFechas";

                        cmd.Parameters.AddWithValue("@FecInicial", fecInicial);
                        cmd.Parameters.AddWithValue("@FecFinal", fecFinal);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EIngreso()
                            {
                                IdIngreso = drd.GetInt32(drd.GetOrdinal("IdIngreso")),
                                IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador")),
                                Trabajador = drd.GetString(drd.GetOrdinal("Trabajador")),
                                IdProveedor = drd.GetInt32(drd.GetOrdinal("IdProveedor")),
                                Proveedor = drd.GetString(drd.GetOrdinal("Proveedor")),
                                Fecha = drd.GetDateTime(drd.GetOrdinal("Fecha")),
                                TipoComprobante = drd.GetString(drd.GetOrdinal("TipoComprobante")),
                                Serie = drd.GetString(drd.GetOrdinal("Serie")),
                                Correlativo = drd.GetString(drd.GetOrdinal("Correlativo")),
                                Igv = drd.GetDecimal(drd.GetOrdinal("Igv")),
                                Estado = drd.GetString(drd.GetOrdinal("Estado")),
                                Total = drd.GetDecimal(drd.GetOrdinal("Total"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Ingreso entre fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public int Registrar(EIngreso entidad)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            int idUltimo = 0;

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "RegistrarIngreso";

                        cmd.Parameters.AddWithValue("@IdTrabajador", entidad.IdTrabajador);
                        cmd.Parameters.AddWithValue("@IdProveedor", entidad.IdProveedor);
                        cmd.Parameters.AddWithValue("@Fecha", entidad.Fecha);
                        cmd.Parameters.AddWithValue("@TipoComprobante", entidad.TipoComprobante);
                        cmd.Parameters.AddWithValue("@Serie", entidad.Serie);
                        cmd.Parameters.AddWithValue("@Correlativo", entidad.Correlativo);
                        cmd.Parameters.AddWithValue("@Igv", entidad.Igv);
                        cmd.Parameters.AddWithValue("@Estado", entidad.Estado);
                        cmd.Parameters.Add("@IdUltimo", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        idUltimo = int.Parse(cmd.Parameters["@IdUltimo"].Value.ToString());
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return idUltimo;
        }

        public bool Anular(int idIngreso)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            int res = 0;

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "AnularIngreso";

                        cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Anular Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }
    }
}
