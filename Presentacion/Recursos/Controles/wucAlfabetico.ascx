<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuAlfabetico.ascx                                                   |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar los caracteres de entrada en una cadena alfabética.          |
| La entrada de datos es obligatoria. NO                                        |
| Caracteres válidos: Letras minusculas [a-z] y mayúsculas [A-Z].               |
|                     Letras acentuadas [áéíóúÁÉÍÓÚ].                           |
|                     Letra ñ y Ñ [ñÑ]                                          |
|                     Carácter de espacio [\s].                                 |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucAlfabetico.ascx.cs" Inherits="PAAD.Controles.wucAlfabetico" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbAlfabetico" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RegularExpressionValidator
  ID="revAlfabetico" runat="server" ControlToValidate="tbAlfabetico" ErrorMessage="*"
  ValidationExpression="[a-zA-ZñÑáéíóúÁÉÍÓÚ \s]+"
  CssClass="text-danger"
  Display="Dynamic">El campo tiene caracteres inválidos.</asp:RegularExpressionValidator>

