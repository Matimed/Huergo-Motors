﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webAccesoriosAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webAccesoriosAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
        <div class="row">
            <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctNombre"  runat="server" Text="Nombre" Propiedad="Nombre"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctTipo"  runat="server" Text="Tipo" Propiedad="Tipo"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctPrecio"  runat="server" Text="Precio" Propiedad="Precio"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-lg-4">
            <uc:CampoDropDown ID= "cddModelo" runat="server" Text="Modelo de Auto" Propiedad="IdVehiculo" DisplayMember="Modelo" />
            </div>
        </div>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
