<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webClientes.aspx.cs" Inherits="HuergoMotors.Web.webClientes" %>


<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    
        <div>
            <asp:Label ID="lbFiltro" runat="server" Text="Filtro"></asp:Label>
            <asp:TextBox ID="txtFiltro" runat="server" Width="226px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ViewStateMode="Disabled" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnRecargar" runat="server" Text="Recargar" ViewStateMode="Disabled" OnClick="btnRecargar_Click" />
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ViewStateMode="Disabled" OnClick="btnNuevo_Click" />
        </div>
        <div>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" OnRowCommand="gv_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:ButtonField ButtonType="Button" CommandName="Seleccionar" Text="Seleccionar" />
                    <asp:ButtonField ButtonType="Button" CommandName="Modificar" Text="Modificar" />
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

            <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
        </div>
  
</asp:Content>
