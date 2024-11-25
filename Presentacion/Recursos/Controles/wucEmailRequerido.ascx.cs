using System;

namespace Controles
{
  public partial class wucEmailRequerido : System.Web.UI.UserControl
  {

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public string Text
    {
      get { return tbEmail.Text.Trim(); }
      set { tbEmail.Text = value; }
    }
    public bool Enabled
    {
      set { tbEmail.Enabled = value; }
    }
    public string Titulo
    {
      set { lblTitulo.Text = value; }
    }
  }
}