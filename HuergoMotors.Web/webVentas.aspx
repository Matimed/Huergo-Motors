<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVentas.aspx.cs" Inherits="HuergoMotors.Web.webVentas" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">

    <uc:Buscador ID="ucBuscador" runat="server" OnBuscarClick="btnBuscar_Click" OnRecargarClick="btnRecargar_Click" OnNuevoClick="btnNuevo_Click" />
    <div class="row justify-content-center p-3 text-center">
        <div class="table-responsive">
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" class="table table-hover table-striped" HeaderStyle-CssClass="thead-dark" GridLines="None" DataKeyNames="Id" OnRowCommand="gv_RowCommand">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="Vehiculo" HeaderText="Vehiculo" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="idVehiculo" HeaderText="idVehiculo" Visible="False" />
                    <asp:BoundField DataField="idCliente" HeaderText="idCliente" Visible="False" />
                    <asp:BoundField DataField="idVendedor" HeaderText="idVendedor" Visible="False" />
                    <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:ButtonField ButtonType="Button" CommandName="Detalle" Text="Detalles" ControlStyle-CssClass="btn btn-outline-primary btn-block" />

                </Columns>
                <EmptyDataTemplate>
                    <div class="text-center">
                        No se encontraron resultados.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    
    <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>


</asp:Content>
