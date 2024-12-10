<%@ Page Title="Gestión de Clientes" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Presentacion.Perfil.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <style>
        .card{
            font-family: 'Merriweather';
            font-weight: lighter;
        }
        .btn-opcion {
            font-family: 'Merryweather';
            display: flow;
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            text-align: center;
            background-color: #95b2b8;
            color: white;
            border: none;
            border-radius: 15px;
            text-decoration: none;
            transition: all 0.3s ease;
            font-weight: bold;
            
        }

        .btn-opcion:hover {

            background-color: #eca400;
            transform: scale(1.05);
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        .btn-opcion:active {
            background-color: #003f7f;
            transform: scale(0.98);
        }

    </style>

    <div class="container mt-4">
        <div class="row">
            <!-- Columna izquierda: Opciones -->
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Bienvenido, <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario"></asp:Label></h5>
                        <a href="#" class="btn-opcion">Historial de compras</a>
                        <a href="#" class="btn-opcion">Estado de cuenta</a>
                        <a href="#" class="btn-opcion">Detalle de crédito</a>
                    </div>
                </div>
            </div>

            <!-- Columna derecha: Última compra -->
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Última compra</h5>
                        <div class="row">
                            <div class="col-md-4">
                                <!-- Imagen del producto -->
                                <img src="ruta_de_imagen.jpg" alt="Producto" class="img-fluid rounded">
                            </div>
                            <div class="col-md-8">
                                <!-- Detalles del producto -->
                                <p><strong>Nombre del producto:</strong> <asp:Label ID="lblNombreProducto" runat="server" Text="Producto"></asp:Label></p>
                                <p><strong>Total:</strong> <asp:Label ID="lblTotalCompra" runat="server" Text="$0.00"></asp:Label></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
