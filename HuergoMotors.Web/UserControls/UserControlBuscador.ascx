<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlBuscador.ascx.cs" Inherits="HuergoMotors.Web.UserControls.UserControlBuscador" %>

    <div class="row py-3 justify-content-around">
        <div class="col-5 col-md-6">
            <asp:TextBox ID="txtFiltro" runat="server" type="search" class="form-control input-lg" placeholder="Filtro"></asp:TextBox>
        </div>
        <div class="col-2 px-1">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  class="btn btn-outline-primary btn-block" ViewStateMode="Disabled" OnClick="btnBuscar_Click" />
        </div>
        <div class="col-3 col-md-2 px-1">
            <asp:Button ID="btnRecargar" runat="server" Text="Recargar" class="btn btn-outline-secondary btn-block" ViewStateMode="Disabled" OnClick="btnRecargar_Click" />
        </div>
        <div class="col-2 px-1">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo"  class="btn btn-outline-success btn-block" ViewStateMode="Disabled" OnClick="btnNuevo_Click" />
        </div>
    </div>


