using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Presentacion.ModificarArticulo
{
    public partial class ModificarArticulo : Page
    {
        private N_Articulo N_Articulos = new N_Articulo();
        private N_Categoria N_Categorias = new N_Categoria();
        private int idArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out idArticulo))
                {
                    CargarCategorias();
                    CargarTallas();
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
            // Obtener categorías desde la capa de negocios
            var categorias = N_Categorias.ListarCategorias();
            
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "NombreCategoria";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();

            ddlCategoria.Items.Insert(0, new ListItem("Categoría", ""));
        }

        private void CargarSubcategorias(int categoriaId)
        {
            // var subcategorias = N_Categorias.ListarSubcategorias(categoriaId);
            
            // ddlSubcategoria.DataSource = subcategorias;
            // ddlSubcategoria.DataTextField = "NombreSubcategoria";
            // ddlSubcategoria.DataValueField = "IdSubcategoria";
            // ddlSubcategoria.DataBind();

            ddlSubcategoria.Items.Insert(0, new ListItem("Subcategoría", ""));
        }

        private void CargarTallas()
        {
            ddlTalla.Items.Clear();
            ddlTalla.Items.Add(new ListItem("Selecciona talla", ""));
            ddlTalla.Items.Add(new ListItem("XS", "XS"));
            ddlTalla.Items.Add(new ListItem("S", "S"));
            ddlTalla.Items.Add(new ListItem("M", "M"));
            ddlTalla.Items.Add(new ListItem("L", "L"));
            ddlTalla.Items.Add(new ListItem("XL", "XL"));
        }

        private void CargarArticulo(int id)
        {
            var articulo = N_Articulos.BuscarArticuloPorID(id);
            
            if (articulo != null)
            {
                txtNombre.Text = articulo.NombreArticulo;
                txtDescripcion.Text = articulo.DescripcionArticulo;
                ddlCategoria.SelectedValue = articulo.IdCategoria.ToString();
                CargarSubcategorias(articulo.IdCategoria);
                ddlSubcategoria.SelectedValue = articulo.SubCategoria;
                txtCodigoArticulo.Text = articulo.CodigoArticulo;
                ddlTalla.SelectedValue = articulo.Talla;
                txtStock.Text = articulo.Stock;
                txtPrecio.Text = articulo.PrecioVenta.ToString("F2");
                // imgPreviewPrincipal.ImageUrl = articulo.ImagenPrincipalPath;

                // Cargar imágenes secundarias
                // RepeaterImagenesSecundarias.DataSource = N_Articulos.ListarImagenesSecundarias(id);
                RepeaterImagenesSecundarias.DataBind();
            }
            else
            {
                // Manejar el error: Artículo no encontrado
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
                ddlSubcategoria.Items.Insert(0, new ListItem("Selecciona subcategoría", ""));
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Articulo articulo = new E_Articulo
                {
                    IdArticulo = idArticulo,
                    NombreArticulo = txtNombre.Text.Trim(),
                    DescripcionArticulo = txtDescripcion.Text.Trim(),
                    IdCategoria = int.Parse(ddlCategoria.SelectedValue),
                    SubCategoria = ddlSubcategoria.SelectedValue,
                    CodigoArticulo = txtCodigoArticulo.Text.Trim(),
                    Talla = ddlTalla.SelectedValue,
                    Stock = txtStock.Text.Trim(),
                    PrecioVenta = double.Parse(txtPrecio.Text.Trim()),
                    // Manejar imagenes y otros campos según sea necesario
                };

                // Manejar imagen principal
                if (fuImagenPrincipal.HasFile)
                {
                    string ruta = GuardarImagen(fuImagenPrincipal);
                    // articulo.ImagenPrincipalPath = ruta;
                }

                string resultado = N_Articulos.ModificarArticulo(articulo);
                // Mostrar mensaje al usuario
                // lblMensaje.Text = resultado;
            }
            catch (Exception ex)
            {
                // lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private string GuardarImagen(FileUpload archivo)
        {
            string carpeta = Server.MapPath("~/Recursos/Imagenes/Articulos/Primarias/");
            string nombreArchivo = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(archivo.FileName);
            string ruta = carpeta + nombreArchivo;
            archivo.SaveAs(ruta);
            return "~/Recursos/Imagenes/Articulos/Primarias/" + nombreArchivo;
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (fuImagenSecundaria.HasFile)
            {
                //string ruta = GuardarImagenSecundaria(fuImagenSecundaria);
                // Agregar la imagen a la base de datos o al listado
                //negocioArticulo.AgregarImagenSecundaria(articuloId, ruta);
                // Recargar las imágenes
                //RepeaterImagenesSecundarias.DataSource = negocioArticulo.ListarImagenesSecundarias(articuloId);
                //RepeaterImagenesSecundarias.DataBind();
            }
        }

        private string GuardarImagenSecundaria(FileUpload archivo)
        {
            string carpeta = Server.MapPath("~/Recursos/Imagenes/Articulos/Secundarias/");
            string nombreArchivo = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(archivo.FileName);
            string ruta = carpeta + nombreArchivo;
            archivo.SaveAs(ruta);
            return "~/Recursos/Imagenes/Articulos/Secundarias/" + nombreArchivo;
        }

        protected void EliminarImagen_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            string rutaImagen = btnEliminar.CommandArgument;

            // Eliminar la imagen de la base de datos
            //negocioArticulo.BorrarImagenSecundaria(articuloId, rutaImagen);

            // Eliminar el archivo del servidor
            string rutaFisica = Server.MapPath(rutaImagen);
            if (System.IO.File.Exists(rutaFisica))
            {
                System.IO.File.Delete(rutaFisica);
            }

            // Recargar las imágenes
            //RepeaterImagenesSecundarias.DataSource = negocioArticulo.ListarImagenesSecundarias(articuloId);
            //RepeaterImagenesSecundarias.DataBind();
        }
    }
}