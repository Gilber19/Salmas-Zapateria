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

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcuNumeroPosReqAutoPosback.ascx.cs" Inherits="PAAD.Controles.wcuNumeroPosReq" %>

<%--<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>

<asp:TextBox ID="tbNumero" runat="server" placeholder="Número" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
<asp:RangeValidator
  ID="rvNumero" runat="server" ControlToValidate="tbNumero" ErrorMessage="*"
  CssClass="text-danger"
  MinimumValue="0"  
  MaximumValue="2147483647"  
  Type="Integer"
  Display="Dynamic">Se requiere número mayor a cero.</asp:RangeValidator>

<asp:RequiredFieldValidator
  ID="rfvTbNumero" runat="server" ErrorMessage="*"
  ControlToValidate="tbNumero" 
  CssClass="text-danger" 
  Display="Dynamic" >Capture un número.</asp:RequiredFieldValidator>

