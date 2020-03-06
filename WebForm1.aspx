<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProyectoForm.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h3>Lista de productos: </h3>
    <div style="font-size: 12px;">
            <p>
               <button id="mostrarBoton" OnClick="Esconder();return false;">Agregar usuario</button>
            </p>
            <table align="center">
                <tr>
                    <td><asp:Label runat="server" ID="lblCodigo" >Codigo: </asp:Label></td>
                    <td><input type="text" id="txtBoxAddCodigo" visible="false"><br /></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="lblNombre"  >Nombre: </asp:Label></td>
                    <td><input type="text"  ID="txtBoxAddNombre"  ><br /></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="lblDescripcion">Descripcion: </asp:Label></td>
                    <td><input type="text" ID="txtBoxAddDescripcion" ><br /></td>
                </tr>
                <tr>
                    <td>
                      <select id="selection" name="selection">
                      </select>
                   </td>
                </tr>
            </table><br />
            <button id="agBoton" OnClick="AgregarProd();return false;">Agregar con AJAX</button><br />
		</div>
        <div id="datos">
        </div>
</asp:Content>
