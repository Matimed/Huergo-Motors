<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webClientesAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webClientesAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctNombre"  runat="server" Text="Nombre" Propiedad="Nombre"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctDireccion"  runat="server" Text="Direccion" Propiedad="Direccion"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctTelefono"  runat="server" Text="Telefono" Propiedad="Telefono"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctEmail"  runat="server" Text="Email" Propiedad="Email"/>
        </div>
    </div>

    <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
    <br />

    <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    
</asp:Content>
