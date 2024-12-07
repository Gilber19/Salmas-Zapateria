using System;
using System.Web.UI.WebControls;
using System.Data;

using Entidades;
using Negocios;
using System.Collections.Generic;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using System.IO;

namespace Presentacion.Articulos
{
    public partial class IBM_Articulo : System.Web.UI.Page
    {
        N_Articulo NA = new N_Articulo();
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
            PnlGrvArticulos.Visible = false;

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
            tbCodigoArticulo.Text = string.Empty;
            tbNombreArticulo.Text = string.Empty;
            tbDescripcionArticulo.Text = string.Empty;
        }
        protected void ControlesOnOFF(bool TrueOrFalse)
        {
            tbCodigoArticulo.Enabled = TrueOrFalse;
            tbNombreArticulo.Enabled = TrueOrFalse;
            tbDescripcionArticulo.Enabled = TrueOrFalse;
        }
        protected void AtributosHeaderCard(string Msg, string Color)
        {
            ControlesOFF();
            CardHeader.Attributes.Clear();
            CardHeader.Attributes.Add("class", "card-header text-center " + Color);
            lblAccion.Text = Msg;
        }
        protected void VisualizaArticulos()
        {
            InicializaControles();
            var articulos = NA.ListarArticulos();
            if (articulos != null)
            {
                Console.WriteLine(articulos); // Check the structure of the data
                GrvArticulos.DataSource = articulos;
                GrvArticulos.DataBind();
                PnlGrvArticulos.Visible = true;
            }
            else
            {
                // Handle the case when articulos is null
                Console.WriteLine("No data available");
            }
        }


        #endregion

        #region Objeto Cliente
        protected E_Articulo ControlesWebForm_ObjetoEntidad()
        {
            E_Articulo Articulo = new E_Articulo()
            {
                CodigoArticulo = tbCodigoArticulo.Text.Trim(),
                NombreArticulo = tbNombreArticulo.Text.Trim(),
                DescripcionArticulo = tbDescripcionArticulo.Text.Trim(),
            };

            return Articulo;
        }
        protected void ObjetoEntidad_ControlesWebForm(int idArticulo)
        {
            E_Articulo Articulo = NA.BuscarArticuloPorID(idArticulo);

            tbCodigoArticulo.Text = Articulo.CodigoArticulo.Trim();
            tbNombreArticulo.Text = Articulo.NombreArticulo.Trim();
            tbDescripcionArticulo.Text = Articulo.DescripcionArticulo.Trim();
        }
        #endregion

        #region Botones menu de navegación 
        protected void BtnMnuNuevo_Click(object sender, EventArgs e)
        {
            InicializaControles();
            AtributosHeaderCard("Registrar nueva Articulo", "bg-success");

            PnlCapturaDatos.Visible = true;
            BtnInsertar.Visible = true;
            BtnCancelar.Visible = true;

            //ESTO SOLO ES UNA PRUEBA
            //E_Articulo nuevoArticulo = new E_Articulo
            //{
            //    IdCategoria = 1,
            //    CodigoArticulo = "qwe123",
            //    NombreArticulo = "Camisa test 1",
            //    PrecioVenta = 12.5,
            //    DescripcionArticulo = "Camiseta de algodón pro",
            //    SubCategoria = "Ropa",
            //    IdImagen = 143,
            //    Talla = "S",
            //    Stock = 20,
            //    IdTalla = 2
            //};

            //string resultado = NA.InsertarArticulo(nuevoArticulo);



        }
        protected void btnListado_Click(object sender, EventArgs e)
        {
            VisualizaArticulos();
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbCriterioBusqueda.Text.Trim() != string.Empty)
                {
                    List<E_Articulo> Lst = NA.BuscarArticuloPorCriterio(TbCriterioBusqueda.Text);

                    if (Lst.Count == 0)        // No se encontró el Articulo
                        lblMensaje.ShowMessage("Warning", "No se encontró el Articulo solicitado");
                    else if (Lst.Count == 1) // Se encontró un Articulo con el criterio solicitado
                    {
                        AtributosHeaderCard("Modificar o Borrar los datos del Articulo", "bg-warning");
                        hfIdArticulo.Value = Lst[0].IdArticulo.ToString();
                        ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdArticulo.Value));

                        PnlCapturaDatos.Visible = true;
                        PnlGrvArticulos.Visible = false;

