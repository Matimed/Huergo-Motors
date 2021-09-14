<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVehiculos.aspx.cs" Inherits="HuergoMotors.Web.webVehiculos" %>

<%--Hace que se pueda referenciar a la master usando "Master.[..]"--%>
<%@ MasterType VirtualPath = "~/Principal.Master" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
        
        <uc:Buscador ID="ucBuscador" runat="server" OnBuscarClick ="btnBuscar_Click" OnRecargarClick ="btnRecargar_Click" OnNuevoClick = "btnNuevo_Click"/>


        <div class="row justify-content-center p-3 text-center ">
            <div class="table-responsive">
                <asp:GridView ID="gv" runat="server" class="table table-hover table-striped" HeaderStyle-CssClass="thead-dark" AutoGenerateColumns="False" GridLines="None" DataKeyNames="Id" OnRowCommand="gv_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="PrecioVenta" HeaderText="$ Venta" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock" />
                        <asp:ButtonField ButtonType="Button" CommandName="Modificar" Text="Modificar" ControlStyle-CssClass="btn btn-outline-primary btn-block" />
                        <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" ControlStyle-CssClass="btn btn-outline-danger btn-block" />
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


                


