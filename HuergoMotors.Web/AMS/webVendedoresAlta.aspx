<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVendedoresAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVendedoresAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div>
            <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        
        <asp:Label ID="lbApellido" runat="server" Text="Apellido"></asp:Label>
        <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lbSucursal" runat="server" Text="Sucursal"></asp:Label>
        <asp:TextBox ID="txtSucursal" runat="server"></asp:TextBox>
        <br />
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    <div />
</asp:Content>
