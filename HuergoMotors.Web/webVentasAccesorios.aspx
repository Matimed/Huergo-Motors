<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVentasAccesorios.aspx.cs" Inherits="HuergoMotors.Web.webVentasAccesorios" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    <uc:Buscador ID="ucBuscador" runat="server" OnBuscarClick="btnBuscar_Click" OnRecargarClick="btnRecargar_Click" OnNuevoClick="btnNuevo_Click" />
    <div class="row justify-content-center p-3 text-center">
        <div class="table-responsive">
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" class="table table-hover table-striped" HeaderStyle-CssClass="thead-dark" GridLines="None" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="idAccesorio" HeaderText="idAccesorio" Visible="False" />
                    <asp:BoundField DataField="idVenta" HeaderText="idVenta" Visible="False" />
                    <asp:BoundField DataField="NombreAccesorio" HeaderText="Nombre" />
                    <asp:BoundField DataField="TipoAccesorio" HeaderText="Tipo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                </Columns>
                <EmptyDataTemplate>
                    <div class="text-center">
                        La Venta no contiene accesorios</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
</asp:Content>

