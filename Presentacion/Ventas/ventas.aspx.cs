
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;



using Negocios;
using Entidades;

using System.Collections.Generic;

namespace Presentacion.Ventas
{
  public partial class ventas : System.Web.UI.Page
  {
    readonly N_Articulo NA = new N_Articulo();
    readonly N_Clientes NC = new N_Clientes();
    E_FacturaVentas Factura = new E_FacturaVentas();



    protected void Page_Load(object sender, EventArgs e)
    {
      TbCriterioBusqueda.Focus();
      if (!IsPostBack)
      {
        ddlClientes.DataSource = NC.ListadoCliente();
        ddlClientes.DataBind();
        tbFechaHora.Text = DateTime.Now.ToString();
        CalculoVenta();
      }
      else
      {
        if (Session["sesionventas"] != null)
        {
          Factura = (E_FacturaVentas)Session["sesionventas"];
          
          if (Factura.ListaArticulos != null)
          {

          }
        }
      }
    }
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
      int cant = 1;
      try
      {
        var regex = new Regex(@"^\d{0,4}\*?[a-zA-Z0-9]{1,20}$");
        if (!regex.IsMatch(TbCriterioBusqueda.Text.Trim()))
        {
          lbllMesajeBusqueda.Text = "El formato de la compra es erronea.";
        }
        if (TbCriterioBusqueda.Text.Trim() != string.Empty)
        {
          string[] calculo = TbCriterioBusqueda.Text.Split('*');

          if (calculo.Length > 1)
          {
            if (calculo[1] != string.Empty)
            {
              TbCriterioBusqueda.Text = calculo[1];
              cant = Convert.ToInt16(calculo[0]);
            }
          }
          else
            TbCriterioBusqueda.Text = calculo[0];

          E_Articulo articulo = NA.BuscarArticuloPorCodigo(TbCriterioBusqueda.Text);

          if (articulo == null)        // No se encontró el articulo
            lbllMesajeBusqueda.Text = "No se encontró el sistema solicitado";
          else
          {
            TbCriterioBusqueda.Text = string.Empty;
            E_Venta ventaArticulo = new E_Venta
            {
              IdArticulo = articulo.IdArticulo,
              CodigoArticulo = articulo.CodigoArticulo,
              NombreArticulo = articulo.NombreArticulo,
              PrecioVenta = Convert.ToDouble(articulo.PrecioVenta),
              Cantidad = cant,
              Importe = cant * Convert.ToDouble(articulo.PrecioVenta),
              Descuento = 0
            };


            Factura.ListaArticulos.Add(ventaArticulo);
            Session["sesionventas"] = Factura;
            CalculoVenta();
          }
          GrvVentas.DataSource = Factura.ListaArticulos;
          GrvVentas.DataBind();
        }
      }
      catch (Exception ex)
      {
        lbllMesajeBusqueda.Text = "Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda." + ex;
      }
    }

    protected void tbCantidad_TextChanged(object sender, EventArgs e)
    {
      TextBox tbCantidad = (TextBox)sender;
      GridViewRow row = (GridViewRow)tbCantidad.NamingContainer;

      Label lblPrecioVenta = (Label)row.FindControl("lblPrecioVenta");
      Label lblImporte = (Label)row.FindControl("lblImporte");

      if (tbCantidad != null && lblPrecioVenta != null && lblImporte != null)
      {
        if (int.TryParse(tbCantidad.Text, out int cantidad)
          && double.TryParse(lblPrecioVenta.Text, out double precioVenta)
          && double.TryParse(lblImporte.Text, out double importe))
        {
          Factura.TotalArticulos -= (int)(importe / precioVenta);
          Factura.TotalArticulos += cantidad;
          Factura.Total -= importe;
          importe = cantidad * precioVenta;
          Factura.Total += importe;
          Factura.ImpuestoVenta = Factura.Total * 0.08;
          Factura.Total += Factura.ImpuestoVenta;

          lblImporte.Text = importe.ToString("C2");

          if (Factura != null)
          {
            foreach (E_Venta v in Factura.ListaArticulos)
            {
              if (v.CodigoArticulo == row.Cells[0].Text)
              {
                v.Cantidad = cantidad;
                v.Importe = importe;
                break;
              }
            }
          }
          Session["sesionventas"] = Factura;
          CalculoVenta();
          GrvVentas.DataSource = Factura.ListaArticulos;
          GrvVentas.DataBind();
          UP_General.Update();
          UP_GrvVentas.Update();
        }
      }
    }

    protected void tbCalculaDescuento_TextChanged(object sender, EventArgs e)
    {
    }

