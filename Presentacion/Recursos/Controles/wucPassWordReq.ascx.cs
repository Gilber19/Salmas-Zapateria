using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLoginFIAD.Controles
{
  public partial class wucPassWordReq : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string Titulo
    {
      set { lblTitulo.Text = value; }
    }

    public String Text
    {
      get { return tbPassWord.Text.Trim(); }
      set { tbPassWord.Text = value; }
    }

    public bool Enabled
    {
      set { tbPassWord.Enabled = value; }
    }
    
  }
}