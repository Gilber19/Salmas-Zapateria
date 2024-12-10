using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace Presentacion.DetalleClientes
{
    public partial class DetalleClientes : System.Web.UI.Page
    {
        private readonly N_Personas negocioPersonas = new N_Personas();
        private readonly N_Apartados negocioApartados = new N_Apartados();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idPersonaQuery = Request.QueryString["idPersona"];

                if (!string.IsNullOrEmpty(idPersonaQuery) && int.TryParse(idPersonaQuery, out int idPersona))
                {
                    CargarDetalleCliente(idPersona);
                    CargarApartadosCliente(idPersona);
                }
                else
                {
                    Response.Redirect("Clientes.aspx");
                }
            }
        }

        private void CargarDetalleCliente(int idPersona)
        {
            try
            {
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
                    RepeaterApartados.DataSource = apartados;
                    RepeaterApartados.DataBind();
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

        protected void BtnAbonar_Click(object sender, EventArgs e)
        {
            var button = (System.Web.UI.WebControls.Button)sender;
            int idApartado = int.Parse(button.CommandArgument);

            var repeaterItem = (RepeaterItem)button.NamingContainer;
            var textBox = (System.Web.UI.WebControls.TextBox)repeaterItem.FindControl("txtAbono");

            if (textBox != null && int.TryParse(textBox.Text, out int cantidadAbono))
            {
                Debug.WriteLine($"Intentando abonar {cantidadAbono} al apartado con ID {idApartado}");

                if (negocioApartados.AbonarApartado(idApartado, cantidadAbono))
                {
                    MostrarMensaje("Abono realizado con éxito.");
                    CargarApartadosCliente(int.Parse(Request.QueryString["idPersona"]));
                }
                else
                {
                    MostrarMensaje("Error al realizar el abono.");
                }
            }
            else
            {
                MostrarMensaje("Ingrese una cantidad válida para abonar.");
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }

        protected Literal LiteralApartados; // Add this line to declare the LiteralApartados control
    }
}
