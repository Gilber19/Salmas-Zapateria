<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="EnviarEmail.aspx.cs" Inherits="Presentacion.Email.EnviarEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
  <div class="container">
    <h4 class="text-black mt-5 mb-0">Gestión de Clientes</h4>
    <hr class="bg-success mt-0 mb-3" />

    <label for="txtPara">Para:</label>
    <asp:TextBox ID="txtPara" runat="server"></asp:TextBox>
    <br />
    <label for="txtAsunto">Asunto:</label>
    <asp:TextBox ID="txtAsunto" runat="server"></asp:TextBox>
    <br />
    <label for="txtMensaje">Mensaje:</label><br />
    <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Rows="10" Columns="30" Width="658px"></asp:TextBox>
    <br />
    <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-primary" Text="Enviar" OnClick="btnEnviar_Click" />
  </div>
</asp:Content>
