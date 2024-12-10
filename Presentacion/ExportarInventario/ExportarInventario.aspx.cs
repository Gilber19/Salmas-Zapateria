using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.ExportarInventario
{
    public partial class ExportarInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["snSesionUsuario"] == null || ((Entidades.E_SesionUsuario)Session["snSesionUsuario"]).NombreRolLogueado != "Administrador")
            {
                Response.Redirect("~/HomePage/HomePage.aspx");
            }

            CargarNombreUsuario();
        }

        private void CargarNombreUsuario()
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

        protected void BtnExportar_Click(object sender, EventArgs e)
        {
            // Lógica para exportar datos
            // Ejemplo: Generar archivo Excel o PDF
            Response.Write("<script>alert('Datos exportados correctamente');</script>");
        }
    }
}