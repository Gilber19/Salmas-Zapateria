﻿<%@ Page Title="Gestión de Clientes" Language="C#" MasterPageFile="~/PaginasMaestras/mpConLogueo.master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Presentacion.Clientes.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphConLogueo" runat="server">
    <link href="/Recursos/CSS/Clientes.css" rel="stylesheet" />
    <div class="container mt-4">
        <div class="row align-items-center mb-3">
            <div class="col-md-4">
                <asp:TextBox 
                    ID="TbCriterioBusqueda" 
                    runat="server" 
                    CssClass="form-control search-bar" 
                    placeholder="Buscar cliente..." 
                    AutoPostBack="true" 
                    OnTextChanged="TbCriterioBusqueda_TextChanged">
                </asp:TextBox>
            </div>
            <div class="col-md-4">
                <h4>CLIENTES</h4>
            </div>
        </div>

        <div class="client-list">
            <asp:Repeater ID="RepeaterClientes" runat="server">
                <ItemTemplate>
                    <div class="client-item">
                        <span><%# Eval("Nombre") %></span>
                        <a href='/DetalleClientes/DetalleClientes.aspx?idPersona=<%# Eval("IdPersona") %>' class="btn btn-primary">Ver detalles</a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
