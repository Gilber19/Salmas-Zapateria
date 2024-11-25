using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;

namespace Datos
{
  public class D_Articulo : D_ConexionBD
  {
    public bool InsertarArticulo(E_Articulo articulo)
    {
      try
      {
        SqlCommand cmd = new SqlCommand("IBM_Articulo", conexion)
        {
          CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
        cmd.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
        cmd.Parameters.AddWithValue("@CodigoArticulo", articulo.CodigoArticulo);
        cmd.Parameters.AddWithValue("@NombreArticulo", articulo.NombreArticulo);
        cmd.Parameters.AddWithValue("@PrecioVenta", articulo.PrecioVenta);
        cmd.Parameters.AddWithValue("@Stock", articulo.Stock);        
        cmd.Parameters.AddWithValue("@DescripcionArticulo", articulo.DescripcionArticulo);
        cmd.Parameters.AddWithValue("@Estado", articulo.Estado);

        AbrirConexion();
        cmd.ExecuteNonQuery();
        return true;
      }
      catch (Exception ex)
      {
        Console.Write("Error al tratar de insertar la categoría: ", ex.Message);
        return false;
      }
      finally
      {
        CerrarConexion();
      }
    }
    public bool BorrarArticulo(int idArticulo)
    {
      E_Articulo articulo = new E_Articulo();
      try
      {
        SqlCommand cmd = new SqlCommand("IBM_Articulo", conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
        cmd.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
        cmd.Parameters.AddWithValue("@CodigoArticulo", articulo.CodigoArticulo);
        cmd.Parameters.AddWithValue("@NombreArticulo", articulo.NombreArticulo);
        cmd.Parameters.AddWithValue("@PrecioVenta", articulo.PrecioVenta);
        cmd.Parameters.AddWithValue("@Stock", articulo.Stock);
        cmd.Parameters.AddWithValue("@DescripcionArticulo", articulo.DescripcionArticulo);
        cmd.Parameters.AddWithValue("@Estado", articulo.Estado);

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

        cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
        cmd.Parameters.AddWithValue("@IdCategoria", articulo.IdCategoria);
        cmd.Parameters.AddWithValue("@CodigoArticulo", articulo.CodigoArticulo);
        cmd.Parameters.AddWithValue("@NombreArticulo", articulo.NombreArticulo);
        cmd.Parameters.AddWithValue("@PrecioVenta", articulo.PrecioVenta);
        cmd.Parameters.AddWithValue("@Stock", articulo.Stock);
        cmd.Parameters.AddWithValue("@DescripcionArticulo", articulo.DescripcionArticulo);
        cmd.Parameters.AddWithValue("@Estado", articulo.Estado);

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
              CodigoArticulo = reader["CodigoArticulo"].ToString(),
              NombreArticulo = reader["NombreArticulo"].ToString(),
              PrecioVenta = Convert.ToDouble(reader["PrecioVenta"].ToString()),
              Stock = Convert.ToInt16(reader["Stock"].ToString()),
              DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
            };
            LstArticulos.Add(Articulo);
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

      return LstArticulos;
    }
    public E_Articulo BuscarArticuloPorID(int idArticulo)
    {
      E_Articulo Articulo = null;

      try
      {
        SqlCommand cmd = new SqlCommand("BuscarArticuloPorId", conexion);
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
              CodigoArticulo = reader["CodigoArticulo"].ToString(),
              NombreArticulo = reader["NombreArticulo"].ToString(),
              PrecioVenta = Convert.ToDouble(reader["PrecioVenta"].ToString()),
              Stock = Convert.ToInt16(reader["Stock"].ToString()),
              DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
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
              Stock = Convert.ToInt16(reader["Stock"].ToString()),
              DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
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
              Stock = Convert.ToInt16(reader["Stock"].ToString()),
              DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
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
              Stock = Convert.ToInt16(reader["Stock"].ToString()),
              DescripcionArticulo = reader["DescripcionArticulo"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
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
