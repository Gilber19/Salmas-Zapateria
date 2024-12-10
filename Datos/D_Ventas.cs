using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;
using System.Configuration;
using System.Linq;

namespace Datos
{
    public class D_Ventas : D_ConexionBD
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        public List<E_Factura> BuscarFactura(string criterio)
        {
            List<E_Factura> lstFactura = new List<E_Factura>();

            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerFactura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Criterio", criterio);

                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_Factura venta = new E_Factura
                        {
                            IdVenta = Convert.ToInt32(reader["IdVenta"]),
                            Cliente = reader["Cliente"].ToString(),
                            Usuario = reader["Usuario"].ToString(),
                            FechaHora = Convert.ToDateTime(reader["FechaHora"].ToString()),
                            TipoComprobante = reader["TipoComprobante"].ToString(),
                            SerieComprobante = reader["SerieComprobante"].ToString(),
                            NumeroComprobante = reader["NumeroComprobante"].ToString(),
                            TotalVenta = Convert.ToDouble(reader["TotalVenta"].ToString()),
                            ImpuestoVenta = Convert.ToDouble(reader["ImpuestoVenta"].ToString()),
                            CodigoArticulo = reader["CodigoArticulo"].ToString(),
                            NombreArticulo = reader["NombreArticulo"].ToString(),
                            Cantidad = Convert.ToInt16(reader["Cantidad"].ToString()),
                            PrecioVenta = Convert.ToDouble(reader["PrecioVenta"].ToString()),
                            Descuento = Convert.ToDouble(reader["Descuento"].ToString()),
                            Total = Convert.ToDouble(reader["Total"].ToString()),
                        };
                        lstFactura.Add(venta);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar por criterio: ", ex.Message);
                return null;
            }
            finally
            {
                CerrarConexion();
            }

            return lstFactura;
        }

        public List<E_FacturaVentas> ListarVentas()
        {
            List<E_FacturaVentas> LstFacturas = new List<E_FacturaVentas>();


            try
            {
                SqlCommand cmd = new SqlCommand("ObtenerTodasLasVentas", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                AbrirConexion();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        E_FacturaVentas venta = new E_FacturaVentas
                        {
                            SerieComprobante = reader["SerieComprobante"].ToString(),
                            FechaHora = Convert.ToDateTime(reader["FechaHora"].ToString()),
                            Total = Convert.ToDouble(reader["Total"].ToString()),
                            IdArticulo = Convert.ToInt32(reader["IdArticulo"].ToString()),
                            Imagenes = reader["Imagenes"].ToString()
                        };
                        venta.Imagenes = "/Recursos/Imagenes/Articulos/" + venta.Imagenes;
                        LstFacturas.Add(venta);
                        //System.Diagnostics.Debug.WriteLine("(DATOS): " + venta.SerieComprobante);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR LISTAR VENTAS (DATOS)");
                return null;
            }
            finally
            {
                CerrarConexion();
            }

            return LstFacturas;

        }

        public int InsertarVenta(E_Venta venta)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("IBM_Ventas", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
                    cmd.Parameters.Add("@IdVenta", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                    cmd.Parameters.AddWithValue("@IdTipoVenta", venta.IdTipoVenta);
                    cmd.Parameters.AddWithValue("@TipoComprobante", venta.TipoComprobante);
                    cmd.Parameters.AddWithValue("@SerieComprobante", venta.SerieComprobante);
                    cmd.Parameters.AddWithValue("@NumeroComprobante", venta.NumeroComprobante);
                    cmd.Parameters.AddWithValue("@FechaHora", venta.FechaHora);
                    cmd.Parameters.AddWithValue("@Impuesto", venta.Impuesto);
                    cmd.Parameters.AddWithValue("@Total", venta.Total);
                    cmd.Parameters.AddWithValue("@Estado", venta.Estado);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    return Convert.ToInt32(cmd.Parameters["@IdVenta"].Value);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR InsertarVenta (DATOS)");

                    throw new Exception("Error al insertar el artículo: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }

        public void InsertarDetalleVenta(E_DetalleVentas detalle)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("IBM_DetalleVentas", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Parámetros del procedimiento almacenado
                    cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
                    cmd.Parameters.AddWithValue("@IdVenta", detalle.IdVenta);
                    cmd.Parameters.AddWithValue("@IdArticulo", detalle.IdArticulo);
                    cmd.Parameters.AddWithValue("@IdTalla", detalle.IdTalla);
                    cmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    cmd.Parameters.AddWithValue("@Descuento", detalle.Descuento);
                    cmd.Parameters.AddWithValue("@PrecioVenta", detalle.PrecioVenta);

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR InsertarDetalleVenta (DATOS)");

                    throw new Exception("Error al insertar el artículo: " + ex.Message, ex);
                }
                finally
                {
                    CerrarConexion();   
                }
            }
        }

        public decimal ObtenerPrecioArticulo(int idArticulo)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerPrecioArticulo", conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);

                    conexion.Open();

                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR ObtenerPrecioArticulo (DATOS)");

                    throw new Exception("Error al obtener el precio del artículo: " + ex.Message, ex);
                }
                finally
                {
                    // Asegúrate de cerrar la conexión correctamente
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        conexion.Close();
                    }
                }
            }
        }





    }



}

