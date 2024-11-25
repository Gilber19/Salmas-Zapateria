<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucAlfanumericoRequerido.ascx.cs" Inherits="GePE.Controles.wfucAlfabeticoRequerido" %>

<%--<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>

<asp:TextBox ID="TbAlfanumericoRequerido" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvTbAlfanumericoRequerido" runat="server" CssClass="text-danger"
    ControlToValidate="TbAlfanumericoRequerido"
    ErrorMessage="* Campo requerido."
    Display="Dynamic"></asp:RequiredFieldValidator>

<asp:RegularExpressionValidator ID="revTbAlfanumericoRequerido" runat="server" CssClass="text-danger"
    ControlToValidate="TbAlfanumericoRequerido"
    ErrorMessage="* Sólo alfanumericos."
    ValidationExpression="^[a-zA-Z0-9 .áéíóúñÁÉÍÓÚÑ]+$"
    Display="Dynamic"></asp:RegularExpressionValidator>
