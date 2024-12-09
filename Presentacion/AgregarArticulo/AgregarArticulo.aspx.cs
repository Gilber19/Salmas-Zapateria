using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Presentacion.AgregarArticulo
{
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        private N_Articulo N_Articulos = new N_Articulo();
        private N_Categoria N_Categorias = new N_Categoria();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            var categorias = N_Categorias.ListarCategorias();
            
            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "NombreCategoria";
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataBind();

            ddlCategoria.Items.Insert(0, new ListItem("Categoría", ""));
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

        private void CargarSubcategorias(int categoriaId)
        {
            // Implementar si es necesario
            ddlSubcategoria.Items.Clear();
            ddlSubcategoria.Items.Insert(0, new ListItem("Subcategoría", ""));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Articulo articulo = new E_Articulo
                {
                    NombreArticulo = txtNombre.Text.Trim(),
                    DescripcionArticulo = txtDescripcion.Text.Trim(),
                    IdCategoria = int.Parse(ddlCategoria.SelectedValue),
                    SubCategoria = ddlSubcategoria.SelectedValue,
                    CodigoArticulo = txtCodigoArticulo.Text.Trim(),
                    Talla = ddlTalla.SelectedValue,
                    Stock = txtStock.Text.Trim(),
                    PrecioVenta = double.Parse(txtPrecio.Text.Trim()),
                    // Añadir otros campos según sea necesario
                };

                // Manejar imagen principal
                if (fuImagenPrincipal.HasFile)
                {
                    string ruta = GuardarImagen(fuImagenPrincipal);
                    // articulo.ImagenPrincipalPath = ruta;
                }

                // Manejar imágenes secundarias
                // Implementar según sea necesario

                string resultado = N_Articulos.InsertarArticulo(articulo);
                // Mostrar mensaje al usuario, por ejemplo:
                // lblMensaje.Text = "Artículo agregado exitosamente.";
            }
            catch (Exception ex)
            {
                // Manejar errores, por ejemplo:
                // lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        private string GuardarImagen(FileUpload archivo)
        {
            string carpeta = Server.MapPath("~/Recursos/Imagenes/Articulos/Primarias/");
            string nombreArchivo = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(archivo.FileName);
            string ruta = System.IO.Path.Combine(carpeta, nombreArchivo);
            archivo.SaveAs(ruta);
            return "~/Recursos/Imagenes/Articulos/Primarias/" + nombreArchivo;
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (fuImagenSecundaria.HasFile)
            {
                // Implementar lógica para agregar imágenes secundarias
            }
        }

        protected void EliminarImagen_Click(object sender, EventArgs e)
        {
            // Implementar lógica para eliminar imágenes secundarias
        }
    }
}