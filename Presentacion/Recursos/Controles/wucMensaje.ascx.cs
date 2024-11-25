using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.Recursos.Controles
{
  public partial class wucMensaje : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    public String Text
    {
      set { lblMensaje.Text = value; }
    }
    public void ShowMessage(string tipo, string mensaje)
    {      
      lblMensaje.Text = mensaje;
      switch (tipo)
      {
        case "Exito": msgDiv.Attributes["class"] = "alert alert-success"; break; // o cualquier clase que uses para estilos de éxito
        case "Error": msgDiv.Attributes["class"] = "alert alert-danger";  break; // para estilos de error
        case "Warning": msgDiv.Attributes["class"] = "alert alert-warning"; break; // para advertencias
        case "Info": msgDiv.Attributes["class"] = "alert alert-info"; break;// para mensajes informativos
      }
      msgDiv.Visible = true; // Muestra el div
      timer.Enabled = true; // Iniciar el temporizador
    }
    protected void timer_Tick(object sender, EventArgs e)
    {
      msgDiv.Visible = false;
      timer.Enabled = false; // Detener el temporizador      
    }

    public void HideMessage()
    {
      lblMensaje.Visible = false; // Oculta el div
    }
  }
}