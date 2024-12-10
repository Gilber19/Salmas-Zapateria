using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Entidades;
using Negocios;
using MigraDoc.DocumentObjectModel.Tables;
using static PdfSharp.Capabilities.Features;

namespace Presentacion.ModificarArticulo
{
    public partial class ModificarArticulo : Page
    {
        private N_Articulo N_Articulos = new N_Articulo();
        private N_Categoria N_Categorias = new N_Categoria();
        private N_SubCategoria N_SubCategorias = new N_SubCategoria();

        private int idArticulo;
        private E_Articulo _articulo
        {
            get { return Session["ArticuloTemporal"] as E_Articulo; }
            set { Session["ArticuloTemporal"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["snSesionUsuario"] == null || ((Entidades.E_SesionUsuario)Session["snSesionUsuario"]).NombreRolLogueado != "Administrador")
            {
                Response.Redirect("~/HomePage/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out idArticulo))
                {
                    CargarCategorias();
                    CargarArticulo(idArticulo);
                }
                else
                {
                    Response.Redirect("~/HomePage/HomePage.aspx");
                }
            }
        }

        private void CargarCategorias()
        {
            var categorias = N_Categorias.ListarCategorias();
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "NombreCategoria";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("Seleccione Categoría", ""));
        }

        private void CargarSubcategorias(int categoriaId)
        {
            var subcategorias = N_SubCategorias.ListarSubCategorias(categoriaId);
            ddlSubcategoria.DataSource = subcategorias;
            ddlSubcategoria.DataTextField = "Subcategoria";
            ddlSubcategoria.DataValueField = "IdSubcategoria";
            ddlSubcategoria.DataBind();
            ddlSubcategoria.Items.Insert(0, new ListItem("Seleccione Subcategoría", ""));
        }

        private void CargarTallas(string stock)
        {
            ddlTallas.Items.Clear();
            ddlTallas.Items.Add(new ListItem("Selecciona talla", ""));

            var tallaStockPairs = stock.Split(',');
            foreach (var pair in tallaStockPairs)
            {
                var trimmedPair = pair.Trim();
                if (!string.IsNullOrEmpty(trimmedPair))
                {
                    var parts = trimmedPair.Split(' ');
                    if (parts.Length >= 2)
                    {
                        string talla = parts[0];
                        string stockCantidad = parts[1];

                        if (int.TryParse(stockCantidad, out int cantidadStock) && cantidadStock > 0)
                        {
                            string displayText = $"{talla} - Stock: {stockCantidad}";
                            ddlTallas.Items.Add(new ListItem(displayText, talla));
                        }
                    }
                }
            }
        }

        private void CargarArticulo(int id)
        {
            _articulo = N_Articulos.BuscarArticuloPorID(id);
            if (_articulo != null)
            {
                txtNombre.Text = _articulo.NombreArticulo;
                txtDescripcion.Text = _articulo.DescripcionArticulo;
                
                // Populate and set Género
                ddlGenero.SelectedValue = _articulo.Genero.ToString();
                
                // Populate Categoría and set selected value
                ddlCategoria.SelectedValue = _articulo.IdCategoria.ToString();
                CargarSubcategorias(_articulo.IdCategoria);

                //// Set Subcategoría
                //if (_articulo.SubCategoria != null && ddlSubcategoria.Items.FindByValue(_articulo.SubCategoria.ToString()) != null)
                //{
                //    ddlSubcategoria.SelectedValue = _articulo.SubCategoria.ToString();
                //}
                //else
                //{
                //    ddlSubcategoria.SelectedIndex = 0;
                //}

                txtCodigoArticulo.Text = _articulo.CodigoArticulo;
                txtPrecio.Text = _articulo.PrecioVenta.ToString("N2");

                // Cargar imagen principal
                var imagenes = _articulo.Imagenes?.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList();

                imgPreviewPrincipal.ImageUrl = imagenes?.FirstOrDefault();
                imgPreviewPrincipal.Style["display"] = "block";

                // Cargar tallas y stock
                CargarTallas(_articulo.Stock);

                // Cargar imágenes secundarias si aplica
                // RepeaterImagenesSecundarias.DataSource = N_Articulos.ListarImagenesSecundarias(id);
                // RepeaterImagenesSecundarias.DataBind();
            }
            else
            {
                Response.Redirect("~/HomePage/HomePage.aspx");
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ddlCategoria.SelectedValue, out int categoriaId))
            {
                CargarSubcategorias(categoriaId);
            }
            else
            {
                ddlSubcategoria.Items.Clear();
                ddlSubcategoria.Items.Insert(0, new ListItem("Seleccione Subcategoría", ""));
            }
        }

