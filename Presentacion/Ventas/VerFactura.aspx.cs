using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Ventas
{
  public partial class VerFactura : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string RutaArchivo = Request.QueryString["pdf"];
        if (!string.IsNullOrEmpty(RutaArchivo))
        {
          pdfViewer.Attributes["src"] = RutaArchivo;
        }
      }
    }
  }
}