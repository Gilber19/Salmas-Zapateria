using System;
using System.Net;
using System.Net.Mail;

namespace Presentacion.Email
{
  public partial class EnviarEmail : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
      try
      {
        string destinatario = txtPara.Text;
        string asunto = txtAsunto.Text;
        string mensaje = txtMensaje.Text;

        // Configurar el cliente SMTP        
        SmtpClient client = new SmtpClient("smtp.gmail.com");
        client.Port = 587; // El puerto puede variar dependiendo del servidor SMTP
        client.Credentials = new NetworkCredential("viraveme@gmail.com", "*********");
        client.EnableSsl = true; // Usar SSL depende de tu servidor SMTP 

        // Crear el mensaje de correo
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("viraveme@gmail.com");
        mailMessage.To.Add(destinatario);
        mailMessage.Subject = asunto;
        mailMessage.Body = mensaje;
        mailMessage.IsBodyHtml = true; // Configura esto según tus necesidades

        // Enviar el correo
        client.Send(mailMessage);
        Response.Write("Correo enviado exitosamente.");
      }
      catch (Exception ex)
      {
        Response.Write("Error al enviar el correo: " + ex.Message);
      }
    }
  }
}