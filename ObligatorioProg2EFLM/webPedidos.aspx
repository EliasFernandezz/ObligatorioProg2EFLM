<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webPedidos.aspx.cs" Inherits="ObligatorioProg2EFLM.webPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1 {
            font-size: x-large;
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom: 25px;
        }
    </style>

    <header>
        <h1>Pedidos
        </h1>
    </header>

    <asp:DropDownList runat="server" ID="cboClienteAsociado">
        <asp:ListItem runat="server" ID="ClienteNoSeleccionado" Text="Seleccione un cliente" Value="" Selected="true" />
    </asp:DropDownList>

    <br />
    <br />

    <asp:DropDownList runat="server" ID="cboTecnicoAsociado">
        <asp:ListItem runat="server" ID="TecnicoNoSeleccionado" Text="Seleccione un tecnico" Value="" Selected="true" />
    </asp:DropDownList>

    <br />
    <br />

    <textarea runat="server" id="txtDescripcionProblema"></textarea>


    <br />
    <br />

    <asp:DropDownList runat="server" ID="cboEstado">
        <asp:ListItem runat="server" ID="EstadoNoSeleccionado" Text="Seleccione un estado"  Value="" Selected="true" />
        <asp:ListItem runat="server" Text="Pendiente" Value="Pendiente" />
        <asp:ListItem runat="server" Text="En progreso" Value="En progreso" />
        <asp:ListItem runat="server" Text="Completada" Value="Completada" />
    </asp:DropDownList>

    <br />
    <asp:Label ID="lblObligatorio" runat="server" Text="* Todos los campos son obligatorios" Font-Size="Small" ForeColor="Blue"></asp:Label>
    <br />

    <asp:Label runat="server" ID="lblErrorIngreso" Text="Alguna de las creedenciales no fue ingresada" Font-Size="Small" Visible="false" ForeColor="red"></asp:Label>

    <br />
    <br />

    <asp:Button runat="server" Text="Agregar orden" OnClick="agregarOrden_Click" />

    <br />
    <br />

    <asp:GridView ID="gvOrdenes" runat="server" AutoGenerateColumns="false" Width="100%" BorderWidth="2" BorderColor="Red" OnRowDataBound="AgregarComentarios">
        <Columns>
            <asp:BoundField DataField="NumOrden" HeaderText="N° de orden" />

            <asp:BoundField DataField="CliAsociado" HeaderText="Cliente asociado" />

            <asp:BoundField DataField="TecAsociado" HeaderText="Tecnico asociado" />

            <asp:BoundField DataField="DescripProblema" HeaderText="Descripcion del problema" />

            <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creacion" />

            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:TemplateField>

                <ItemTemplate>
                    <asp:ListView runat="server" ID="ListaComentarios">
                        <ItemTemplate> 
                            <asp:Label Text="<%#Eval("Coment") %>""></asp:Label>
                        </ItemTemplate>
                    </asp:ListView>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
