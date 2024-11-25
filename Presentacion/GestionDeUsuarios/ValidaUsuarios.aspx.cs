using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.GestionDeUsuarios
{
  public partial class ValidaUsuarios : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnLogin_Click(object sender, EventArgs e)
    {
      E_SesionUsuario usuario = new E_SesionUsuario();

      if (AutenticarUsuario(tbCorreoElectronico.Text.Trim(), tbPassWord.Text.Trim()))
      {
        usuario.NombreUsuario = "VICTOR RAFAEL";
        usuario.NombreRolLogueado = "Administrador";
        usuario.EmailUsuario = "vvmejia@ventasgn.com";

        Session["snSesionUsuario"] = usuario;

        Response.Redirect("/Categorias/IBM_Categoria.aspx");
      }
      else
        lblMensaje.Text = "El correo o la contraseña es incorrecto.";
    }

    private bool AutenticarUsuario(string usuario, string password)
    {
      // Aquí debes implementar tu lógica de validación.      
      return usuario == "vvmejia@ventasgn.com" && password == "123"; // Reemplaza esto con la lógica real
    }
  }
}