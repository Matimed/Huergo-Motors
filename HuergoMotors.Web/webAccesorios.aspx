<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webAccesorios.aspx.cs" Inherits="HuergoMotors.Web.webAccesorios" %>


<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
    
    <uc:Buscador ID="ucBuscador" runat="server" OnBuscarClick ="btnBuscar_Click" OnRecargarClick ="btnRecargar_Click" OnNuevoClick = "btnNuevo_Click"/>
        
    <div class="row justify-content-center p-3 text-center">
            <div class="table-responsive">
                <asp:GridView ID="gv" runat="server" class="table table-hover table-striped" HeaderStyle-CssClass="thead-dark" AutoGenerateColumns="False" GridLines="None" DataKeyNames="Id" OnRowCommand="gv_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="IdVehiculo" HeaderText="IdVehiculo" Visible="False" />
                        <asp:ButtonField ButtonType="Button" CommandName="Modificar" Text="Modificar" ControlStyle-CssClass="btn btn-outline-primary btn-block" />
                        <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" ControlStyle-CssClass="btn btn-outline-danger btn-block" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    
        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>

  
</asp:Content>
