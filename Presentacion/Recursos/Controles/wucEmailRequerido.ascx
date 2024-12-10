<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuEmailReq.ascx                                                     |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar el formato de entrada de un correo electrónico.              |
| La entrada de datos es obligatoria. SI                                        |
| Formato de entrada: usuario@servidor.pas                                      |
|                                                                               |  
|             usuario: Nombre de idenfificación del usuario los caracteres.     |
|                      válidos son: Letras miúsculas [a-z] números [0-9], los   |
|                      los carácteres punto y guión medio [.-].                 |
|                   @: El caracter @ es obligatorio despues del usuario.        |
|            servidor: Nombre de idenfificación del servidor donde esta ospedado|
|                      el correo los caracteres válidos son: Letras miúsculas   |
|                      [a-z], números [0-9], los carácteres punto y guión medio |
|                      [.-].                                                    |
|                 pas: Iniciales del pais de donde es el correo 2 o 3 letras.   |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucEmailRequerido.ascx.cs" Inherits="Controles.wucEmailRequerido" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<div class="form-group">
  <div class="col-12">
    <asp:Label ID="lblTitulo" runat="server" CssClass="fw-bold"></asp:Label>
    <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" ></asp:TextBox>

    <asp:RegularExpressionValidator
      ID="revtbEmail" runat="server" ControlToValidate="tbEmail" ErrorMessage="*"
      ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"
      Display="Dynamic"
      CssClass="text-danger font-weight-normal"><i class="bi bi-exclamation-circle"></i> Parece un Correo electrónico no válido.  
    </asp:RegularExpressionValidator>

    <asp:RequiredFieldValidator
      ID="rfvTbEmail" runat="server" ErrorMessage="*"
      ControlToValidate="tbEmail"
      Display="Dynamic"
      CssClass="text-danger font-weight-normal"><i class="bi bi-exclamation-circle"></i> El correo electrónico es requerido.
    </asp:RequiredFieldValidator>
  </div>
</div>
