<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuCURP.ascx                                                          |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar el formato de entrada del RFC                                |
| La entrada de datos es obligatoria. NO                                        |
| Caracteres válidos: LLLL999999LLLLLL99                                        |
|                     L = Letras mayúscula                                      |
|                     9 = Números [0-9]                                         |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCURP.ascx.cs" Inherits="PAAD.Controles.wucCURP" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

 <asp:TextBox ID="tbCURP" runat="server" placeholder="LLLL999999LLLLLL99" CssClass="form-control"></asp:TextBox>

 <asp:RegularExpressionValidator 
   ID="revCURP" runat="server" 
   ControlToValidate="tbCURP" 
   ErrorMessage="*" 
   ValidationExpression="[A-Z]{4}[0-9]{6}[A-Z]{6}[0-9]{2}" 
   CssClass="text-danger"
   Display="Dynamic">Formato incorrecto: LLLL999999lLLLLLL99

 </asp:RegularExpressionValidator>
        