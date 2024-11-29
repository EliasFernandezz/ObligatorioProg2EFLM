<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webInicio.aspx.cs" Inherits="ObligatorioProg2EFLM.webInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1 {
            font-size: x-large;
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom: 25px;
        }
    </style>

    <header>
        <h1>Inicio
        </h1>
    </header>
    <asp:GridView ID="gvOrdenes" runat="server" AutoGenerateColumns="false" Width="95%" BorderWidth="2" BorderColor="Blue">
        <Columns>

            <asp:BoundField DataField="NumOrden" HeaderText="Numero de orden" />

            <asp:BoundField DataField="Estado" HeaderText="Estado" />


        </Columns>
    </asp:GridView>

</asp:Content>
