using System;
using System.Collections.Generic;
using Entidades;
using Negocios;

namespace Presentacion.DetalleClientes
{
    public partial class DetalleClientes : System.Web.UI.Page
    {
        private readonly N_Personas negocioPersonas = new N_Personas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el idPersona desde la query string
                string idPersonaQuery = Request.QueryString["idPersona"];

                if (!string.IsNullOrEmpty(idPersonaQuery) && int.TryParse(idPersonaQuery, out int idPersona))
                {
                    CargarDetalleCliente(idPersona);
                }
                else
                {
                    Response.Redirect("Clientes.aspx"); // Redirigir si no hay un id válido
                }
            }
        }

        private void CargarDetalleCliente(int idPersona)
        {
            try
            {
                // Obtener los detalles del cliente desde la capa de negocios
                List<E_Personas> detalles = negocioPersonas.ObtenerDetalleCliente(idPersona);

                if (detalles.Count > 0)
                {
                    var cliente = detalles[0];
                    LblNombre.Text = cliente.Nombre;
                    LblTelefono.Text = cliente.Telefono;
                    LblLimiteCredito.Text = cliente.LimiteCredito.ToString();
                    LblLimiteDisponible.Text = cliente.LimiteDisponible.ToString();
                }
                else
                {
                    Response.Write("<script>alert('No se encontraron detalles para este cliente.');</script>");
                    Response.Redirect("Clientes.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error al cargar los detalles del cliente: {ex.Message}');</script>");
            }
        }
    }
}