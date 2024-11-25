using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAAD.Controles
{
  public partial class wucAlfabeticoReq : System.Web.UI.UserControl
  {
    public string Text
    {
      get { return tbAlfabetico.Text.Trim(); }
      set { tbAlfabetico.Text = value; }
    }
    public bool Enabled
    {
      set { tbAlfabetico.Enabled = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
  }
}