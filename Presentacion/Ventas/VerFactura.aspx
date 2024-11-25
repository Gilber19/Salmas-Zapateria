<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="VerFactura.aspx.cs" Inherits="Presentacion.Ventas.VerFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
  <div class="pdf-container bg-success" style="height: 100vh; padding: 20px;">
    <div class="text-center mb-3">
      <asp:HyperLink ID="hlRegresar" runat="server" NavigateUrl="Facturas.aspx" CssClass="btn btn-primary mt-3">Regresar</asp:HyperLink>
    </div>

    <div class="pdf-container">
      <iframe id="pdfViewer" runat="server" frameborder="0" style="width: 100%; height: calc(100vh - 100px);"></iframe>
    </div>

  </div>
</asp:Content>