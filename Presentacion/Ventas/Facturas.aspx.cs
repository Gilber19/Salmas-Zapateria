using System;
using System.Collections.Generic;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

using MigraDoc.DocumentObjectModel.Shapes;

using Negocios;
using Entidades;
using System.IO;

namespace Presentacion.Ventas
{
  public partial class Facturas : System.Web.UI.Page
  {
    readonly N_Articulo NA = new N_Articulo();
    readonly N_Clientes NC = new N_Clientes();
    E_FacturaVentas Factura = new E_FacturaVentas();

    readonly N_Ventas NV = new N_Ventas();
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void btnGeneraFactura_Click(object sender, EventArgs e)
    {
      string Ruta = Server.MapPath("~/Facturas/" + "Factura.pdf");
      CrearFactura(Ruta);
    }

    public void CrearFactura(string RutaNombre)
    {
      List<E_Factura> lstFactura = NV.BuscarFactura(tbCriterio.Text.Trim());
      if (lstFactura.Count > 0)
      {
        // Crear un nuevo documento
        Document document = new Document();
        document.Info.Title = "Factura";
        document.Info.Subject = "Factura de ventas";
        document.Info.Author = "PCSIS";

        // Configurar estilos
        DefineEstilos(document);

        // Agregar una sección
        Section section = document.AddSection();
        // Establecer los márgenes de la hoja
        section.PageSetup.LeftMargin = Unit.FromCentimeter(2);
        section.PageSetup.RightMargin = Unit.FromCentimeter(2);
        section.PageSetup.TopMargin = Unit.FromCentimeter(1.5);
        section.PageSetup.BottomMargin = Unit.FromCentimeter(2);

        // Agregar encabezado
        AgregaEncabezado(section, lstFactura);

        // Agregar datos del cliente
        InformacionCliente(section, lstFactura);

        // Agregar tabla de artículos
        AddItemsTable(section, lstFactura);

        // Agregar resumen y total
        DetalleVentas(section, lstFactura);

        // Renderizar el documento
        PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
        pdfRenderer.Document = document;
        pdfRenderer.RenderDocument();

        // Guardar el documento en un archivo
        RutaNombre = Server.MapPath("~/Facturas/") + "Factura.pdf";
        pdfRenderer.PdfDocument.Save(RutaNombre);
        string Nombre = "/Facturas/" + Path.GetFileName(RutaNombre);
        // Abrir el documento con el visor de PDF predeterminado        
        Response.Redirect("/Ventas/VerFactura.aspx?pdf=" + Nombre);
        //Process.Start(RutaNombre);
      }
    }

    private void DefineEstilos(Document document)
    {
      // Definir estilos para el documento
      Style style = document.Styles["Normal"];
      style.Font.Name = "Arial";

      style = document.Styles[StyleNames.Header];
      style.ParagraphFormat.AddTabStop("0cm", TabAlignment.Right);

      style = document.Styles[StyleNames.Footer];
      style.ParagraphFormat.AddTabStop("2cm", TabAlignment.Center);

      style = document.Styles.AddStyle("Table", "Normal");
      style.Font.Name = "Arial";
      style.Font.Size = 12;

      style = document.Styles.AddStyle("Reference", "Normal");
      style.ParagraphFormat.SpaceBefore = "5mm";
      style.ParagraphFormat.SpaceAfter = "5mm";
      style.ParagraphFormat.TabStops.AddTabStop("5cm", TabAlignment.Right);
    }

    private void AgregaEncabezado(Section section, List<E_Factura> lstFactura)
    {
      // Agregar una imagen

      string imagePath = "E:\\VentasWebGN\\Presentacion\\Recursos\\Imagenes\\ImagenGN.png";
      Image image = section.AddImage(imagePath);
      image.Width = Unit.FromCentimeter(18);
      image.Height = Unit.FromCentimeter(2.5);

      // Agregar encabezado con el título de la factura
      Paragraph paragraph = section.AddParagraph();
      paragraph.Format.SpaceBefore = "0.5cm";
      paragraph.Format.SpaceAfter = "0.5cm";
      paragraph.Format.Alignment = ParagraphAlignment.Right;
      paragraph.Format.Font.Size = 20;
      paragraph.Format.Font.Bold = true;
      paragraph.Format.Font.Color = new Color(0, 0, 255);
      paragraph.AddText(lstFactura[0].TipoComprobante);
    }

