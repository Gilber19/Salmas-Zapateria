using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Presentacion.VerArticulo
{
    public partial class VerArticulo : System.Web.UI.Page
    {
        E_Articulo articulo;
        N_Articulo NA = new N_Articulo();
        int idArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArticulo();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void CargarArticulo()
        {
            if (int.TryParse(Request.QueryString["idArticulo"], out idArticulo))
            {
                articulo = NA.BuscarArticuloPorID(idArticulo);

                if (articulo != null)
                {
                    lblNombreArticulo.Text = articulo.NombreArticulo;
                    lblDescripcionArticulo.Text = articulo.DescripcionArticulo;
                    lblPrecioVenta.Text = $"${articulo.PrecioVenta:F2}";
                    lblEstado.Text = articulo.Estado ? "Disponible" : "No Disponible";

                    // Mostrar imágenes
                    if (!string.IsNullOrEmpty(articulo.Imagenes))
                    {
                        var imagenes = articulo.Imagenes.Split(','); // Dividir las imágenes

                        // Configurar la primera imagen como predeterminada
                        string primeraImagen = imagenes.FirstOrDefault();
                        if (!string.IsNullOrEmpty(primeraImagen))
                        {
                            mainImage.Src = primeraImagen; // Asignar el atributo src a la imagen principal
                        }

                        // Vincular imágenes al Repeater
                        rptImagenes.DataSource = imagenes.Select(imagen => new { Imagen = imagen });
                        rptImagenes.DataBind();
                    }

                    // Mostrar talla DropDownList
                    if (!string.IsNullOrEmpty(articulo.Stock))
                    {
                        var stockItems = articulo.Stock.Split(',');
                        foreach (var stockItem in stockItems)
                        {
                            var stockDetails = stockItem.Split(' '); // Separar talla y cantidad
                            if (stockDetails.Length == 2)
                            {
                                string talla = stockDetails[0];
                                ddlTalla.Items.Add(new ListItem($"{talla}", talla));
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("El artículo no está disponible.");
                }
            }
            else
            {
                Response.Write("Id del artículo no válido.");
            }
        }



    }

}