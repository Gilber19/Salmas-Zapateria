using System;
using System.Collections.Generic;
using System.Diagnostics;
using Datos;
using Entidades;

namespace Negocios
{
    public class N_Articulo
    {
        D_Articulo DA = new D_Articulo();

        private readonly D_Articulo datosArticulo = new D_Articulo();

        public string InsertarArticulo(E_Articulo articulo)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(articulo.NombreArticulo))
                throw new Exception("El nombre del artículo es obligatorio.");
            if (articulo.PrecioVenta <= 0)
                throw new Exception("El precio debe ser mayor a 0.");


            return datosArticulo.InsertarArticulo(articulo);
        }

        public string BorrarArticulo(int idArticulo)
        {
            string Mensaje = string.Empty;

            // Validación del ID
            if (idArticulo <= 0)
                Mensaje = "Error: El ID del artículo debe ser mayor que cero.";

            if (Mensaje == string.Empty) //Validaciones correctas
            {
                try
                {
                    if (DA.BorrarArticulo(idArticulo)) // Llamada a la capa de datos para borrar los datos.
                        Mensaje = "Exito: El artículo fue borrado correctamente.";
                    else
                        Mensaje = "Error: El artículo no pudo ser borrado.";
                }
                catch (Exception ex)
                {
                    Mensaje = "Error: Ocurrió un error inesperado. " + ex.Message;
                }
            }
            return Mensaje;
        }

        public string ModificarArticulo(E_Articulo Articulo)
        {
            string Mensaje = string.Empty;

            // Validaciones
            if (Articulo.IdArticulo <= 0)
                Mensaje = "Error: El ID de la categoría debe ser mayor que cero.";

            if (string.IsNullOrWhiteSpace(Articulo.NombreArticulo))
                Mensaje = "Error: El nombre de la categoría es obligatorio.";

            if (Articulo.DescripcionArticulo.Length > 250)
                Mensaje = "Error: La descripción no puede exceder los 250 caracteres.";
            /* Pendiente de implementar por falta de sp
            if (DC.BuscarArticuloPorCriterioModificar(Articulo.IdArticulo, Articulo.NombreArticulo).Count > 0) // Llamada a la capa de datos para buscar el nombre de la categoría.
                Mensaje = "Error: El nombre de la categoría " + Articulo.NombreArticulo + " ya existe en la base de datos.";
            */
            if (Mensaje == string.Empty) //Validaciones correctas
            {
                try
                {
                    if (DA.ModificarArticulo(Articulo)) // Llamada a la capa de datos para insertar los datos.
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
        public List<E_Articulo> ListarArticulos()
        {
            try
            {
                return DA.ListarArticulos();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en N_Articulo.ListarArticulos: " + ex.Message);
                return new List<E_Articulo>();  // Retornar una lista vacía en caso de error
            }
        }
        public List<E_Articulo> ListarArticulosPorGenero(int genero)
        {
            if (genero <= 0)
            {
                return new List<E_Articulo>();
            }
            else
            {
                try
                {
                    return DA.ListarArticulosPorGenero(genero);
                }
                catch (Exception)
                {
                    return new List<E_Articulo>();  // Retornar una lista vacía en caso de error
                }
            }
        }
        public List<E_Articulo> ListarArticulosPorCategoria(int genero, int idCategoria)
        {
            if (idCategoria <= 0)
            {
                return new List<E_Articulo>();
            }
            else
            {
                try
                {
                    return DA.ListarPorCategoria(genero, idCategoria);
                }
                catch (Exception)
                {
                    return new List<E_Articulo>();  // Retornar una lista vacía en caso de error
                }
            }
        }
        public List<E_Articulo> ListarArticulosPorSubCategoria(int genero, int idSubCategoria)
        {
            if (idSubCategoria <= 0)
            {
                return new List<E_Articulo>();
            }
            else
            {
                try
                {
                    return DA.ListarPorSubCategoria(genero, idSubCategoria);
                }
                catch (Exception)
                {
                    return new List<E_Articulo>();  // Retornar una lista vacía en caso de error
                }
            }
        }
        public E_Articulo BuscarArticuloPorID(int idArticulo)
        {
            if (idArticulo <= 0)
            {
                return null;
            }
            else
            {
                try
                {
                    return DA.BuscarArticuloPorID(idArticulo);
                }
                catch (Exception)
                {
                    return null;  // Retornar null en caso de error
                }
            }
        }
        public E_Articulo BuscarArticuloPorCodigo(string codigoArticulo)
        {
            if (codigoArticulo == string.Empty)
                return null;
            else
            {
                try
                {
                    return DA.BuscarArticuloPorCodigo(codigoArticulo);
                }
                catch (Exception)
                {
                    return null;  // Retornar null en caso de error
                }
            }
        }
        public List<E_Articulo> BuscarArticuloPorCriterio(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
            {
                return new List<E_Articulo>();
            }
            else
            {
                try
                {
                    return DA.BuscarArticuloPorCriterio(criterio);
                }
                catch (Exception)
                {
                    return new List<E_Articulo>();  // Retornar una lista vacía en caso de error
                }
            }
        }
    }
}
