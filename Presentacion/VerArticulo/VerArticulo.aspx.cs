using System;
using Entidades;
using Negocios;

namespace Presentacion.VerArticulo
{
    public partial class VerArticulo : System.Web.UI.Page
    {
        E_Articulo articulo;
        int idArticulo; // Utilizado para guardar el idArticulo obtenido desde el HomePage.

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                articulo = new E_Articulo
                {
                    IdArticulo = 1,
                    IdCategoria = 2,
                    CodigoArticulo = "A123",
                    NombreArticulo = "Camiseta Deportiva",
                    DescripcionArticulo = "Camiseta ligera y cómoda para deportes.",
                    PrecioVenta = 29.99,
                    Estado = true,
                    IdImagen = 101,
                    Talla = "M",
                    SubCategoria = "Deportiva",
                    IdTalla = "M",
                    Stock = "XL (10), L (20), M (30), S (40), XS (50)",
                    Imagenes = "imagen1.jpg,imagen2.jpg",
                    Genero = 1,
                    NombreCategoria = "Ropa Deportiva"
                };

                // Verificar si el objeto articulo no es null
                if (articulo != null)
                {
                    lblIdArticulo.Text = articulo.IdArticulo.ToString();
                    lblCategoria.Text = articulo.IdCategoria.ToString();
                    lblCodigoArticulo.Text = articulo.CodigoArticulo;
                    lblNombreArticulo.Text = articulo.NombreArticulo;
                    lblDescripcionArticulo.Text = articulo.DescripcionArticulo;
                    lblPrecioVenta.Text = $"${articulo.PrecioVenta:F2}";
                    lblEstado.Text = articulo.Estado ? "Disponible" : "No Disponible";
                    lblImagenes.Text = articulo.Imagenes;
                    lblTalla.Text = articulo.Talla;
                    lblSubCategoria.Text = articulo.SubCategoria;
                    lblStock.Text = articulo.Stock;
                    lblGenero.Text = articulo.Genero == 1 ? "Hombre" : "Mujer";
                    lblNombreCategoria.Text = articulo.NombreCategoria;
                }
                else
                {
                    // Si el artículo es null, muestra un mensaje de error o maneja el caso
                    Response.Write("El artículo no está disponible.");
                }
            }
        }

    }
}
