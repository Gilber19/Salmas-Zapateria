using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

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
                usuario.NombreUsuario = "Nombre de Usuario";
                usuario.NombreRolLogueado = "Administrador";
                usuario.EmailUsuario = "admin@salmaszapateria.com";

                Session["snSesionUsuario"] = usuario;

                Response.Redirect("/HomePage/HomePage.aspx");
            }
            else
                lblMensaje.Text = "El correo o la contraseña es incorrecto.";
        }

        private bool AutenticarUsuario(string usuario, string password)
        {
            N_Usuario validar = new N_Usuario();

            return validar.ValidarLogin(usuario, password);
        }
    }
}