using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using Entidades;

namespace Datos
{
    public class D_Ventas : D_ConexionBD
    {
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
                        };

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


    }



}