    private void InformacionCliente(Section section, List<E_Factura> lstFactura)
    {

      // Agregar información del cliente
      Table table = section.AddTable();

      table.Borders.Width = 0;
      table.Rows.LeftIndent = 0;

      Column column = table.AddColumn("9cm");
      column.Format.Alignment = ParagraphAlignment.Left;

      column = table.AddColumn("9cm");
      column.Format.Alignment = ParagraphAlignment.Left;

      Row row = table.AddRow();

      row = table.AddRow();
      row.Cells[0].AddParagraph("Tipo: " + lstFactura[0].TipoComprobante);
      row.Cells[1].AddParagraph("VENTAS GERRERO NEGRO");

      row = table.AddRow();
      row.Cells[0].AddParagraph("Serie: " + lstFactura[0].SerieComprobante);
      row.Cells[1].AddParagraph("Calle Coral No. 1685 Col. Niños Heroes");

      row = table.AddRow();
      row.Cells[0].AddParagraph("Comprobante No: " + lstFactura[0].NumeroComprobante);
      row.Cells[1].AddParagraph("Ensenada, Baja California");

      row = table.AddRow();
      row.Cells[0].AddParagraph("Fecha: " + Convert.ToDateTime(lstFactura[0].FechaHora).ToString());
      row.Cells[1].AddParagraph("Tel. 646-52-96-59. Email; ventas@ventasgn.com");

      row = table.AddRow();
      row.Cells[0].AddParagraph("");
      row.Cells[1].AddParagraph("");

      row.Cells[0].AddParagraph("Cliente: " + lstFactura[0].Cliente);
      row.Cells[1].AddParagraph("Cajero : " + lstFactura[0].Usuario);

      row = table.AddRow();
      row.Cells[0].AddParagraph("Dirección: " + "FALTA DE SP: Calle Falsa 123, Ciudad de México, CDMX");
      row.Cells[1].AddParagraph("");

      row = table.AddRow();
      row.Cells[0].AddParagraph("Telefono: " + "FALTA DE SP: 646.174.25.55");
      row.Cells[1].AddParagraph("");

      row = table.AddRow();
      row.Cells[0].AddParagraph("Email: " + "Fatla: falta@gamail.com");
      row.Cells[1].AddParagraph("");

      row = table.AddRow();
      row.Cells[0].AddParagraph("");
      row.Cells[1].AddParagraph("");

    }

    private void AddItemsTable(Section section, List<E_Factura> lstFactura)
    {
      // Agregar tabla de artículos
      MigraDoc.DocumentObjectModel.Tables.Table table = section.AddTable();
      table.Borders.Width = 0.1;
      table.Rows.LeftIndent = 0;

      Column column = table.AddColumn("2cm");
      column.Format.Alignment = ParagraphAlignment.Center;

      column = table.AddColumn("9cm");
      column.Format.Alignment = ParagraphAlignment.Left;

      column = table.AddColumn("1cm");
      column.Format.Alignment = ParagraphAlignment.Right;

      column = table.AddColumn("2cm");
      column.Format.Alignment = ParagraphAlignment.Right;

      column = table.AddColumn("2cm");
      column.Format.Alignment = ParagraphAlignment.Right;

      column = table.AddColumn("2cm");
      column.Format.Alignment = ParagraphAlignment.Right;

      Row row = table.AddRow();
      row.HeadingFormat = true;
      row.Format.Alignment = ParagraphAlignment.Center;
      row.Format.Font.Bold = true;
      row.Shading.Color = Colors.Gray;

      row.Cells[0].AddParagraph("Clave");
      row.Cells[1].AddParagraph("Artículo");
      row.Cells[2].AddParagraph("Cant");
      row.Cells[3].AddParagraph("Precio");
      row.Cells[4].AddParagraph("Descuento");
      row.Cells[5].AddParagraph("Importe");

      // Agregar articulos
      foreach (E_Factura venta in lstFactura)
      {
        row = table.AddRow();
        row.Cells[0].AddParagraph(venta.CodigoArticulo.ToString());
        row.Cells[1].AddParagraph(venta.NombreArticulo);
        row.Cells[2].AddParagraph(Convert.ToInt16(venta.Cantidad).ToString());
        row.Cells[3].AddParagraph(Convert.ToDouble(venta.PrecioVenta).ToString("N2"));
        row.Cells[4].AddParagraph(Convert.ToDouble(venta.Descuento).ToString("N2"));
        row.Cells[5].AddParagraph(Convert.ToDouble((venta.Cantidad * venta.PrecioVenta) - venta.Descuento).ToString("N2"));
      }
    }

    private void DetalleVentas(Section section, List<E_Factura> lstFactura)
    {      
      double subtotal = 0, IVA = 0, descuentos = 0, totalArticulo = 0;

      // Agregar articulos
      foreach (E_Factura venta in lstFactura)
      {
        totalArticulo += venta.Cantidad;
        subtotal += Convert.ToDouble((venta.Cantidad * venta.PrecioVenta) - venta.Descuento);
        descuentos += venta.Descuento;
      }

      IVA = subtotal * 0.08;

      Paragraph paragraph = section.AddParagraph();

      paragraph.AddText("\nUsted compro : " + totalArticulo.ToString() + " artículos");
      paragraph.AddText("\nUsted Ahorro : " + descuentos.ToString("C2"));


      // Agregar resumen y total
      paragraph = section.AddParagraph();

      paragraph.Format.SpaceBefore = "1cm";
      paragraph.Format.SpaceAfter = "1cm";
      paragraph.Format.Alignment = ParagraphAlignment.Right;
      paragraph.Format.Font.Size = 12;
      //paragraph.Format.Font.Bold = false;

      paragraph.AddText("\n\nSubtotal  : " + subtotal.ToString("N2"));
      paragraph.AddText("\n8% de IVA : " + (IVA).ToString("N2"));
      paragraph.Format.Font.Bold = true;
      paragraph.AddText("\nTotal     : " + lstFactura[0].Total.ToString("C2"));
      paragraph.AddText("\n\n Son " + NumeroATexto.Convertir(lstFactura[0].Total) + " M.N.");
    }
  }
}