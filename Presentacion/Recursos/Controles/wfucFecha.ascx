<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wfucFecha.ascx.cs" Inherits="WebLoginFIAD.Controles.wfucFecha" %>


<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="TbFecha" runat="server" placeholder="dd/mm/aaaa" CssClass="form-control"></asp:TextBox>
<asp:RegularExpressionValidator
  ID="revTbFecha" runat="server"
  ControlToValidate="TbFecha"
  ErrorMessage="*"
  ValidationExpression="^([0-2][0-9]|3[0-1])(\/|-)(0[1-9]|1[0-2])\2(\d{4})$"
  CssClass="text-danger"
  Display="Dynamic">Formato de fecha incorrecto (dd/mm/aaaa).
</asp:RegularExpressionValidator>
