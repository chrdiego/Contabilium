<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebF.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Lista de usuarios</h3>
<p>
</p>
		<div style="text-align: left; font-size: 12px;">
            <p>
			<asp:Button runat="server" ID="agregarBtn" Text="Agregar usuario" onClick="agregarBtn_Click"/><br />
            </p>
            <p>
            <asp:Label runat="server" ID="lblNombre" Visible="false">Nombre: </asp:Label>
            <asp:TextBox runat="server" ID="txtBoxAddNombre" Visible="false" required="true"></asp:TextBox><br />
            <asp:Label runat="server" ID="lblApellido" Visible="false" >Apellido: </asp:Label>
            <asp:TextBox runat="server" ID="txtBoxAddApellido" Visible="false" required="true"></asp:TextBox><br />
            <asp:Label runat="server" ID="lblEdad" Visible="false">Edad: </asp:Label>
            <asp:TextBox runat="server" ID="txtBoxAddEdad" Visible="false" required="true"></asp:TextBox><br />
            <asp:RadioButtonList id="radioTipo" runat="server" Visible ="false" TextAlign="Right" >
                <asp:ListItem Text="Usuario" Value="usuario" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Administrador" Value="administrador"></asp:ListItem>
            </asp:RadioButtonList><br />
            <asp:Button runat="server" ID="agregarABD" Text="Agregar" Visible="false" onClick="agregarABD_Click" />
            <asp:Button runat="server" ID="cancelarBtn" Text="Cancelar" Visible="false" OnClick="cancelarBtn_Click" />
            </p>
		</div>
<asp:Repeater runat="server" ID="usersRepeater">
    <HeaderTemplate>
             <table border="1">
                <tr>
                   <td><b>Nombre</b></td>
                   <td><b>Apellido</b></td>
                    <td><b>Edad</b></td>
                    <td><b>Tipo de usuario</b></td>
                    <td><b></b></td>
                    <td><b></b></td>
                </tr>
          </HeaderTemplate>
<ItemTemplate>
             <tr>
                <td> <%# DataBinder.Eval(Container.DataItem, "Nombre") %> </td>
                <td> <%# DataBinder.Eval(Container.DataItem, "Apellido") %> </td>
                 <td> <%# DataBinder.Eval(Container.DataItem, "Edad") %> </td>
                 <td> <%# DataBinder.Eval(Container.DataItem, "IDTipoUsuario").ToString() %> </td>
             </tr>
          </ItemTemplate>
</asp:Repeater>
</asp:Content>
