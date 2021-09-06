<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVehiculosAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVehiculosAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
     <div>
            
            <uc:CampoTexto ID="ctTipo"  runat="server" Text="Tipo" Propiedad="Tipo"/>
            <uc:CampoTexto ID="ctModelo"  runat="server" Text="Modelo" Propiedad="Modelo"/>
            <uc:CampoTexto ID="ctPrecio"  runat="server" Text="Precio" Propiedad="PrecioVenta"/>
            <uc:CampoTexto ID="ctStock"  runat="server" Text="Stock" Propiedad="Stock"/>
         
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar cambios" />
            <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
            <br />

            <asp:Label ID="lbMsg" runat="server" Text="lbMsg"></asp:Label>
         </div>
            
</asp:Content>
