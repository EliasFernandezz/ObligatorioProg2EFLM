<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webTecnicos.aspx.cs" Inherits="ObligatorioProg2EFLM.webTecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1 {
            font-size: x-large;
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom: 25px;
        }
    </style>

    <header>
        <h1>Tecnicos
        </h1>
    </header>

    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre del tecnico"></asp:TextBox>
    <asp:Label ID="lblNombre" runat="server" Text="* Este campo es obligatorio" Font-Size="Small" ForeColor="Blue"></asp:Label>

    <br />
    <br />
    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido del tecnico"></asp:TextBox>
    <asp:Label ID="lblApellido" runat="server" Text="* Este campo es obligatorio" Font-Size="Small" ForeColor="Blue"></asp:Label>

    <br />
    <br />
    <asp:TextBox ID="txtCedula" runat="server" placeholder="Cedula del tecnico"></asp:TextBox>
    <asp:Label ID="lblCedula" runat="server" Text="* Este campo es obligatorio" Font-Size="Small" ForeColor="Blue"></asp:Label>

    <br />
    <br />
    <asp:TextBox ID="txtDireccion" runat="server" placeholder="Direccion del tecnico"></asp:TextBox>

    <br />
    <br />
    <asp:TextBox ID="txtEspecialidad" runat="server" placeholder="Especialidad del tecnico"></asp:TextBox>

    <br />
    <asp:Label ID="lblError" runat="server" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>
    <asp:Label ID="lblErrorValidacion" runat="server" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>
    <br />

    <asp:Button ID="btnTecnico" runat="server" Text="agregar tecnico" OnClick="agregarTecnico_Click"></asp:Button>
    <br />

    <asp:Label ID="lblEdicion" runat="server" Font-Size="Small" Text="Editando..." Visible="false" ForeColor="green"></asp:Label>

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
