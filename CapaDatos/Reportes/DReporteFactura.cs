using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Entidad.Reportes;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos.Reportes
{
    public class DReporteFactura
    {
        public List<EReporteFactura> Mostrar(int idVenta)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EReporteFactura>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ReporteFactura";

                        cmd.Parameters.AddWithValue("@IdVenta", idVenta);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EReporteFactura()
                            {
                                IdVenta = drd.GetInt32(drd.GetOrdinal("IdVenta")),
                                Trabajador = drd.GetString(drd.GetOrdinal("Trabajador")),
                                Cliente = drd.GetString(drd.GetOrdinal("Cliente")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Fecha = drd.GetDateTime(drd.GetOrdinal("Fecha")),
                                TipoComprobante = drd.GetString(drd.GetOrdinal("TipoComprobante")),
                                Serie = drd.GetString(drd.GetOrdinal("Serie")),
                                Correlativo = drd.GetString(drd.GetOrdinal("Correlativo")),
                                Igv = drd.GetDecimal(drd.GetOrdinal("Igv")),
                                Articulo = drd.GetString(drd.GetOrdinal("Nombre")),
                                PrecioVenta = drd.GetDecimal(drd.GetOrdinal("PrecioVenta")),
                                Cantidad = drd.GetInt32(drd.GetOrdinal("Cantidad")),
                                Descuento = drd.GetDecimal(drd.GetOrdinal("Descuento")),
                                TotalParcial = drd.GetDecimal(drd.GetOrdinal("TotalParcial"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Factura Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
