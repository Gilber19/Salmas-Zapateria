<%--------------------------------------------------------------------------+
 | Autor: Victor Rafael Velazquez Mejía                                     |
 | Nombre: wcuNumeroPosReq                                                  |
 | Acción: Control para validad números enteros requeridos mayores a cero   |
 |                                                                          |
 |        Tipo       |   Valores aceptados                                  |
 |   ---------------+--------------------                                   |      
 |   unsigned short | 1 a 65535                                             |
 |   unsigned int   | 1 a 4294967295                                        |
 |   unsigned long  | 1 a 4294967295                                        |
 +---------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcuNumeroPosReq.ascx.cs" Inherits="Controles.wcuNumeroPosReq" %>

<%--<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>

<asp:TextBox ID="tbNumero" runat="server" CssClass="form-control" ></asp:TextBox>
<asp:RangeValidator
  ID="rvNumero" runat="server" ControlToValidate="tbNumero" 
  MinimumValue="0"  
  MaximumValue="2147483647"  
  Type="Integer"
  Display="Dynamic"
  CssClass="text-danger font-weight-normal"><i class="text-danger fas fa-exclamation-triangle mr-2"></i>Capture un dato válido.
</asp:RangeValidator>

<asp:RequiredFieldValidator
  ID="rfvTbNumero" runat="server"
  ControlToValidate="tbNumero" 
  Display="Dynamic"
  CssClass="text-danger font-weight-normal"><i class="text-danger fas fa-exclamation-triangle mr-2"></i>Campo requerido.
</asp:RequiredFieldValidator>

