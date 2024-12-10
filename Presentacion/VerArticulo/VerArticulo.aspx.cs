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
            if (int.TryParse(Request.QueryString["idArticulo"], out idArticulo))
            {
                articulo = NA.BuscarArticuloPorID(idArticulo);
            }

            if (articulo == null)
            {
                lblMensaje.Text = "Artículo no encontrado.";
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(ddlTalla.SelectedValue))
            {
                lblMensaje.Text = "Por favor, selecciona una talla.";
                lblMensaje.CssClass = "alert alert-warning";
                lblMensaje.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(ddlCantidad.SelectedValue))
            {
                lblMensaje.Text = "Por favor, selecciona una cantidad.";
                lblMensaje.CssClass = "alert alert-warning";
                lblMensaje.Visible = true;
                return;
            }

            string tallaSeleccionada = ddlTalla.SelectedValue;
            int cantidadSeleccionada = int.Parse(ddlCantidad.SelectedValue);

            // Obtener stock disponible para la talla seleccionada
            int stockDisponible = ObtenerStockDisponible(tallaSeleccionada);

            if (cantidadSeleccionada > stockDisponible)
            {
                lblMensaje.Text = $"La cantidad seleccionada excede el stock disponible ({stockDisponible}) para la talla {tallaSeleccionada}.";
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
                return;
            }

            // Agregar el artículo a los apartados en sesión
            List<E_ArticuloApartado> apartados = Session["Apartados"] as List<E_ArticuloApartado> ?? new List<E_ArticuloApartado>();

            apartados.Add(new E_ArticuloApartado
            {
                IdArticulo = idArticulo,
                Talla = tallaSeleccionada,
                Cantidad = cantidadSeleccionada
            });

            Session["Apartados"] = apartados;

            lblMensaje.Text = "Artículo agregado a tus apartados.";
            lblMensaje.CssClass = "alert alert-success";
            lblMensaje.Visible = true;
        }
        private int ObtenerStockDisponible(string talla)
        {
            if (articulo == null)
                return 0;

            int stockDisponible = 0;

            if (!string.IsNullOrEmpty(articulo.Stock))
            {
                var stockItems = articulo.Stock.Split(',');
                foreach (var stockItem in stockItems)
                {
                    var stockDetails = stockItem.Trim().Split(' ');
                    if (stockDetails.Length == 2)
                    {
                        string tallaItem = stockDetails[0];
                        if (int.TryParse(stockDetails[1], out int cantidadItem) && tallaItem.Equals(talla, StringComparison.OrdinalIgnoreCase))
                        {
                            stockDisponible = cantidadItem;
                            break;
                        }
                    }
                }
            }

            return stockDisponible;
        }

        private void CargarArticulo()
        {
            if (int.TryParse(Request.QueryString["idArticulo"], out idArticulo))
            {
                articulo = NA.BuscarArticuloPorID(idArticulo);

                if (articulo != null)
                {
                    Page.Title = articulo.NombreArticulo;
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