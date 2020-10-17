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
    public class DTrabajador
    {
        public List<ETrabajador> Mostrar()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<ETrabajador>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarTrabajador";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new ETrabajador()
                            {
                                IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Apellidos = drd.GetString(drd.GetOrdinal("Apellidos")),
                                Genero = drd.GetString(drd.GetOrdinal("Genero")),
                                FecNacimiento = drd.GetDateTime(drd.GetOrdinal("FecNacimiento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email")),
                                Acceso = drd.GetString(drd.GetOrdinal("Acceso")),
                                Username = drd.GetString(drd.GetOrdinal("Username")),
                                Password = drd.GetString(drd.GetOrdinal("Password")),
                                Estado = drd.GetString(drd.GetOrdinal("Estado"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<ETrabajador> BuscarApellido(string apellido)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<ETrabajador>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarApellidosTrabajador";

                        cmd.Parameters.AddWithValue("@Apellidos", apellido);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new ETrabajador()
                            {
                                IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Apellidos = drd.GetString(drd.GetOrdinal("Apellidos")),
                                Genero = drd.GetString(drd.GetOrdinal("Genero")),
                                FecNacimiento = drd.GetDateTime(drd.GetOrdinal("FecNacimiento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email")),
                                Acceso = drd.GetString(drd.GetOrdinal("Acceso")),
                                Username = drd.GetString(drd.GetOrdinal("Username")),
                                Password = drd.GetString(drd.GetOrdinal("Password")),
                                Estado = drd.GetString(drd.GetOrdinal("Estado"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Trabajador por Apellido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<ETrabajador> BuscarNumDocumento(string numDocumento)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<ETrabajador>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarNumDocumentoTrabajador";

                        cmd.Parameters.AddWithValue("@NumDocumento", numDocumento);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new ETrabajador()
                            {
                                IdTrabajador = drd.GetInt32(drd.GetOrdinal("IdTrabajador")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Apellidos = drd.GetString(drd.GetOrdinal("Apellidos")),
                                Genero = drd.GetString(drd.GetOrdinal("Genero")),
                                FecNacimiento = drd.GetDateTime(drd.GetOrdinal("FecNacimiento")),
                                NumDocumento = drd.GetString(drd.GetOrdinal("NumDocumento")),
                                Direccion = drd.GetString(drd.GetOrdinal("Direccion")),
                                Telefono = drd.GetString(drd.GetOrdinal("Telefono")),
                                Email = drd.GetString(drd.GetOrdinal("Email")),
                                Acceso = drd.GetString(drd.GetOrdinal("Acceso")),
                                Username = drd.GetString(drd.GetOrdinal("Username")),
                                Password = drd.GetString(drd.GetOrdinal("Password")),
                                Estado = drd.GetString(drd.GetOrdinal("Estado"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Trabajador por N° de Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public bool Registrar(ETrabajador entidad)
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
                        cmd.CommandText = "RegistrarTrabajador";

                        cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", entidad.Apellidos);
                        cmd.Parameters.AddWithValue("@Genero", entidad.Genero);
                        cmd.Parameters.AddWithValue("@FecNacimiento", entidad.FecNacimiento);
                        cmd.Parameters.AddWithValue("@NumDocumento", entidad.NumDocumento);
                        cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                        cmd.Parameters.AddWithValue("@Email", entidad.Email);
                        cmd.Parameters.AddWithValue("@Acceso", entidad.Acceso);
                        cmd.Parameters.AddWithValue("@Username", entidad.Username);
                        cmd.Parameters.AddWithValue("@Password", entidad.Password);
                        cmd.Parameters.AddWithValue("@Estado", entidad.Estado);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Editar(ETrabajador entidad)
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
                        cmd.CommandText = "EditarTrabajador";

                        cmd.Parameters.AddWithValue("@IdTrabajador", entidad.IdTrabajador);
                        cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", entidad.Apellidos);
                        cmd.Parameters.AddWithValue("@Genero", entidad.Genero);
                        cmd.Parameters.AddWithValue("@FecNacimiento", entidad.FecNacimiento);
                        cmd.Parameters.AddWithValue("@NumDocumento", entidad.NumDocumento);
                        cmd.Parameters.AddWithValue("@Direccion", entidad.Direccion);
                        cmd.Parameters.AddWithValue("@Telefono", entidad.Telefono);
                        cmd.Parameters.AddWithValue("@Email", entidad.Email);
                        cmd.Parameters.AddWithValue("@Acceso", entidad.Acceso);
                        cmd.Parameters.AddWithValue("@Username", entidad.Username);
                        cmd.Parameters.AddWithValue("@Password", entidad.Password);
                        cmd.Parameters.AddWithValue("@Estado", entidad.Estado);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Editar Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Eliminar(int idTrabajador)
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
                        cmd.CommandText = "EliminarTrabajador";

                        cmd.Parameters.AddWithValue("@IdTrabajador", idTrabajador);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Eliminar Trabajador", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
