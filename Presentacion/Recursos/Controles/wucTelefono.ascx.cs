using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAAD.Controles
{
  public partial class wucTelefono : System.Web.UI.UserControl
  {
    public string Text
    {
      get { return tbTelefono.Text.Trim(); }
      set { tbTelefono.Text = value; }
    }
    public bool Enabled
    {
      set { tbTelefono.Enabled = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}