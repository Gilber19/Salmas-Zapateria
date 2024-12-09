<%@ Page Title="Ver Artículo" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="VerArticulo.aspx.cs" Inherits="Presentacion.VerArticulo.VerArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <div style="display: flex; flex-direction: column; align-items: center; gap: 20px; margin: 20px; font-family: Arial, sans-serif;">
        <!-- Image Section -->
        <div style="display: flex; flex-direction: column; align-items: center;">
            <!-- Main Image -->
            <img id="mainImage" runat="server" alt="Imagen principal"
                style="width: 400px; height: 400px; object-fit: cover; border: 1px solid #ddd; border-radius: 5px;" />

            <!-- Thumbnail Images -->
            <div style="display: flex; gap: 10px; margin-top: 10px;">
                <asp:Repeater ID="rptImagenes" runat="server">
                    <ItemTemplate>
                        <img src='<%# Eval("Imagen") %>' alt="Imagen"
                            style="width: 80px; height: 80px; object-fit: cover; cursor: pointer; border: 1px solid #ddd; border-radius: 5px;"
                            onclick="document.getElementById('<%= mainImage.ClientID %>').src=this.src;" />
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

        <!-- Details Section -->
        <div style="width: 80%; max-width: 600px; text-align: center;">
            <h2 style="margin: 0 0 10px; font-size: 24px; font-weight: bold;">
                <asp:Label ID="lblNombreArticulo" runat="server" Text="Nombre del producto"></asp:Label>
            </h2>
            <p style="margin: 5px 0; font-size: 20px; color: #333; font-weight: bold;">
                Precio:
                <asp:Label ID="lblPrecioVenta" runat="server"></asp:Label>
            </p>
            <p style="margin: 5px 0; font-size: 16px; color: #666;">
                <asp:Label ID="lblDescripcionArticulo" runat="server"></asp:Label>
            </p>
            <p style="margin: 5px 0; font-size: 16px; color: #666;">
                Estado:
                <asp:Label ID="lblEstado" runat="server"></asp:Label>
            </p>

            <!-- Dropdowns -->
            <div style="margin: 15px 0; display: flex; justify-content: center; gap: 20px;">
                <div>
                    <label for="ddlTalla" style="font-size: 16px;">Selecciona la talla:</label>
                    <asp:DropDownList ID="ddlTalla" runat="server"
                        Style="display: block; margin-top: 5px; padding: 5px; width: 100%; border-radius: 5px; border: 1px solid #ccc;">
                        <asp:ListItem Text="Seleccione una talla" Value="" />
                    </asp:DropDownList>
                </div>
                <div>
                    <label for="ddlCantidad" style="font-size: 16px;">Selecciona la cantidad:</label>
                    <asp:DropDownList ID="ddlCantidad" runat="server"
                        Style="display: block; margin-top: 5px; padding: 5px; width: 100%; border-radius: 5px; border: 1px solid #ccc;">
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="3" Value="3" />
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Add Button -->
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"
                Style="margin-top: 20px; background-color: #006400; color: white; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer;" />
        </div>
    </div>

</asp:Content>
