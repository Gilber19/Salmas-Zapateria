<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="Facturas.aspx.cs" Inherits="Presentacion.Ventas.Facturas" %>

<%@ Register Src="~/Recursos/Controles/wcuAlfaNumericoReq.ascx" TagPrefix="uc1" TagName="wcuAlfaNumericoReq" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">

  <div class="container">
    <h4 class="text-black mt-5 mb-0">Gestión de Faturas</h4>
    <hr class="bg-success mt-0 mb-3" />

    <uc1:wcuAlfaNumericoReq runat="server" ID="tbCriterio" />
    <asp:Button ID="btnGeneraFactura" runat="server" Text="Genera Factura" CssClass="btn btn-primary mt-3" OnClick="btnGeneraFactura_Click" />
  </div>

</asp:Content>

