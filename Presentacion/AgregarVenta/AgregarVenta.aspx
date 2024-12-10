<%@ Page Title="Agregar Venta" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="AgregarVenta.aspx.cs" Inherits="Presentacion.AgregarVenta.AgregarVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <style>
        .back-button {
            display: flex;
            align-items: center;
            gap: 5px;
            font-size: 1rem;
            font-weight: bold;
            cursor: pointer;
        }

            .back-button i {
                font-size: 1.5rem;
            }


        .container-fluid {
            padding: 50px;
        }

        .row {
            display: flex;
            flex-wrap: nowrap; /* Mantiene los contenedores en una sola línea */
        }

        .sales-list {
            width: 45%;
            border: 1px solid #ddd;
            border-radius: 5px;
            padding: 15px;
        }

            /* Imagen de los productos */
            .sales-list img {
                max-width: 100px;
                height: auto;
                object-fit: cover;
            }

        /* Columna derecha con formulario de venta */
        .sales-form {
            width: 50%;
            border-radius: 5px;
            padding: 20px;
            margin-left: 60px;
        }

            .sales-form h3 {
                text-align: center;
                margin-bottom: 20px;
            }

        .form-group {
            margin-bottom: 15px;
        }

            .form-group label {
                font-weight: bold;
            }

            .form-group select,
            .form-group input {
                width: 100%;
                padding: 10px;
                border: 1px solid #ddd;
                border-radius: 5px;
            }

        .btn {
            width: 100%;
            padding: 10px;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-add {
            background-color: #007bff;
            color: white;
            margin-bottom: 10px;
        }

        .btn-listo {
            background-color: #f9a825;
            color: white;
        }

        .btn:hover {
            opacity: 0.9;
        }

        /* Responsividad */
        @media (max-width: 768px) {
            .row {
                flex-direction: column; /* Apila los contenedores en dispositivos pequeños */
            }

            .sales-list,
            .sales-form {
                width: 100%; /* Ancho completo */
            }
        }
    </style>

    <div class="container-fluid">
        <div class="back-button" onclick="window.history.back();">
            <i class="bi bi-arrow-left"></i>Volver

        </div>
        <div class="row">
            <!-- Contenedor izquierdo: Lista de Ventas -->
            <div class="col-md-8 col-lg-5 sales-list">
                <!-- Label para mostrar mensajes -->
                <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>

                <!-- Lista de Ventas -->
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

            <!-- Contenedor derecho: Formulario -->
            <div class="col-md-2 col-lg-7 sales-form">
                <!-- Formulario de venta -->
                <h3>AGREGAR VENTA</h3>

                <div class="form-group">
                    <label for="codigo">Código del artículo *</label>
                    <input type="text" id="codigo" name="codigo" placeholder="Código">
                </div>

                <div class="form-group">
                    <label for="talla">Talla *</label>
                    <select id="talla" name="talla">
                        <option value="">Seleccione</option>
                        <option value="S">S</option>
                        <option value="M">M</option>
                        <option value="L">L</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="cantidad">Cantidad *</label>
                    <select id="cantidad" name="cantidad">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="pago">Tipo de pago *</label>
                    <select id="pago" name="pago">
                        <option value="Efectivo">Efectivo</option>
                        <option value="Tarjeta">Tarjeta</option>
                        <option value="Transferencia">Transferencia</option>
                    </select>
                </div>

                <button class="btn btn-add">Añadir otro artículo</button>
                <button class="btn btn-listo">Listo</button>
            </div>
        </div>
    </div>
</asp:Content>
