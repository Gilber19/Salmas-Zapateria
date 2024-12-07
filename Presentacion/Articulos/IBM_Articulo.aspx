<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="IBM_Articulo.aspx.cs" Inherits="Presentacion.Articulos.IBM_Articulo" %>

<%@ Register Src="~/Recursos/Controles/cuTextoAlfaNumerico.ascx" TagPrefix="uc1" TagName="cuTextoAlfaNumerico" %>
<%@ Register Src="~/Recursos/Controles/wucTextoRequerido.ascx" TagPrefix="uc1" TagName="wucTextoRequerido" %>
<%@ Register Src="~/Recursos/Controles/wucTexto.ascx" TagPrefix="uc1" TagName="wucTexto" %>
<%@ Register Src="~/Recursos/Controles/wucMensajeDeError.ascx" TagPrefix="uc1" TagName="wucMensajeDeError" %>
<%@ Register Src="~/Recursos/Controles/wucMensaje.ascx" TagPrefix="uc1" TagName="wucMensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
  <div class="container">
    <h4 class="text-black mt-5 mb-0">Gestión de Artículos</h4>
    <hr class="bg-success mt-0 mb-3" />

    <div class="row">
      <div class="col-lg-8 col-md-6 col-sm-6">
        <asp:LinkButton ID="BtnMnuNuevo" runat="server" CssClass="btn btn-success" ToolTip="Registrar un nuevo Articulo" CausesValidation="False" OnClick="BtnMnuNuevo_Click"><i class="bi bi-file-plus"></i> Nuevo Articulo</asp:LinkButton>
        <asp:LinkButton ID="BtnMnuListado" runat="server" CssClass="btn btn-secondary" ToolTip="Listado de Articulos en archivo" OnClick="btnListado_Click" CausesValidation="False"><i class="bi bi-list-task"></i> Listado</asp:LinkButton>
        <asp:LinkButton ID="BtnPDF" runat="server" CssClass="btn btn-info text-right" CausesValidation="False" OnClick="BtnPDF_Click"><i class="bi bi-person-raised-hand"></i> PDF</asp:LinkButton>
      </div>

      <div class="col-lg-4 col-md-6 col-sd-6">
        <div class="row">
          <div class="col-lg-9">
            <asp:TextBox ID="TbCriterioBusqueda" runat="server" CssClass="form-control" placeholder="Buscar" ToolTip="Buscar"></asp:TextBox>
          </div>
          <div class="col-lg-3">
            <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-success" ToolTip="Permite buscar un Articulo" Text="Buscar" CausesValidation="False" OnClick="BtnBuscar_Click" />
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid w-75 mt-5">
      <uc1:wucMensaje ID="lblMensaje" runat="server" />

      <asp:Panel ID="PnlCapturaDatos" runat="server">
        <div class="card mt-5">
          <div id="CardHeader" runat="server">
            <h5>
              <asp:Label ID="lblAccion" CssClass="text-white" runat="server"></asp:Label>
            </h5>
          </div>

          <div class="card-body">
            <div class="row">
              <uc1:wucTextoRequerido runat="server" ID="tbCodigoArticulo" Titulo="Código de la artículo" />
              <uc1:wucTextoRequerido runat="server" ID="tbNombreArticulo" Titulo="Nombre de la artículo" />
              <uc1:wucTexto runat="server" ID="tbDescripcionArticulo" Titulo="Descripción" TextMode="MultiLine" />
              <uc1:wucMensaje runat="server" ID="cuMensaje" />
            </div>
          </div>

          <div class="card-footer">
            <asp:Button ID="BtnInsertar" runat="server" CssClass="btn btn-success" Text="Grabar" OnClick="btnInsertar_Click" />
            <asp:Button ID="BtnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" CausesValidation="False" OnClick="btnBorrar_Click" OnClientClick="return confirm(&quot;Los datos del Articulo serán borrados permanentemente. ¿Está seguro de borrarlos?&quot;);" />
            <asp:Button ID="BtnModificar" runat="server" CssClass="btn btn-primary" Text="Modificar" OnClick="BtnModificar_Click" />

            <asp:Button ID="BtnMnuModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" CausesValidation="False" OnClick="BtnMnuModificar_Click" />
            <asp:Button ID="BtnMnuBorrar" runat="server" Text="Borrar" CssClass="btn btn-danger" CausesValidation="False" OnClick="BtnMnuBorrar_Click" />
            <asp:Button ID="BtnCancelar" runat="server" Text="Finalizar" CssClass="btn btn-secondary" CausesValidation="False" OnClick="BtnCancelar_Click" />
          </div>
        </div>
      </asp:Panel>

      <!-- Contenedor del tipo panel para el GridView de presentación del listado de Articulos-->
      <asp:Panel ID="PnlGrvArticulos" runat="server">
        <div class="container">
          <asp:GridView ID="GrvArticulos" runat="server"
            DataKeyNames="IdArticulo"
            AutoGenerateColumns="False"
            OnRowEditing="GrvArticulos_RowEditing"
            OnRowDeleting="GrvArticulos_RowDeleting"
            CssClass="table table-sm table-bordered">
            <Columns>
              <asp:BoundField DataField="CodigoArticulo" HeaderText="CÓDIGO"></asp:BoundField>
              <asp:BoundField DataField="NombreArticulo" HeaderText="ARTÍCULO"></asp:BoundField>
              <asp:BoundField DataField="PrecioVenta" HeaderText="PRECIO"></asp:BoundField>
              <asp:BoundField DataField="DescripcionArticulo" HeaderText="DESCRIPCIÓN"></asp:BoundField>
              <asp:BoundField DataField="IdImagen" HeaderText="IMAGEN"></asp:BoundField>
              <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="EDITAR">
                <ItemTemplate>
                  <asp:LinkButton ID="GrvBtnEditar" runat="server" CssClass="btn btn-sm btn-primary " ToolTip="Editar los datos de la artículo" CausesValidation="false" CommandName="Edit"><i class="bi bi-pen"></i></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
              </asp:TemplateField>
              <asp:TemplateField InsertVisible="false" ShowHeader="false" HeaderText="BORRAR">
                <ItemTemplate>
                  <asp:LinkButton ID="GrvBtnBorrar" runat="server" CssClass="btn btn-sm btn-danger" ToolTip="Borrar los datos de la artículo" CausesValidation="false" CommandName="Delete"><i class="bi bi-trash"></i></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
              </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="text-center text-white bg-dark" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle CssClass="back table-secondary" ForeColor="Black" />
            <RowStyle BackColor="White" ForeColor="Black" />
          </asp:GridView>
        </div>
      </asp:Panel>
    </div>
    <asp:HiddenField ID="hfIdArticulo" runat="server" Value="" />
  </div>
</asp:Content>
