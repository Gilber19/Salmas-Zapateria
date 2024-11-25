using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Recursos.Controles
{
  public partial class cuTextoAlfaNumerico : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {      
    }

    public String Text
    {
      get { return TbAlfanumericoRequerido.Text.Trim(); }
      set { TbAlfanumericoRequerido.Text = value; }
    }

    public string Titulo
    {
      set { lblTitulo.Text = value; }
    }

    public TextBoxMode TextMode
    {
      get { return TbAlfanumericoRequerido.TextMode; }
      set { TbAlfanumericoRequerido.TextMode = value; }
    }

    public bool Enabled
    {
      set { TbAlfanumericoRequerido.Enabled = value; }
    }
  }
}