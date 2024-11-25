<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpSinLogueo.master" AutoEventWireup="true" CodeBehind="ValidaUsuarios.aspx.cs" Inherits="Presentacion.GestionDeUsuarios.ValidaUsuarios" %>

<%@ Register Src="~/Recursos/Controles/wucEmailRequerido.ascx" TagPrefix="uc1" TagName="wucEmailRequerido" %>
<%@ Register Src="~/Recursos/Controles/wucPassWordReq.ascx" TagPrefix="uc1" TagName="wucPassWordReq" %>
<%@ Register Src="~/Recursos/Controles/wucMensajeDeError.ascx" TagPrefix="uc1" TagName="wucMensajeDeError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSinLogueo" runat="server">

  <div class="container-fluid w-25 mt-5">
    <div class="card">
      <img src="../Recursos/Imagenes/FondoInicio.png" class="card-img-top" />
    </div>
    <div class="card-body">
      <div class="row mt-3">
        <uc1:wucEmailRequerido runat="server" ID="tbCorreoElectronico" />
        <uc1:wucPassWordReq runat="server" ID="tbPassWord" />
        <uc1:wucMensajeDeError runat="server" ID="lblMensaje" />
      </div>
    </div>
    <div class="card-footer">
            <asp:LinkButton ID="BtnLogin" runat="server" class="btn text-white bg-nav form-control" OnClick="BtnLogin_Click">Ingresar</asp:LinkButton>

    </div>
  </div>
</asp:Content>
