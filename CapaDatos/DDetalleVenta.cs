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
    public class DDetalleVenta
    {
        public List<EDetalleVenta> Mostrar(int idVenta)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EDetalleVenta>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostarDetalleVenta";

                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EDetalleVenta()
                            {
                                IdDetVenta = drd.GetInt32(drd.GetOrdinal("IdDetVenta")),
                                IdVenta = drd.GetInt32(drd.GetOrdinal("IdVenta")),
                                IdDetIngreso = drd.GetInt32(drd.GetOrdinal("IdDetIngreso")),
                                Articulo = drd.GetString(drd.GetOrdinal("Articulo")),
                                Cantidad = drd.GetInt32(drd.GetOrdinal("Cantidad")),
                                PrecioVenta = drd.GetDecimal(drd.GetOrdinal("PrecioVenta")),
                                Descuento = drd.GetDecimal(drd.GetOrdinal("Descuento")),
                                Subtotal = drd.GetDecimal(drd.GetOrdinal("Subtotal"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Detalle venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public bool Registrar(EDetalleVenta entidad)
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
                        cmd.CommandText = "RegistrarDetalleVenta";

                        cmd.Parameters.AddWithValue("@IdVenta", entidad.IdVenta);
                        cmd.Parameters.AddWithValue("@IdDetIngreso", entidad.IdDetIngreso);
                        cmd.Parameters.AddWithValue("@Cantidad", entidad.Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioVenta", entidad.PrecioVenta);
                        cmd.Parameters.AddWithValue("@Descuento", entidad.Descuento);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Detalle venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
