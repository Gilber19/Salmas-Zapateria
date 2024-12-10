<%@ Page Title="Historial Ventas" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="HistorialVentas.aspx.cs" Inherits="Presentacion.HistorialVentas.HistorialVentas" %>

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

    <style>
        /* Estilo general para el sidebar */
        .sidebar {
            width: 200px;
            background-color: #f9f9f9; /* Fondo claro */
            border-right: 1px solid #ccc;
            padding: 20px;
            font-family: Arial, sans-serif;
            height: 100vh; /* Ocupa toda la altura */
        }

        /* Información del usuario */
        .user-info {
            margin-bottom: 20px;
            font-size: 16px;
            color: #333;
        }

            .user-info .user-name {
                font-weight: bold;
            }

        /* Estilo para la lista de navegación */
        .menu {
            list-style: none;
            padding: 0;
            margin: 0;
        }

            .menu li {
                margin-bottom: 10px;
            }

                .menu li a {
                    text-decoration: none;
                    color: #333;
                    font-size: 14px;
                    display: block;
                    padding: 5px 0;
                }

                    .menu li a:hover {
                        color: #007BFF; /* Azul para hover */
                    }

                    .menu li a.active {
                        font-weight: bold;
                        color: #000;
                    }

        @media (max-width: 768px) {
            .sidebar {
                width: 100%;
                border-right: none;
                border-bottom: 1px solid #ccc;
                height: auto;
            }
        }
    </style>




</asp:Content>
