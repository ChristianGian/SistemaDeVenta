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
    public class DArticulo
    {
        public List<EArticulo> Mostrar()
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EArticulo>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "MostrarArticulo";

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EArticulo()
                            {
                                IdArticulo = drd.GetInt32(drd.GetOrdinal("IdArticulo")),
                                Codigo = drd.GetString(drd.GetOrdinal("Codigo")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Descripcion = drd.GetString(drd.GetOrdinal("Descripcion")),
                                Imagen = (byte[])drd["Imagen"],
                                IdCategoria = drd.GetInt32(drd.GetOrdinal("IdCategoria")),
                                Categoria = drd.GetString(drd.GetOrdinal("Categoria")),
                                IdPresentacion = drd.GetInt32(drd.GetOrdinal("IdPresentacion")),
                                Presentacion = drd.GetString(drd.GetOrdinal("Presentacion"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Mostrar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public List<EArticulo> Buscar(string nombre)
        {
            var cadena = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
            var lista = new List<EArticulo>();

            using (var cn = new SqlConnection(cadena))
            {
                try
                {
                    if (cn.State == ConnectionState.Closed) cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "BuscarArticulo";

                        cmd.Parameters.AddWithValue("@Nombre", nombre);

                        var drd = cmd.ExecuteReader();

                        while (drd.Read())
                        {
                            var enti = new EArticulo()
                            {
                                IdArticulo = drd.GetInt32(drd.GetOrdinal("IdCategoria")),
                                Codigo = drd.GetString(drd.GetOrdinal("Codigo")),
                                Nombre = drd.GetString(drd.GetOrdinal("Nombre")),
                                Descripcion = drd.GetString(drd.GetOrdinal("Descripcion")),
                                Imagen = (byte[])drd["Imagen"],
                                IdCategoria = drd.GetInt32(drd.GetOrdinal("IdCategoria")),
                                Categoria = drd.GetString(drd.GetOrdinal("Categoria")),
                                IdPresentacion = drd.GetInt32(drd.GetOrdinal("IdPresentacion")),
                                Presentacion = drd.GetString(drd.GetOrdinal("Presentacion"))
                            };
                            lista.Add(enti);
                        }
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Buscar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            return lista;
        }

        public bool Registrar(EArticulo entidad)
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
                        cmd.CommandText = "RegistrarArticulo";

                        cmd.Parameters.AddWithValue("@Codigo", entidad.Codigo);
                        cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                        cmd.Parameters.AddWithValue("@Imagen", entidad.Imagen);
                        cmd.Parameters.AddWithValue("@IdCategoria", entidad.IdCategoria);
                        cmd.Parameters.AddWithValue("@IdPresentacion", entidad.IdPresentacion);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Registrar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Editar(EArticulo entidad)
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
                        cmd.CommandText = "EditarArticulo";

                        cmd.Parameters.AddWithValue("@IdArticulo", entidad.IdArticulo);
                        cmd.Parameters.AddWithValue("@Codigo", entidad.Codigo);
                        cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                        cmd.Parameters.AddWithValue("@Imagen", entidad.Imagen);
                        cmd.Parameters.AddWithValue("@IdCategoria", entidad.IdCategoria);
                        cmd.Parameters.AddWithValue("@IdPresentacion", entidad.IdPresentacion);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Editar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (cn.State == ConnectionState.Open) cn.Close();
                }
            }
            if (res == 1) return true;
            else return false;
        }

        public bool Eliminar(int idArticulo)
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
                        cmd.CommandText = "EliminarArticulo";

                        cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);

                        res = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "SQL Error Eliminar Artículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
