using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;
using System.Configuration;

namespace Datos
{
    public class D_Articulo : D_ConexionBD
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public string InsertarArticulo(E_Articulo articulo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("IBM_Articulos", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
                    cmd.Parameters.AddWithValue("@IdArticulo", articulo.IdArticulo);
                    cmd.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
                    cmd.Parameters.AddWithValue("@CodigoArticulo", articulo.CodigoArticulo);
                    cmd.Parameters.AddWithValue("@NombreArticulo", articulo.NombreArticulo);
                    cmd.Parameters.AddWithValue("@PrecioVenta", articulo.PrecioVenta);
                    cmd.Parameters.AddWithValue("@DescripcionArticulo", articulo.DescripcionArticulo);
                    cmd.Parameters.AddWithValue("@DescripcionImagen", articulo.DescripcionArticulo); // Usar el mismo campo.
                    cmd.Parameters.AddWithValue("@SubCategoria", articulo.SubCategoria);
                    cmd.Parameters.AddWithValue("@Imagenes", articulo.Imagenes); // CAMBIAR POR IDIMAGEN
                    cmd.Parameters.AddWithValue("@IdTalla", articulo.IdTalla); // Adding the missing parameter
                    cmd.Parameters.AddWithValue("@Stock", articulo.Stock);
                    cmd.Parameters.AddWithValue("@IdImagen", articulo.IdImagen);
                    cmd.Parameters.AddWithValue("@Estado", true); // Se inserta activo por defecto.
                    cmd.Parameters.AddWithValue("@Genero", articulo.Genero);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return "Artículo insertado correctamente.";
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el artículo: " + ex.Message, ex);
                }
            }
        }

        public bool BorrarArticulo(int idArticulo)
        {
            E_Articulo articulo = new E_Articulo();
            try
            {
                SqlCommand cmd = new SqlCommand("IBM_Articulo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado
                cmd.Parameters.AddWithValue("@Accion", "BORRAR");
                cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);
                cmd.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
                cmd.Parameters.AddWithValue("@CodigoArticulo", articulo.CodigoArticulo);
                cmd.Parameters.AddWithValue("@NombreArticulo", articulo.NombreArticulo);
                cmd.Parameters.AddWithValue("@PrecioVenta", articulo.PrecioVenta);
                cmd.Parameters.AddWithValue("@DescripcionArticulo", articulo.DescripcionArticulo);
                cmd.Parameters.AddWithValue("@DescripcionImagen", articulo.DescripcionArticulo); // Usar el mismo campo.
                cmd.Parameters.AddWithValue("@SubCategoria", articulo.SubCategoria);
                cmd.Parameters.AddWithValue("@Imagen", articulo.Imagenes); // CAMBIAR POR IDIMAGEN
                cmd.Parameters.AddWithValue("@Talla", articulo.Talla);
                cmd.Parameters.AddWithValue("@Stock", articulo.Stock);
                cmd.Parameters.AddWithValue("@Estado", false); // Se inserta activo por defecto.
                cmd.Parameters.AddWithValue("@IdTalla", articulo.IdTalla); // Adding the missing parameter
                cmd.Parameters.AddWithValue("@IdImagen", articulo.IdImagen);
                cmd.Parameters.AddWithValue("@Genero", articulo.Genero);

                conexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al borrar la Articulo: ", ex.Message);
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public bool ModificarArticulo(E_Articulo articulo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("IBM_Articulo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado
                cmd.Parameters.AddWithValue("@Accion", "MODIFICAR");
                cmd.Parameters.AddWithValue("@IdArticulo", articulo.IdArticulo);
                cmd.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
                cmd.Parameters.AddWithValue("@CodigoArticulo", articulo.CodigoArticulo);
                cmd.Parameters.AddWithValue("@NombreArticulo", articulo.NombreArticulo);
                cmd.Parameters.AddWithValue("@PrecioVenta", articulo.PrecioVenta);
                cmd.Parameters.AddWithValue("@DescripcionArticulo", articulo.DescripcionArticulo);
                cmd.Parameters.AddWithValue("@DescripcionImagen", articulo.DescripcionArticulo); // Usar el mismo campo
                cmd.Parameters.AddWithValue("@SubCategoria", articulo.SubCategoria);
                cmd.Parameters.AddWithValue("@Imagen", articulo.Imagenes);
                cmd.Parameters.AddWithValue("@IdTalla", articulo.IdTalla);
                cmd.Parameters.AddWithValue("@Talla", articulo.Talla);
                cmd.Parameters.AddWithValue("@IdImagen", articulo.IdImagen);
                cmd.Parameters.AddWithValue("@Stock", articulo.Stock);
                cmd.Parameters.AddWithValue("@Estado", articulo.Estado); // Se inserta activo por defecto
                cmd.Parameters.AddWithValue("@Genero", articulo.Genero);

                AbrirConexion();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public List<E_Articulo> ListarArticulos()
        {
            List<E_Articulo> LstArticulos = new List<E_Articulo>();

            try
            {
                SqlCommand cmd = new SqlCommand("LstArticulos", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Articulo Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            CodigoArticulo = reader["CodigoArticulo"]?.ToString() ?? string.Empty,
                            NombreArticulo = reader["NombreArticulo"]?.ToString() ?? string.Empty,
                            PrecioVenta = reader["PrecioVenta"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["PrecioVenta"]),
                            DescripcionArticulo = reader["DescripcionArticulo"]?.ToString() ?? string.Empty,
                            Estado = reader["Estado"] == DBNull.Value ? false : Convert.ToBoolean(reader["Estado"]),
                            IdImagen = reader["IdImagen"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdImagen"]),
                            Imagenes = reader["Imagen"]?.ToString() ?? string.Empty, //!ARREGLAR EN EL SP EN EL LSTARTICULOS
                            Stock = reader["Stock"].ToString(),
                            Talla = reader["Talla"].ToString(),
                            //Genero = reader["Genero"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Genero"]),
                        };

                        Articulo.Imagenes = "/Recursos/Imagenes/" + Articulo.Imagenes;


                        LstArticulos.Add(Articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return LstArticulos;
        }
        public List<E_Articulo> ListarArticulosPorGenero(int idGenero)
        {
            List<E_Articulo> LstArticulos = new List<E_Articulo>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerArticulosGenero", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdGenero", idGenero);

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Articulo Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            NombreArticulo = reader["NombreArticulo"]?.ToString() ?? string.Empty,
                            CodigoArticulo = reader["CodigoArticulo"]?.ToString() ?? string.Empty,
                            DescripcionArticulo = reader["DescripcionArticulo"]?.ToString() ?? string.Empty,
                            PrecioVenta = reader["PrecioVenta"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["PrecioVenta"]),
                            Imagenes = reader["Imagen"]?.ToString() ?? string.Empty,
                            Genero = reader["IdGenero"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdGenero"]),
                        };

                        Articulo.Imagenes = "/Recursos/Imagenes/" + Articulo.Imagenes;


                        LstArticulos.Add(Articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR LISTAR POR GENERO (DATOS)");


                throw new Exception("Error al listar artículos por categoría: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return LstArticulos;
        }
        public List<E_Articulo> ListarPorCategoria(int idGenero, int idCategoria)
        {
            List<E_Articulo> LstArticulos = new List<E_Articulo>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerArticulosPorCategoria", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                cmd.Parameters.AddWithValue("@IdGenero", idGenero);

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Articulo Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            NombreArticulo = reader["NombreArticulo"]?.ToString() ?? string.Empty,
                            CodigoArticulo = reader["CodigoArticulo"]?.ToString() ?? string.Empty,
                            DescripcionArticulo = reader["DescripcionArticulo"]?.ToString() ?? string.Empty,
                            PrecioVenta = reader["PrecioVenta"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["PrecioVenta"]),
                            Imagenes = reader["Imagen"]?.ToString() ?? string.Empty,
                            NombreCategoria = reader["NombreCategoria"]?.ToString() ?? string.Empty,
                            Genero = reader["IdGenero"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdGenero"]),
                        };

                        Articulo.Imagenes = "/Recursos/Imagenes/" + Articulo.Imagenes;
                        //System.Diagnostics.Debug.WriteLine("{Articulo.Stock}" + Articulo.NombreArticulo + " ::::: " + Articulo.NombreCategoria);

                        LstArticulos.Add(Articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR LISTAR POR CATEGORIA (DATOS)");

                throw new Exception("Error al listar artículos por categoría: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return LstArticulos;

        }
        public List<E_Articulo> ListarPorSubCategoria(int idGenero, int idSubCategoria)
        {
            List<E_Articulo> LstArticulos = new List<E_Articulo>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerArticulosPorSubCategoria", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@IdSubCategoria", idSubCategoria);
                cmd.Parameters.AddWithValue("@IdGenero", idGenero);

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Articulo Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            NombreArticulo = reader["NombreArticulo"]?.ToString() ?? string.Empty,
                            CodigoArticulo = reader["CodigoArticulo"]?.ToString() ?? string.Empty,
                            DescripcionArticulo = reader["DescripcionArticulo"]?.ToString() ?? string.Empty,
                            PrecioVenta = reader["PrecioVenta"] == DBNull.Value ? 0.0 : Convert.ToDouble(reader["PrecioVenta"]),
                            Imagenes = reader["Imagen"]?.ToString() ?? string.Empty,
                            SubCategoria = reader["SubCategoria"]?.ToString() ?? string.Empty,
                            Genero = reader["IdGenero"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdGenero"]),
                        };

                        Articulo.Imagenes = "/Recursos/Imagenes/" + Articulo.Imagenes;
                        //System.Diagnostics.Debug.WriteLine("{Articulo.Stock}" + Articulo.NombreArticulo + " ::::: " + Articulo.SubCategoria);


                        LstArticulos.Add(Articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR LISTAR POR SUBCATEGORIA (DATOS)");

                throw new Exception("Error al listar artículos por subcategoría: " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return LstArticulos;
        }
        public E_Articulo BuscarArticuloPorID(int idArticulo)
        {
            E_Articulo Articulo = null;

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerArticulo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            NombreArticulo = reader["NombreArticulo"].ToString(),
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            CodigoArticulo = reader["CodigoArticulo"].ToString(),
                            DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"].ToString()),
                            Estado = Convert.ToBoolean(reader["Estado"]),
                            IdImagen = Convert.ToInt32(reader["IdImagen"]),
                            Stock = reader["Tallas_Stock"].ToString(), // Cambiado para coincidir con el nombre del SP

                        };
                        //System.Diagnostics.Debug.WriteLine("{Articulo.Stock}" + Articulo.NombreArticulo + " ::::: " + Articulo.Stock );

                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                System.Diagnostics.Debug.WriteLine("ERROR EN BUSCAR ARTICULO POR ID (DATOS)");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return Articulo;
        }
        public E_Articulo BuscarArticuloPorCodigo(string codigoArticulo)
        {
            E_Articulo Articulo = null;

            try
            {
                SqlCommand cmd = new SqlCommand("BuscarArticuloPorCodigo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codigoArticulo", codigoArticulo);

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            CodigoArticulo = reader["CodigoArticulo"].ToString(),
                            NombreArticulo = reader["NombreArticulo"].ToString(),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"].ToString()),
                            DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"]),
                            IdImagen = Convert.ToInt32(reader["IdImagen"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CerrarConexion();
            }

            return Articulo;
        }
        public List<E_Articulo> BuscarArticuloPorCriterio(string criterio)
        {
            List<E_Articulo> LstArticulos = new List<E_Articulo>();

            try
            {
                SqlCommand cmd = new SqlCommand("BuscarArticuloPorCriterio", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Criterio", criterio);

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Articulo Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            CodigoArticulo = reader["CodigoArticulo"].ToString(),
                            NombreArticulo = reader["NombreArticulo"].ToString(),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"].ToString()),
                            DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"]),
                            IdImagen = Convert.ToInt32(reader["IdImagen"])
                        };
                        LstArticulos.Add(Articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return LstArticulos;
            }
            finally
            {
                CerrarConexion();
            }

            return LstArticulos;
        }
        public List<E_Articulo> BuscarArticuloPorCriterioModificar(int idArticulo, string criterio)
        {
            List<E_Articulo> LstArticulos = new List<E_Articulo>();

            try
            {
                SqlCommand cmd = new SqlCommand("BuscarArticuloPorCriterioModificar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);
                cmd.Parameters.AddWithValue("@Criterio", criterio);

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Articulo Articulo = new E_Articulo
                        {
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"]),
                            CodigoArticulo = reader["CodigoArticulo"].ToString(),
                            NombreArticulo = reader["NombreArticulo"].ToString(),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"].ToString()),
                            DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
                            Estado = Convert.ToBoolean(reader["Estado"]),
                            IdImagen = Convert.ToInt32(reader["IdImagen"])
                        };
                        LstArticulos.Add(Articulo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return LstArticulos;
            }
            finally
            {
                CerrarConexion();
            }

            return LstArticulos;
        }
    }
}
               