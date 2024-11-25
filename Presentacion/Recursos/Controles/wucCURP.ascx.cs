using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAAD.Controles
{
  public partial class wucCURP : System.Web.UI.UserControl
  {
    public string Text
    {
      get { return tbCURP.Text.Trim(); }
      set { tbCURP.Text = value; }
    }
    public bool Enabled
    {
      set { tbCURP.Enabled = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}