using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAAD.Controles
{
  public partial class wcuEmail : System.Web.UI.UserControl
  {
    public string Text
    {
      get { return tbEmail.Text.Trim(); }
      set { tbEmail.Text = value; }
    }
    public bool Enabled
    {
      set { tbEmail.Enabled = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
  }
}