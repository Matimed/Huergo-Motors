<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webVendedores.aspx.cs" Inherits="HuergoMotors.Web.Vendedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Filtro"></asp:Label>
            <asp:TextBox ID="txFiltro" runat="server" Width="226px"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" Height="28px" Width="28px" />
            <asp:Image ID="Image2" runat="server" Height="28px" Width="28px" />
        </div>
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gv_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" />
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
        <asp:Button ID="btCerrar" runat="server" Text="Cerrar" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
        <asp:Button ID="btModificar" runat="server" Text="Modificar" />
        <asp:Button ID="btNuevo" runat="server" Text="Nuevo" ViewStateMode="Disabled" />
    </form>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
