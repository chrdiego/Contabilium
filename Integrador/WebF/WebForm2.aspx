<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebF.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Modificar usuario</h3>
    		<div style="text-align: left; font-size: 12px;">
                <table align="center">
                    <tr>
                        <td><asp:Label runat="server" ID="lblNombre" >Nombre: </asp:Label><br /></td>
                        <td><asp:TextBox runat="server" ID="txtBoxAddNombre" ></asp:TextBox><br /></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="lblApellido" >Apellido: </asp:Label><br /></td>
                        <td><asp:TextBox runat="server" ID="txtBoxAddApellido" ></asp:TextBox><br /></td>
                    </tr>
                    <tr>
                        <td><asp:Label runat="server" ID="lblEdad" >Edad: </asp:Label><br /></td>
                        <td><asp:TextBox runat="server" ID="txtBoxAddEdad"></asp:TextBox><br /></td>
                    </tr>
                    <tr>
                        <td><asp:RadioButtonList id="radioTipo" runat="server" TextAlign="Right" >
                <asp:ListItem Text="Usuario" Value="usuario" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Administrador" Value="administrador"></asp:ListItem>
            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td><asp:Button runat="server" ID="modificarBtn" Text="Modificar" Visible="true" OnClick="modificarBtn_Click" />
                        <asp:Button runat="server" ID="cancelarBtn" Text="Cancelar" Visible="true" OnClick="cancelarBtn_Click" /></td>
                    </tr>
                </table>
		</div>
</asp:Content>
