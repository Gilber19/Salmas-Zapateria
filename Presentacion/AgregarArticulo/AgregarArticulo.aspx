<%@ Page Title="Agregar Artículo" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="Presentacion.AgregarArticulo.AgregarArticulo" %>

<%@ Register Src="~/Recursos/Controles/wucTextoRequerido.ascx" TagPrefix="uc1" TagName="wucTextoRequerido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <div class="container my-5">
        <h2 class="text-center mb-4">Agregar Artículo</h2>
        <asp:Panel runat="server">
            <asp:Label ID="lblMensaje" runat="server" CssClass="alert" Visible="false"></asp:Label>
            <div class="row">
                <!-- Primera columna -->
                <div class="col-md-4">
                    <!-- Nombre -->
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre *</label>
                        <uc1:wucTextoRequerido ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Agregar el nombre" />
                    </div>
                    <!-- Descripción -->
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción *</label>
                        <uc1:wucTextoRequerido ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Agregar una descripción del producto" TextMode="MultiLine" Rows="4" />
                    </div>
                    <!-- Género -->
                    <div class="mb-3">
                        <label for="ddlGenero" class="form-label">Género *</label>
                        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Seleccione Género" Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Hombre" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Mujer" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- Categoría -->
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría *</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                            <asp:ListItem Text="Seleccione Categoría" Value="" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <!-- Subcategoría -->
                    <div class="mb-3">
                        <label for="ddlSubcategoria" class="form-label">Subcategoría *</label>
                        <asp:DropDownList ID="ddlSubcategoria" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Seleccione Subcategoría" Value="" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Segunda columna -->
                <div class="col-md-4">
                    <!-- Imagen Principal -->
                    <div class="mb-3">
                        <label for="fuImagenPrincipal" class="form-label">Imagen Principal *</label>
                        <asp:FileUpload ID="fuImagenPrincipal" runat="server" CssClass="form-control"
                            onchange="previewImage(this, 'imgPreviewPrincipal')" />
                        <asp:Image ID="imgPreviewPrincipal" runat="server" CssClass="img-fluid mt-2"
                            ClientIDMode="Static" Style="max-width: 200px; display: none;" alt="Imagen Principal" />
                    </div>
                    <!-- Código del Artículo -->
                    <div class="mb-3">
                        <label for="txtCodigoArticulo" class="form-label">Código del Artículo *</label>
                        <uc1:wucTextoRequerido ID="txtCodigoArticulo" runat="server" CssClass="form-control" Placeholder="Código" />
                    </div>
                    <!-- Sección de Tallas y Stock -->
                    <div class="mb-3">
                        <label for="txtTallaNuevo" class="form-label">Añadir Talla y Stock *</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtTallaNuevo" runat="server" CssClass="form-control" Placeholder="Nueva Talla"></asp:TextBox>
                            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" Placeholder="Stock" TextMode="Number"></asp:TextBox>
                            <asp:Button ID="btnAgregarTalla" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarTalla_Click" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Tallas y Stock Disponibles *</label>
                            <asp:DropDownList ID="ddlTallas" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>

                </div>

                <!-- Tercera columna -->
                <div class="col-md-4">
                    <!-- Precio -->
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio *</label>
                        <uc1:wucTextoRequerido ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="$ Ingrese el precio" />
                    </div>
                    <!-- Imágenes Secundarias -->
                    <div class="mb-3">
                        <label for="fuImagenSecundaria" class="form-label">Imágenes Secundarias</label>
                        <asp:FileUpload ID="fuImagenSecundaria" runat="server" CssClass="form-control"
                            onchange="previewImage(this, 'imgPreviewSecundaria')" />
                        <asp:Image ID="imgPreviewSecundaria" runat="server" CssClass="img-fluid mt-2"
                            ClientIDMode="Static" Style="max-width: 200px; display: none;" alt="Imagen Secundaria" />
                        <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen"
                            CssClass="btn btn-primary mt-2" OnClick="btnAgregarImagen_Click" />

                        <asp:Repeater ID="RepeaterImagenesSecundarias" runat="server">
                            <ItemTemplate>
                                <div class="d-flex align-items-center mt-2">
                                    <img src='<%# Eval("ImagePath") %>' alt="Imagen Secundaria" class="img-thumbnail me-2" style="width: 100px;" />
                                    <asp:Button ID="btnEliminarImagen" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("ImagePath") %>' OnClick="btnEliminarImagen_Click" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- Botón Agregar -->
                    <div class="mb-3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Articulo" CssClass="btn btn-success w-100" OnClick="btnAgregar_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

    <script>
        function previewImage(input, imgPreview) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    var preview = document.getElementById(imgPreview);
                    if (preview) {
                        preview.src = e.target.result;
                        preview.style.display = 'block';
                    } else {
                        console.log('Preview element not found:', imgPreview);
                    }
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #ffffff; /* Fondo general */
            margin: 0;
            padding: 0;
        }

        .container {
            background-color: #fff; /* Color aplicado a los contenedores */
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
        }

        h2 {
            font-size: 1.8rem;
            font-weight: bold;
            color: #333333;
        }

        .form-label {
            font-weight: bold;
            color: #000000;
        }

        .form-control, .form-select {
            background-color: #95b2b8; /* Aplicación del color a los campos */
            border: 1px solid #adc9bc;
            border-radius: 4px;
            padding: 10px;
            font-size: 1rem;
        }

            .form-control::placeholder {
                color: #6c757d;
            }

            .form-control:focus, .form-select:focus {
                border-color: #495057;
                outline: none;
                box-shadow: 0 0 5px rgba(0, 123, 255, 0.25);
            }

        .img-fluid {
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 5px;
        }

        .btn {
            border-radius: 4px;
            padding: 10px 15px;
            font-size: 1rem;
        }

        .btn-primary {
            background-color: #95b2b8 !important;
            border: none;
        }

            .btn-primary:hover {
                background-color: #95b2c1 !important;
                font-size: 1.025rem;
            }

        .btn-danger {
            background-color: #dc3545;
            border: none;
        }

            .btn-danger:hover {
                background-color: #bb2d3b;
            }

        .btn-success {
            background-color: #95b2b8 !important;
            border: none;
            max-width: 160px;
        }

            .btn-success:hover {
                background-color: #218838;
                font-size: 1.025rem !important;
            }

        .w-100 {
            width: 100%;
        }

        .mt-2 {
            margin-top: 0.5rem;
        }

        .mb-3 {
            margin-bottom: 1rem;
        }

        .d-flex {
            display: flex;
            align-items: center;
        }

        .align-items-center {
            align-items: center;
        }

        .img-thumbnail {
            border-radius: 8px;
            max-width: 100px;
        }

        .alert {
            color: #dc3545;
            font-weight: bold;
            display: none;
        }

        #previewContainer {
            display: grid;
            grid-template-columns: repeat(2, 1fr);
            gap: 10px;
            max-width: 220px; /* Ajusta según el diseño */
        }
    </style>
</asp:Content>
