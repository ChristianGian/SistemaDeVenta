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
    public class DCliente
    {
        public List<ECliente> Mostrar()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<ECliente>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarCliente";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new ECliente()
                            {
                                IdCliente = drd.GetInt32(drd.GetOrdinal("IdCliente")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Apellidos = drd.GetString(drd.GetOrdinal("Apellidos")),
                                Genero = drd.GetString(drd.GetOrdinal("Genero")),
                                FecNacimiento = drd.GetDateTime(drd.GetOrdinal("FecNacimiento")),
                                TipoDocumento = drd.GetString(drd.GetOrdinal("TipoDocumento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<ECliente> BuscarApellido(string apellido)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<ECliente>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarApellidosCliente";

                        cmd.Parameters.AddWithValue("@Apellidos", apellido);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new ECliente()
                            {
                                IdCliente = drd.GetInt32(drd.GetOrdinal("IdCliente")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Apellidos = drd.GetString(drd.GetOrdinal("Apellidos")),
                                Genero = drd.GetString(drd.GetOrdinal("Genero")),
                                FecNacimiento = drd.GetDateTime(drd.GetOrdinal("FecNacimiento")),
                                TipoDocumento = drd.GetString(drd.GetOrdinal("TipoDocumento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Cliente por Apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<ECliente> BuscarNumDocumento(string numDocumento)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<ECliente>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarNumDocumentoCliente";

                        cmd.Parameters.AddWithValue("@NumDocumento", numDocumento);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new ECliente()
                            {
                                IdCliente = drd.GetInt32(drd.GetOrdinal("IdCliente")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Apellidos = drd.GetString(drd.GetOrdinal("Apellidos")),
                                Genero = drd.GetString(drd.GetOrdinal("Genero")),
                                FecNacimiento = drd.GetDateTime(drd.GetOrdinal("FecNacimiento")),
                                TipoDocumento = drd.GetString(drd.GetOrdinal("TipoDocumento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Cliente por N° de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public bool Registrar(ECliente entidad)
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
                        cmd.CommandText = "RegistrarCliente";

                        cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", entidad.Apellidos);
                        cmd.Parameters.AddWithValue("@Genero", entidad.Genero);
                        cmd.Parameters.AddWithValue("@FecNacimiento", entidad.FecNacimiento);
                        cmd.Parameters.AddWithValue("@TipoDocumento", entidad.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumDocumento", entidad.NumDocumento);
                        cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                        cmd.Parameters.AddWithValue("@Email", entidad.Email);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Editar(ECliente entidad)
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
                        cmd.CommandText = "EditarCliente";

                        cmd.Parameters.AddWithValue("@IdCliente", entidad.IdCliente);
                        cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", entidad.Apellidos);
                        cmd.Parameters.AddWithValue("@Genero", entidad.Genero);
                        cmd.Parameters.AddWithValue("@FecNacimiento", entidad.FecNacimiento);
                        cmd.Parameters.AddWithValue("@TipoDocumento", entidad.TipoDocumento);
                        cmd.Parameters.AddWithValue("@NumDocumento", entidad.NumDocumento);
                        cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                        cmd.Parameters.AddWithValue("@Email", entidad.Email);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Editar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Eliminar(int idCliente)
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
                        cmd.CommandText = "EliminarCliente";

                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
