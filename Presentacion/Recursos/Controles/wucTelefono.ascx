<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuTelefono.ascx                                                     |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar el formato de entrada de un número teléfónico.               |
| La entrada de datos es obligatoria. NO                                        |
| Formato de entrada: (999) 999-99-99                                           |
|                                                                               |  
|             (999): (999) = Lada telefónica es opcional, pero si se usa los    |
|                    ( ) son obligatorios seguidos de un espacio.               |
|         999-99-99: Número teléfonico los caracteres válidos son números [0-9] |
|                    y el guión medio [-].                                      |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucTelefono.ascx.cs" Inherits="PAAD.Controles.wucTelefono" %>
 
<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbTelefono" runat="server" placeholder="Teléfono a 10 dígitos" CssClass="form-control"></asp:TextBox>
<asp:RegularExpressionValidator 
  ID="revTelefono" runat="server" 
  ControlToValidate="tbTelefono" 
  ErrorMessage="*" ValidationExpression="[0-9]{10}" 
  CssClass="text-danger"
  Display="Dynamic">Capture número telefónoc de 10 dígitos.

</asp:RegularExpressionValidator>
         