    private void CalculoVenta()
    {
      E_FacturaVentas factura = (E_FacturaVentas)Session["sesionventas"];

      if (factura != null)
      {
        double total = 0;
        double impuesto = 0;
        double subtotal = 0;
        int cantidad = 0;

        if (factura.ListaArticulos != null)
        {
          foreach (E_Venta v in factura.ListaArticulos)
          {
            subtotal += Convert.ToDouble(v.Importe);
            cantidad += Convert.ToInt16(v.Cantidad);
          }
          impuesto = subtotal * 0.08;
          total = subtotal + impuesto;

          Factura.Total = total;
          Factura.ImpuestoVenta = impuesto;
          Factura.TotalArticulos = cantidad;

          Session["sesionventas"] = Factura;

          lblSubTotal.Text = "SubTotal : " + subtotal.ToString("C2", new System.Globalization.CultureInfo("en-US"));
          lblImpuesto.Text = "IVA : " + impuesto.ToString("C2", new System.Globalization.CultureInfo("en-US"));
          lblTotal.Text = total.ToString("C2", new System.Globalization.CultureInfo("en-US"));
          lblTotalArticulos.Text = "Total Artículos: " + Factura.TotalArticulos.ToString();
        }
      }
    }

    protected void GrvVentas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      e.Cancel = true; //Deshabilitar las ediciones del registro

      Factura = (E_FacturaVentas)Session["sesionventas"];
      Factura.ListaArticulos.RemoveAt(e.RowIndex);
      Session["sesionventas"] = Factura;

      CalculoVenta();
      GrvVentas.DataSource = Factura.ListaArticulos;
      GrvVentas.DataBind();
      UP_General.Update();
      //UP_GrvVentas.Update();
    }

    protected void btnCobrar_Click(object sender, EventArgs e)
    {
      Factura = (E_FacturaVentas)Session["sesionventas"];

      using (SqlConnection connection = new SqlConnection("Server=PRESTI-PC/SQLEXPRESS; Database=ControlDeVentas; Trusted_Connection=SSPI; " +
        "MultipleActiveResultSets=true; TrustServerCertificate=True"))
      {
        connection.Open();
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
          // Grabar los datos de la factura
          string queryFactura = "INSERT INTO Ventas (IdPersona, IdUsuario, TipoComprobante, SerieComprobante, NumeroComprobante," +
                                                     "FechaHora, TotalVenta, ImpuestoVenta, Estado) " +
                                                     "OUTPUT INSERTED.ID VALUES " +
                                                     "(@IdPersona, @IdUsuario, @TipoComprobante, @SerieComprobante, @NumeroComprobante," +
                                                     " @FechaHora, @TotalVenta, @ImpuestoVenta, @Estado)";
          SqlCommand commandFactura = new SqlCommand(queryFactura, connection, transaction);
          commandFactura.Parameters.AddWithValue("@IdPersona", ddlClientes.SelectedItem);
          commandFactura.Parameters.AddWithValue("@IdUsuario", 1);
          commandFactura.Parameters.AddWithValue("@TipoComprobante", tbTipoComprobante.Text);
          commandFactura.Parameters.AddWithValue("@SerieComprobante", tbSerieComprobante.Text);
          commandFactura.Parameters.AddWithValue("@NumeroComprobante", tbNumeroComprobante.Text);
          commandFactura.Parameters.AddWithValue("@FechaHara", Convert.ToDateTime("2024/12/12"));
          commandFactura.Parameters.AddWithValue("@TotalVenta", Factura.Total);
          commandFactura.Parameters.AddWithValue("@ImpuestoVenta", Factura.ImpuestoVenta);
          commandFactura.Parameters.AddWithValue("@Estado", true);

          int idVenta = (int)commandFactura.ExecuteScalar();

          // Grabar los datos de cada venta en la factura
          foreach (var venta in Factura.ListaArticulos)
          {
            string queryVenta = "INSERT INTO DetalleVentas " +
                                      "(IdVenta, IdArticulo, Cantidad, PrecioVenta, Descuento) " +
                                "VALUES (@IdVenta, @IdArticulo, @Cantidad, @PrecioVenta, @Descuento)";
            SqlCommand commandVenta = new SqlCommand(queryVenta, connection, transaction);
            commandVenta.Parameters.AddWithValue("@IdVenta", idVenta);
            commandVenta.Parameters.AddWithValue("@IdArticulo", venta.IdArticulo);
            commandVenta.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
            commandVenta.Parameters.AddWithValue("@PrecioVenta", venta.PrecioVenta);
            commandVenta.Parameters.AddWithValue("@Descuento", venta.Descuento);
            commandVenta.ExecuteNonQuery();
          }

          transaction.Commit();
        }
        catch(Exception ex)
        {
          lbllMesajeBusqueda.Text = "Error: " + ex.Message + " " + ex.InnerException + " cuando se trataga de grabar la venta." + ex;
          transaction.Rollback();
          throw;
        }
      }
    }


  }


}