using System;
using System.Collections.Generic;
using Entidades;
using Negocios;

namespace Presentacion.DetalleClientes
{
    public partial class DetalleClientes : System.Web.UI.Page
    {
        private readonly N_Personas negocioPersonas = new N_Personas();
        private readonly N_Apartados negocioApartados = new N_Apartados(); // Capa de negocio para apartados

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el idPersona desde la query string
                string idPersonaQuery = Request.QueryString["idPersona"];

                if (!string.IsNullOrEmpty(idPersonaQuery) && int.TryParse(idPersonaQuery, out int idPersona))
                {
                    CargarDetalleCliente(idPersona);
                    CargarApartadosCliente(idPersona);
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
                List<E_Personas> clientes = negocioPersonas.ObtenerDetalleCliente(idPersona);

                if (clientes != null && clientes.Count > 0)
                {
                    E_Personas cliente = clientes[0];
                    LblNombre.Text = cliente.Nombre;
                    LblTelefono.Text = cliente.Telefono;
                    LblLimiteCredito.Text = cliente.LimiteCredito.ToString("C");
                    LblLimiteDisponible.Text = cliente.LimiteDisponible.ToString("C");
                }
                else
                {
                    MostrarMensaje("No se encontraron detalles para este cliente.");
                    Response.Redirect("Clientes.aspx");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar los detalles del cliente: {ex.Message}");
            }
        }

        private void CargarApartadosCliente(int idUsuario)
        {
            try
            {
                // Obtener los apartados desde la capa de negocios
                List<E_Apartados> apartados = negocioApartados.ListarApartadosPorUsuario(idUsuario);

                if (apartados != null && apartados.Count > 0)
                {
                    foreach (var apartado in apartados)
                    {
                        // Crear dinámicamente los controles HTML para cada apartado
                        string apartadoHtml = $@"
                            <div class='apartado-item'>
                                <img src='{apartado.ImagenesArticulo}' alt='Imagen Artículo'>
                                <div class='apartado-details'>
                                    <p>{apartado.NombresArticulos}</p>
                                    <p>Fecha Apartado: {apartado.FechaApartado}</p>
                                    <p>ID: {apartado.IdApartado}</p>
                                    <p>Fecha de vencimiento: {apartado.FechaVencimiento: dd/MM/yyyy}</p>
                                    <button class='btn btn-detalle'>Ver detalles</button>
                                </div>
                            </div>";

                        // Agregar el HTML al contenedor dinámicamente
                        LiteralApartados.Text += apartadoHtml;
                    }
                }
                else
                {
                    LiteralApartados.Text = "<p>No hay apartados disponibles para este cliente.</p>";
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar los apartados: {ex.Message}");
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            // Usa un control Label en la página para mostrar mensajes al usuario
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }
    }
}
