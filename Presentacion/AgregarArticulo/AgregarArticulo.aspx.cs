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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias();
                AgregarFilaTalla();
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

        private void CargarSubcategorias(int categoriaId)
        {
            var subcategorias = N_SubCategorias.ListarSubCategorias(categoriaId);
            
            ddlSubcategoria.DataSource = subcategorias;
            ddlSubcategoria.DataTextField = "NombreSubcategoria";
            ddlSubcategoria.DataValueField = "IdSubcategoria";
            ddlSubcategoria.DataBind();

            ddlSubcategoria.Items.Insert(0, new ListItem("Subcategoría", ""));
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

        protected void btnAgregarTalla_Click(object sender, EventArgs e)
        {
            AgregarFilaTalla();
        }

        private void AgregarFilaTalla()
        {
            var tallas = new List<TallaStock>();

            foreach (RepeaterItem item in rptTallas.Items)
            {
                TextBox txtTalla = (TextBox)item.FindControl("txtTalla");
                TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");
                tallas.Add(new TallaStock
                {
                    Talla = txtTalla.Text.Trim(),
                    Cantidad = txtCantidad.Text.Trim()
                });
            }

            // Agregar una nueva fila vacía
            tallas.Add(new TallaStock());

            rptTallas.DataSource = tallas;
            rptTallas.DataBind();
        }

        protected void btnEliminarTalla_Click(object sender, EventArgs e)
        {
            var tallas = new List<TallaStock>();

            foreach (RepeaterItem item in rptTallas.Items)
            {
                TextBox txtTalla = (TextBox)item.FindControl("txtTalla");
                TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");
                Button btnEliminar = (Button)item.FindControl("btnEliminarTalla");

                // Evitar agregar la talla que se está eliminando
                if (btnEliminar != sender)
                {
                    tallas.Add(new TallaStock
                    {
                        Talla = txtTalla.Text.Trim(),
                        Cantidad = txtCantidad.Text.Trim()
                    });
                }
            }

            rptTallas.DataSource = tallas;
            rptTallas.DataBind();
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            // Implementar la lógica para eliminar la imagen secundaria
            Button btnEliminar = (Button)sender;
            string imagePath = btnEliminar.CommandArgument;

            // Lógica para eliminar la imagen del servidor y actualizar la base de datos
            // Por ejemplo:
            // 1. Eliminar el archivo de imagen
            string fullPath = Server.MapPath(imagePath);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            // 2. Actualizar la base de datos para eliminar la referencia de la imagen
            // N_Articulos.EliminarImagen(imagePath);

            // 3. Actualizar el Repeater para reflejar los cambios
            // CargarImágenesSecundarias();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var stockPorTalla = new List<E_Tallas>();

                foreach (RepeaterItem item in rptTallas.Items)
                {
                    TextBox txtTalla = (TextBox)item.FindControl("txtTalla");
                    TextBox txtCantidad = (TextBox)item.FindControl("txtCantidad");

                    if (string.IsNullOrWhiteSpace(txtTalla.Text))
                    {
                        lblMensaje.Text = "La talla no puede estar vacía.";
                        lblMensaje.CssClass = "alert alert-danger";
                        lblMensaje.Visible = true;
                        return;
                    }

                    if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad < 0)
                    {
                        lblMensaje.Text = "La cantidad debe ser un número positivo.";
                        lblMensaje.CssClass = "alert alert-danger";
                        lblMensaje.Visible = true;
                        return;
                    }

                    stockPorTalla.Add(new E_Tallas
                    {
                        Talla = txtTalla.Text.Trim(),
                        Stock = cantidad
                    });
                }

                if (stockPorTalla.Count == 0)
                {
                    lblMensaje.Text = "Debe agregar al menos una talla.";
                    lblMensaje.CssClass = "alert alert-danger";
                    lblMensaje.Visible = true;
                    return;
                }

                // Formatear el stock como "XL (10), L (20), M (30)"
                string stockFormateado = string.Join(", ", stockPorTalla.Select(s => $"{s.Talla} ({s.Stock})"));

                E_Articulo articulo = new E_Articulo
                {
                    NombreArticulo = txtNombre.Text.Trim(),
                    DescripcionArticulo = txtDescripcion.Text.Trim(),
                    IdCategoria = int.Parse(ddlCategoria.SelectedValue),
                    SubCategoria = ddlSubcategoria.SelectedValue,
                    CodigoArticulo = txtCodigoArticulo.Text.Trim(),
                    Genero = int.Parse(ddlGenero.SelectedValue),
                    PrecioVenta = double.Parse(txtPrecio.Text.Trim()),
                    Stock = stockFormateado,
                    // Otras propiedades según sea necesario
                };

                // Manejar imagen principal
                if (fuImagenPrincipal.HasFile)
                {
                    string ruta = GuardarImagen(fuImagenPrincipal);
                    articulo.Imagenes = ruta;
                }

                // Manejar imágenes secundarias
                // Implementar según sea necesario

                string resultado = N_Articulos.InsertarArticulo(articulo);

                // Mostrar mensaje al usuario
                lblMensaje.Text = "Artículo agregado exitosamente.";
                lblMensaje.CssClass = "alert alert-success";
                lblMensaje.Visible = true;

                // Mostrar el stock en el GridView
                gvStock.DataSource = articulo.ObtenerStock()
                    .Select(kvp => new { Talla = kvp.Key, Cantidad = kvp.Value })
                    .ToList();
                gvStock.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar errores
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "alert alert-danger";
                lblMensaje.Visible = true;
            }
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            // Implementar la lógica para agregar una imagen secundaria
            // Por ejemplo:
            // 1. Guardar la imagen en el servidor
            // 2. Actualizar la base de datos con la ruta de la imagen
            // 3. Actualizar el Repeater para reflejar los cambios
            // CargarImágenesSecundarias();
        }

        private string GuardarImagen(FileUpload archivo)
        {
            string carpeta = Server.MapPath("~/Recursos/Imagenes/Articulos/Primarias/");
            string nombreArchivo = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(archivo.FileName);
            string ruta = System.IO.Path.Combine(carpeta, nombreArchivo);
            archivo.SaveAs(ruta);
            return "~/Recursos/Imagenes/Articulos/Primarias/" + nombreArchivo;
        }
    }

    // Clase auxiliar para manejar tallas en el Repeater
    public class TallaStock
    {
        public string Talla { get; set; }
        public string Cantidad { get; set; }
    }
}