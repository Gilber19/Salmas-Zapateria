<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="IBM_Clientes.aspx.cs" Inherits="Presentacion.Clientes.IBM_Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
  <div class="container">
    <h4 class="text-black mt-5 mb-0">Gestión de Clientes</h4>
    <hr class="bg-success mt-0 mb-3" />

    <div class="row">
      <div class="col-lg-8 col-md-6 col-sm-6">
        <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-success" ToolTip="Registrar un nuevo cliente" CausesValidation="False"><i class="bi bi-file-plus"></i> Nuevo cliente</asp:LinkButton>
        <asp:LinkButton ID="BtnMnuListado" runat="server" CssClass="btn btn-secondary" ToolTip="Listado de sistemas en archivo" CausesValidation="False"><i class="bi bi-list-task"></i> Listado</asp:LinkButton>
        <asp:LinkButton ID="BtnAyuda" runat="server" CssClass="btn btn-info text-right" CausesValidation="False"><i class="bi bi-person-raised-hand"></i> Ayuda</asp:LinkButton>
      </div>

      <div class="col-lg-4 col-md-6 col-sd-6">
        <div class="row">
          <div class="col-lg-9">
            <asp:TextBox ID="TbCriterioBusqueda" runat="server" CssClass="form-control" placeholder="Buscar" ToolTip="Buscar"></asp:TextBox>
          </div>
          <div class="col-lg-3">
            <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-success" ToolTip="Permite buscar un sistema" Text="Buscar" CausesValidation="False" />
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
