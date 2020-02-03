<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebF.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Eliminar usuario</h3>
    <p>
        ¿Está seguro que desea eliminar el usuario <asp:Label runat="server" Text="zipzap" id="lbl1"></asp:Label> <asp:Label runat="server" Text="zipzap" id="lbl2"></asp:Label> ID:<asp:Label runat="server" Text="zipzap" id="lbl3"></asp:Label>? <br /><br />
        <asp:Button runat="server" Text="Si" id="yesBtn" OnClick="yesBtn_Click"/> <asp:Button runat="server" Text="No" ID="noBtn" OnClick="noBtn_Click" />
    </p>
</asp:Content>
