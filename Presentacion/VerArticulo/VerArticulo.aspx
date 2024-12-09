<%@ Page Title="Ver Artículo" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="VerArticulo.aspx.cs" Inherits="Presentacion.VerArticulo.VerArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <h1>Detalle del Artículo</h1>
    <div>
        <strong>ID Artículo:</strong> <asp:Label ID="lblIdArticulo" runat="server"></asp:Label><br />
        <strong>Categoría:</strong> <asp:Label ID="lblCategoria" runat="server"></asp:Label><br />
        <strong>Código Artículo:</strong> <asp:Label ID="lblCodigoArticulo" runat="server"></asp:Label><br />
        <strong>Nombre:</strong> <asp:Label ID="lblNombreArticulo" runat="server"></asp:Label><br />
        <strong>Descripción:</strong> <asp:Label ID="lblDescripcionArticulo" runat="server"></asp:Label><br />
        <strong>Precio de Venta:</strong> <asp:Label ID="lblPrecioVenta" runat="server"></asp:Label><br />
        <strong>Estado:</strong> <asp:Label ID="lblEstado" runat="server"></asp:Label><br />
        <strong>Imágenes:</strong> <asp:Label ID="lblImagenes" runat="server"></asp:Label><br />
        <strong>Talla:</strong> <asp:Label ID="lblTalla" runat="server"></asp:Label><br />
        <strong>Subcategoría:</strong> <asp:Label ID="lblSubCategoria" runat="server"></asp:Label><br />
        <strong>Stock:</strong> <asp:Label ID="lblStock" runat="server"></asp:Label><br />
        <strong>Género:</strong> <asp:Label ID="lblGenero" runat="server"></asp:Label><br />
        <strong>Nombre Categoría:</strong> <asp:Label ID="lblNombreCategoria" runat="server"></asp:Label><br />
    </div>
</asp:Content>
