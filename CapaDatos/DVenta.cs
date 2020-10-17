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
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace CapaDatos
{
    public class DVenta
    {
        public List<EVenta> Mostrar()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EVenta>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarVenta";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EVenta()
                            {
                                IdVenta = drd.GetInt32(drd.GetOrdinal("IdVenta")),
                                IdCliente = drd.GetInt32(drd.GetOrdinal("IdCliente")),
                                Cliente = drd.GetString(drd.GetOrdinal("Cliente")),
                                IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador")),
                                Trabajador = drd.GetString(drd.GetOrdinal("Trabajador")),
                                Fecha = drd.GetDateTime(drd.GetOrdinal("Fecha")),
                                TipoComprobante = drd.GetString(drd.GetOrdinal("TipoComprobante")),
                                Serie = drd.GetString(drd.GetOrdinal("Serie")),
                                Correlativo = drd.GetString(drd.GetOrdinal("Correlativo")),
                                Igv = drd.GetDecimal(drd.GetOrdinal("Igv")),
                                Total = drd.GetDecimal(drd.GetOrdinal("Total"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<EVenta> BuscarEntreFechas(DateTime fecInicio, DateTime fecFinal)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EVenta>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarEntreFechasVentas";

                        cmd.Parameters.AddWithValue("@FecInicio", fecInicio);
                        cmd.Parameters.AddWithValue("@FecFin", fecFinal);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EVenta()
                            {
                                IdVenta = drd.GetInt32(drd.GetOrdinal("IdVenta")),
                                IdCliente = drd.GetInt32(drd.GetOrdinal("IdCliente")),
                                Cliente = drd.GetString(drd.GetOrdinal("Cliente")),
                                IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador")),
                                Trabajador = drd.GetString(drd.GetOrdinal("Trabajador")),
                                Fecha = drd.GetDateTime(drd.GetOrdinal("Fecha")),
                                TipoComprobante = drd.GetString(drd.GetOrdinal("TipoComprobante")),
                                Serie = drd.GetString(drd.GetOrdinal("Serie")),
                                Correlativo = drd.GetString(drd.GetOrdinal("Correlativo")),
                                Igv = drd.GetDecimal(drd.GetOrdinal("Igv")),
                                Total = drd.GetDecimal(drd.GetOrdinal("Total"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Venta por fechas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public int Registrar(EVenta entidad)
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
                        cmd.CommandText = "RegistrarVenta";

                        cmd.Parameters.AddWithValue("@IdCliente", entidad.IdCliente);
                        cmd.Parameters.AddWithValue("@IdTrabajador", entidad.IdTrabajador);
                        cmd.Parameters.AddWithValue("@Fecha", entidad.Fecha);
                        cmd.Parameters.AddWithValue("@TipoComprobante", entidad.TipoComprobante);
                        cmd.Parameters.AddWithValue("@Serie", entidad.Serie);
                        cmd.Parameters.AddWithValue("@Correlativo", entidad.Correlativo);
                        cmd.Parameters.AddWithValue("@Igv", entidad.Igv);
                        cmd.Parameters.Add("@IdUltimo", SqlDbType.Int).Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();

                        idUltimo = int.Parse(cmd.Parameters["@IdUltimo"].Value.ToString());
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return idUltimo;
        }

        public bool Eliminar(int idVenta)
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
                        cmd.CommandText = "EliminarVenta";

                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Eliminar Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 2) return true;
            else return false;
        }

        public bool DisminuirStock(int idDetIngreso, int cantidad)
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
                    MessageBox.Show(e.Message, "Error SQL Disminuir stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        //Mostrar artículos para la venta
        public List<EArticuloParaVenta> MostrarArticulosParaVenta()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EArticuloParaVenta>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarArticulosParaVenta";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EArticuloParaVenta()
                            {
                                IdDetIngreso = drd.GetInt32(drd.GetOrdinal("IdDetIngreso")),
                                Codigo = drd.GetString(drd.GetOrdinal("Codigo")),
                                IdArticulo = drd.GetInt32(drd.GetOrdinal("IdArticulo")),
                                Articulo = drd.GetString(drd.GetOrdinal("Articulo")),
                                Categoria = drd.GetString(drd.GetOrdinal("Categoria")),
                                Presentacion = drd.GetString(drd.GetOrdinal("Presentacion")),
                                StockActual = drd.GetInt32(drd.GetOrdinal("StockActual")),
                                PrecioCompra = drd.GetDecimal(drd.GetOrdinal("PrecioCompra")),
                                PrecioVenta = drd.GetDecimal(drd.GetOrdinal("PrecioVenta")),
                                FechaVencimiento = drd.GetDateTime(drd.GetOrdinal("FecVencimiento"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar artículos para venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<EArticuloParaVenta> BuscarArticuloPorNombre(string nombre)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EArticuloParaVenta>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarArticulosPorNombreParaVenta";

                        cmd.Parameters.AddWithValue("@Nombre", nombre);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EArticuloParaVenta()
                            {
                                IdDetIngreso = drd.GetInt32(drd.GetOrdinal("IdDetIngreso")),
                                Codigo = drd.GetString(drd.GetOrdinal("Codigo")),
                                IdArticulo = drd.GetInt32(drd.GetOrdinal("IdArticulo")),
                                Articulo = drd.GetString(drd.GetOrdinal("Articulo")),
                                Categoria = drd.GetString(drd.GetOrdinal("Categoria")),
                                Presentacion =drd.GetString(drd.GetOrdinal("Presentacion")),
                                StockActual = drd.GetInt32(drd.GetOrdinal("StockActual")),
                                PrecioCompra = drd.GetDecimal(drd.GetOrdinal("PrecioCompra")),
                                PrecioVenta = drd.GetDecimal(drd.GetOrdinal("PrecioVenta")),
                                FechaVencimiento = drd.GetDateTime(drd.GetOrdinal("FecVencimiento"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Artículo por nombre", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<EArticuloParaVenta> BuscarArticuloPorCodigo(string codigo)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EArticuloParaVenta>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarArticulosPorCodigoParaVenta";

                        cmd.Parameters.AddWithValue("@Codigo", codigo);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EArticuloParaVenta()
                            {
                                IdDetIngreso = drd.GetInt32(drd.GetOrdinal("IdDetIngreso")),
                                Codigo = drd.GetString(drd.GetOrdinal("Codigo")),
                                IdArticulo = drd.GetInt32(drd.GetOrdinal("IdArticulo")),
                                Articulo = drd.GetString(drd.GetOrdinal("Articulo")),
                                Categoria = drd.GetString(drd.GetOrdinal("Categoria")),
                                Presentacion = drd.GetString(drd.GetOrdinal("Presentacion")),
                                StockActual = drd.GetInt32(drd.GetOrdinal("StockActual")),
                                PrecioCompra = drd.GetDecimal(drd.GetOrdinal("PrecioCompra")),
                                PrecioVenta = drd.GetDecimal(drd.GetOrdinal("PrecioVenta")),
                                FechaVencimiento = drd.GetDateTime(drd.GetOrdinal("FecVencimiento"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Artículo por código", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
