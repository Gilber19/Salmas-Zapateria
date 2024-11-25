using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Entidades;
using System.ComponentModel;
using System.Configuration;

namespace Datos
{
  public class D_Categoria : D_ConexionBD
  {

    public bool InsertarCategoria(E_Categoria categoria)
    { 
      try
      {
        SqlCommand cmd = new SqlCommand("IBM_Categoria", conexion)
        {
          CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.AddWithValue("@Accion", "INSERTAR");
        cmd.Parameters.AddWithValue("@ClaveCategoria", categoria.ClaveCategoria );
        cmd.Parameters.AddWithValue("@IdCategoria", categoria.IdCategoria);
        cmd.Parameters.AddWithValue("@NombreCategoria", categoria.NombreCategoria);
        cmd.Parameters.AddWithValue("@DescripcionCategoria", categoria.DescripcionCategoria);
        cmd.Parameters.AddWithValue("@Estado", categoria.Estado);

        AbrirConexion();
        cmd.ExecuteNonQuery();
        return true;
      }
      catch (Exception ex)
      {
        Console.Write("Error al tratar de insertar la categoría: ", ex.Message);
        return false;
      }
    }
    public bool BorrarCategoria(int idCategoria)
    {
      E_Categoria Categoria = new E_Categoria();
      try
      {
        SqlCommand cmd = new SqlCommand("IBM_Categoria", conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Accion", "BORRAR");
        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
        cmd.Parameters.AddWithValue("@ClaveCategoria", Categoria.ClaveCategoria);
        cmd.Parameters.AddWithValue("@NombreCategoria", Categoria.NombreCategoria);
        cmd.Parameters.AddWithValue("@DescripcionCategoria", Categoria.DescripcionCategoria);
        cmd.Parameters.AddWithValue("@Estado", Categoria.Estado);

        conexion.Open();
        cmd.ExecuteNonQuery();
        return true;      
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error al borrar la Categoria: ", ex.Message);
        return false;
      }
      finally
      {
        CerrarConexion();
      }
    }
    public bool ModificarCategoria(E_Categoria Categoria)
    {
      try
      {
        SqlCommand cmd = new SqlCommand("IBM_Categoria", conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Accion", "MODIFICAR");
        cmd.Parameters.AddWithValue("@IdCategoria", Categoria.IdCategoria);
        cmd.Parameters.AddWithValue("@ClaveCategoria", Categoria.ClaveCategoria);
        cmd.Parameters.AddWithValue("@NombreCategoria", Categoria.NombreCategoria);
        cmd.Parameters.AddWithValue("@DescripcionCategoria", Categoria.DescripcionCategoria);
        cmd.Parameters.AddWithValue("@Estado", Categoria.Estado);

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
    public List<E_Categoria> ListarCategorias()
    {
      List<E_Categoria> LstCategorias = new List<E_Categoria>();

      try
      {
        SqlCommand cmd = new SqlCommand("LstCategorias", conexion)
        {
          CommandType = CommandType.StoredProcedure
        };

        AbrirConexion();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            E_Categoria Categoria = new E_Categoria
            {
              IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
              ClaveCategoria = reader["ClaveCategoria"].ToString(),
              NombreCategoria = reader["NombreCategoria"].ToString(),
              DescripcionCategoria = reader["DescripcionCategoria"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
            };
            LstCategorias.Add(Categoria);
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

      return LstCategorias;
    }
    public E_Categoria BuscarCategoriaPorID(int idCategoria)
    {
      E_Categoria Categoria = null;

      try
      {
        SqlCommand cmd = new SqlCommand("BuscarCategoriaPorId", conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

        AbrirConexion();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          if (reader.Read())
          {
            Categoria = new E_Categoria
            {
              IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
              ClaveCategoria = reader["ClaveCategoria"].ToString(),
              NombreCategoria = reader["NombreCategoria"].ToString(),
              DescripcionCategoria = reader["DescripcionCategoria"].ToString(),
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

      return Categoria;
    }

    public List<E_Categoria> BuscarCategoriaPorCriterio(string criterio)
    {
      List<E_Categoria> LstCategorias = new List<E_Categoria>();

      try
      {
        SqlCommand cmd = new SqlCommand("BuscarCategoriaPorCriterio", conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Criterio", criterio);

        AbrirConexion();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            E_Categoria Categoria = new E_Categoria
            {
              IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
              ClaveCategoria = reader["ClaveCategoria"].ToString(),
              NombreCategoria = reader["NombreCategoria"].ToString(),
              DescripcionCategoria = reader["DescripcionCategoria"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
            };
            LstCategorias.Add(Categoria);
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error al buscar por criterio: ", ex.Message);
        return LstCategorias;
      }
      finally
      {
        CerrarConexion();
      }

      return LstCategorias;
    }
    public List<E_Categoria> BuscarCategoriaPorCriterioModificar(int idCategoria, string criterio)
    {
      List<E_Categoria> LstCategorias = new List<E_Categoria>();

      try
      {
        SqlCommand cmd = new SqlCommand("BuscarCategoriaPorCriterioModificar", conexion);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
        cmd.Parameters.AddWithValue("@Criterio", criterio);

        AbrirConexion();
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            E_Categoria Categoria = new E_Categoria
            {
              IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
              ClaveCategoria = reader["ClaveCategoria"].ToString(),
              NombreCategoria = reader["NombreCategoria"].ToString(),
              DescripcionCategoria = reader["DescripcionCategoria"].ToString(),
              Estado = Convert.ToBoolean(reader["Estado"])
            };
            LstCategorias.Add(Categoria);
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error al buscar por criterio: ", ex.Message);
        return LstCategorias;
      }
      finally
      {
        CerrarConexion();
      }

      return LstCategorias;
    }
  }
}
