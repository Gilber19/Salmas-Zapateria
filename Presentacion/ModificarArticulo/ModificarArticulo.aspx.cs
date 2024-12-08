using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace Presentacion.ModificarArticulo
{
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        private int IdArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idString = Request.QueryString["id"];
            if (!string.IsNullOrEmpty(idString) && int.TryParse(idString, out int id))
            {
                IdArticulo = id;
                Console.WriteLine(IdArticulo);
            }
            else
            {
                // Handle the case where the id is not valid
                Console.WriteLine("Invalid or missing id parameter.");
            }

            if (!IsPostBack)
            {
                CargarDetalles();
            }
        }


        private void CargarDetalles()
        {
            N_Articulo N_Articulo = new N_Articulo();
            E_Articulo articulo = N_Articulo.BuscarArticuloPorID(IdArticulo);
            //E_Articulo articulo = new E_Articulo();
            //articulo.IdArticulo = 1;
            //articulo.NombreArticulo = "Camisa";
            //articulo.DescripcionArticulo = "Camisa de vestir";
            //articulo.PrecioVenta = 100;
            //articulo.Stock = "10,20,30,40,50";
            //articulo.Talla = "XL,L,M,S,XS";
            //articulo.Imagenes = "imagen1.png,imagen2.png,imagen3.png";

            if (articulo == null)
            {
                // Loggear el ID del artículo que no se encontró
                Response.Redirect("~/HomePage/HomePage.aspx");
            }

            // Cargar datos en los controles
            lblNombreProducto.Text = articulo.NombreArticulo;
            txtNombreProducto.Text = articulo.NombreArticulo;
            lblDescripcion.Text = articulo.DescripcionArticulo;
            txtDescripcion.Text = articulo.DescripcionArticulo;
            //ddlTalla.DataSource = articulo.Tallas;

            ddlTalla.DataBind();
            //txtStock.Text = articulo.Stock.ToString();

            //imgPrincipal.Src = articulo.ImagenPrincipal;
            //RepeaterGallery.DataSource = articulo.ImagenesAdicionales;
            RepeaterGallery.DataBind();
        }

        protected void SaveChanges(object sender, EventArgs e)
        {
            N_Articulo N_Articulo = new N_Articulo();
            E_Articulo articuloActualizado = N_Articulo.BuscarArticuloPorID(IdArticulo);
            //E_Articulo articuloActualizado = new E_Articulo();
            //articuloActualizado.IdArticulo = 1;
            //articuloActualizado.NombreArticulo = "Camisa";
            //articuloActualizado.DescripcionArticulo = "Camisa de vestir";
            //articuloActualizado.PrecioVenta = 100;
            //articuloActualizado.Stock = "10,20,30,40,50";
            //articuloActualizado.Talla = "XL,L,M,S,XS";
            //articuloActualizado.Imagenes = "imagen1.png,imagen2.png,imagen3.png";
            
            // Actualizar los datos del artículo
            articuloActualizado.NombreArticulo = txtNombreProducto.Text;
            articuloActualizado.DescripcionArticulo = txtDescripcion.Text;
            //articuloActualizado.Talla = ddlTalla.SelectedValue;
            //articuloActualizado.Stock = int.Parse(txtStock.Text);
            //articuloActualizado.ImagenPrincipal = imgPrincipal.Src;
            //articuloActualizado.ImagenesAdicionales = RepeaterGallery.DataSource as List<string>;

            N_Articulo.ModificarArticulo(articuloActualizado);
            Response.Redirect("~/HomePage/HomePage.aspx");
        }
    }
}