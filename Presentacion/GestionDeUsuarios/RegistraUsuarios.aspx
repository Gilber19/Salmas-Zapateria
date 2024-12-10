<%@ Page Title="" Language="C#" MasterPageFile="~/PaginasMaestras/mpSinLogueo.master" AutoEventWireup="true" CodeBehind="RegistraUsuarios.aspx.cs" Inherits="Presentacion.GestionDeUsuarios.RegistraUsuarios" %>

<%@ Register Src="~/Recursos/Controles/wucAlfabeticoReq.ascx" TagPrefix="uc1" TagName="wucAlfabeticoReq" %>
<%@ Register Src="~/Recursos/Controles/wucTextoRequerido.ascx" TagPrefix="uc1" TagName="wucTextoRequerido" %>
<%@ Register Src="~/Recursos/Controles/wucTelefono.ascx" TagPrefix="uc1" TagName="wucTelefono" %>
<%@ Register Src="~/Recursos/Controles/wucEmailRequerido.ascx" TagPrefix="uc1" TagName="wucEmailRequerido" %>
<%@ Register Src="~/Recursos/Controles/wucPassWordReq.ascx" TagPrefix="uc1" TagName="wucPassWordReq" %>
<%@ Register Src="~/Recursos/Controles/wucMensajeDeError.ascx" TagPrefix="uc1" TagName="wucMensajeDeError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSinLogueo" runat="server">
  <div class="container-fluid mt-5 w-25">
    <div class="card-body">
      <div class="row">
        <div>
          <h5 class="m-0">Nombre</h5> 
          <uc1:wucAlfabeticoReq ID="wucNombre" runat="server" CssClass="form-control" />
        </div>
        <div>
          <h5 class="m-0">Dirección</h5>
          <uc1:wucTextoRequerido ID="wucDireccion" runat="server" CssClass="form-control" />
        </div>
        <div>
          <h5 class="m-0">Teléfono</h5>
            <uc1:wucTelefono ID="wucTelefono" runat="server" CssClass="form-control" />
        </div>
        <div>
          <h5 class="m-0">Correo</h5> 
          <uc1:wucEmailRequerido ID="wucCorreoElectronico" runat="server" CssClass="m-0 p-0" />
        </div>
        <div>
          <h5 class="m-0">Contraseña</h5>
          <uc1:wucPassWordReq ID="wucPassWord" runat="server" CssClass="m-0 p-0" />
          <uc1:wucMensajeDeError ID="lblMensaje" runat="server" />
        </div>
      </div>
    </div>
    <div class="card-footer">
      <asp:LinkButton ID="BtnLogin" runat="server" class="btn text-white bg-nav form-control" OnClick="BtnLogin_Click">Registrar</asp:LinkButton>
    </div>
  </div>
</asp:Content>