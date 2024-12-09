using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace Presentacion.HomePage
{
    public partial class HomePage : System.Web.UI.Page
    {
        public bool IsEditMode
        {
            get
            {
                return ViewState["IsEditMode"] != null && (bool)ViewState["IsEditMode"];
            }
            set
            {
                ViewState["IsEditMode"] = value;
            }
        }

        public bool GetIsEditMode()
        {
            return IsEditMode;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindProductos();
            if (!IsPostBack)
            {
                UpdateEditMode();
            }
        }

        private void BindProductos()
        {
            N_Articulo N_Articulo = new N_Articulo();
            List<E_Articulo> productos = new List<E_Articulo>();

            bool hasGenero = int.TryParse(Request.QueryString["genero"], out int genero);
            bool hasCategoria = int.TryParse(Request.QueryString["categoria"], out int categoria);
            bool hasSubcategoria = int.TryParse(Request.QueryString["subcategoria"], out int subcategoria);

            if (hasGenero)
            {
                if (hasCategoria)
                {
                    if (hasSubcategoria)
                    {
                        productos = N_Articulo.ListarArticulosPorSubCategoria(genero, subcategoria);
                    }
                    else
                    {
                        productos = N_Articulo.ListarArticulosPorCategoria(genero, categoria);
                    }
                }
                else
                {
                    productos = N_Articulo.ListarArticulosPorGenero(genero);
                }
            }
            else
            {
                if (hasCategoria)
                {
                    if (hasSubcategoria)
                    {
                        productos = N_Articulo.ListarArticulosPorSubCategoria(categoria, subcategoria);
                    }
                    else
                    {
                        productos = N_Articulo.ListarArticulosPorCategoria(1, categoria);
                    }
                }
                else
                {
                    productos = N_Articulo.ListarArticulos();
                }
            }

            if (productos != null && productos.Count > 0)
            {
                rptProductos.DataSource = productos;
                rptProductos.DataBind();
                pnlNoData.Visible = false;
            }
            else
            {
                rptProductos.DataSource = null;
                rptProductos.DataBind();
                IsEditMode = true;
                pnlNoData.Visible = true;
            }
        }

        private void UpdateEditMode()
        {
            pnlDefaultMode.Visible = !IsEditMode;
            pnlEditMode.Visible = IsEditMode;
            btnToggleEditMode.Text = IsEditMode ? "Añadir" : "Editar";

            // Actualizar la fuente de datos
            BindProductos();
        }

        protected void ToggleEditMode_Click(object sender, EventArgs e)
        {
            IsEditMode = !IsEditMode;
            lblMensaje.Visible = false;
            UpdateEditMode();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgregarArticulo/AgregarArticulo.aspx");
        }

        protected void rptProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument == null)
                return;

            if (!int.TryParse(e.CommandArgument.ToString(), out int idArticulo))
                return;

            switch (e.CommandName)
            {
                case "Eliminar":
                    EliminarArticulo(idArticulo);
                    break;
                case "Modificar":
                    ModificarArticulo(idArticulo);
                    break;
            }

            BindProductos();
        }

        private void EliminarArticulo(int idArticulo)
        {
            N_Articulo N_Articulo = new N_Articulo();
            string resultado = N_Articulo.BorrarArticulo(idArticulo);

            lblMensaje.Visible = true;
            if (resultado.StartsWith("Exito"))
            {
                lblMensaje.Text = resultado;
                lblMensaje.CssClass = "alert alert-success";
            }
            else
            {
                lblMensaje.Text = resultado;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        private void ModificarArticulo(int idArticulo)
        {
            Response.Redirect($"~/ModificarArticulo/ModificarArticulo.aspx?id={idArticulo}");
        }
    }
}