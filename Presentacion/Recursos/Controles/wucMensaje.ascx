<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucMensaje.ascx.cs" Inherits="Presentacion.Recursos.Controles.wucMensaje" %>

<link href="../CSS/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="../CSS/ventasCSS.css" rel="stylesheet" />

<div id="msgDiv" runat="server" class="message">
  <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</div>

<asp:Timer ID="timer" runat="server" Interval="3000" OnTick="timer_Tick" Enabled="false" />
