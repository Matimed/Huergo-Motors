<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webAccesoriosAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webAccesoriosAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div>
        <uc:CampoTexto ID="ctNombre"  runat="server" Text="Nombre" Propiedad="Nombre"/>
        <uc:CampoTexto ID="ctTipo"  runat="server" Text="Tipo" Propiedad="Tipo"/>
        <uc:CampoTexto ID="ctPrecio"  runat="server" Text="Precio" Propiedad="Precio"/>

        <asp:Label ID="lbModelo" runat="server" Text="Modelo de Auto"></asp:Label>
        <asp:DropDownList ID="ddlIdVehiculo" runat="server"></asp:DropDownList>
        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
