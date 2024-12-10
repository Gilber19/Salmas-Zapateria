<%@ Page Title="Gestión de Clientes" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="DetalleClientes.aspx.cs" Inherits="Presentacion.DetalleClientes.DetalleClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
   
        <style>
            body {
                font-family: Arial, sans-serif;
                background-color: #f8f9fa;
            }

            .row-header {
                display: flex;
                justify-content: space-between;
                align-items: center;
                margin-top: 20px;
                padding: 0 15px;
            }

            .details-container {
                margin-top: 20px;
                padding: 20px;
                background: white;
                border-radius: 5px;
                box-shadow: none;
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

            .apartados-container {
                margin-top: 20px;
                background: white;
                border-radius: 5px;
                padding: 15px;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            }

            .apartado-item {
                margin-bottom: 15px;
                display: flex;
                align-items: center;
                justify-content: space-between;
                background-color: #fff;
                border: 1px solid #ddd;
                border-radius: 5px;
                overflow: hidden;
                box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                padding: 10px;
            }

                .apartado-item img {
                    border-radius: 10px;
                    max-width: 270px;
                    max-height: 270px;
                    object-fit: cover;
                    display: block;
                    margin: 0 auto;
                }

            .apartado-details {
                flex-grow: 1;
                padding: 10px;
                text-align: left;
            }

                .apartado-details h5 {
                    margin: 0;
                    font-size: 16px;
                }

            .btn-detalle {
                background-color: #ECA400;
                border: none;
                color: white;
            }

                .btn-detalle:hover {
                    background-color: #b88204;
                }

            .error-message {
                color: red;
                font-weight: bold;
            }

            .bi-arrow-left {
                max-width: 20px;
            }
        </style>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Detalle Cliente</title>
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    </head>

    <body>
        <div class="container mt-4">
            <div class="row mt-3">
                <!-- Columna izquierda -->
                <div class="col-md-4 mt-5">
                    <a href="/Clientes/Clientes.aspx" class="btn btn-back">
                        <i class="bi bi-arrow-left"></i>Regresar
                    </a>
                    <h3 id="nombre-cliente" class="mb-0">
                        <asp:Label ID="LblNombre" runat="server"></asp:Label>
                    </h3>
                    <div class="details-container">
                        <p>
                            <strong>Teléfono:</strong>
                            <asp:Label ID="LblTelefono" runat="server"></asp:Label>
                        </p>
                        <p><strong>Límite de Crédito:</strong> <asp:Label ID="LblLimiteCredito" runat="server"></asp:Label></p>
                        <p><strong>Crédito Disponible:</strong> <asp:Label ID="LblLimiteDisponible" runat="server"></asp:Label></p>
                    </div>
                </div>

                <!-- Columna derecha -->
                <div class="col-md-8 mt-5">
                    <asp:Label ID="LblMensaje" runat="server" CssClass="error-message" Visible="false"></asp:Label>
                    <h4 class="mb-0">Apartados</h4>
                    <div class="apartados-container">
                        <!-- Literal para renderizar los apartados dinámicamente -->
                        <div class="apartados-container">
                            <asp:Repeater ID="RepeaterApartados" runat="server">
                                <ItemTemplate>
                                    <div class='apartado-item'>
                                        <img src='<%# Eval("ImagenesArticulo") %>' alt='Imagen Artículo' />
                                        <div class='apartado-details'>
                                            <p><%# Eval("NombresArticulos") %></p>
                                            <p>ID: <%# Eval("IdApartado") %></p>
                                            <p>Total: <%# Eval("TotalCosto") %></p>
                                            <p>Abonado: <%# Eval("TotalAbonado") %></p>
                                            <p>Adeudo: <%# Eval("Adeudo") %></p>
                                            <p>Fecha de vencimiento: <%# Eval("FechaVencimiento", "{0:dd/MM/yyyy}") %></p>
                                            <asp:TextBox ID="txtAbono" runat="server" CssClass="form-control" Placeholder="Ingrese cantidad"></asp:TextBox>
                                            <asp:Button ID="btnAbonar" runat="server" CssClass="btn btn-detalle" Text="Abonar" CommandArgument='<%# Eval("IdApartado") %>' OnClick="BtnAbonar_Click" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    </body>
</asp:Content>
