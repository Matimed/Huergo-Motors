<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webAccesorios.aspx.cs" Inherits="HuergoMotors.Web.webAccesorios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="frmAccesorios" runat="server">
        <div>
        <asp:Button ID="btVolver" runat="server" Text="Volver" OnClick="btVolver_Click" />
            <asp:Label ID="Label1" runat="server" Text="Filtro"></asp:Label>
            <asp:TextBox ID="txtFiltro" runat="server" Width="226px"></asp:TextBox>
        <asp:Button ID="btBuscar" runat="server" Text="Buscar" ViewStateMode="Disabled" OnClick="btBuscar_Click" />
        <asp:Button ID="btnRecargar" runat="server" Text="Recargar" ViewStateMode="Disabled" OnClick="btnRecargar_Click" />
        <asp:Button ID="btNuevo" runat="server" Text="Nuevo" ViewStateMode="Disabled" OnClick="btNuevo_Click" />
        </div>
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" OnRowCommand="gv_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                <asp:BoundField DataField="IdVehiculo" HeaderText="IdVehiculo" Visible="False" />
                <asp:ButtonField ButtonType="Button" CommandName="Modificar" Text="Modificar" />
                <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </form>
    <p>
        <asp:Label ID="lbMensaje" runat="server" Text="Label"></asp:Label>
    </p>
</body>
</html>
