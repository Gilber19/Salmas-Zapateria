<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucTextoRequerido.ascx.cs" Inherits="Presentacion.Recursos.Controles.wucTextoRequerido" %>

<link href="../CSS/bootstrap.css" rel="stylesheet" />

<div class="form-group">
    <asp:Label ID="lblTitulo" runat="server" CssClass="fw-bold"></asp:Label>
    <asp:TextBox ID="tbTexto" runat="server" CssClass="form-control"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfvTbTexto" runat="server" CssClass="text-danger"
        ControlToValidate="tbTexto"
        ErrorMessage="Campo requerido."
        Display="Dynamic">
    </asp:RequiredFieldValidator>
</div>