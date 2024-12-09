using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.HistorialVentas
{
    public partial class HistorialVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["snSesionUsuario"] != null)
                {
                    // Recuperar el objeto de la sesión
                    E_SesionUsuario usuario = (E_SesionUsuario)Session["snSesionUsuario"];
                    // Asignar el rol del usuario al label
                    lblNombreUsuario.Text = usuario.NombreRolLogueado;
                }
                else
                {
                    lblNombreUsuario.Text = "Invitado"; // Mensaje por defecto
                }
            }
        }

    }
}