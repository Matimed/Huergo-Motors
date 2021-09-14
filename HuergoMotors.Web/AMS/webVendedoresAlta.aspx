<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVendedoresAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVendedoresAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctNombre"  runat="server" Text="Nombre" Propiedad="Nombre"/>
        </div>

        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctApellido"  runat="server" Text="Apellido" Propiedad="Apellido"/>
        </div>

        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctSucursal"  runat="server" Text="Sucursal" Propiedad="Sucursal"/>
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

    <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
    
</asp:Content>
