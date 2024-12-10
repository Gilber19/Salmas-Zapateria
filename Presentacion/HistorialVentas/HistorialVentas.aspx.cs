using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
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
                CargarNombreUsuario();
                ListarVentas();
            }
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

        private void ListarVentas()
        {
            try
            {
                N_Ventas negocioVentas = new N_Ventas();
                List<E_FacturaVentas> ventas = negocioVentas.ListarVentas();

                if (ventas != null && ventas.Count > 0)
                {
                    RepeaterHistorial.DataSource = ventas;
                    RepeaterHistorial.DataBind();
                }
                else
                {
                    // Mostrar un mensaje si no hay datos
                    RepeaterHistorial.DataSource = null;
                    RepeaterHistorial.DataBind();
                    MostrarMensaje("No hay ventas registradas.");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MostrarMensaje("Ocurrió un error al listar las ventas: " + ex.Message);
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            // Si tienes un Label o Literal para mensajes, úsalo aquí
            lblMensaje.Text = mensaje;
            lblMensaje.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgregarVenta/AgregarVenta.aspx");
        }
    }
}