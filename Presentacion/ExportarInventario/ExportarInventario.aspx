<%@ Page Title="Exportar Inventario" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="ExportarInventario.aspx.cs" Inherits="Presentacion.ExportarInventario.ExportarInventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <style>
        /* Estilos para el diseño */
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

        .export-button {
            background-color: #ffcc00;
            color: #000;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
        }

        .export-button:hover {
            background-color: #e6b800;
        }
    </style>

    <div class="container-fluid">
        <div class="row">
            <!-- Sidebar -->
            <div class="col-md-3 col-lg-2 sidebar">
                <div class="user-info p-3">
                    <h6>Hola,
                        <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
                    </h6>
                </div>
                <ul class="menu list-unstyled p-3">
                    <li><a href="../HistorialVentas/HistorialVentas.aspx" class="text-decoration-none">Historial de ventas</a></li>
                    <li><a href="../ExportarInventario/ExportarInventario.aspx" class="text-decoration-none active">Exportar inventario</a></li>
                    <li><a href="../Clientes/Clientes.aspx" class="text-decoration-none">Clientes</a></li>
                </ul>
            </div>

            <!-- Contenido Principal -->
            <div class="col-md-9 col-lg-10 content-section">
                <h3>Exportar venta de pantalones</h3>
                <p>
                    Haz clic en el botón para exportar la información de las ventas de pantalones.
                </p>
                <asp:Button ID="BtnExportar" runat="server" CssClass="export-button" Text="Exportar" OnClick="BtnExportar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
