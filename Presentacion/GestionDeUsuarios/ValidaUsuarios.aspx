<%@ Page Title="Salma's Zapatería" Language="C#" MasterPageFile="~/PaginasMaestras/mpSinLogueo.master" AutoEventWireup="true" CodeBehind="ValidaUsuarios.aspx.cs" Inherits="Presentacion.GestionDeUsuarios.ValidaUsuarios" %>

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
                            <label for="tbCorreoElectronico" class="form-label">Correo</label>
                            <uc1:wucEmailRequerido ID="tbCorreoElectronico" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group mb-4">
                            <label for="tbPassWord" class="form-label">Contraseña</label>
                            <uc1:wucPassWordReq ID="tbPassWord" runat="server" CssClass="form-control" />
                            <uc1:wucMensajeDeError ID="lblMensaje" runat="server" CssClass="text-danger mt-2" />
                        </div>
                        <div class="d-grid mb-2">
                            <asp:LinkButton ID="BtnLogin" runat="server" CssClass="btn btn-primary" OnClick="BtnLogin_Click">Ingresar</asp:LinkButton>
                        </div>
                            <div class="d-grid">
                            <asp:LinkButton ID="BtnRegistrar" runat="server" CssClass="btn bg-nav text-white" PostBackUrl="~/GestionDeUsuarios/RegistraUsuarios.aspx">Registrarse</asp:LinkButton>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>