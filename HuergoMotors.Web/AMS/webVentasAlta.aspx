<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="webVentasAlta.aspx.cs" Inherits="HuergoMotors.Web.AMS.webVentasAlta" %>

<asp:Content ID="contenido" ContentPlaceHolderID="body" runat="server">
      
    <h2 class="py-2">Generales:</h2>
    <hr />
    <div class="row pt-2 pb-4">
          <div class="col-md-6 col-lg-4">
              <uc:CampoTexto ID="ctFecha" runat="server" Text="Fecha" Tipo="Date" Propiedad="Fecha" Nullable="True" />
          </div>
          <div class="col-md-6 col-lg-4">
              <uc:CampoDropDown ID="cddVendedor" runat="server" Text="Vendedor" Propiedad="IdVendedor" DisplayMember="NombreCompleto" />
          </div>
          <div class="col-md-6 col-lg-4">
              <uc:CampoDropDown ID="cddVehiculo" runat="server" Text="Modelo de vehiculo" Propiedad="IdVehiculo" DisplayMember="Modelo" AutoPostBack="True" OnSelectedIndexChanged="cddVehiculoIndexChanged" />
          </div>
          <div class="col-md-6 col-lg-4">
              <uc:CampoTexto ID="ctTipo" runat="server" Text="Tipo" Propiedad="Tipo" ReadOnly="True" />
          </div>
          <div class="col-md-6 col-lg-4">
              <uc:CampoTexto ID="ctPrecio" runat="server" Text="Precio" Propiedad="PrecioVenta" ReadOnly="True" />
          </div>
    </div>

    <h2 class="pt-4 ">Cliente:</h2>
    <hr />
    <div class="row form-group">
        <div class="col-8 col-md-5 col-lg-4 py-2">
            <asp:TextBox ID="txtCliente" CssClass="form-control input-lg" placeholder="Filtro" runat="server"></asp:TextBox>
        </div>
        <div class="col-4 col-md-2 col-lg-2 py-2">
            <asp:Button ID="btnFiltrarCliente" runat="server" Text="Buscar" CssClass="btn btn-outline-primary btn-block" ViewStateMode="Disabled" OnClick="btnBuscarCliente_Click" />
        </div>
        <div class="col-12 col-md-5 col-lg-6 py-2">
            <uc:CampoDropDown ID= "cddCliente" runat="server" Propiedad="IdCliente" DisplayMember="Nombre" AutoPostBack="True"  OnSelectedIndexChanged = "cddClienteIndexChanged"/>
        </div>
    </div>

    <div class="row pb-4">
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctDireccion" runat="server" Text="Direccion" Propiedad="Direccion" ReadOnly="True" />
        </div>
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="ctTelefono" runat="server" Text="Telefono" Propiedad="Telefono" ReadOnly="True" />
        </div>
        <div class="col-md-6 col-lg-4">
            <uc:CampoTexto ID="CtEmail" runat="server" Text="Email" Propiedad="Email" ReadOnly="True" />
        </div>
    </div>
    
    <h2 class="pt-4 ">Accesorios:</h2>
    <hr />
    <div class="row pt-2 pb-4 justify-content-between">
        <div class="col-8 col-lg-6">
            <asp:DropDownList ID="ddlAccesorio"  CssClass="custom-select" runat="server"></asp:DropDownList>
        </div>
        <div class="col-4 col-lg-3">
            <asp:Button ID="btnAgregarAccesorio" runat="server"  CssClass="btn btn-outline-primary btn-block" OnClick="btnAgregarAccesorio_Click" Text="Agregar" />
        </div>
    </div>

    <div class="row justify-content-center p-3 text-center">
        <div class="table-responsive">
            <asp:GridView ID="gvAccesorios" class="table table-hover table-striped" HeaderStyle-CssClass="thead-light" GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gv_RowCommand" DataKeyNames="Id" >
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:ButtonField ButtonType="Button" CommandName="Remover" Text="Remover" ControlStyle-CssClass="btn btn-outline-danger btn-block" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

        
        <h2 class="pt-4 ">Observaciones:</h2>
    <hr />
    <div class="row pt-2 pb-4">
        <div class="col-12">

        <uc:CampoTexto ID="ctObservaciones"  runat="server" Text="" Propiedad="Observaciones" Nullable="True" />
        </div>
        </div>
        
    <div class="row py-5  justify-content-lg-end justify-content-md-between">
        <div class="col-md-5 col-lg-4 py-2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar cambios" CssClass="btn btn-primary btn-block" OnClick="btnGuardar_Click" />
        </div>
        <div class="col-md-4 col-lg-3 py-2">
             <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary btn-block" OnClick="btnVolver_Click" />
        </div>
    </div>


        <asp:Label ID="lbMsg" runat="server" Text="lbMsg"></asp:Label>
</asp:Content>