using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;

namespace Presentacion.HomePage
{
    public partial class HomePage : System.Web.UI.Page
    {
        public bool IsEditMode
        {
            get
            {
                return ViewState["IsEditMode"] != null && (bool)ViewState["IsEditMode"];
            }
            set
            {
                ViewState["IsEditMode"] = value;
            }
        }

        public bool GetIsEditMode()
        {
            return IsEditMode;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si el usuario ha iniciado sesión
            if (Session["snSesionUsuario"] is E_SesionUsuario usuario)
            {
                // Verifica si el usuario es administrador
                if (usuario.NombreRolLogueado == "Administrador")
                {
                    // Permite la edición
                    btnToggleEditMode.Visible = true;
                    IsEditMode = GetIsEditMode();
                    UpdateEditMode();
                }
                else
                {
                    // Oculta las opciones de edición
                    btnToggleEditMode.Visible = false;
                    IsEditMode = false;
                    UpdateEditMode();
                }
            }
            else
            {
                // Redirige al usuario a la página de inicio de sesión
                Response.Redirect("~/GestionDeUsuarios/ValidaUsuarios.aspx");
            }

            BindProductos();
        }

        private void BindProductos()
        {
            N_Articulo N_Articulo = new N_Articulo();
            List<E_Articulo> productos = new List<E_Articulo>();

            //List<E_Articulo> a = new N_Articulo().ListarArticulosPorSubCategoria(1, 1); //DEBUG ONLY
            //List<E_Personas> b = new N_Personas().ListarClientes(); //DEBUG ONLY
            //List<E_FacturaVentas> c = new N_Ventas().ListarVentas(); //DEBUG ONLY
            //List<E_Personas> d = new N_Personas().ObtenerDetalleCliente(2); //DEBUG ONLY
            //E_Articulo e = new N_Articulo().BuscarArticuloPorID(1); //DEBUG ONLY
            //List<E_Articulo> f = new N_Articulo().ListarArticulos(); //DEBUG ONLY
            //List<E_Apartados> g = new N_Apartados().ListarDetalleApartado(2); //DEBUG ONLY
            //List<E_Apartados> h = new N_Apartados().ObtenerApartadosPorVencer(); //DEBUG ONLY

            // ATENCION ATENCION ATENCION ATENCION ATENCION ATENCION ATENCION ATENCION ATENCION ATENCION ATENCION
            // ASI SE CREAN VENTAS
            
            N_Ventas nventas = new N_Ventas();
            List<E_DetalleVentas> detalles = new List<E_DetalleVentas>()
            {
                new E_DetalleVentas { IdArticulo = 1, IdTalla = 2, Cantidad = 3, Descuento = 0 },
                new E_DetalleVentas { IdArticulo = 3, IdTalla = 1, Cantidad = 1, Descuento = 0 }
            };

            // Crear el objeto E_Venta y asignar los valores correspondientes
            E_Venta venta = new E_Venta
            {
                IdUsuario = 1,               
                IdTipoVenta = "3",             
                TipoComprobante = "Factura", 
                SerieComprobante = "A001",   
                NumeroComprobante = "12345", 
                FechaHora = DateTime.Now,    
                Impuesto = 8.0,            
                Estado = true                
            };

            // Monto abonado (esta me la mandan ustedes desde front)
            decimal montoAbonado = 100.00m;

            try
            {
                // Pasar el objeto venta, la lista de detalles y el monto abonado al método ProcesarVenta
                int idVenta = nventas.ProcesarVenta(venta, detalles, montoAbonado);
                System.Diagnostics.Debug.WriteLine("Venta procesada con éxito. ID de venta: " + idVenta);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERROR ProcesarVenta (PRESENTACION)");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            //*/



            bool hasGenero = int.TryParse(Request.QueryString["genero"], out int genero);
            bool hasCategoria = int.TryParse(Request.QueryString["categoria"], out int categoria);
            bool hasSubcategoria = int.TryParse(Request.QueryString["subcategoria"], out int subcategoria);

            if (hasGenero)
            {
                if (hasCategoria)
                {
                    if (hasSubcategoria)
                    {
                        productos = N_Articulo.ListarArticulosPorSubCategoria(genero, subcategoria);
                    }
                    else
                    {
                        productos = N_Articulo.ListarArticulosPorCategoria(genero, categoria);
                    }
                }
                else
                {
                    productos = N_Articulo.ListarArticulosPorGenero(genero);
                }
            }
            else
            {
                if (hasCategoria)
                {
                    if (hasSubcategoria)
                    {
                        productos = N_Articulo.ListarArticulosPorSubCategoria(categoria, subcategoria);
                    }
                    else
                    {
                        productos = N_Articulo.ListarArticulosPorCategoria(1, categoria);
                    }
                }
                else
                {
                    productos = N_Articulo.ListarArticulos();
                }
            }

            if (productos != null && productos.Count > 0)
            {
                rptProductos.DataSource = productos;
                rptProductos.DataBind();
                pnlNoData.Visible = false;
            }
            else
            {
                rptProductos.DataSource = null;
                rptProductos.DataBind();
                IsEditMode = true;
                pnlNoData.Visible = true;
            }
        }

        private void UpdateEditMode()
        {
            pnlDefaultMode.Visible = !IsEditMode;
            pnlEditMode.Visible = IsEditMode;
            btnToggleEditMode.Text = IsEditMode ? "Añadir" : "Editar";

            // Actualizar la fuente de datos
            BindProductos();
        }

        protected void ToggleEditMode_Click(object sender, EventArgs e)
        {
            IsEditMode = !IsEditMode;
            lblMensaje.Visible = false;
            UpdateEditMode();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgregarArticulo/AgregarArticulo.aspx");
        }

        protected void rptProductos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandArgument == null)
                return;

            if (!int.TryParse(e.CommandArgument.ToString(), out int idArticulo))
                return;

            switch (e.CommandName)
            {
                case "Eliminar":
                    EliminarArticulo(idArticulo);
                    break;
                case "Modificar":
                    ModificarArticulo(idArticulo);
                    break;
            }

            BindProductos();
        }

        private void EliminarArticulo(int idArticulo)
        {
            N_Articulo N_Articulo = new N_Articulo();
            string resultado = N_Articulo.BorrarArticulo(idArticulo);

            lblMensaje.Visible = true;
            if (resultado.StartsWith("Exito"))
            {
                lblMensaje.Text = resultado;
                lblMensaje.CssClass = "alert alert-success";
            }
            else
            {
                lblMensaje.Text = resultado;
                lblMensaje.CssClass = "alert alert-danger";
            }
        }

        private void ModificarArticulo(int idArticulo)
        {
            Response.Redirect($"~/ModificarArticulo/ModificarArticulo.aspx?id={idArticulo}");
        }

        protected void RedireccionarAProducto(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender; // Correct type casting
            RepeaterItem item = (RepeaterItem)btn.NamingContainer; // Get the RepeaterItem
            HiddenField hfIdArticulo = (HiddenField)item.FindControl("hfIdArticulo");

            if (hfIdArticulo != null && !string.IsNullOrEmpty(hfIdArticulo.Value))
            {
                Response.Redirect($"~/VerArticulo/VerArticulo.aspx?idArticulo={hfIdArticulo.Value}");
            }
        }


    }
}