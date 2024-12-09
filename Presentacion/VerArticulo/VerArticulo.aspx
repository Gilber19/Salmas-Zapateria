<%@ Page Title="Ver Artículo" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="VerArticulo.aspx.cs" Inherits="Presentacion.VerArticulo.VerArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <div style="display: flex; flex-wrap: wrap; align-items: flex-start; gap: 20px; margin: 20px; font-family: Arial, sans-serif;">
        <!-- Image Section -->
        <div style="flex: 1; max-width: 300px;">
            <img id="mainImage" src="default-image.jpg" alt="Imagen Principal" style="width: 100%; border: 1px solid #ddd; border-radius: 5px; padding: 5px;" />
            <div style="margin-top: 10px; display: flex; gap: 10px; justify-content: center;">
                <asp:Repeater ID="rptImagenes" runat="server">
                    <ItemTemplate>
                        <img src='<%# Eval("Imagen") %>' alt="Imagen" style="width: 60px; height: 60px; object-fit: cover; cursor: pointer; border: 1px solid #ddd; border-radius: 5px;" onclick="document.getElementById('mainImage').src=this.src;" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <!-- Details Section -->
        <div style="flex: 2; max-width: 600px;">
            <h2 style="margin: 0 0 10px; font-size: 24px;">
                <asp:Label ID="lblNombreArticulo" runat="server" Text="Nombre del producto"></asp:Label>
            </h2>
            <p style="margin: 5px 0; font-size: 18px; color: #333;">
                <strong>Precio:</strong> <asp:Label ID="lblPrecioVenta" runat="server"></asp:Label>
            </p>
            <p style="margin: 5px 0; font-size: 16px; color: #666;">
                <asp:Label ID="lblDescripcionArticulo" runat="server"></asp:Label>
            </p>
            <p style="margin: 5px 0; font-size: 16px; color: #666;">
                <strong>Estado:</strong> <asp:Label ID="lblEstado" runat="server"></asp:Label>
            </p>
            
            <!-- Size Dropdown -->
            <div style="margin: 15px 0;">
                <label for="ddlTalla" style="font-size: 16px; margin-right: 10px;">Selecciona la talla:</label>
                <asp:DropDownList ID="ddlTalla" runat="server" style="padding: 5px; border-radius: 5px; border: 1px solid #ccc;">
                    <asp:ListItem Text="Seleccione una talla" Value="" />
                </asp:DropDownList>
            </div>

            <!-- Quantity Dropdown -->
            <div style="margin: 15px 0;">
                <label for="ddlCantidad" style="font-size: 16px; margin-right: 10px;">Selecciona la cantidad:</label>
                <asp:DropDownList ID="ddlCantidad" runat="server" style="padding: 5px; border-radius: 5px; border: 1px solid #ccc;">
                    <asp:ListItem Text="1" Value="1" />
                    <asp:ListItem Text="2" Value="2" />
                    <asp:ListItem Text="3" Value="3" />
                </asp:DropDownList>
            </div>

            <!-- Add Button -->
            <div style="margin-top: 20px;">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" 
                    style="background-color: #006400; color: white; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer;" />
            </div>
        </div>
    </div>
</asp:Content>
