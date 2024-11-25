<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucTexto.ascx.cs" Inherits="Presentacion.Recursos.Controles.wucTexto" %>


<link href="../CSS/bootstrap.css" rel="stylesheet" />

<div class="form-group mt-3">
  <div class="col-lg-12 col-md-4 col-sm-6">
    <asp:Label ID="lblTitulo" runat="server" CssClass="fw-bold mb-1"></asp:Label>
    <asp:TextBox ID="tbTexto" runat="server" CssClass="form-control"></asp:TextBox>
  </div>
</div>