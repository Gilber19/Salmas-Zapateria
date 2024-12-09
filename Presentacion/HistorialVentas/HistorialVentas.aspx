<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="HistorialVentas.aspx.cs" Inherits="Presentacion.HistorialVentas.HistorialVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">

    <div class="sidebar">
        <!-- Mostrar el nombre del usuario -->
        <div class="user-info">
            <p>
                Hola, 
                <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
            </p>
        </div>

        <!-- Opciones de menú -->
        <ul class="menu">
            <li><a href="#historial" id="historialLink">Historial de ventas</a></li>
            <li><a href="#exportar">Exportar inventario</a></li>
            <li><a href="#clientes">Clientes</a></li>
        </ul>
    </div>

    <!-- Label para mostrar mensajes -->
    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>

    <!-- Repeater de productos -->
    <asp:Repeater ID="RepeaterHistorial" runat="server">
        <HeaderTemplate>
            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-5 g-3">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="col">
                <div class="card h-100">
                    <asp:Panel
                        ID="pnlEditButtons"
                        runat="server"
                        CssClass="d-flex justify-content-end edit-buttons">
                    </asp:Panel>
                    <img src="<%# Eval("Imagenes") %>" alt="Imagen del producto" class="card-img-top image" />
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("serieComprobante") %></h5>
                        <p class="card-text">Fecha de venta: <%# Eval("fechaHora") %></p>
                        <p class="card-text">Total: $<%# Eval("total", "{0:N2}") %></p>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
