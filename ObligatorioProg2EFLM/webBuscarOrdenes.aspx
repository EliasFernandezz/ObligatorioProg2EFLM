<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTecnicos.Master" AutoEventWireup="true" CodeBehind="webBuscarOrdenes.aspx.cs" Inherits="ObligatorioProg2EFLM.webBuscarOrdenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1 {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom: 25px;
        }
    </style>

    <header>
        <h1>Busqueda de órdenes
        </h1>
    </header>
    <div id="DivBusqueda" runat="server">

        <asp:Label runat="server">Ingrese el numero de orden que desea ver</asp:Label>
        <asp:TextBox type="number" ID="BusquedaNum" runat="server"></asp:TextBox>
        <asp:Button runat="server" Text="Buscar" OnClick="Btn_buscar" />
    </div>

    <asp:GridView ID="gvVerOrdenes" Visible="false" runat="server" AutoGenerateColumns="false" Width="95%" BorderWidth="2" BorderColor="Red">
        <Columns>

            <asp:BoundField DataField="Estado" HeaderText="Estado" />

            <asp:BoundField DataField="CliAsociado" HeaderText="Cliente asociado" />

            <asp:BoundField DataField="TecAsociado" HeaderText="Tecnico asociado" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnTextAreaComentario" runat="server" Text="Agregar comentario" OnCommand="clickTextAreaComentario" CommandArgument="<%#Container.DataItemIndex%>" CausesValidation="false" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div ID="controlesAgregarComentario" runat="server" visible="false">
        <asp:TextBox id ="txtComentarioAgregado" runat="server" TextMode="MultiLine" placeholder="ingrese un comentario"></asp:TextBox>
        <asp:Button ID="btnAgregarComentario" runat="server" Text="Agregar" OnCommand="clickAgregarComentario" CausesValidation="false" />
    </div>
    <!-- necesario hacer los comentarios del tecnico !-->

</asp:Content>
