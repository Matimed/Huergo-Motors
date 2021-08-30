<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVehiculosAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVehiculosAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
     <div>
            <asp:Label ID="lbTipo" runat="server" Text="Tipo"></asp:Label>
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lbModelo" runat="server" Text="Modelo"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lbPrecio" runat="server" Text="Precio de Venta"></asp:Label>
            <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="Label4" runat="server" Text="Stock Disponible"></asp:Label>
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
            <br />

            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar cambios" />
            <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
            <br />
            <asp:Label ID="lbMsg" runat="server" Text="lbMsg"></asp:Label>
         </div>
            
</asp:Content>
