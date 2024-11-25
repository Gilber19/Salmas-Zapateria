using System;
using System.Web.Security;
using System.Web;

using Entidades;

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
      }
      else
        Response.Redirect("~/GestionDeUsuarios/ValidaUsuarios.aspx");
    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
      FormsAuthentication.SignOut();
      Session.Abandon();
      Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
      Response.Redirect("~/GestionDeUsuarios/ValidaUsuarios.aspx");
    }
  }
}