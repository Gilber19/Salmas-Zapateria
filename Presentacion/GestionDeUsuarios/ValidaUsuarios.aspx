<%@ Page Title="Salma's Zapatería" Language="C#" MasterPageFile="~/PaginasMaestras/mpSinLogueo.master" AutoEventWireup="true" CodeBehind="ValidaUsuarios.aspx.cs" Inherits="Presentacion.GestionDeUsuarios.ValidaUsuarios" %>

<%@ Register Src="~/Recursos/Controles/wucEmailRequerido.ascx" TagPrefix="uc1" TagName="wucEmailRequerido" %>
<%@ Register Src="~/Recursos/Controles/wucPassWordReq.ascx" TagPrefix="uc1" TagName="wucPassWordReq" %>
<%@ Register Src="~/Recursos/Controles/wucMensajeDeError.ascx" TagPrefix="uc1" TagName="wucMensajeDeError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSinLogueo" runat="server">
  <div class="container-fluid mt-5 w-25">
    <div class="card-body">
      <div class="row">
        <div>
            <h5 class="m-0">Correo</h5>
            <uc1:wucEmailRequerido CssClass="m-0 p-0" runat="server" ID="tbCorreoElectronico" />
        </div>
        <div class="mt-4">
            <h5 class="m-0">Contraseña</h5>
            <uc1:wucPassWordReq CssClass="m-0 p-0" runat="server" ID="tbPassWord" />
            <uc1:wucMensajeDeError runat="server" ID="lblMensaje" />
        </div>
      </div>
    </div>
    <div class="card-footer">
        <asp:LinkButton ID="BtnLogin" runat="server" class="btn text-white bg-nav form-control" OnClick="BtnLogin_Click">Ingresar</asp:LinkButton>
    </div>
    <asp:LinkButton ID="BtnRegistrar" runat="server" class="btn text-white bg-nav form-control" PostBackUrl="~/GestionDeUsuarios/RegistraUsuarios.aspx">Registrarse</asp:LinkButton>
  </div>
</asp:Content>
