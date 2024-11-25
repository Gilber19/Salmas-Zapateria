using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Recursos.Controles
{
  public partial class wucTextoRequerido : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public String Text
    {
      get { return tbTexto.Text.Trim(); }
      set { tbTexto.Text = value; }
    }

    public string Titulo
    {
      set { lblTitulo.Text = value; }
    }

    public TextBoxMode TextMode
    {
      get { return tbTexto.TextMode; }
      set { tbTexto.TextMode = value; }
    }

    public bool Enabled
    {
      set { tbTexto.Enabled = value; }
    }
  }
}