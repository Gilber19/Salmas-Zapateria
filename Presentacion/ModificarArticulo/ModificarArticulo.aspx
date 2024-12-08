<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="Presentacion.ModificarArticulo.ModificarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <div class="container mt-4">
        <div class="row">
            <!-- Primera Columna -->
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox
                        ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Agregar el nombre" Text='<%# Bind("NombreArticulo") %>'></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox
                        ID="txtDescripcion" runat="server" CssClass="form-control" Placeholder="Una descripcion del producto" Text='<%# Bind("DescripcionArticulo") %>' TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlCategoria" class="form-label">Categoria</label>
                    <asp:DropDownList ID = "ddlCategoria" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label for="ddlSubcategoria" class="form-label">Subcategoria</label>
                    <asp:DropDownList ID="ddlSubcategoria" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Segunda Columna -->
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="fuImagenPrincipal" class="form-label">Imagen Principal</label>
                    <asp:FileUpload
                        ID="fuImagenPrincipal" runat="server" CssClass="form-control" />
                    <img
                        id="imgPreviewPrincipal" runat="server" src='<%# Bind("ImagenPrincipalPath") %>' alt="Imagen Principal" class="img-fluid mt-2" />
                </div>
                <div class="mb-3">
                    <label for="txtCodigoArticulo" class="form-label">Código del Artículo</label>
                    <asp:TextBox ID="txtCodigoArticulo" runat="server" CssClass="form-control" Placeholder="Código" Text='<%# Bind("CodigoArticulo") %>'></asp:TextBox>
                </div>
                <div class="row mb-3">
                    <div class="col">
                        <label for="ddlTalla" class="form-label">Talla</label>
                        <asp:DropDownList ID="ddlTalla" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Selecciona talla" Value="" />
                            <asp:ListItem Text="XS" Value="XS" />
                            <asp:ListItem Text="S" Value="S" />
                            <asp:ListItem Text="M" Value="M" />
                            <asp:ListItem Text="L" Value="L" />
                            <asp:ListItem Text="XL" Value="XL" />
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <label for="txtStock" class="form-label">Stock</label>
                        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" Text='<%# Bind("Stock") %>'></asp:TextBox>
                    </div>
                </div>
            </div>

            <!-- Tercer Columna -->
            <div class="col-md-4">
                <div class="mb-3">
                    <label for="RepeaterImagenesSecundarias" class="form-label">Imágenes Secundarias</label>
                    <asp:Repeater
                        ID="RepeaterImagenesSecundarias" runat="server">
                        <ItemTemplate>
                            <div class="d-flex mb-2">
                                <img src='<%# Eval("ImagePath") %>' alt="Imagen Secundaria" class="img-thumbnail me-2" style="width: 100px;" />
                                <asp:Button
                                    ID="btnEliminarImagen" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("ImagePath") %>' OnClick="EliminarImagen_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:FileUpload
                        ID="fuImagenSecundaria" runat="server" CssClass="form-control mt-2" />
                    <asp:Button
                        ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" CssClass="btn btn-primary mt-2" OnClick="btnAgregarImagen_Click" />
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <asp:TextBox
                        ID="txtPrecio" runat="server" CssClass="form-control" Placeholder="Ingrese el precio" Text='<%# Bind("PrecioVenta") %>'></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button
                        ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-success" OnClick="btnModificar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>