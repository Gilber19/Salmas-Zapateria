using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Apartados
{
    public partial class Apartados : System.Web.UI.Page
    {
        private N_Articulo negocioArticulo = new N_Articulo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["snSesionUsuario"] == null || ((E_SesionUsuario)Session["snSesionUsuario"]).NombreRolLogueado != "Cliente")
            {
                Response.Redirect("~/HomePage/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                BindApartados();
            }
        }

        private void BindApartados()
        {
            var apartados = Session["Apartados"] as List<E_ArticuloApartado> ?? new List<E_ArticuloApartado>();

            rptApartados.DataSource = apartados;
            rptApartados.DataBind();

            double total = 0;
            foreach (var item in apartados)
            {
                E_Articulo articulo = negocioArticulo.BuscarArticuloPorID(item.IdArticulo);
                if (articulo != null)
                {
                    total += articulo.PrecioVenta * item.Cantidad;
                }
            }

            litTotal.Text = total.ToString("N2");
        }

        protected void rptApartados_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                EliminarApartado(idArticulo);
            }
            else if (e.CommandName == "Actualizar")
            {
                int idArticulo = Convert.ToInt32(e.CommandArgument);
                // Encontrar el TextBox dentro del Repeater
                TextBox txtCantidad = (TextBox)e.Item.FindControl("txtCantidad");
                if (txtCantidad != null)
                {
                    int nuevaCantidad;
                    if (int.TryParse(txtCantidad.Text, out nuevaCantidad) && nuevaCantidad > 0)
                    {
                        ActualizarCantidad(idArticulo, nuevaCantidad);
                    }
                    else
                    {
                        // Opcional: Manejar cantidades inválidas
                        // Por ejemplo, mostrar un mensaje de error
                    }
                }
            }
        }

        private void EliminarApartado(int idArticulo)
        {
            var apartados = Session["Apartados"] as List<E_ArticuloApartado>;
            if (apartados != null)
            {
                var articulo = apartados.Find(a => a.IdArticulo == idArticulo);
                if (articulo != null)
                {
                    apartados.Remove(articulo);
                    Session["Apartados"] = apartados;
                    BindApartados();
                }
            }
        }

        private void ActualizarCantidad(int idArticulo, int nuevaCantidad)
        {
            var apartados = Session["Apartados"] as List<E_ArticuloApartado>;
            if (apartados != null)
            {
                var articulo = apartados.Find(a => a.IdArticulo == idArticulo);
                if (articulo != null)
                {
                    articulo.Cantidad = nuevaCantidad;
                    Session["Apartados"] = apartados;
                    BindApartados();
                }
            }
        }

        protected void Apartar_Click(object sender, EventArgs e)
        {
            var apartados = Session["Apartados"] as List<E_ArticuloApartado>;
            if (apartados != null && apartados.Count > 0)
            {
                // Implementar la lógica para guardar el apartado en la base de datos
                // Por ejemplo:
                // foreach(var item in apartados)
                // {
                //     negocioArticulo.ApartarArticulo(item);
                // }

                // Limpiar la sesión después de apartar
                Session["Apartados"] = null;
                BindApartados();

                // Opcional: redirigir a una página de confirmación
                Response.Redirect("~/HomePage/HomePage.aspx");
            }
        }

        public string ObtenerPrimeraImagen(int idArticulo)
        {
            E_Articulo articulo = negocioArticulo.BuscarArticuloPorID(idArticulo);
            if (articulo != null && !string.IsNullOrEmpty(articulo.Imagenes))
            {
                string primeraImagen = articulo.Imagenes.Split(',')[0].Trim();
                System.Diagnostics.Debug.WriteLine(primeraImagen);

                return primeraImagen;
            }
            else {
                return "/Recursos/Imagenes/Articulos/default.jpg";
            }
        }

        public string ObtenerNombreArticulo(int idArticulo)
        {
            E_Articulo articulo = negocioArticulo.BuscarArticuloPorID(idArticulo);
            return articulo != null ? articulo.NombreArticulo : "Desconocido";
        }

        public string ObtenerPrecioVenta(int idArticulo)
        {
            E_Articulo articulo = negocioArticulo.BuscarArticuloPorID(idArticulo);
            return articulo != null ? articulo.PrecioVenta.ToString("N2") : "0.00";
        }
    }
}