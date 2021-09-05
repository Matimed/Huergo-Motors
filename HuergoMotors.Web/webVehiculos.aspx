<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVehiculos.aspx.cs" Inherits="HuergoMotors.Web.webVehiculos" %>

<%--Hace que se pueda referenciar a la master usando "Master.[..]"--%>
<%@ MasterType VirtualPath = "~/Principal.Master" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
        
        <uc:Buscador ID="ucBuscador" runat="server" OnBuscarClick ="btnBuscar_Click" OnRecargarClick ="btnRecargar_Click" OnNuevoClick = "btnNuevo_Click"/>


        <div>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="Id" OnRowCommand="gv_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="PrecioVenta" HeaderText="$ Venta" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
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

            <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
        </div>
  
</asp:Content>


                


