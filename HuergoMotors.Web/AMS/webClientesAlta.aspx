<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webClientesAlta.aspx.cs" Inherits="HuergoMotors.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Direccion"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Telefono"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="btAceptar" runat="server" OnClick="Button1_Click" Text="Guardar Cambios" />
        <asp:Button ID="btCancelar" runat="server" OnClick="Button1_Click" Text="Cancelar" />
    </form>
    <form>
        <div>
            <asp:Label ID="lbMsg" runat="server" Text="lbMsg"></asp:Label>
        </div>
    </form>
</body>
</html>
