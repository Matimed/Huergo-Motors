<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webClientesAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webClientesAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        
        <asp:Label ID="lbDireccion" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lbTelefono" runat="server" Text="Telefono"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
