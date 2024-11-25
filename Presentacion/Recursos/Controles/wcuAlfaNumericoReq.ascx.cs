using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiPAAD.Controles
{
  public partial class wcuAlfaNumericoReq : System.Web.UI.UserControl
  {
    public string Text
    {
      get { return tbAlfaNumerico.Text.Trim(); }
      set { tbAlfaNumerico.Text = value; }
    }
    public bool Enabled
    {
      set { tbAlfaNumerico.Enabled = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}