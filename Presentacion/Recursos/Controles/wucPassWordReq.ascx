<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPassWordReq.ascx.cs" Inherits="WebLoginFIAD.Controles.wucPassWordReq" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<div class="form-group">
  <div class="col-12">
    <asp:Label ID="lblTitulo" runat="server" CssClass="fw-bold m-2"></asp:Label>
    <asp:TextBox ID="tbPassWord" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

    <asp:RequiredFieldValidator
      ID="rfvPassWord" runat="server" ErrorMessage="*"
      ControlToValidate="tbPassWord"
      Display="Dynamic"
      CssClass="text-danger">
      <i class="bi bi-exclamation-circle"></i> La contraseña obligatoria.
    </asp:RequiredFieldValidator>
  </div>
</div>
