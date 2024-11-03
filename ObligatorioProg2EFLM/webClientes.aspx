<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webClientes.aspx.cs" Inherits="ObligatorioProg2EFLM.webClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="Nombre: " runat="server"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del cliente"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" Font-Size="Small" Visible = "false" ForeColor="Red" ControlToValidate="txtNombre" />

    <br />
    <br />
    <asp:Label Text="Apellido: " runat="server"></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido del cliente"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" Font-Size="Small" Visible = "false" ForeColor="Red" ControlToValidate="txtApellido" />

    <br />
    <br />
    <asp:Label Text="Cedula: " runat="server"></asp:Label>
    <asp:TextBox ID="txtCedula" runat="server" placeholder="Cedula del cliente"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvCedula" runat="server" Font-Size="Small" Visible = "false" ForeColor="Red" ControlToValidate="txtCedula" />

    <br />
    <br />    
    <asp:Label Text="Direccion: " runat="server"></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion del cliente"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" Font-Size="Small" Visible = "false" ForeColor="Red" ControlToValidate="txtDireccion" />

    <br />
    <br />
    <asp:Label Text="Telefono: " runat="server"></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server" type="number" placeholder="Telefono del cliente"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" Font-Size="Small" Visible = "false" ForeColor="Red" ControlToValidate="txtTelefono" />

    <br />
    <br />
    <asp:Label Text="Email: " runat="server"></asp:Label>
    <asp:TextBox ID="txtEmail" type="email" runat="server" placeholder="Email del cliente"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" Font-Size="Small" Visible = "false" ForeColor="Red" ControlToValidate="txtEmail" />
    <br />
    <br />
    <asp:Button ID="btnCliente" runat="server" Text="agregar cliente" OnClick="agregarCliente_click"></asp:Button>
    <br />
    <br />
    <asp:GridView ID="gvClientes" runat="server" Width="70%" BorderWidth="1" BorderColor="Red"></asp:GridView>
</asp:Content>
