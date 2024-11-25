<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="ventas.aspx.cs" Inherits="Presentacion.Ventas.ventas" %>

<%@ Register Src="~/Recursos/Controles/wucMensajeDeError.ascx" TagPrefix="uc1" TagName="wucMensajeDeError" %>
<%@ Register Src="~/Recursos/Controles/cuTextoAlfaNumerico.ascx" TagPrefix="uc1" TagName="cuTextoAlfaNumerico" %>
<%@ Register Src="~/Recursos/Controles/wfucFecha.ascx" TagPrefix="uc1" TagName="wfucFecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
  <div class="container-fluid">
    <div class="row mt-3">
      <div class="col-3">
        <strong>Cliente:</strong>
        <asp:DropDownList ID="ddlClientes" runat="server" DataValueField="IdPersona" DataTextField="NombrePersona" CssClass="form-control"></asp:DropDownList>
      </div>

      <div class="col-3">
        <strong>Tipo comprobante:</strong>
        <uc1:cuTextoAlfaNumerico runat="server" ID="tbTipoComprobante" />
      </div>

      <div class="col-2">
        <strong>Serie del comprobante:</strong>
        <uc1:cuTextoAlfaNumerico runat="server" ID="tbSerieComprobante" />
      </div>

      <div class="col-2">
        <strong>Numero Comprobante:</strong>
        <asp:TextBox ID="tbNumeroComprobante" runat="server"></asp:TextBox>
      </div>
      
    </div>
    <div class="col-2">
      <strong>Fecha venta:</strong>
      <asp:TextBox ID="tbFechaHora" runat="server"></asp:TextBox>
    </div>


    <div class="row text-center mt-3 bg-body-secondary">
      <div class="col-lg-2">
        <strong>Código del artículo:</strong>
      </div>
      <div class="col-lg-2">
        <asp:TextBox ID="TbCriterioBusqueda" runat="server" CssClass="form-control" placeholder="Buscar" ToolTip="Buscar"></asp:TextBox>
      </div>
      <div class="col-lg-2">
        <asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-success" ToolTip="Permite buscar un sistema" Text="Buscar" CausesValidation="False" OnClick="BtnBuscar_Click" />
      </div>
      <div class="col-lg-2">
        <uc1:wucMensajeDeError runat="server" ID="lbllMesajeBusqueda" />
      </div>
    </div>

    <div class="container-fluid m-0">

        <asp:UpdatePanel ID="UP_General" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div class="row m-0 p-0">
              <asp:UpdatePanel ID="UP_GrvVentas" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <asp:GridView ID="GrvVentas" runat="server"
                    AutoGenerateColumns="False"
                    DataKeyNames="IdArticulo"
                    OnRowDeleting="GrvVentas_RowDeleting"
                    CssClass="table table-bordered table-light table-hover table-striped grid-view">
                    <Columns>
                      <asp:BoundField DataField="CodigoArticulo" HeaderText="Código artículo"></asp:BoundField>
                      <asp:BoundField DataField="NombreArticulo" HeaderText="Descripción artículo"></asp:BoundField>
                      <asp:TemplateField HeaderText="Precio venta">
                        <ItemTemplate>
                          <asp:Label ID="lblPrecioVenta" runat="server" Text='<%# Bind("PrecioVenta") %>'></asp:Label>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                          <asp:TextBox ID="tbCantidad" runat="server" AutoPostBack="True" OnTextChanged="tbCantidad_TextChanged" Text='<%# Bind("Cantidad") %>'></asp:TextBox>
                        </ItemTemplate>
                      </asp:TemplateField>

                      <asp:TemplateField HeaderText="Importe">
                        <ItemTemplate>
                          <asp:Label ID="lblImporte" runat="server" Text='<%# Bind("Importe") %>'></asp:Label>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="BORRAR">
                        <ItemTemplate>
                          <asp:LinkButton ID="GrvBtnBorrar" runat="server" CssClass="btn btn-sm btn-danger" CausesValidation="false" CommandName="Delete">Borrar</asp:LinkButton>
                        </ItemTemplate>
                      </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </ContentTemplate>
              </asp:UpdatePanel>
            </div>

            <div class="row">
              <div class="col-3">
                <h4>
                  <asp:Label ID="lblTotalArticulos" runat="server" CssClass=" fw-bold"></asp:Label></h4>
              </div>
              <div class="col-3  text-end">
                <asp:Button ID="btnCobrar" runat="server" CssClass="btn btn-primary" Text="Cobrar" OnClick="btnCobrar_Click" />
              </div>
              <div class="col-6 text-end">
                <h4>
                  <asp:Label ID="lblSubTotal" runat="server" CssClass="fw-bold"></asp:Label></h4>
                <h4>
                  <asp:Label ID="lblImpuesto" runat="server" CssClass="fw-bold"></asp:Label></h4>
                <h4>
                  <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold"></asp:Label></h4>
              </div>
            </div>
          </ContentTemplate>
        </asp:UpdatePanel>
      </div>

  </div>
  
</asp:Content>
