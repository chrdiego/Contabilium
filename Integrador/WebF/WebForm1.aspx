<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebF.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Lista de usuarios</h3>
		<div style="font-size: 12px;">
            <p>
			<asp:Button runat="server" ID="agregarBtn" Text="Agregar usuario" onClick="agregarBtn_Click"/><br />
            </p>
            <table align="center">
                <tr>
                    <td><asp:Label runat="server" ID="lblNombre" Visible="false">Nombre: </asp:Label></td>
                    <td><asp:TextBox runat="server" ID="txtBoxAddNombre" Visible="false"></asp:TextBox><br /></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="lblApellido" Visible="false" >Apellido: </asp:Label></td>
                    <td><asp:TextBox runat="server" ID="txtBoxAddApellido" Visible="false" ></asp:TextBox><br /></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="lblEdad" Visible="false">Edad: </asp:Label></td>
                    <td><asp:TextBox runat="server" ID="txtBoxAddEdad" Visible="false"></asp:TextBox><br /></td>
                </tr>
                <tr>
                    <td>
                   <asp:RadioButtonList id="radioTipo" runat="server" Visible ="false" TextAlign="Right" RepeatDirection="Horizontal" >
                       <asp:ListItem Text="Usuario" Value="usuario" Selected="True"></asp:ListItem>
                       <asp:ListItem Text="Administrador" Value="administrador"></asp:ListItem>
                   </asp:RadioButtonList>
                        </td>
                </tr>
                <tr>
                   <td><asp:Button runat="server" ID="agregarABD" Text="Agregar" Visible="false" onClick="agregarABD_Click" />
                   <asp:Button runat="server" ID="cancelarBtn" Text="Cancelar" Visible="false" OnClick="cancelarBtn_Click" /></td>
                </tr>
            </table><br />
		</div>
<asp:Repeater runat="server" ID="usersRepeater">
    <HeaderTemplate>
             <table align="center" border="1">
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
                 <td> <%# (DataBinder.Eval(Container.DataItem, "IDTipoUsuario").ToString() == "1" ? "Usuario" : DataBinder.Eval(Container, "DataItem.IDTipoUsuario").ToString() == "2" ? "Administrador" : DataBinder.Eval(Container, "DataItem.IDTipoUsuario")) %> </td>
                 <td> <asp:Button runat="server" ID="editarBtn" CommandName="editarBtn" text="Editar" CommandArgument='<%# Eval("IDUsuario") %>' /></td>
                 <td> <asp:Button runat="server" ID="eliminarBtn" CommandName="eliminarBtn" text="Eliminar" CommandArgument='<%# Eval("IDUsuario") %>' /> </td>
             </tr>
          </ItemTemplate>
</asp:Repeater>
</asp:Content>
