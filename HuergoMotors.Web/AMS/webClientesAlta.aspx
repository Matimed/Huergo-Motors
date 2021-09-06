<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webClientesAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webClientesAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div>
        <uc:CampoTexto ID="ctNombre"  runat="server" Text="Nombre" Propiedad="Nombre"/>
        <uc:CampoTexto ID="ctDireccion"  runat="server" Text="Direccion" Propiedad="Direccion"/>
        <uc:CampoTexto ID="ctTelefono"  runat="server" Text="Telefono" Propiedad="Telefono"/>
        <uc:CampoTexto ID="ctEmail"  runat="server" Text="Email" Propiedad="Email"/>

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
