<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webClientes.aspx.cs" Inherits="ObligatorioProg2EFLM.webClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        h1{
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
    <asp:Label ID="lblErrorIngreso" runat="server" Text="Alguna de las creedenciales obligatorias no fue ingresada" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>
    <asp:Label ID="lblErrorValidacion" runat="server" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>
    <br />

    <asp:Button ID="btnCliente" runat="server" Text="agregar cliente" OnClick="agregarCliente_click"></asp:Button>
    <br />

    <asp:Label ID="lblEdicion" runat="server" Font-Size="Small" Text="Editando..." Visible="false" ForeColor="green"></asp:Label>
    <asp:Label ID="lblErrorEdicion" runat="server" Font-Size="Small" Visible="false" ForeColor="red"/>

    <br />
    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" Width="100%" BorderWidth="2" BorderColor="Red"
        OnRowDeleting="borrarCliente" OnRowEditing="editarCliente" OnRowCancelingEdit="cancelarEdicionCliente" OnRowUpdating="actualizarCliente">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />

            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />

            <asp:BoundField DataField="Direccion" HeaderText="Direccion" />

            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />

            <asp:BoundField DataField="Email" HeaderText="Email" />

            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn-danger" ShowDeleteButton="true" DeleteText="Eliminar" />
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn-danger" ShowEditButton="true" EditText="Editar"/>
        </Columns>
    </asp:GridView>
</asp:Content>
