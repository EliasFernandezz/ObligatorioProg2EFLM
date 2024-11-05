<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webClientes.aspx.cs" Inherits="ObligatorioProg2EFLM.webClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="Nombre: " runat="server"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del cliente"></asp:TextBox>

    <br />
    <br />
    <asp:Label Text="Apellido: " runat="server"></asp:Label>
    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido del cliente"></asp:TextBox>

    <br />
    <br />
    <asp:Label Text="Cedula: " runat="server"></asp:Label>
    <asp:TextBox ID="txtCedula" runat="server" placeholder="Cedula del cliente"></asp:TextBox>

    <br />
    <br />
    <asp:Label Text="Direccion: " runat="server"></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion del cliente"></asp:TextBox>

    <br />
    <br />
    <asp:Label Text="Telefono: " runat="server"></asp:Label>
    <asp:TextBox ID="txtTelefono" runat="server" type="number" placeholder="Telefono del cliente"></asp:TextBox>

    <br />
    <br />
    <asp:Label Text="Email: " runat="server"></asp:Label>
    <asp:TextBox ID="txtEmail" type="email" runat="server" placeholder="Email del cliente"></asp:TextBox>

    <br />
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>
    <br />

    <asp:Button ID="btnCliente" runat="server" Text="agregar cliente" OnClick="agregarCliente_click"></asp:Button>
    <br />
    <br />
    <asp:GridView ID="gvClientes" runat="server" Width="95%" BorderWidth="2" BorderColor="Red">
        <Columns>
            <asp:BoundField DataField ="Nombre" HeaderText ="Nombre"/>

            <asp:BoundField DataField ="Apellido" HeaderText ="Apellido"/>

            <asp:BoundField DataField ="Cedula" HeaderText ="Cedula"/>

            <asp:BoundField DataField ="Direccion" HeaderText ="Direccion"/>

            <asp:BoundField DataField ="Telefono" HeaderText ="Telefono"/>

            <asp:BoundField DataField ="Email" HeaderText ="Email"/>
        </Columns>
    </asp:GridView>
</asp:Content>
