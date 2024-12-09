<%@ Page Title="Gestión de Clientes" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="DetalleClientes.aspx.cs" Inherits="Presentacion.DetalleClientes.DetalleClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Detalle Cliente</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
        <style>
            body {
                font-family: Arial, sans-serif;
                background-color: #f8f9fa;
            }

            .details-container {
                margin-top: 20px;
                padding: 20px;
                background: white;
                border-radius: 5px;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            }

            .btn-back {
                margin-bottom: 20px;
                background-color: #ECA400;
                border: none;
                color: white;
            }

                .btn-back:hover {
                    background-color: #b88204;
                }
        </style>
    </head>
    <body>
        <div class="container mt-4">
            <a href="/Clientes/Clientes.aspx" class="btn btn-back">
                <i class="bi bi-arrow-left"></i>Regresar
            </a>

            <div class="details-container">
                <h3>Detalles del Cliente</h3>
                <hr>
                <p>
                    <strong>Nombre:</strong>
                    <asp:Label ID="LblNombre" runat="server"></asp:Label>
                </p>
                <p>
                    <strong>Teléfono:</strong>
                    <asp:Label ID="LblTelefono" runat="server"></asp:Label>
                </p>
                <p><strong>Límite de Crédito:</strong> $<asp:Label ID="LblLimiteCredito" runat="server"></asp:Label></p>
                <p><strong>Crédito Disponible:</strong> $<asp:Label ID="LblLimiteDisponible" runat="server"></asp:Label></p>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    </body>
    </html>
</asp:Content>
