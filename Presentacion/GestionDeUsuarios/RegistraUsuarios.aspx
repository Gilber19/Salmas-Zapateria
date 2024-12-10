<%@ Page Title="Salma's Zapatería" Language="C#" MasterPageFile="~/PaginasMaestras/mpSinLogueo.master" AutoEventWireup="true" CodeBehind="RegistraUsuarios.aspx.cs" Inherits="Presentacion.GestionDeUsuarios.RegistraUsuarios" %>

<%@ Register Src="~/Recursos/Controles/wucAlfabeticoReq.ascx" TagPrefix="uc1" TagName="wucAlfabeticoReq" %>
<%@ Register Src="~/Recursos/Controles/wucTextoRequerido.ascx" TagPrefix="uc1" TagName="wucTextoRequerido" %>
<%@ Register Src="~/Recursos/Controles/wucTelefono.ascx" TagPrefix="uc1" TagName="wucTelefono" %>
<%@ Register Src="~/Recursos/Controles/wucEmailRequerido.ascx" TagPrefix="uc1" TagName="wucEmailRequerido" %>
<%@ Register Src="~/Recursos/Controles/wucPassWordReq.ascx" TagPrefix="uc1" TagName="wucPassWordReq" %>
<%@ Register Src="~/Recursos/Controles/wucMensajeDeError.ascx" TagPrefix="uc1" TagName="wucMensajeDeError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSinLogueo" runat="server">
  <div class="container mt-5">
    <div class="row justify-content-center">
      <div class="col-md-6">
          <div class="card-body">
            <form>
              <div class="form-group mb-3">
                <label for="wucNombre" class="form-label">Nombre</label>
                <uc1:wucAlfabeticoReq ID="wucNombre" runat="server" CssClass="form-control" />
              </div>
              <div class="form-group mb-3">
                <label for="wucDireccion" class="form-label">Dirección</label>
                <uc1:wucTextoRequerido ID="wucDireccion" runat="server" CssClass="form-control" />
              </div>
              <div class="form-group mb-3">
                <label for="wucTelefono" class="form-label">Teléfono</label>
                <uc1:wucTelefono ID="wucTelefono" runat="server" CssClass="form-control" />
              </div>
              <div class="form-group mb-3">
                <label for="wucCorreoElectronico" class="form-label">Correo</label>
                <uc1:wucEmailRequerido ID="wucCorreoElectronico" runat="server" CssClass="form-control" />
              </div>
              <div class="form-group mb-3">
                <label for="wucPassWord" class="form-label">Contraseña</label>
                <uc1:wucPassWordReq ID="wucPassWord" runat="server" CssClass="form-control" />
                <uc1:wucMensajeDeError ID="lblMensaje" runat="server" CssClass="text-danger mt-2" />
              </div>
              <div class="d-grid">
                <asp:LinkButton ID="BtnLogin" runat="server" CssClass="btn btn-primary" OnClick="BtnLogin_Click">Registrar</asp:LinkButton>
              </div>
            </form>
          </div>
      </div>
    </div>
  </div>
</asp:Content>