using System;
using System.IO;
using System.Web.UI;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

using Entidades;
using Negocios;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace Presentacion.Categorias
{
  public partial class IBM_Categoria : System.Web.UI.Page
  {
    N_Categoria NC = new N_Categoria();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
        InicializaControles();
    }

    #region Métodos generales
    protected void InicializaControles()
    {
      ControlesOFF();
      ControlesClear();
      ControlesOnOFF(true);
    }
    protected void ControlesOFF()
    {
      PnlCapturaDatos.Visible = false;
      PnlGrvCategorias.Visible = false;

      BtnInsertar.Visible = false;
      BtnBorrar.Visible = false;
      BtnModificar.Visible = false;
      BtnCancelar.Visible = false;

      BtnMnuModificar.Visible = false;
      BtnMnuBorrar.Visible = false;
    }
    protected void ControlesClear()
    {
      TbCriterioBusqueda.Text = string.Empty;
      tbClaveCategoria.Text = string.Empty;
      tbNombreCategoria.Text = string.Empty;
      tbDescripcionCategoria.Text = string.Empty;
    }
    protected void ControlesOnOFF(bool TrueOrFalse)
    {
      tbClaveCategoria.Enabled = TrueOrFalse;
      tbNombreCategoria.Enabled = TrueOrFalse;
      tbDescripcionCategoria.Enabled = TrueOrFalse;
    }
    protected void AtributosHeaderCard(string Msg, string Color)
    {
      ControlesOFF();
      CardHeader.Attributes.Clear();
      CardHeader.Attributes.Add("class", "card-header text-center " + Color);
      lblAccion.Text = Msg;
    }
    protected void VisualizaCategorias()
    {
      InicializaControles();
      GrvCategorias.DataSource = NC.ListarCategorias();
      GrvCategorias.DataBind();
      PnlGrvCategorias.Visible = true;
    }
    #endregion

    #region Objeto Cliente
    protected E_Categoria ControlesWebForm_ObjetoEntidad()
    {
      E_Categoria Categoria = new E_Categoria()
      {
        NombreCategoria = tbNombreCategoria.Text.Trim(),
        DescripcionCategoria = tbDescripcionCategoria.Text.Trim(),
      };

      return Categoria;
    }
    protected void ObjetoEntidad_ControlesWebForm(int idCategoria)
    {
      E_Categoria Categoria = NC.BuscarCategoriaPorID(idCategoria);

      tbNombreCategoria.Text = Categoria.NombreCategoria.Trim();
      tbDescripcionCategoria.Text = Categoria.DescripcionCategoria.Trim();
    }
    #endregion

    #region Botones menu de navegación 
    protected void BtnMnuNuevo_Click(object sender, EventArgs e)
    {
      InicializaControles();
      AtributosHeaderCard("Registrar nueva Categoria", "bg-success");

      PnlCapturaDatos.Visible = true;
      BtnInsertar.Visible = true;
      BtnCancelar.Visible = true;
    }
    protected void btnListado_Click(object sender, EventArgs e)
    {
      VisualizaCategorias();
    }
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
      try
      {
        if (TbCriterioBusqueda.Text.Trim() != string.Empty)
        {
          List<E_Categoria> Lst = NC.BuscarCategoriaPorCriterio(TbCriterioBusqueda.Text);

          if (Lst.Count == 0)        // No se encontró el sistema
            lblMensaje.ShowMessage("Warning", "No se encontró el sistema solicitado");
          else if (Lst.Count == 1) // Se encontró un sistema con el criterio solicitado
          {
            AtributosHeaderCard("Modificar o Borrar los datos de la categoría", "bg-warning");
            hfIdCategoria.Value = Lst[0].IdCategoria.ToString();
            ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdCategoria.Value));

            PnlCapturaDatos.Visible = true;
            PnlGrvCategorias.Visible = false;

            BtnMnuModificar.Visible = true;
            BtnMnuBorrar.Visible = true;
            BtnCancelar.Visible = true;
          }
          else // Se encontro mas de un sistema con el criterio solicitado
          {
            InicializaControles();
            GrvCategorias.DataSource = Lst;
            GrvCategorias.DataBind();
            PnlGrvCategorias.Visible = true;
          }
        }
      }
      catch (Exception ex)
      {
        wucMensaje.Text = "Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda." + ex;
      }
    }
    protected void BtnPDF_Click(object sender, EventArgs e)
    {
      // Crear un nuevo documento
      Document doc = new Document();
      Section section = doc.AddSection();
      
      // Agregar un título con estilos
      Paragraph title = section.AddParagraph("Reporte de Categorías");
      title.Format.Font.Size = 18;
      title.Format.Font.Bold = true;
      title.Format.SpaceAfter = 12; 
      title.Format.Alignment = ParagraphAlignment.Center;

      // Agregar una tabla con estilos
      MigraDoc.DocumentObjectModel.Tables.Table table = section.AddTable();
      table.Borders.Width = 0.75; 
      Column column1 = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(3)); 
      column1.Format.Alignment = ParagraphAlignment.Center; 
      Column column2 = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(6)); 
      column2.Format.Alignment = ParagraphAlignment.Center; 
      Column column3 = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(6));
      column3.Format.Alignment = ParagraphAlignment.Center; 
      Row row = table.AddRow(); 
      row.HeadingFormat = true;
      row.Format.Alignment = ParagraphAlignment.Center;
      row.Shading.Color = Colors.Gray; 
      Cell cell1 =row.Cells[0]; cell1.AddParagraph("ID"); 
      cell1.Format.Font.Bold = true; 
      Cell cell2 = row.Cells[1]; 
      cell2.AddParagraph("Nombre"); 
      cell2.Format.Font.Bold = true; 
      Cell cell3 = row.Cells[2]; 
      cell3.AddParagraph("Descripción"); 
      cell3.Format.Font.Bold = true;

      // Agregar filas de datos de ejemplo
      List<E_Categoria> Lista = NC.ListarCategorias();
      foreach(E_Categoria c in Lista)      
      { 
        row = table.AddRow(); 
        row.Cells[0].AddParagraph(c.IdCategoria.ToString()); 
        row.Cells[1].AddParagraph(c.NombreCategoria); 
        row.Cells[2].AddParagraph(c.DescripcionCategoria); 
      } 
      
      // Crear un renderizador de PDF
      PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true); 
      pdfRenderer.Document = doc; 
      pdfRenderer.RenderDocument(); 
      
      // Guardar el documento en un MemoryStream
      MemoryStream stream = new MemoryStream(); 
      pdfRenderer.PdfDocument.Save(stream, false);
      
      // Enviar el documento PDF al navegador para su descarga
      Response.Clear(); 
      Response.ContentType = "application/pdf";
      Response.AddHeader("Content-Disposition", "attachment; filename=ReporteCategorias.pdf"); 
      Response.OutputStream.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length); 
      Response.OutputStream.Flush(); 
      Response.End();
    }
    #endregion

    #region Botones IBM
    protected void btnInsertar_Click(object sender, EventArgs e)
    {
      E_Categoria EC = ControlesWebForm_ObjetoEntidad();

      string[] Msg = NC.InsertarCategoria(EC).Split(':');
      lblMensaje.ShowMessage(Msg[0], Msg[1]);

      if (Msg[0] == "Exito")
        InicializaControles();

      PnlCapturaDatos.Visible = true;
      BtnInsertar.Visible = true;
      BtnCancelar.Visible = true;
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
      int ID = Convert.ToInt16(hfIdCategoria.Value);
      string[] Msg = NC.BorrarCategoria(ID).Split(':');

      lblMensaje.ShowMessage(Msg[0], Msg[1]);

      if (Msg[0] == "Exito")
        VisualizaCategorias();
    }
    protected void BtnModificar_Click(object sender, EventArgs e)
    {
      int ID = Convert.ToInt16(hfIdCategoria.Value);
      E_Categoria EC = new E_Categoria(ID, tbNombreCategoria.Text.Trim(), tbDescripcionCategoria.Text.Trim(), true);

      string[] Msg = NC.ModificarCategoria(EC).Split(':');
      lblMensaje.ShowMessage(Msg[0], Msg[1]);

      if (Msg[0] == "Exito")
        VisualizaCategorias();
    }
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
      VisualizaCategorias();
    }

    protected void BtnMnuModificar_Click(object sender, EventArgs e)
    {
      AtributosHeaderCard("Modificar los datos de la categoría", "bg-primary");

      BtnMnuModificar.Visible = false;
      BtnMnuBorrar.Visible = false;

      BtnModificar.Visible = true;
      BtnCancelar.Visible = true;

      ControlesOnOFF(true);

      PnlCapturaDatos.Visible = true;
      PnlGrvCategorias.Visible = false;
    }
    protected void BtnMnuBorrar_Click(object sender, EventArgs e)
    {
      AtributosHeaderCard("Borrar los datos de la categoría", "bg-danger");

      BtnMnuModificar.Visible = false;
      BtnMnuBorrar.Visible = false;

      BtnBorrar.Visible = true;
      BtnCancelar.Visible = true;

      ControlesOnOFF(false);

      PnlCapturaDatos.Visible = true;
      PnlGrvCategorias.Visible = false;
    }
    #endregion

    #region Botones Grv
    protected void GrvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
    {
      try
      {
        ControlesOFF();
        AtributosHeaderCard("Modificar los datos de la categoría", "bg-primary");

        hfIdCategoria.Value = GrvCategorias.DataKeys[e.NewEditIndex].Value.ToString();
        e.Cancel = true; //Deshabilita el modo edit del GridView de sistemas
        ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdCategoria.Value));

        PnlCapturaDatos.Visible = true;
        PnlGrvCategorias.Visible = false;

        BtnModificar.Visible = true;
        BtnCancelar.Visible = true;

      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: OCURRIO UN ERROR INESPERADO: " + ex.Message + " " + ex.InnerException);
      }
    }
    protected void GrvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      try
      {
        ControlesOFF();
        ControlesOnOFF(false);

        //lblAccion.Text = "Borrar los datos de un sistema";
        AtributosHeaderCard("Borrar los datos de la categoría", "bg-danger");
        hfIdCategoria.Value = GrvCategorias.DataKeys[e.RowIndex].Value.ToString();
        ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdCategoria.Value));
        e.Cancel = true;  //Deshabilita el modo borrado del GridView de sistemas

        PnlCapturaDatos.Visible = true;
        PnlGrvCategorias.Visible = false;

        BtnBorrar.Visible = true;
        BtnCancelar.Visible = true;
      }
      catch (Exception ex)
      {
        wucMensaje.Text = "Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda." + ex;
      }
    }
    #endregion
  }
}