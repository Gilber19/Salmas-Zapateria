<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="ModificarArticulo.aspx.cs" Inherits="Presentacion.ModificarArticulo.ModificarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <div class="container mt-4">
        <div class="row">
            <!-- Sección de imagen principal -->
            <div class="col-md-6">
                <div class="position-relative">
                    <img id="imgPrincipal" runat="server" src="" alt="Producto" class="img-fluid rounded" />
                    <button type="button" class="btn btn-secondary position-absolute top-0 end-0 edit-button" onclick="toggleEditMode('Image')">
                        <i class="bi bi-pencil"></i>
                    </button>
                </div>
            </div>

            <!-- Galería -->
            <div class="col-md-6">
                <div class="d-flex gap-2">
                    <asp:Repeater ID="RepeaterGallery" runat="server">
                        <ItemTemplate>
                            <img src='<%# Eval("ImagePath") %>' alt="Vista" class="img-thumbnail" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <button type="button" class="btn btn-secondary edit-button" onclick="toggleEditMode('Gallery')">
                        <i class="bi bi-pencil"></i>
                    </button>
                </div>
            </div>
        </div>

        <!-- Información del producto -->
        <div class="mt-4">
            <h3>
                <asp:Label ID="lblNombreProducto" runat="server" Text=""></asp:Label>
                <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control d-none"></asp:TextBox>
                <button type="button" class="btn btn-secondary btn-sm" onclick="toggleEditMode('Name')">
                    <i class="bi bi-pencil"></i>
                </button>
            </h3>
            <p>
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción del producto"></asp:Label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control d-none"></asp:TextBox>
                <button type="button" class="btn btn-secondary btn-sm" onclick="toggleEditMode('Description')">
                    <i class="bi bi-pencil"></i>
                </button>
            </p>
            <div class="mt-3">
                <label for="ddlTalla" class="form-label">Selecciona la talla *</label>
                <asp:DropDownList ID="ddlTalla" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Selecciona" Value="" />
                </asp:DropDownList>
            </div>
            <div class="mt-3">
                <label for="txtStock" class="form-label">Stock *</label>
                <asp:TextBox ID="txtStock" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <!-- Botones de confirmación -->
        <div class="mt-4">
            <button type="submit" class="btn btn-success">
                <i class="bi bi-check"></i> Confirmar Cambios
            </button>
        </div>
    </div>
</asp:Content>