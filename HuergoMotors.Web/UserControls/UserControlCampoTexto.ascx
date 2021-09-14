<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlCampoTexto.ascx.cs" Inherits="HuergoMotors.Web.UserControls.UserControlCampoTexto" %>


<div class="form-group">
    <asp:Label for="txtValor" ID="lbCampo" runat="server"></asp:Label>

    <div class="input-group mb-3">
        <div runat="server" id="divPrependDollar" visible="false" class="input-group-prepend">
            <span class="input-group-text">$</span>
        </div>

        <asp:TextBox ID="txtValor" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
</div>
