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
    public partial class RegistraUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            N_Usuario registrar = new N_Usuario();

            try
            {
                bool registrado = registrar.RegistrarUsuario(
                    wucNombre.Text.Trim(),
                    wucDireccion.Text.Trim(),
                    wucTelefono.Text.Trim(),
                    wucCorreoElectronico.Text.Trim(),
                    wucPassWord.Text.Trim()
                );

                if (registrado)
                {
                    lblMensaje.Text = "Usuario registrado exitosamente.";
                    Response.Redirect("/GestionDeUsuarios/ValidaUsuarios.aspx");
                }
                else
                {
                    lblMensaje.Text = "Error al registrar el usuario.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
            }
        }
    }
}