<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webAccesoriosAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webAccesoriosAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lbTipo" runat="server" Text="Tipo"></asp:Label>
        <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lbPrecio" runat="server" Text="Precio"></asp:Label>
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lbModelo" runat="server" Text="Modelo de Auto"></asp:Label>
        <asp:DropDownList ID="ddlIdVehiculo" runat="server"></asp:DropDownList>
        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
