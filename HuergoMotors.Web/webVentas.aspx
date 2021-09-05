<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVentas.aspx.cs" Inherits="HuergoMotors.Web.webVentas" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    
        <uc:Buscador ID="ucBuscador" runat="server" OnBuscarClick ="btnBuscar_Click" OnRecargarClick ="btnRecargar_Click" OnNuevoClick = "btnNuevo_Click"/>
        <div>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Vehiculo" HeaderText="Vehiculo" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="idVehiculo" HeaderText="idVehiculo" Visible="False" />
                    <asp:BoundField DataField="idCliente" HeaderText="idCliente" Visible="False" />
                    <asp:BoundField DataField="idVendedor" HeaderText="idVendedor" Visible="False" />
                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
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

            <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                     <asp:BoundField DataField="idAccesorio" HeaderText="idAccesorio" Visible="False" />
                    <asp:BoundField DataField="idVenta" HeaderText="idVenta" Visible="False" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
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
