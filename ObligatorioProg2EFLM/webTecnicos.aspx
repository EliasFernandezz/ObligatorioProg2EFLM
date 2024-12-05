<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webTecnicos.aspx.cs" Inherits="ObligatorioProg2EFLM.webTecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Maincontent" runat="server">

    <style>
        h1 {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom: 25px;
        }
    </style>

    <header>
        <h1>Tecnicos
        </h1>
    </header>

    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del tecnico"></asp:TextBox>

    <br />
    <br />
    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido del tecnico"></asp:TextBox>

    <br />
    <br />
    <asp:TextBox ID="txtCedula" runat="server" placeholder="Cedula del tecnico"></asp:TextBox>

    <br />
    <br />
    <asp:TextBox ID="txtEspecialidad" runat="server" placeholder="Especialidad del tecnico"></asp:TextBox>

    <br />
    <asp:Label ID="lblObligatorio" runat="server" Text="* Todos los campos son obligatorios" Font-Size="Small" ForeColor="Blue"></asp:Label>
    <br />

    <asp:Label ID="lblErrorIngreso" runat="server" Text="Alguna de las creedenciales no fue ingresada" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>
    <asp:Label ID="lblErrorValidacion" runat="server" Font-Size="Small" Visible="false" ForeColor="Red"></asp:Label>
    <br />

    <asp:Button ID="btnTecnico" runat="server" Text="agregar tecnico" OnClick="agregarTecnico_Click"></asp:Button>
    <br />

    <asp:Label ID="lblEdicion" runat="server" Font-Size="Small" Text="Editando..." Visible="false" ForeColor="green"></asp:Label>
    <asp:Label ID="lblErrorEdicion" runat="server" Font-Size="Small" Text="" Visible="false" ForeColor="red"></asp:Label>

    <br />
    <asp:GridView ID="gvTecnicos" runat="server" AutoGenerateColumns="false" Width="95%" BorderWidth="2" BorderColor="Red"
        OnRowCancelingEdit="cancelarEdicionTecnico" OnRowDeleting="borrarTecnico" OnRowEditing="editarTecnico" OnRowUpdating="actualizarTecnico">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />

            <asp:BoundField DataField="Cedula" HeaderText="Cedula" />

            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />

            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn-danger" ShowDeleteButton="true" DeleteText="Eliminar" />
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn-danger" ShowEditButton="true" EditText="Editar" />
        </Columns>
    </asp:GridView>
</asp:Content>
