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
  }
}
