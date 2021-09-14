<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVehiculosAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVehiculosAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctTipo"  runat="server" Text="Tipo" Propiedad="Tipo"/>
        </div>

        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctModelo"  runat="server" Text="Modelo" Propiedad="Modelo"/>
        </div>

        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctPrecio"  runat="server" Text="Precio" Tipo="price" Propiedad="PrecioVenta"/>
        </div>

        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctStock" Tipo="number" step="1" runat="server" Text="Stock" Propiedad="Stock"/>
        </div>
    </div>
         
    <div class="row pt-5  justify-content-lg-end justify-content-md-between">
        <div class="col-md-5 col-lg-4 py-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary btn-block" OnClick="btnGuardar_Click" />
        </div>
        <div class="col-md-4 col-lg-3 py-2">
             <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary btn-block" OnClick="btnVolver_Click" />
        </div>
    </div>

    <asp:Label ID="lbMsg" runat="server" Text="lbMsg"></asp:Label>
       
            
</asp:Content>
