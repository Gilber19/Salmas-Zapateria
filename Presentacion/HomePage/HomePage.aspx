<%@ Page Title="Salma's Zapatería" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Presentacion.HomePage.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <style>

    .btn.dropdown-toggle::after {
        display: none;
    }

    .image {
    width: 210px;
    height: 210px;
    object-fit: contain;
    border: none;
    background-color: #f8f9fa;
}


    .card {
        font-family: 'Merriweather';
        position: relative;
        border: none; 
        box-shadow: none; 
        margin: 0;
        padding: 0;
    }

    .edit-buttons {
        position: absolute;
        top: 10px;
        right: 10px;
    }

    .row-cols-5 > * {
        flex: 0 0 20%; 
        max-width: 20%;
        padding: 0;
    }
    </style>

    <div class="container mt-4">
        <!-- Mensajes -->
        <div id="alertSuccess" runat="server" visible="true" class="mt-4 mb-4">
            <asp:Label
                ID="lblMensaje"
                runat="server"
                Visible='<%# GetIsEditMode() %>'
            />        
        </div>

        <div class="d-flex flex-column flex-md-row justify-content-between align-items-center mb-4">
            <h3 class="mb-3 mb-md-0">Novedades</h3>
            <!-- Editar -->
            <asp:Panel ID="pnlDefaultMode" runat="server" Visible="true" class="mb-2 mb-md-0">
                <asp:Button
                    ID="btnToggleEditMode"
                    runat="server"
                    CssClass="btn btn-primary"
                    OnClick="ToggleEditMode_Click"
                    Text="Editar" />
            </asp:Panel>

            <!-- Añadir y confirmar -->
            <asp:Panel ID="pnlEditMode" runat="server" Visible="false" class="d-flex flex-wrap">
                <asp:LinkButton
                    ID="btnAdd"
                    runat="server"
                    CssClass="btn btn-success me-2 mb-2"
                    OnClick="btnAdd_Click">
                    <i class="bi bi-plus"></i> Añadir
                </asp:LinkButton>
                <asp:LinkButton
                    ID="btnExitEditMode"
                    runat="server"
                    CssClass="btn btn-secondary mb-2"
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
                    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-5 g-3">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <asp:Panel
                                ID="pnlEditButtons"
                                runat="server"
                                Visible='<%# IsEditMode %>'
                                CssClass="d-flex justify-content-end edit-buttons"
                                Style="z-index: 100;"
                                >
                                
                                <div class="dropdown">
                                    <button class="btn btn-link dropdown-toggle p-0" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                        <i class="bi bi-three-dots-vertical"></i>
                                    </button>
                                    <ul class="dropdown-menu dropdown-menu-end">
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
                                    </ul>
                                </div>
                            </asp:Panel>
                            <asp:LinkButton 
                             ID="lnkProducto" 
                             runat="server" 
                             CssClass="card h-100" 
                             CommandArgument='<%# Eval("IdArticulo") %>' 
                             OnClick="RedireccionarAProducto" 
                             style="cursor: pointer;">
                            <img src="<%# Eval("Imagenes") %>" alt="Imagen del producto" class="card-img-top image" />
                                <div class="card-body">
                                     <h5 class="card-title"><%# Eval("NombreArticulo") %></h5>
                                    <p class="card-text">$<%# Eval("PrecioVenta", "{0:N2}") %></p>
                                </div>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <asp:HiddenField ID="hfIdArticulo" runat="server" Value='<%# Eval("IdArticulo") %>' />
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