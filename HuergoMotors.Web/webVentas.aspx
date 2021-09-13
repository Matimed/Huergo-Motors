<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVentas.aspx.cs" Inherits="HuergoMotors.Web.webVentas" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">

    <uc:Buscador ID="ucBuscador" runat="server" OnBuscarClick="btnBuscar_Click" OnRecargarClick="btnRecargar_Click" OnNuevoClick="btnNuevo_Click" />
    <div class="row justify-content-center p-3 text-center">
        <div class="table-responsive">
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" class="table table-hover table-striped" HeaderStyle-CssClass="thead-dark" GridLines="None" DataKeyNames="Id" OnSelectedIndexChanged="gv_SelectedIndexChanged">

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
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="row justify-content-center p-3 text-center">
        <div class="table-responsive">
            <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" class="table table-hover table-striped" HeaderStyle-CssClass="thead-dark" GridLines="None" DataKeyNames="Id">

                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                    <asp:BoundField DataField="idAccesorio" HeaderText="idAccesorio" Visible="False" />
                    <asp:BoundField DataField="idVenta" HeaderText="idVenta" Visible="False" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                </Columns>

            </asp:GridView>
        </div>
    </div>

    <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>


</asp:Content>