        protected void btnAgregarTalla_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTallaNuevo.Text))
            {
                if (!int.TryParse(txtStock.Text, out int cantidad) || cantidad < 0)
                {
                    lblMensaje.Text = "Por favor ingrese una cantidad válida para el stock";
                    lblMensaje.CssClass = "alert alert-danger";
                    lblMensaje.Visible = true;
                    return;
                }

                string tallaConStock = $"{txtTallaNuevo.Text.Trim()} {cantidad}";
                ddlTallas.Items.Add(new ListItem(tallaConStock, txtTallaNuevo.Text.Trim()));

                txtTallaNuevo.Text = string.Empty;
                txtStock.Text = string.Empty;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(ddlCategoria.SelectedValue) ||
                    string.IsNullOrEmpty(ddlSubcategoria.SelectedValue) ||
                    string.IsNullOrEmpty(ddlGenero.SelectedValue) ||
                    string.IsNullOrEmpty(txtPrecio.Text) ||
                    string.IsNullOrEmpty(txtCodigoArticulo.Text) ||
                    ddlTallas.Items.Count == 0)
                {
                    lblMensaje.Text = "Por favor complete todos los campos requeridos.";
                    lblMensaje.CssClass = "alert alert-danger";
                    lblMensaje.Visible = true;
                    return;
                }

                N_Tallas NT = new N_Tallas();
                E_Tallas T = new E_Tallas();
                var stockPorTalla = new List<E_Tallas>();
                foreach (ListItem item in ddlTallas.Items)
                {
                    string texto = item.Text.Trim();

                    // Verifica si contiene "Stock:"
                    if (texto.Contains("Stock:"))
                    {
                        string[] partes = texto.Split(new[] { '-', ':' }, StringSplitOptions.RemoveEmptyEntries);

                        if (partes.Length >= 2)
                        {
                            string talla = partes[0].Trim(); // Talla está antes del separador
                            string talla1 = NT.ObtenerIdTalla(talla); // Primera palabra como Talla
                            if (talla1 != "34")
                            {
                                T.idtallas.Add(talla1);
                            }

                            // Obtén el stock desde la última parte
                            string ultimaParte = partes[partes.Length - 1].Trim();

                            if (int.TryParse(ultimaParte, out int stock))
                            {
                                T.stocks.Add(stock.ToString());
                                stockPorTalla.Add(new E_Tallas
                                {
                                    Talla = talla,
                                    Stock = stock
                                });
                            }
                        }
                    }
                    else
                    {
                        // Supón que está en el formato "Talla Stock"
                        string[] partes = texto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (partes.Length == 2)
                        {
                            string talla = partes[0].Trim(); // Primera palabra como Talla
                            string talla1 = NT.ObtenerIdTalla(talla); // Primera palabra como Talla
                            if (talla1 != "34")
                            {
                                T.idtallas.Add(talla1);
                            }

                            if (int.TryParse(partes[1].Trim(), out int stock))
                            {
                                T.stocks.Add(stock.ToString());
                                stockPorTalla.Add(new E_Tallas
                                {
                                    Talla = talla,
                                    Stock = stock
                                });
                            }
                        }
                    }
                }

                List<string> imagenes = new List<string>();

                if (fuImagenPrincipal.HasFile)
                {
                    string rutaImagenPrincipal = GuardarImagen(fuImagenPrincipal);
                    imagenes.Add(rutaImagenPrincipal);
                }

                if (fuImagenSecundaria.HasFile)
                {
                    string rutaImagenSecundaria = GuardarImagen(fuImagenSecundaria);
                    imagenes.Add(rutaImagenSecundaria);
                }

                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out idArticulo))
                {
                }

                //E_Articulo articulo = new E_Articulo
                //{
                //    IdArticulo = idArticulo,
                //    NombreArticulo = txtNombre.Text.Trim(),
                //    DescripcionArticulo = txtDescripcion.Text.Trim(),
                //    IdCategoria = int.Parse(ddlCategoria.SelectedValue),
                //    SubCategoria = ddlSubcategoria.SelectedValue,
                //    CodigoArticulo = txtCodigoArticulo.Text.Trim(),
                //    Genero = int.Parse(ddlGenero.SelectedValue),
                //    PrecioVenta = double.Parse(txtPrecio.Text.Trim()),
                //    Talla = string.Join(",", T.idtallas),
                //    Stock = string.Join(",", T.stocks),
                //    Imagenes = string.Join(",", imagenes),

                //};

                _articulo.IdArticulo = idArticulo;
                System.Diagnostics.Debug.WriteLine("IdArticulo: " + _articulo.IdArticulo);

                _articulo.NombreArticulo = txtNombre.Text.Trim();
                System.Diagnostics.Debug.WriteLine("NombreArticulo: " + _articulo.NombreArticulo);

                _articulo.DescripcionArticulo = txtDescripcion.Text.Trim();
                System.Diagnostics.Debug.WriteLine("DescripcionArticulo: " + _articulo.DescripcionArticulo);

                _articulo.Genero = int.Parse(ddlGenero.SelectedValue);
                System.Diagnostics.Debug.WriteLine("Genero: " + _articulo.Genero);

                _articulo.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                System.Diagnostics.Debug.WriteLine("IdCategoria: " + _articulo.IdCategoria);

                _articulo.SubCategoria = ddlSubcategoria.SelectedValue;
                System.Diagnostics.Debug.WriteLine("SubCategoria: " + _articulo.SubCategoria);

                _articulo.StockInt = int.Parse(_articulo.SubCategoria);
                System.Diagnostics.Debug.WriteLine("SubCategoria: " + _articulo.StockInt);

                _articulo.CodigoArticulo = txtCodigoArticulo.Text.Trim();
                System.Diagnostics.Debug.WriteLine("CodigoArticulo: " + _articulo.CodigoArticulo);

                _articulo.PrecioVenta = double.Parse(txtPrecio.Text.Trim());
                System.Diagnostics.Debug.WriteLine("PrecioVenta: " + _articulo.PrecioVenta);

                _articulo.Talla = string.Join(",", T.idtallas); // Listo
                System.Diagnostics.Debug.WriteLine("Talla: " + _articulo.Talla);

                _articulo.Stock = string.Join(",", T.stocks); // Listo
                System.Diagnostics.Debug.WriteLine("Stock: " + _articulo.Stock);

                _articulo.Imagenes = string.Join(",", imagenes);
                System.Diagnostics.Debug.WriteLine("Imagenes: " + _articulo.Imagenes);


                string hola = N_Articulos.ModificarArticulo(_articulo);
                Response.Redirect("~/HomePage/HomePage.aspx");
                lblMensaje.Text = "Artículo modificado correctamente.";
                lblMensaje.CssClass = "alert alert-success";
                lblMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al modificar el artículo: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
            }
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (_articulo == null)
            {
                lblMensaje.Text = "Debe cargar primero el artículo antes de agregar imágenes adicionales.";
                lblMensaje.CssClass = "alert alert-warning";
                lblMensaje.Visible = true;
                return;
            }

            if (fuImagenSecundaria.HasFile)
            {
                string rutaImagen = GuardarImagen(fuImagenSecundaria);
                var imagenes = _articulo.Imagenes?.Split(',').Where(x => !string.IsNullOrEmpty(x)).ToList() ?? new List<string>();
                imagenes.Add(rutaImagen);
                _articulo.Imagenes = string.Join(",", imagenes);

                N_Articulos.ModificarArticulo(_articulo);

                lblMensaje.Text = "Imagen agregada correctamente.";
                lblMensaje.CssClass = "alert alert-success";
                lblMensaje.Visible = true;
            }
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            // Lógica para eliminar imagen
        }

        private string GuardarImagen(FileUpload archivo)
        {
            string carpeta = Server.MapPath("~/Recursos/Imagenes/Articulos/");
            string nombreArchivo = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(archivo.FileName);
            string ruta = System.IO.Path.Combine(carpeta, nombreArchivo);
            archivo.SaveAs(ruta);
            return archivo.FileName.Replace("System.Web.UI.WebControls.FileUpload", "");
        }

        protected void EliminarImagen_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string rutaImagen = btnEliminar.CommandArgument;

            // Eliminar la imagen de la base de datos
            // N_Articulos.BorrarImagenSecundaria(idArticulo, rutaImagen);

            // Eliminar el archivo del servidor
            string rutaFisica = Server.MapPath(rutaImagen);
            if (System.IO.File.Exists(rutaFisica))
            {
                System.IO.File.Delete(rutaFisica);
            }

            // Recargar las imágenes
            // RepeaterImagenesSecundarias.DataSource = N_Articulos.ListarImagenesSecundarias(idArticulo);
            // RepeaterImagenesSecundarias.DataBind();
        }
    }
}