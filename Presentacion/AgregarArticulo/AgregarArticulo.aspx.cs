using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Presentacion.AgregarArticulo
{
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        private N_Articulo N_Articulos = new N_Articulo();
        private N_Categoria N_Categorias = new N_Categoria();
        private N_SubCategoria N_SubCategorias = new N_SubCategoria();

        private E_Articulo _articulo
        {   
            get { return Session["ArticuloTemporal"] as E_Articulo; }
            set { Session["ArticuloTemporal"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                imgPreviewPrincipal.Style["display"] = "none"; 
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
                // Validar el stock
                if (!int.TryParse(txtStock.Text, out int cantidad) || cantidad < 0)
                {
                    lblMensaje.Text = "Por favor ingrese una cantidad válida para el stock";
                    lblMensaje.CssClass = "alert alert-danger";
                    lblMensaje.Visible = true;
                    return;
                }

                // Agregar la talla con su stock en el nuevo formato "TALLA STOCK"
                string tallaConStock = $"{txtTallaNuevo.Text.Trim()} {cantidad}";
                ddlTallas.Items.Add(new ListItem(tallaConStock, txtTallaNuevo.Text.Trim()));
                
                // Limpiar los campos
                txtTallaNuevo.Text = string.Empty;
                txtStock.Text = string.Empty;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
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

                var stockPorTalla = new List<E_Tallas>();
                foreach (ListItem item in ddlTallas.Items)
                {
                    // Extraer la talla y el stock del texto del item en formato "TALLA STOCK"
                    string[] partes = item.Text.Split(' ');
                    if (partes.Length >= 2)
                    {
                        string talla = partes[0];
                        if (int.TryParse(partes[1], out int stock))
                        {
                            stockPorTalla.Add(new E_Tallas
                            {
                                Talla = talla,
                                Stock = stock
                            });
                        }
                    }
                }

                List<string> imagenes = new List<string>();
                
                if (fuImagenPrincipal.HasFile)
                {
                    string rutaImagenPrincipal = GuardarImagen(fuImagenPrincipal);
                    imagenes.Add(rutaImagenPrincipal);
                }

                // Create article with only essential properties
                E_Articulo articulo = new E_Articulo
                {
                    NombreArticulo = txtNombre.Text.Trim(),
                    DescripcionArticulo = txtDescripcion.Text.Trim(),
                    IdCategoria = int.Parse(ddlCategoria.SelectedValue),
                    SubCategoria = ddlSubcategoria.SelectedValue,
                    CodigoArticulo = txtCodigoArticulo.Text.Trim(),
                    Genero = int.Parse(ddlGenero.SelectedValue),
                    PrecioVenta = double.Parse(txtPrecio.Text.Trim()),
                    Stock = string.Join(", ", stockPorTalla.Select(s => $"{s.Talla} {s.Stock}")),
                    Imagenes = string.Join(",", imagenes)
                };

                _articulo = articulo;

                // Insert article
                N_Articulos.InsertarArticulo(articulo);

                lblMensaje.Text = "Artículo agregado correctamente.";
                lblMensaje.CssClass = "alert alert-success";
                lblMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar el artículo: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
            }
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (_articulo == null)
            {
                lblMensaje.Text = "Debe crear primero el artículo antes de agregar imágenes adicionales.";
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
            return "~/Recursos/Imagenes/Articulos/" + nombreArchivo;
        }
    }
}