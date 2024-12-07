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
            if (!IsPostBack)
            {
                BindProductos();
                UpdateEditMode();
            }
        }

        private void BindProductos()
        {
            N_Articulo negociosArticulo = new N_Articulo();
            List<E_Articulo> productos = negociosArticulo.ListarArticulos();

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

            rptProductos.DataSource = new N_Articulo().ListarArticulos();
            rptProductos.DataBind();
        }

        protected void ToggleEditMode_Click(object sender, EventArgs e)
        {
            IsEditMode = !IsEditMode;
            lblMensaje.Visible = false;

            UpdateEditMode();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }

        protected void rptProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument == null)
                return;

            if (!int.TryParse(e.CommandArgument.ToString(), out int productId))
                return;

            switch (e.CommandName)
            {
                case "Eliminar":
                    EliminarProducto(productId);
                    break;
                case "Modificar":
                    ModificarProducto(productId);
                    break;
            }

            BindProductos();
        }

        private void EliminarProducto(int productId)
        {
            N_Articulo negociosArticulo = new N_Articulo();
            // bool exito = negociosArticulo.EliminarArticulo(productId);
            bool exito = true;

            lblMensaje.Visible = true;

            if (exito)
            {
                lblMensaje.Text = "Producto eliminado exitosamente.";
                lblMensaje.CssClass = "alert alert-success";
            }
            else
            {
                lblMensaje.Text = "Error al eliminar el producto.";
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        private void ModificarProducto(int productId)
        {
            // Response.Redirect($"ModificarProducto.aspx?id={productId}");
        }
    }
}