<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuRFC.ascx                                                          |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar el formato de entrada del RFC                                |
| La entrada de datos es obligatoria. NO                                        |
| Caracteres válidos: LLLL999999 ó LLLL999999-XXX ó LLLL999999XXX               |
|                     L = Letras mayúscula                                      |
|                     9 = Números [0-9]                                         |
|                     A = AlfaNumérico [A-Z], [0-9]                             |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucRFC.ascx.cs" Inherits="PAAD.Controles.wucRFC" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

 <asp:TextBox ID="tbRFC" runat="server" placeholder="LLLL999999-XXX" CssClass="form-control"></asp:TextBox>
 
<asp:RegularExpressionValidator 
  ID="RegularExpressionValidator1" 
  runat="server" 
  ControlToValidate="tbRFC" 
  ErrorMessage="*" 
  ValidationExpression="[A-Z]{4}[0-9]{6}(-?[A-Z,0-9]{3})?" 
  CssClass="text-danger" 
  Display="Dynamic">Formato incorrecto: LLLL999999 ó LLLL999999-XXX ó LLLL999999XXX</asp:RegularExpressionValidator>
         
          
