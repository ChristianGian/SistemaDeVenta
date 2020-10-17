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
    public class DDetalleIngreso
    {
        public List<EDetalleIngreso> Mostrar(int idIngreso)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EDetalleIngreso>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarDetalleIngreso";

                        cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EDetalleIngreso()
                            {
                                IdArticulo = drd.GetInt32(drd.GetOrdinal("IdArticulo")),
                                Articulo = drd.GetString(drd.GetOrdinal("Articulo")),
                                PrecioCompra = drd.GetDecimal(drd.GetOrdinal("PrecioCompra")),
                                PrecioVenta = drd.GetDecimal(drd.GetOrdinal("PrecioVenta")),
                                StockInicial = drd.GetInt32(drd.GetOrdinal("StockInicial")),
                                FecProduccion = drd.GetDateTime(drd.GetOrdinal("FecProduccion")),
                                FecVencimiento = drd.GetDateTime(drd.GetOrdinal("FecVencimiento")),
                                Subtotal = drd.GetDecimal(drd.GetOrdinal("Subtotal"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Detalle ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public bool Registrar(EDetalleIngreso entidad)
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
                        cmd.CommandText = "RegistrarDetalleIngreso";

                        cmd.Parameters.AddWithValue("@IdIngreso", entidad.IdIngreso);
                        cmd.Parameters.AddWithValue("@IdArticulo", entidad.IdArticulo);
                        cmd.Parameters.AddWithValue("@PrecioCompra", entidad.PrecioCompra);
                        cmd.Parameters.AddWithValue("@PrecioVenta", entidad.PrecioVenta);
                        cmd.Parameters.AddWithValue("@StockInicial", entidad.StockInicial);
                        cmd.Parameters.AddWithValue("@StockActual", entidad.StockActual);
                        cmd.Parameters.AddWithValue("@FecProduccion", entidad.FecProduccion);
                        cmd.Parameters.AddWithValue("@FecVencimiento", entidad.FecVencimiento);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Detalle ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool DisminuiStock(int idDetIngreso, int cantidad)
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
                        cmd.CommandText = "DisminuirStock";

                        cmd.Parameters.AddWithValue("@IdDetIngreso", idDetIngreso);
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Disminuir Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
