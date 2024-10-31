<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webClientes.aspx.cs" Inherits="ObligatorioProg2EFLM.webClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="Nombre: " runat="server"></asp:Label>
<br />
<asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
<br />
<asp:Label Text="Apellido: " runat="server"></asp:Label>
<br />
<asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
<br />
<asp:Label Text="Cedula: " runat="server"></asp:Label>
<br />
<asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
<br />
<asp:Label Text="Direccion: " runat="server"></asp:Label>
<br />
<asp:TextBox ID="txtDireccion" runat="server" />
<br />
<asp:Label Text="Telefono: " runat="server"></asp:Label>
<br />
<asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
<br />
<asp:Label Text="Email: " runat="server"></asp:Label>
<br />
<asp:TextBox ID="txtEmail" type="email" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="btnCliente" runat="server" Text="agregar cliente" OnClick="agregarCliente"></asp:Button>
</asp:Content>
