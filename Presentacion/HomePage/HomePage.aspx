<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Presentacion.HomePage.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <style>
        .btn.dropdown-toggle::after {
            display: none;
        }
    </style>

    <div class="container mt-4">
        <!-- Mensajes -->
        <div id="alertSuccess" runat="server" visible="true" class="mt-4 mb-4">
            <asp:Label
                ID="lblMensaje"
                runat="server"
                Visible= <%# GetIsEditMode() %>
            />        
        </div>

        <div class="d-flex justify-content-between align-items-center mb-4">
            <h3 class="mb-0">Novedades</h3>
            <!-- Editar -->
            <asp:Panel ID="pnlDefaultMode" runat="server" Visible="true">
                <asp:Button
                    ID="btnToggleEditMode"
                    runat="server"
                    CssClass="btn btn-primary"
                    OnClick="ToggleEditMode_Click"
                    Text="Editar" />
            </asp:Panel>

            <!-- Añadir y confirmar -->
            <asp:Panel ID="pnlEditMode" runat="server" Visible="false">
                <asp:LinkButton
                    ID="btnAdd"
                    runat="server"
                    CssClass="btn btn-success me-2"
                    OnClick="btnAdd_Click">
                    <i class="bi bi-plus"></i> Añadir
                </asp:LinkButton>
                <asp:LinkButton
                    ID="btnExitEditMode"
                    runat="server"
                    CssClass="btn btn-secondary"
                    OnClick="ToggleEditMode_Click">
                    <i class="bi bi-check"></i>
                </asp:LinkButton>
            </asp:Panel>
        </div>

        <!-- Sección de novedades -->
        <div class="mb-4">
            <!-- Repeater de productos -->
            <asp:Repeater ID="rptProductos" runat="server" OnItemCommand="rptProductos_ItemCommand">
                <HeaderTemplate>
                    <div class="row row-cols-2 row-cols-md-5 g-3" style="align-content: center; justify-content: start;">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col" style="max-width: 700px;">
                        <div class="d-flex align-items-start">
                            <!-- Editar articulo -->
                            <asp:Panel
                                ID="pnlEditButtons"
                                runat="server"
                                Visible='<%# GetIsEditMode() %>'
                                class="ms-2">
                                <div class="dropdown">
                                <button class="btn btn-link dropdown-toggle p-0" type="button" data-bs-toggle="dropdown" aria-expanded="false" style="position: relative;">
                                    <i class="bi bi-three-dots-vertical"></i>
                                </button>
                                    <ul class="dropdown-menu">
                                        <li>
                                            <asp:LinkButton 
                                                ID="lnkEliminar" 
                                                runat="server" 
                                                CssClass="dropdown-item"
                                                CommandName="Eliminar" 
                                                CommandArgument='<%# Eval("IdArticulo") %>'>
                                                Eliminar
                                            </asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton 
                                                ID="lnkModificar" 
                                                runat="server"
                                                CssClass="dropdown-item" 
                                                CommandName="Modificar" 
                                                CommandArgument='<%# Eval("IdArticulo") %>'>
                                                Modificar
                                            </asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                            </asp:Panel>
                        </div>
                        <h5 class="mt-2 mb-0"><%# Eval("NombreArticulo") %></h5>
                        <p class="mt-2 mb-0">$<%# Eval("PrecioVenta", "{0:N2}") %></p>
                        
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

            <asp:Panel
                ID="pnlNoData"
                runat="server"
                CssClass="alert alert-info"
                Visible="false">
                No se encontraron artículos.
            </asp:Panel>
        </div>
    </div>
</asp:Content>