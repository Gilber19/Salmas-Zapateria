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
            if (AutenticarUsuario(tbCorreoElectronico.Text.Trim(), tbPassWord.Text.Trim()))
            {
                N_Usuario negocioUsuario = new N_Usuario();

                E_Usuario usuarioInfo = negocioUsuario.RetornarId(tbCorreoElectronico.Text.Trim()).FirstOrDefault();

                System.Diagnostics.Debug.WriteLine(usuarioInfo.IdUsuario);
                if (usuarioInfo != null)
                {
                    E_SesionUsuario usuario = new E_SesionUsuario
                    {
                        IdUsuario = usuarioInfo.IdUsuario,
                        IdRolLogueado = usuarioInfo.IdRol,
                        NombreUsuario = usuarioInfo.NombreUsuario,
                    };

                    switch (usuario.IdRolLogueado)
                    {
                        case 1:
                            usuario.NombreRolLogueado = "Administrador";
                            break;
                        case 2:
                            usuario.NombreRolLogueado = "Cliente";
                            break;
                        case 3:
                            usuario.NombreRolLogueado = "Empleado";
                            break;
                    }

                    usuario.EmailUsuario = tbCorreoElectronico.Text.Trim();

                    Session["snSesionUsuario"] = usuario;
                    Response.Redirect("/HomePage/HomePage.aspx");
                }
                else
                {
                    lblMensaje.Text = "Error al recuperar la información del usuario.";
                }
            }
            else
            {
                lblMensaje.Text = "El correo o la contraseña es incorrecto.";
            }
        }

        private bool AutenticarUsuario(string usuario, string password)
        {
            N_Usuario validar = new N_Usuario();

            return validar.ValidarLogin(usuario, password);
        }
    }
}