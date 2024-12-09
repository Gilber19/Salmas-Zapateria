using System;
using System.Collections.Generic;
using Negocios;
using Entidades;

namespace Presentacion.Clientes
{
    public partial class Clientes : System.Web.UI.Page
    {
        private readonly N_Personas negocioClientes = new N_Personas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes(); // Cargar clientes al cargar la página
            }
        }

        private void CargarClientes()
        {
            try
            {
                // Obtener el listado de clientes desde la capa de negocios
                List<E_Personas> clientes = negocioClientes.ListarClientes();

                if (clientes == null || clientes.Count == 0)
                {
                    RepeaterClientes.DataSource = null;
                    RepeaterClientes.DataBind();
                    return;
                }

                // Asignar datos al Repeater y enlazar
                RepeaterClientes.DataSource = clientes;
                RepeaterClientes.DataBind();
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en la página
                Response.Write($"<script>alert('Error al cargar los clientes: {ex.Message}');</script>");
            }
        }
    }
}
