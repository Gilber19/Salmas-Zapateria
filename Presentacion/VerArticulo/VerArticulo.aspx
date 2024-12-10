<%@ Page Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="VerArticulo.aspx.cs" Inherits="Presentacion.VerArticulo.VerArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <div class="container">
        <div id="alertSuccess" runat="server" visible="true" class="mt-4 mb-4">
            <asp:Label
                ID="lblMensaje"
                runat="server" />
        </div>

        <div class="row">

            <div class="col-md-6 mt-5 d-flex flex-column align-items-center gap-4">

                <img id="mainImage" runat="server" alt="Imagen principal"
                    style="width: 100%; height: 400px; object-fit: contain; border: 1px solid #ddd; border-radius: 20px;" />

                <div class="d-flex gap-2 mt-3">
                    <asp:Repeater ID="rptImagenes" runat="server">
                        <ItemTemplate>
                            <img src='<%# Eval("Imagen") %>' alt="Imagen"
                                style="width: 80px; height: 80px; object-fit: contain; cursor: pointer; border: 1px solid #ddd; border-radius: 10px;"
                                onclick="document.getElementById('<%= mainImage.ClientID %>').src=this.src;" />

                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>


            <div class="col-md-6 mt-5 text-left">
                <h2 class="mb-3" style="font-size: 24px; font-weight: bold;">
                    <asp:Label ID="lblNombreArticulo" runat="server" Text="Nombre del producto"></asp:Label>
                </h2>
                <p class="mb-4" style="font-size: 20px; color: #333; font-weight: bold;">
                    Precio:
                   
                    <asp:Label ID="lblPrecioVenta" runat="server"></asp:Label>
                </p>
                <p class="mb-4" style="font-size: 16px; color: #666;">
                    <asp:Label ID="lblDescripcionArticulo" runat="server"></asp:Label>
                </p>
                <p class="mb-4" style="font-size: 16px; color: #666;">
                    Estado:
                   
                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                </p>

                <!-- Dropdowns -->
                <div class="d-flex justify-content-left gap-3 my-3">
                    <div>
                        <label for="ddlTalla" style="font-size: 16px;">Selecciona la talla:</label>
                        <asp:DropDownList ID="ddlTalla" runat="server" CssClass="form-select mt-1" Style="width: 100%;">
                            <asp:ListItem Text="Seleccione una talla" Value="" />
                        </asp:DropDownList>
                    </div>
                    <div>
                        <label for="ddlCantidad" style="font-size: 16px;">Selecciona la cantidad:</label>
                        <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="form-select mt-1" Style="width: 100%;">
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                            <asp:ListItem Text="3" Value="3" />
                            <asp:ListItem Text="4" Value="4" />
                            <asp:ListItem Text="5" Value="5" />
                            <asp:ListItem Text="6" Value="6" />
                            <asp:ListItem Text="7" Value="7" />
                            <asp:ListItem Text="8" Value="8" />
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Add Button -->
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"
                    CssClass="btn btn-success w-50" Style="padding: 10px 20px;" />
            </div>
        </div>
    </div>
</asp:Content>
