<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webVehiculosAlta.aspx.cs" Inherits="HuergoMotors.Web.webVehiculosAlta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 392px">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Tipo"></asp:Label>
            <asp:TextBox ID="txtTipo" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Modelo"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Precio de Venta"></asp:Label>
        <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Stock Disponible"></asp:Label>
            <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btGuardar" runat="server" OnClick="btGuardar_Click" Text="Guardar cambios" />
        <asp:Label ID="lbMsg" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btVolver" runat="server" OnClick="btVolver_Click" Text="Volver" />
    </form>
</body>
</html>
