<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webClientesAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webClientesAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
   
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctNombre"  runat="server" Text="Nombre" Propiedad="Nombre"/>
        </div>
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctDireccion"  runat="server" Text="Direccion" Propiedad="Direccion"/>
        </div>

        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctTelefono"  runat="server" Text="Telefono" Propiedad="Telefono"/>
        </div>
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctEmail"  runat="server" Text="Email" Propiedad="Email"/>
        </div>
    </div>

    <div class="row pt-5 justify-content-lg-end justify-content-md-between">
        <div class="col-md-5 col-lg-4 p-4">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary btn-block" OnClick="btnGuardar_Click" />
        </div>
        <div class="col-md-4 col-lg-3 p-4">
             <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary btn-block" OnClick="btnVolver_Click" />
        </div>
    </div>

    <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    
</asp:Content>
