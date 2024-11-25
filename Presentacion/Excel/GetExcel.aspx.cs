using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using OfficeOpenXml;

using System.Configuration;

namespace Presentacion.Excel
{
  public partial class GetExcel : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnImportar_Click(object sender, EventArgs e)
    {
      ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Para uso no comercial

      if (fuExcel.HasFile)
      {
        string Ruta = Path.Combine(Server.MapPath("~/Excel"), fuExcel.FileName);
        fuExcel.SaveAs(Ruta);

        DataTable dt = new DataTable();
       
        using (ExcelPackage package = new ExcelPackage(new FileInfo(Ruta))) //Abre el archivo Excel usando EPPlus.
        {
          ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; //Obtiene la primera hoja de cálculo del libro de Excel.
          int colCount = worksheet.Dimension.End.Column; //Obtiene el número de columnas.
          int rowCount = worksheet.Dimension.End.Row;//Obtiene el número filas.

          //Itera sobre cada columna en la primera fila para agregar nombres de columna al DataTable
          for (int col = 1; col <= colCount; col++)
          {
            dt.Columns.Add(worksheet.Cells[1, col].Text);
          }

          //Itera sobre cada fila de datos, comenzando desde la segunda fila.
          for (int row = 2; row <= rowCount; row++)
          {
            DataRow dr = dt.NewRow();
            for (int col = 1; col <= colCount; col++)
            {
              dr[col - 1] = worksheet.Cells[row, col].Text;
            }
            dt.Rows.Add(dr);
          }
        }

        //Obtiene la cadena de conexión a la base de datos desde el archivo web.config.
        string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        //Crea una nueva conexión a la base de datos utilizando la cadena de conexión.
        using (SqlConnection con = new SqlConnection(connectionString))
        {
          try
          {
            //Crea un objeto SqlBulkCopy para copiar los datos en la base de datos.
            using (SqlBulkCopy sqlBulk = new SqlBulkCopy(con))
            {
              sqlBulk.DestinationTableName = "Categorias2";
              con.Open();
              //Copia los datos del DataTable a la tabla de destino en la base de datos.
              sqlBulk.WriteToServer(dt);
              con.Close();
            }
            lblMensaje.Text = "Su archivo excel se respaldo en la base de datos.";
          }
          catch (Exception ex)
          {
            lblMensaje.Text = "Ocurrio un error: " + ex.Message;
            
          }


        }

      }
    }
  }
}