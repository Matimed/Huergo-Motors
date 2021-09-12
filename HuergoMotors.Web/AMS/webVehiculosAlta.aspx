<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVehiculosAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVehiculosAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctTipo"  runat="server" Text="Tipo" Propiedad="Tipo"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctModelo"  runat="server" Text="Modelo" Propiedad="Modelo"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctPrecio"  runat="server" Text="Precio" Propiedad="PrecioVenta"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctStock"  runat="server" Text="Stock" Propiedad="Stock"/>
        </div>
    </div>
         
    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar cambios" />
    <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
    <br />

    <asp:Label ID="lbMsg" runat="server" Text="lbMsg"></asp:Label>
       
            
</asp:Content>
