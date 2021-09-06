﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVendedoresAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVendedoresAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div>
        <uc:CampoTexto ID="ctNombre"  runat="server" Text="Nombre" Propiedad="Nombre"/>
        <uc:CampoTexto ID="ctApellido"  runat="server" Text="Apellido" Propiedad="Apellido"/>
        <uc:CampoTexto ID="ctSucursal"  runat="server" Text="Sucursal" Propiedad="Sucursal"/>
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    <div />
</asp:Content>
