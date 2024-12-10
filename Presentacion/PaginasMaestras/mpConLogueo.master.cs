using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using Entidades;
using Negocios;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Presentacion.PaginasMaestras
{
    public partial class mpConLogueo : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            E_SesionUsuario usuario = new E_SesionUsuario();
            if (Session["snSesionUsuario"] != null)
            {
                usuario = (E_SesionUsuario)Session["snSesionUsuario"];

                lblTipoUsuario.Text = usuario.NombreRolLogueado;
                lblNombreUsuario.Text = usuario.NombreUsuario; 

                lbLogOut.Visible = true;

                // Controlar la visibilidad de los botones según el rol
                bool esAdministrador = usuario.NombreRolLogueado.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
                lbHistorialVentas.Visible = esAdministrador;
                lbExportarInventario.Visible = esAdministrador;
                lbClientes.Visible = esAdministrador;
            }
            else
            {
                Response.Redirect("~/GestionDeUsuarios/ValidaUsuarios.aspx");
            }

            if (!IsPostBack)
            {
                CargarCategorias();
            }
        }

        private void CargarCategorias()
        {
            N_Categoria negocioCategoria = new N_Categoria();
            List<E_Categoria> categorias = negocioCategoria.ListarCategorias();

            rptCategorias.DataSource = categorias;
            rptCategorias.DataBind();
        }

        protected void rptCategorias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                E_Categoria categoria = (E_Categoria)e.Item.DataItem;
                Repeater rptSubcategorias = (Repeater)e.Item.FindControl("rptSubcategorias");

                if (rptSubcategorias != null)
                {
                    N_SubCategoria negocioSubCategoria = new N_SubCategoria();
                    List<E_SubCategoria> subcategorias = negocioSubCategoria.ListarSubCategorias(categoria.IdCategoria);

                    rptSubcategorias.DataSource = subcategorias;
                    rptSubcategorias.DataBind();
                }
            }
        }

        protected string GetNavLinkClass(object generoId)
        {
            string selectedGenero = Request.QueryString["genero"];
            return generoId.ToString() == selectedGenero ? "nav-link active" : "nav-link";
        }

        protected void lbHistorialVentas_Click(object sender, EventArgs e)
        {
            if (EsAdministrador())
            {
                Response.Redirect("~/HistorialVentas/HistorialVentas.aspx");
            }
            else
            {
                MostrarMensajeAccesoDenegado();
            }
        }

        protected void lbExportarInventario_Click(object sender, EventArgs e)
        {
            if (EsAdministrador())
            {
                Response.Redirect("~/ExportarInventario/ExportarInventario.aspx");
            }
            else
            {
                MostrarMensajeAccesoDenegado();
            }
        }

        protected void lbClientes_Click(object sender, EventArgs e)
        {
            if (EsAdministrador()) 
            {
                Response.Redirect("~/Clientes/Clientes.aspx");
            }
            else
            {
                MostrarMensajeAccesoDenegado();
            }
        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Response.Redirect("~/GestionDeUsuarios/ValidaUsuarios.aspx");
        }

        protected bool EsAdministrador()
        {
            if (Session["snSesionUsuario"] is E_SesionUsuario usuario)
            {
                return usuario.NombreRolLogueado.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        protected void MostrarMensajeAccesoDenegado()
        {
            // Implementa la lógica para mostrar un mensaje al usuario.
            // Puede ser redirigir a una página de error o mostrar un popup.
            Response.Write("<script>alert('Acceso denegado. Solo los administradores pueden acceder a esta funcionalidad.');</script>");
        }
    }
}