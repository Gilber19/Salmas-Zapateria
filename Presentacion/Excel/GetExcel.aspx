<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="GetExcel.aspx.cs" Inherits="Presentacion.Excel.GetExcel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">


  <h4 class="text-black mt-5 mb-0">Ejemplo importa Excel</h4>
  <hr class="bg-success mt-0 mb-3" />

  <div>
    <h3 class="text-bg-dark">Selecciona un archivo</h3>
    <asp:FileUpload ID="fuExcel" runat="server"  />
    <asp:Button ID="btnImportar" runat="server" CssClass="btn btn-primary" Text="Importar" OnClick="btnImportar_Click" />
    <asp:Label ID="lblMensaje" runat="server" CssClass="text-success form-control"></asp:Label>
  </div>


</asp:Content>
