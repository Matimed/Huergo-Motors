<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVentasAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVentasAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <div>
        <uc:CampoTexto ID="ctFecha"  runat="server" Text="Fecha" Propiedad="Fecha" Nullable="True"/>
        <uc:CampoDropDown ID= "cddVendedor" runat="server" Text="Vendedor" Propiedad="IdVendedor" DisplayMember="NombreCompleto" />
        <uc:CampoDropDown ID= "cddVehiculo" runat="server" Text="Modelo de vehiculo" Propiedad="IdVehiculo" DisplayMember="Modelo" AutoPostBack="True" OnSelectedIndexChanged ="cddVehiculoIndexChanged" />
        <uc:CampoTexto ID="ctTipo"  runat="server" Text="Tipo" Propiedad="Tipo" ReadOnly="True" />
        <uc:CampoTexto ID="ctPrecio"  runat="server" Text="Precio" Propiedad="PrecioVenta" ReadOnly="True" />
        <hr />


        <asp:Label ID="lbCliente" runat="server" Text="Cliente:"></asp:Label>
        <br />

        <asp:TextBox ID="txtCliente" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltrarCliente" runat="server" Text="Buscar" ViewStateMode="Disabled" OnClick="btnBuscarCliente_Click" />
        <br />

        <uc:CampoDropDown ID= "cddCliente" runat="server" Propiedad="IdCliente" DisplayMember="Nombre" AutoPostBack="True"  OnSelectedIndexChanged = "cddClienteIndexChanged"/>
        <uc:CampoTexto ID="ctDireccion"  runat="server" Text="Direcion" Propiedad="Direccion" ReadOnly="True" />
        <uc:CampoTexto ID="ctTelefono"  runat="server" Text="Telefono" Propiedad="Telefono" ReadOnly="True" />
        <uc:CampoTexto ID="CtEmail"  runat="server" Text="Email" Propiedad="Email" ReadOnly="True" />
        <hr />
        

        <asp:Label ID="lbAccesorios" runat="server" Text="Accesorios:"></asp:Label>
        <br />

        <asp:DropDownList ID="ddlAccesorio" runat="server" Height="17px" Width="122px" AutoPostBack="True"></asp:DropDownList>
        <asp:Button ID="btnAgregarAccesorio" runat="server" OnClick="btnAgregarAccesorio_Click" Text="Agregar" />
        <br />

        <asp:GridView ID="gvAccesorios" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" Width="497px">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
            </Columns>
        </asp:GridView>
        <hr />


        <uc:CampoTexto ID="ctObservaciones"  runat="server" Text="Observaciones" Propiedad="Observaciones" Nullable="True" />

        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar cambios" />
        <asp:Button ID="btnVolver" runat="server" OnClick="btnVolver_Click" Text="Volver" />
        <br />

        <asp:Label ID="lbMsg" runat="server" Text="lbMsg"></asp:Label>
    </div>
</asp:Content>