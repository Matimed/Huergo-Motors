<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlBuscador.ascx.cs" Inherits="HuergoMotors.Web.UserControls.UserControlBuscador" %>


<div>
    <asp:Label ID="lbFiltro" runat="server" Text="Filtro"></asp:Label>
    <asp:TextBox ID="txtFiltro" runat="server" Width="226px"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ViewStateMode="Disabled" OnClick="btnBuscar_Click" />
    <asp:Button ID="btnRecargar" runat="server" Text="Recargar" ViewStateMode="Disabled" OnClick="btnRecargar_Click" />
    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ViewStateMode="Disabled" OnClick="btnNuevo_Click" />
</div>
