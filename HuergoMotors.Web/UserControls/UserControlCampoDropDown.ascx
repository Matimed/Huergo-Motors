<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlCampoDropDown.ascx.cs" Inherits="HuergoMotors.Web.UserControls.UserControlCampoDropDown" %>


<div class="form-group py-2">
    <asp:Label ID="lbCampo" runat="server"></asp:Label>
    <asp:DropDownList ID="ddlCampo" runat="server" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="custom-select"></asp:DropDownList>
    <br />
</div>
