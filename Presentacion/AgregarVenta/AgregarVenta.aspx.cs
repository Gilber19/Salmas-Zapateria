using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.AgregarVenta
{
    public partial class AgregarVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarVentas();
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
    }
}