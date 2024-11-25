using System;

namespace Controles
{
  public partial class wcuNumeroPosReq : System.Web.UI.UserControl
  {
    public string Text
    {
      get { return tbNumero.Text.Trim(); }
      set { tbNumero.Text = value; }
    }
    public bool Enabled
    {
      set { tbNumero.Enabled = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}