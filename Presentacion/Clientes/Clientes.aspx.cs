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
                CargarClientes(); // Cargar todos los clientes al cargar la página
            }
        }

        private void CargarClientes(string nombre = "")
        {
            try
            {
                // Obtener el listado de clientes desde la capa de negocios
                List<E_Personas> clientes = string.IsNullOrWhiteSpace(nombre)
                    ? negocioClientes.ListarClientes()
                    : negocioClientes.ListarClientesPorNombre(nombre);

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

        protected void TbCriterioBusqueda_TextChanged(object sender, EventArgs e)
        {
            string nombre = TbCriterioBusqueda.Text.Trim(); // Capturar el texto ingresado
            CargarClientes(nombre); // Filtrar clientes por nombre
        }
    }   
}
