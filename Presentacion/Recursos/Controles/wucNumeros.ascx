<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucNumeros.ascx.cs" Inherits="PAAD.Controles.wucNumeros" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />

<asp:TextBox ID="tbNumero" runat="server" placeholder="Número" CssClass="form-control"></asp:TextBox>

<asp:RangeValidator
  ID="rvNumero" runat="server" ControlToValidate="tbNumero" ErrorMessage="*"
  CssClass="text-danger"
  MinimumValue="1"  
  MaximumValue="2147483647"  
  Type="Integer"
  Display="Dynamic">Se requiere número mayor acero.</asp:RangeValidator>