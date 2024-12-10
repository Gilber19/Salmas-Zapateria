<%@ Page Title="Historial de Ventas" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="HistorialVentas.aspx.cs" Inherits="Presentacion.HistorialVentas.HistorialVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <style>
        /* Estilos generales del sidebar */
        .sidebar {
            background-color: #f8f9fa;
            border-right: 1px solid #ddd;
        }

        .menu a {
            color: #000;
            text-decoration: none;
            display: block;
            padding: 10px 15px;
        }

            .menu a.active {
                font-weight: bold;
                background-color: #e0e0e0;
                border-radius: 5px;
            }

            .menu a:hover {
                background-color: #f1f1f1;
            }

        .content-section {
            padding: 20px;
        }
        /* Estilo para los elementos de la lista */
        .list-group-item {
            border: 1px solid #ddd;
            border-radius: 5px;
            margin-bottom: 10px;
            padding: 15px;
        }

            /* Imagen de los productos */
            .list-group-item img {
                max-width: 100px;
                height: auto;
                object-fit: cover;
            }

        /* Estilo para el botón de agregar */
        .add-button {
            background-color: #007bff;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
        }

        .add-button:hover {
            background-color: #0056b3;
        }
    </style>

    <div class="container-fluid">
        <div class="row">
            <!-- Sidebar -->
            <div class="col-md-3 col-lg-2 sidebar bg-light border-end">
                <div class="user-info p-3">
                    <h6>Hola,
                        <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
                    </h6>
                </div>
                <ul class="menu list-unstyled p-3">
                    <li><a href="../HistorialVentas/HistorialVentas.aspx" id="historialLink" class="text-decoration-none active">Historial de ventas</a></li>
                    <li><a href="../ExportarInventario/ExportarInventario.aspx" class="text-decoration-none">Exportar inventario</a></li>
                    <li><a href="../Clientes/Clientes.aspx" class="text-decoration-none">Clientes</a></li>
                </ul>
            </div>

            <!-- Label para mostrar mensajes -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>

            <!-- Lista de Ventas -->
            <div class="col-md-9 col-lg-10 sales-list">
                <!-- Botón Agregar al lado derecho -->
                <div class="d-flex justify-content-end mb-3">
                    <asp:LinkButton
                    ID="btnAdd"
                    runat="server"
                    CssClass="btn btn-success me-2 mb-2"
                    OnClick="btnAdd_Click">
                    <i class="bi bi-plus"></i> Añadir Venta
                </asp:LinkButton>
                </div>

                <asp:Repeater ID="RepeaterHistorial" runat="server">
                    <ItemTemplate>
                        <div class="list-group-item d-flex align-items-start gap-3">
                            <!-- Imagen del producto -->
                            <img src='<%# Eval("Imagenes") %>' alt="Producto" class="img-thumbnail" style="width: 100px; height: auto;">
                            <!-- Información de la venta -->
                            <div>
                                <h5 class="mb-1"><%# Eval("serieComprobante") %></h5>
                                <p class="mb-1">Fecha de venta: <%# Eval("fechaHora") %></p>
                                <p class="mb-1">Total: $<%# Eval("total", "{0:N2}") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
