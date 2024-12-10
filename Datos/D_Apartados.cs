using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;
using System.Configuration;

namespace Datos
{
    public class D_Apartados : D_ConexionBD
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public List<E_Apartados> ListarApartadosPorUsuario(int idUsuario)
        {
            List<E_Apartados> LstApartados = new List<E_Apartados>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerApartadosConTotales", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);


                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Apartados Apartado = new E_Apartados
                        {
                            IdApartado = Convert.ToInt32(reader["IdApartado"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            MontoAbonado = Convert.ToDecimal(reader["MontoAbonado"]),
                            FechaApartado = Convert.ToDateTime(reader["FechaApartado"]),
                            FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]),
                            Estado = reader["Estado"].ToString(),
                            TotalCosto = Convert.ToDouble(reader["TotalCosto"]),
                            TotalAbonado = Convert.ToDouble(reader["TotalAbonado"]),
                            Adeudo = Convert.ToDouble(reader["Adeudo"]),
                            ImagenesArticulo = reader["ImagenesArticulos"].ToString(),
                            NombresArticulos = reader["NombresArticulos"].ToString(),
                        };

                        Apartado.ImagenesArticulo = "/Recursos/Imagenes/Articulos/" + Apartado.ImagenesArticulo;

                        LstApartados.Add(Apartado);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR ListarApartadosPorUsuario (DATOS)");

                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return null;
            }
            finally
            {
                CerrarConexion();
            }

            return LstApartados;

        }

        public List<E_Apartados> ListarDetalleApartado(int idUsuario)
        {
            List<E_Apartados> LstApartados = new List<E_Apartados>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerApartadosConTotales", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);


                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Apartados Apartado = new E_Apartados
                        {
                            IdApartado = Convert.ToInt32(reader["IdApartado"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            MontoAbonado = Convert.ToDecimal(reader["MontoAbonado"]),
                            FechaApartado = Convert.ToDateTime(reader["FechaApartado"]),
                            FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]),
                            Estado = reader["Estado"].ToString(),
                            TotalCosto = Convert.ToDouble(reader["TotalCosto"]),
                            TotalAbonado = Convert.ToDouble(reader["TotalAbonado"]),
                            Adeudo = Convert.ToDouble(reader["Adeudo"]),
                            ImagenesArticulo = reader["ImagenesArticulos"].ToString(),
                            NombresArticulos = reader["NombresArticulos"].ToString(),
                        };

                        Apartado.ImagenesArticulo = "/Recursos/Imagenes/Articulos/" + Apartado.ImagenesArticulo;

                        LstApartados.Add(Apartado);
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR ListarDetalleApartado (DATOS)");

                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return null;
            }
            finally
            {
                CerrarConexion();
            }

            return LstApartados;

        }

        public bool AbonarApartado(int idApartado, int abono)
        {
            E_Apartados Apartado = new E_Apartados();

            try
            {
                SqlCommand cmd = new SqlCommand("AbonarApartado", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdApartado", idApartado);
                cmd.Parameters.AddWithValue("@Abono", abono);

                AbrirConexion();

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR AbonarApartado (DATOS)");

                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return false;

            }
            finally
            {
                CerrarConexion();
            }
        }

        public List<E_Apartados> ObtenerApartadosPorVencer()
        {
            List<E_Apartados> LstApartado= new List<E_Apartados>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerApartadosPorVencer", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Apartados Apartado = new E_Apartados
                        {
                            IdApartado = Convert.ToInt32(reader["IdApartado"]),
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            Nombre = reader["Nombre"]?.ToString() ?? string.Empty,
                            Telefono = reader["Telefono"]?.ToString() ?? string.Empty,
                            TotalAbonado = Convert.ToDouble(reader["MontoAbonado"]),
                            TotalCosto = Convert.ToDouble(reader["Total"]),
                            Adeudo = Convert.ToDouble(reader["Deuda"]),
                            FechaVencimiento = Convert.ToDateTime(reader["FechaVencimiento"]),
                            FechaApartado = Convert.ToDateTime(reader["FechaApartado"]),
                        };

                        //System.Diagnostics.Debug.WriteLine("{Articulo.Stock}" + Articulo.NombreArticulo + " ::::: " + Articulo.Imagenes);


                        LstApartado.Add(Apartado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error ObtenerApartadosPorVencer (DATOS) " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return LstApartado;
        }

        public List<E_Apartados> HistorialClientes(int id)
        {
            List<E_Apartados> LstApartado = new List<E_Apartados>();

            try
            {
                SqlCommand cmd = new SqlCommand("HistorialComprasCliente", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdPersona", id);
                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Apartados Apartado = new E_Apartados
                        {
                            Nombre = reader["Nombre"]?.ToString() ?? string.Empty,
                            TotalCosto = Convert.ToDouble(reader["TotalCosto"]),
                            LimiteCredito = reader["LimiteCredito"]?.ToString() ?? string.Empty,
                            NombreArticulo = reader["NombreArticulo"]?.ToString() ?? string.Empty,
                            ImagenesArticulo = reader["ImagenesArticulo"]?.ToString() ?? string.Empty,
                            FechaApartado = Convert.ToDateTime(reader["FechaApartado"]),
                        };

                        LstApartado.Add(Apartado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error ObtenerApartadosPorVencer (DATOS) " + ex.Message, ex);
            }
            finally
            {
                CerrarConexion();
            }

            return LstApartado;
        }

    }
}
