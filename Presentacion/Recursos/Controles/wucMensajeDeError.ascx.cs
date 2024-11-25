using System;

namespace Presentacion.Recursos.Controles
{
  public partial class wucMensajeDeError : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public String Text
    {      
      set { lblMensaje.Text = value; }
    }
  }
}