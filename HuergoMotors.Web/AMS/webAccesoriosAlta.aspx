<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webAccesoriosAlta.aspx.cs" Inherits="HuergoMotors.Web.webAccesoriosAlta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Tipo"></asp:Label>
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
        <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Modelo de Auto"></asp:Label>
            <asp:DropDownList ID="cboVehiculos" runat="server">
            </asp:DropDownList>
        </p>
        <asp:Button ID="btGuardarcambios" runat="server" Text="Guardar cambios" OnClick="btGuardarcambios_Click" />
        <asp:Button ID="btVolver" runat="server" Text="Volver" OnClick="btVolver_Click" />
        </div>
        <asp:Label ID="lbMensaje" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
