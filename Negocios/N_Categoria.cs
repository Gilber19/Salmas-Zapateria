using Entidades;
using Datos;
using System;
using System.Collections.Generic;

namespace Negocios
{
  public class N_Categoria
  {
    D_Categoria DC = new D_Categoria();

    public string InsertarCategoria(E_Categoria categoria)
    {
      string Mensaje = string.Empty;

      // Validaciones
      if (string.IsNullOrWhiteSpace(categoria.NombreCategoria))
        Mensaje = "Error: El nombre de la categoría es obligatorio.";

      if (categoria.DescripcionCategoria.Length > 250)
        Mensaje = "Error: La descripción no puede exceder los 250 caracteres.";

      if (DC.BuscarCategoriaPorCriterio(categoria.NombreCategoria).Count > 0) // Llamada a la capa de datos para buscar el nombre de la categoría.
        Mensaje = "Error: El nombre de la categoría " + categoria.NombreCategoria + " ya existe en la base de datos.";

      if (Mensaje == string.Empty) //Validaciones correctas
      {
        try
        {
          if (DC.InsertarCategoria(categoria)) // Llamada a la capa de datos para insertar los datos.
            Mensaje = "Exito: La categoría fue insertada correctamente.";
          else
            Mensaje = "Error: La categoría no pudo ser insertada.";
        }
        catch (Exception ex)
        {
          return "Error: Ocurrió un error inesperado." + ex.Message;
        }
      }

      return Mensaje;
    }
    public string BorrarCategoria(int idCategoria)
    {
      string Mensaje = string.Empty;

      // Validación del ID
      if (idCategoria <= 0)
        Mensaje = "Error: El ID de la categoría debe ser mayor que cero.";

      if (Mensaje == string.Empty) //Validaciones correctas
      {
        try
        {
          if (DC.BorrarCategoria(idCategoria)) // Llamada a la capa de datos para borrar los datos.
            Mensaje = "Exito: La categoría fue borrada correctamente.";
          else
            Mensaje = "Error: La categoría no pudo ser borrada.";
        }
        catch (Exception ex)
        {
          Mensaje = "Error: Ocurrió un error inesperado." + ex.Message;
        }
      }
      return Mensaje;
    }
    public string ModificarCategoria(E_Categoria Categoria)
    {
      string Mensaje = string.Empty;

      // Validaciones
      if (Categoria.IdCategoria <= 0)
        Mensaje = "Error: El ID de la categoría debe ser mayor que cero.";

      if (string.IsNullOrWhiteSpace(Categoria.NombreCategoria))
        Mensaje = "Error: El nombre de la categoría es obligatorio.";

      if (Categoria.DescripcionCategoria.Length > 250)
        Mensaje = "Error: La descripción no puede exceder los 250 caracteres.";

      if (DC.BuscarCategoriaPorCriterioModificar(Categoria.IdCategoria, Categoria.NombreCategoria).Count > 0) // Llamada a la capa de datos para buscar el nombre de la categoría.
        Mensaje = "Error: El nombre de la categoría " + Categoria.NombreCategoria + " ya existe en la base de datos.";

      if (Mensaje == string.Empty) //Validaciones correctas
      {
        try
        {
          if (DC.ModificarCategoria(Categoria)) // Llamada a la capa de datos para insertar los datos.
            Mensaje = "Exito: La categoría fue modificada correctamente.";
          else
            Mensaje = "Error: La categoría no pudo ser modificada.";
        }
        catch (Exception ex)
        {
          return "Error: Ocurrió un error inesperado." + ex.Message;
        }
      }

      return Mensaje;
    }
    public List<E_Categoria> ListarCategorias()
    {
      try
      {
        return DC.ListarCategorias();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return new List<E_Categoria>();  // Retornar una lista vacía en caso de error
      }
    }
    public E_Categoria BuscarCategoriaPorID(int idCategoria)
    {
      if (idCategoria <= 0)
      {
        return null;
      }
      else
      {
        try
        {
          return DC.BuscarCategoriaPorID(idCategoria);
        }
        catch (Exception)
        {
          return null;  // Retornar null en caso de error
        }
      }
    }
    public List<E_Categoria> BuscarCategoriaPorCriterio(string criterio)
    {
      if (string.IsNullOrWhiteSpace(criterio))
      {
        return new List<E_Categoria>();
      }
      else
      {
        try
        {
          return DC.BuscarCategoriaPorCriterio(criterio);
        }
        catch (Exception)
        {
          return new List<E_Categoria>();  // Retornar una lista vacía en caso de error
        }
      }
    }
  }
}
