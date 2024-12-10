<%@ Page Title="Apartados" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="Apartados.aspx.cs" Inherits="Presentacion.Apartados.Apartados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <style>
        .image {
            height: 100%;
            max-height: 200px;
            aspect-ratio: 1 / 1;
            object-fit: cover;
            border: none;
        } 
    </style>

    <div class="container mt-4">
        <!-- Mensajes -->
        <div id="alertSuccess" runat="server" visible="true" class="mt-4 mb-4">
            <asp:Label
                ID="lblMensaje"
                runat="server"
            />
        </div>

        <div class="row">
            <!-- Parte Izquierda: Lista de Artículos -->
            <div class="col-lg-8 col-md-12">
                <asp:Repeater ID="rptApartados" runat="server" OnItemCommand="rptApartados_ItemCommand">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="row no-gutters">
                                <div class="col-md-4">
                                    <img src='<%# ObtenerPrimeraImagen(Convert.ToInt32(Eval("IdArticulo"))) %>' 
                                        alt="Artículo" 
                                        class="card-img-top image" />
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# ObtenerNombreArticulo(Convert.ToInt32(Eval("IdArticulo"))) %></h5>
                                        <p class="card-text"><strong>Precio:</strong> $<%# ObtenerPrecioVenta(Convert.ToInt32(Eval("IdArticulo"))) %></p>
                                        <div class="form-group">
                                            <label for="txtCantidad">Cantidad:</label>
                                            <asp:TextBox ID="txtCantidad" runat="server" 
                                                Text='<%# Eval("Cantidad") %>' 
                                                CssClass="form-control" 
                                                Style="width: 80px;" />
                                        </div>
                                        <div class="mt-2">
                                            <asp:Button ID="btnActualizar" runat="server" 
                                                CommandName="Actualizar" 
                                                CommandArgument='<%# Eval("IdArticulo") %>' 
                                                Text="Actualizar" 
                                                CssClass="btn btn-secondary btn-sm mr-2" />
                                            <asp:Button ID="btnEliminar" runat="server" 
                                                CommandName="Eliminar" 
                                                CommandArgument='<%# Eval("IdArticulo") %>' 
                                                Text="Eliminar" 
                                                CssClass="btn btn-danger btn-sm" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <!-- Parte Derecha: Detalles y Botón para Apartar -->
            <div class="col-lg-4 col-md-12">
                <div class="card">
                    <div class="card-header">
                        Detalles del Apartado
                    </div>
                    <div class="card-body">
                        <p><strong>Fecha de Apartado:</strong> <%= DateTime.Now.ToString("dd/MM/yyyy") %></p>
                        <p><strong>Total:</strong> $<asp:Literal ID="litTotal" runat="server">0.00</asp:Literal></p>
                        <asp:Button ID="btnApartar" runat="server" 
                            Text="Apartar" 
                            CssClass="btn btn-primary btn-block" 
                            OnClick="Apartar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>