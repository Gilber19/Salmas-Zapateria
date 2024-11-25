<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cuTextoAlfaNumerico.ascx.cs" Inherits="Presentacion.Recursos.Controles.cuTextoAlfaNumerico" %>

<link href="../CSS/bootstrap.css" rel="stylesheet" />

<div class="form-group">
  <asp:Label ID="lblTitulo" runat="server" CssClass="fw-bold mb-1"></asp:Label>
  <asp:TextBox ID="TbAlfanumericoRequerido" runat="server" CssClass="form-control"></asp:TextBox>

  <asp:RequiredFieldValidator ID="rfvTbAlfanumericoRequerido" runat="server" CssClass="text-danger fw-bold"
    ControlToValidate="TbAlfanumericoRequerido"
    ErrorMessage="Campo requerido."
    Display="Dynamic"></asp:RequiredFieldValidator>

  <asp:RegularExpressionValidator ID="revTbAlfanumericoRequerido" runat="server" CssClass="text-danger fw-bold"
    ControlToValidate="TbAlfanumericoRequerido"
    ErrorMessage="Sólo alfanumericos."
    ValidationExpression="^[a-zA-Z0-9 .áéíóúñÁÉÍÓÚÑ]+$"
    Display="Dynamic"></asp:RegularExpressionValidator>
</div>
