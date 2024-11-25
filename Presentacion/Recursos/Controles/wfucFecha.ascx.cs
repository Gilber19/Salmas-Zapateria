using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLoginFIAD.Controles
{
  public partial class wfucFecha : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Text
    {
      get { return TbFecha.Text.Trim(); }
      set { TbFecha.Text = value; }
    }

    public bool Enabled
    {
      set { TbFecha.Enabled = value; }
    }
  }
}