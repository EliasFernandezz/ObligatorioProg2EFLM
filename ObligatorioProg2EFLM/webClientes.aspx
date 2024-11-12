<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webClientes.aspx.cs" Inherits="ObligatorioProg2EFLM.webClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1{
            font-size:x-large;
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom:25px;
        }
    </style>

    <header>
        <h1>
            Clientes
        </h1>
    </header>

    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del cliente"></asp:TextBox>
    <asp:Label ID="lblNombre" runat="server" Text="* Este campo es obligatorio" Font-Size="Small" ForeColor="Blue"></asp:Label>

    <br />
    <br />
    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido del cliente"></asp:TextBox>
    <asp:Label ID="lblApellido" runat="server" Text="* Este campo es obligatorio" Font-Size="Small" ForeColor="Blue"></asp:Label>

    <br />
    <br />
    <asp:TextBox ID="txtCedula" runat="server" placeholder="Cedula del cliente"></asp:TextBox>
    <asp:Label ID="lblCedula" runat="server" Text="* Este campo es obligatorio" Font-Size="Small" ForeColor="Blue"></asp:Label>

    <br />
    <br />
    <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion del cliente"></asp:TextBox>

    <br />
    <br />
    <asp:TextBox ID="txtTelefono" runat="server" type="number" placeholder="Telefono del cliente"></asp:TextBox>

    <br />
    <br />
    <asp:TextBox ID="txtEmail" type="email" runat="server" placeholder="Email del cliente"></asp:TextBox>

    <br />
    <asp:Label ID="lblError" runat="server" Text="Alguna de las creedenciales obligatorias no fue ingresada" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>
    <br />

    <asp:Button ID="btnCliente" runat="server" Text="agregar cliente" OnClick="agregarCliente_click"></asp:Button>
    <br />
    <br />
    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" Width="100%" BorderWidth="2" BorderColor="Red">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />

            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />

            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />

            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />

            <asp:BoundField DataField="Email" HeaderText="Email" />
        </Columns>
    </asp:GridView>
</asp:Content>
