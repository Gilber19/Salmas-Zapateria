<%@ Page Title="Agregar Artículo" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="Presentacion.AgregarArticulo.AgregarArticulo" %>

<%@ Register Src="~/Recursos/Controles/wucTextoRequerido.ascx" TagPrefix="uc1" TagName="wucTextoRequerido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <div class="container my-5">
        <asp:Label
            ID="lblMensaje" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
        <h2 class="text-center mb-4">Agregar Artículo</h2>
        <asp:Panel runat="server">
            <div class="row g-3">
                <!-- Primera columna -->
                <div class="col-md-4">
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre *</label>
                        <uc1:wucTextoRequerido 
                            ID="txtNombre" 
                            runat="server" 
                            CssClass="form-control" 
                            Placeholder="Agregar el nombre" 
                            Text='<%# Bind("NombreArticulo") %>' />
                    </div>
                    <div class="mb-3">
                        <label for="txtDescripcion" class="form-label">Descripción *</label>
                        <uc1:wucTextoRequerido 
                            ID="txtDescripcion" 
                            runat="server" 
                            CssClass="form-control" 
                            Placeholder="Agregar una descripción del producto" 
                            Text='<%# Bind("DescripcionArticulo") %>' 
                            TextMode="MultiLine" 
                            Rows="4" />
                    </div>
                    <div class="mb-3">
                        <label for="ddlGenero" class="form-label">Género *</label>
                        <asp:DropDownList
                            ID="ddlGenero" 
                            runat="server" 
                            CssClass="form-select">
                            <asp:ListItem Text="Género" Value="" Disabled="True" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Hombre" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Mujer" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="ddlCategoria" class="form-label">Categoría *</label>
                        <asp:DropDownList
                            ID="ddlCategoria" 
                            runat="server" 
                            CssClass="form-select" 
                            AutoPostBack="True" 
                            OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                            <asp:ListItem Text="Categoría" Value="" Disabled="True" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="ddlSubcategoria" class="form-label">Subcategoría *</label>
                        <asp:DropDownList
                            ID="ddlSubcategoria" 
                            runat="server" 
                            CssClass="form-select">
                            <asp:ListItem Text="Subcategoría" Value="" Disabled="True" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Segunda columna -->
                <div class="col-md-4">
                    <div class="mb-3">
                        <label for="fuImagenPrincipal" class="form-label">Imagen Principal *</label>
                        <asp:FileUpload
                            ID="fuImagenPrincipal" 
                            runat="server" 
                            CssClass="form-control" />
                        <div class="image-placeholder">
                            <i class="bi bi-camera"></i>
                        </div>
                        <asp:Image
                            ID="imgPreviewPrincipal" 
                            runat="server" 
                            CssClass="img-fluid mt-2" 
                            ImageUrl='<%# Bind("ImagenPrincipalPath") %>' 
                            alt="Imagen Principal" />
                    </div>
                    <div class="mb-3">
                        <label for="txtCodigoArticulo" class="form-label">Código del Artículo *</label>
                        <uc1:wucTextoRequerido 
                            ID="txtCodigoArticulo" 
                            runat="server" 
                            CssClass="form-control" 
                            Placeholder="Código" 
                            Text='<%# Bind("CodigoArticulo") %>' />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Stock por Talla *</label>
                        <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:BoundField DataField="Key" HeaderText="Talla" />
                                <asp:BoundField DataField="Value" HeaderText="Cantidad" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div class="mb-3">
                        <label class="form-label">Agregar Tallas *</label>
                        <asp:Repeater
                            ID="rptTallas" runat="server">
                            <ItemTemplate>
                                <div class="row g-2 mb-2">
                                    <div class="col">
                                        <asp:TextBox ID="txtTalla" runat="server" CssClass="form-control" Placeholder="Talla"></asp:TextBox>
                                    </div>
                                    <div class="col">
                                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" Placeholder="Cantidad"></asp:TextBox>
                                    </div>
                                    <div class="col-auto">
                                        <asp:Button ID="btnEliminarTalla" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminarTalla_Click" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Button ID="btnAgregarTalla" runat="server" Text="Agregar Talla" CssClass="btn btn-primary mt-2" OnClick="btnAgregarTalla_Click" />
                    </div>
                </div>
                    <div class="mb-3">
                        <label for="txtPrecio" class="form-label">Precio *</label>
                        <uc1:wucTextoRequerido 
                            ID="txtPrecio" 
                            runat="server" 
                            CssClass="form-control" 
                            Placeholder="$ Ingrese el precio" 
                            Text='<%# Bind("PrecioVenta") %>' />
                    </div>
                    <div class="mb-3">
                        <asp:Button
                            ID="btnAgregar" 
                            runat="server" 
                            Text="Agregar" 
                            CssClass="btn btn-warning text-white w-100" 
                            OnClick="btnAgregar_Click" />
                    </div>
                </div>

                <!-- Tercer columna -->
                <div class="col-md-4">
                    <div class="mb-3">
                        <label for="RepeaterImagenesSecundarias" class="form-label">Imágenes Secundarias *</label>
                        <asp:Repeater ID="RepeaterImagenesSecundarias" runat="server">
                            <ItemTemplate>
                                <div class="d-flex mb-2">
                                    <img src='<%# Eval("ImagePath") %>' alt="Imagen Secundaria" class="img-thumbnail me-2" style="width: 100px;" />
                                    <asp:Button 
                                        ID="btnEliminarImagen" 
                                        runat="server" 
                                        Text="Eliminar" 
                                        CssClass="btn btn-danger btn-sm" 
                                        CommandArgument='<%# Eval("ImagePath") %>' 
                                        OnClick="btnEliminarImagen_Click" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:FileUpload 
                            ID="fuImagenSecundaria" 
                            runat="server" 
                            CssClass="form-control mt-2" />
                        <asp:Button 
                            ID="btnAgregarImagen" 
                            runat="server" 
                            Text="Agregar Imagen" 
                            CssClass="btn btn-primary mt-2" 
                            OnClick="btnAgregarImagen_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>