                        BtnMnuModificar.Visible = true;
                        BtnMnuBorrar.Visible = true;
                        BtnCancelar.Visible = true;
                    }
                    else // Se encontro mas de un Articulo con el criterio solicitado
                    {
                        InicializaControles();
                        GrvArticulos.DataSource = Lst;
                        GrvArticulos.DataBind();
                        PnlGrvArticulos.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                cuMensaje.Text = "Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda." + ex;
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
            Column column1 = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(2));
            column1.Format.Alignment = ParagraphAlignment.Center;
            Column column2 = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(6));
            column2.Format.Alignment = ParagraphAlignment.Center;
            Column column3 = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(2));
            column3.Format.Alignment = ParagraphAlignment.Center;
            Column column4 = table.AddColumn(MigraDoc.DocumentObjectModel.Unit.FromCentimeter(6));
            column4.Format.Alignment = ParagraphAlignment.Center;
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Shading.Color = Colors.Gray;
            Cell cell1 = row.Cells[0]; cell1.AddParagraph("ID");
            cell1.Format.Font.Bold = true;
            Cell cell2 = row.Cells[1];
            cell2.AddParagraph("Nombre");
            cell2.Format.Font.Bold = true;
            Cell cell3 = row.Cells[2];
            cell3.AddParagraph("Precio");
            cell3.Format.Font.Bold = true;
            Cell cell4 = row.Cells[3];
            cell4.AddParagraph("Descripción");
            cell4.Format.Font.Bold = true;

            // Agregar filas de datos de ejemplo
            List<E_Articulo> Lista = NA.ListarArticulos();
            foreach (E_Articulo c in Lista)
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(c.CodigoArticulo.ToString());
                row.Cells[1].AddParagraph(c.NombreArticulo);
                row.Cells[2].AddParagraph(c.PrecioVenta.ToString());
                row.Cells[3].AddParagraph(c.DescripcionArticulo);
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
            E_Articulo EC = ControlesWebForm_ObjetoEntidad();

            string[] Msg = NA.InsertarArticulo(EC).Split(':');
            lblMensaje.ShowMessage(Msg[0], Msg[1]);

            if (Msg[0] == "Exito")
                InicializaControles();

            PnlCapturaDatos.Visible = true;
            BtnInsertar.Visible = true;
            BtnCancelar.Visible = true;
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(hfIdArticulo.Value);
            string[] Msg = NA.BorrarArticulo(ID).Split(':');

            lblMensaje.ShowMessage(Msg[0], Msg[1]);

            if (Msg[0] == "Exito")
                VisualizaArticulos();
        }
        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int ID = Convert.ToInt16(hfIdArticulo.Value);
                E_Articulo EC = new E_Articulo(ID, 1, "001", tbNombreArticulo.Text, tbDescripcionArticulo.Text, 150, 4, true, 0);

                string[] Msg = NA.ModificarArticulo(EC).Split(':');
                if (Msg.Length >= 2)
                {
                    lblMensaje.ShowMessage(Msg[0], Msg[1]);

                    if (Msg[0] == "Exito")
                        VisualizaArticulos();
                }
                else
                {
                    lblMensaje.ShowMessage("Error", "Respuesta inesperada del servidor.");
                }
            }
            catch (FormatException ex)
            {
                lblMensaje.ShowMessage("Error", "ID de artículo no válido: " + ex.Message);
            }
            catch (Exception ex)
            {
                lblMensaje.ShowMessage("Error", "Ocurrió un error: " + ex.Message);
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            VisualizaArticulos();
        }

        protected void BtnMnuModificar_Click(object sender, EventArgs e)
        {
            AtributosHeaderCard("Modificar los datos del Articulo", "bg-primary");

            BtnMnuModificar.Visible = false;
            BtnMnuBorrar.Visible = false;

            BtnModificar.Visible = true;
            BtnCancelar.Visible = true;

            ControlesOnOFF(true);

            PnlCapturaDatos.Visible = true;
            PnlGrvArticulos.Visible = false;
        }
        protected void BtnMnuBorrar_Click(object sender, EventArgs e)
        {
            AtributosHeaderCard("Borrar los datos de un Articulo", "bg-danger");

            BtnMnuModificar.Visible = false;
            BtnMnuBorrar.Visible = false;

            BtnBorrar.Visible = true;
            BtnCancelar.Visible = true;

            ControlesOnOFF(false);

            PnlCapturaDatos.Visible = true;
            PnlGrvArticulos.Visible = false;
        }
        #endregion

        #region Botones Grv
        protected void GrvArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                ControlesOFF();
                AtributosHeaderCard("Modificar los datos del Articulo", "bg-primary");

                hfIdArticulo.Value = GrvArticulos.DataKeys[e.NewEditIndex].Value.ToString();
                e.Cancel = true; //Deshabilita el modo edit del GridView de Articulos
                ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdArticulo.Value));

                PnlCapturaDatos.Visible = true;
                PnlGrvArticulos.Visible = false;

                BtnModificar.Visible = true;
                BtnCancelar.Visible = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: OCURRIO UN ERROR INESPERADO: " + ex.Message + " " + ex.InnerException);
            }
        }
        protected void GrvArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                ControlesOFF();
                ControlesOnOFF(false);

                //lblAccion.Text = "Borrar los datos de un Articulo";
                AtributosHeaderCard("Borrar los datos de la acción", "bg-danger");
                hfIdArticulo.Value = GrvArticulos.DataKeys[e.RowIndex].Value.ToString();
                ObjetoEntidad_ControlesWebForm(Convert.ToInt16(hfIdArticulo.Value));
                e.Cancel = true;  //Deshabilita el modo borrado del GridView de Articulos

                PnlCapturaDatos.Visible = true;
                PnlGrvArticulos.Visible = false;

                BtnBorrar.Visible = true;
                BtnCancelar.Visible = true;
            }
            catch (Exception ex)
            {
                cuMensaje.Text = "Error: " + ex.Message + " " + ex.InnerException + " cuando se tratar realizó la búsqueda." + ex;
            }
        }
        #endregion
    }
}