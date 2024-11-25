<%------------------------------------------------------------------------------+
| Autor: Victor Rafael N.Velazquez Mejía                                        |
| Archivo: wcuAlfabeticoReq.ascx                                                |
| Fecha de creación: 13 de abril de 2017                                        |
| Fecha de modificación: 13 de abril de 2017                                    |
|-------------------------------------------------------------------------------|
| Función: Validar que se capture datos                                         |
| La entrada de datos es obligatoria. SI                                        |
| Caracteres válidos: Todos.                                                    |
|-------------------------------------------------------------------------------|
| D.R. PCSIS (Proyectos Computacionales y Servicios de Ingeniería de Software). | 
---------------------------------------------------------------------------------%>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wcuAlfaNumericoReq.ascx.cs" Inherits="SiPAAD.Controles.wcuAlfaNumericoReq" %>

<%--<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>

<asp:TextBox ID="tbAlfaNumerico" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RequiredFieldValidator
  ID="rfvtbAlfaNumerico" runat="server" ErrorMessage="*"
  ControlToValidate="tbAlfaNumerico"
  CssClass="text-danger"
  Display="Dynamic">No puede dejar este campo en blanco.
</asp:RequiredFieldValidator>

