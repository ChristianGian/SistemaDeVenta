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
    public class DProveedor
    {
        public List<EProveedor> Mostrar()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EProveedor>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarProveedor";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EProveedor()
                            {
                                IdProveedor = drd.GetInt32(drd.GetOrdinal("IdProveedor")),
                                RazonSocial = drd.GetString(drd.GetOrdinal("RazonSocial")),
                                SectorComercial = drd.GetString(drd.GetOrdinal("SectorComercial")),
                                TipoDocumento = drd.GetString(drd.GetOrdinal("TipoDocumento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email")),
                                Url = drd.GetString(drd.GetOrdinal("Url"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<EProveedor> BuscarRazonSocial(string razonSocial)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EProveedor>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarRazonSocialProveedor";

                        cmd.Parameters.AddWithValue("@RazonSocial", razonSocial);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EProveedor()
                            {
                                IdProveedor = drd.GetInt32(drd.GetOrdinal("IdProveedor")),
                                RazonSocial = drd.GetString(drd.GetOrdinal("RazonSocial")),
                                SectorComercial = drd.GetString(drd.GetOrdinal("SectorComercial")),
                                TipoDocumento = drd.GetString(drd.GetOrdinal("TipoDocumento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email")),
                                Url = drd.GetString(drd.GetOrdinal("Url"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Proveedor por Razón Social", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<EProveedor> BuscarNumDocumento(string numDocumento)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EProveedor>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarNumDocumentoProveedor";

                        cmd.Parameters.AddWithValue("@NumDocumento", numDocumento);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EProveedor()
                            {
                                IdProveedor = drd.GetInt32(drd.GetOrdinal("IdProveedor")),
                                RazonSocial = drd.GetString(drd.GetOrdinal("RazonSocial")),
                                SectorComercial = drd.GetString(drd.GetOrdinal("SectorComercial")),
                                TipoDocumento = drd.GetString(drd.GetOrdinal("TipoDocumento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email")),
                                Url = drd.GetString(drd.GetOrdinal("Url"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Proveedor por N° de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public bool Registrar(EProveedor entidad)
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
                        cmd.CommandText = "RegistrarProveedor";

                        cmd.Parameters.AddWithValue("@RazonSocial", entidad.RazonSocial);
                        cmd.Parameters.AddWithValue("@SectorComercial", entidad.SectorComercial);
                        cmd.Parameters.AddWithValue("@TipoDocumento", entidad.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumDocumento", entidad.NumDocumento);
                        cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                        cmd.Parameters.AddWithValue("@Email", entidad.Email);
                        cmd.Parameters.AddWithValue("@Url", entidad.Url);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Editar(EProveedor entidad)
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
                        cmd.CommandText = "EditarProveedor";

                        cmd.Parameters.AddWithValue("@IdProveedor", entidad.IdProveedor);
                        cmd.Parameters.AddWithValue("@RazonSocial", entidad.RazonSocial);
                        cmd.Parameters.AddWithValue("@SectorComercial", entidad.SectorComercial);
                        cmd.Parameters.AddWithValue("@TipoDocumento", entidad.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumDocumento", entidad.NumDocumento);
                        cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                        cmd.Parameters.AddWithValue("@Email", entidad.Email);
                        cmd.Parameters.AddWithValue("@Url", entidad.Url);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Eliminar(int idProveedor)
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
                        cmd.CommandText = "EliminarProveedor";

                        cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
