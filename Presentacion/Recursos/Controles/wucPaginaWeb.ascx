<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuPaginaWeb.ascx                                                        |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar el formato de entrada de una Página Web.                     |
| La entrada de datos es obligatoria. NO                                        |
| Formato de entrada: https://paginaweb.com                                     |
|                                                                               |  
|        http// o https// : Es opcional.                                        |
|        paginaweb : Los caracteres válidos son: Letras minúsculas [a-z], [A-Z] |
|                    números [0-9], los carácteres punto y guión medio [.-].    |                                                    |
|               com: Iniciales del pais de donde es el correo 2 o 3 letras.     |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPaginaWeb.ascx.cs" Inherits="PAAD.Controles.wucPaginaWeb" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbPaginaWeb" runat="server" placeholder="https//paginaweb.com" CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator
  ID="revtPaginaWeb" runat="server" ControlToValidate="tbPaginaWeb" ErrorMessage="*"
  ValidationExpression="(https?:\/\/)?([A-Za-z0-9\/\.-:]+)([\?~]?)?([A-Za-z0-9\/\.-=&_\?]*)*"
  CssClass="text-danger"
  Display="Dynamic">Formato de página web erroneo.</asp:RegularExpressionValidator>
<%--(https?:\/\/)?([A-Za-z0-9\/\.-]+)\.([a-z][A-Z]\.]{2,6})([\/\w \?=.-]*)*\/?--%>