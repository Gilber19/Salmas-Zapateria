using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAAD.Controles
{
  public partial class wucPaginaWeb : System.Web.UI.UserControl
  {
    public string Text
    {
      get { return tbPaginaWeb.Text.Trim(); }
      set { tbPaginaWeb.Text = value; }
    }
    public bool Enabled
    {
      set { tbPaginaWeb.Enabled = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}