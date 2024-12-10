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
                SqlCommand cmd = new SqlCommand("ObtenerApartados", conexion)
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
                            ImagenesArticulo = reader["ImagenesArticulos"].ToString(),
                            NombresArticulos = reader["NombresArticulos"].ToString()
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

    }
}
