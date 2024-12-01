<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webReporteDeActividad.aspx.cs" Inherits="ObligatorioProg2EFLM.webReporteDeActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1 {
            font-size: x-large;
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom: 25px;
        }
    </style>

    <header>
        <h1>Reporte de actividad
        </h1>
    </header>

    Funcionalidades:
⦁	Resumen por técnico: Mostrar cuántas órdenes ha gestionado cada técnico y cuántas están en cada estado (Pendiente, En Progreso, Completada).
    <asp:GridView ID="gvContabilidadxTecnico" runat="server" AutoGenerateColumns="false" Width="95%" BorderWidth="2" BorderColor="Blue">
        <Columns>

            <asp:BoundField DataField="TecAsociado" HeaderText="Tecnico:" />

            <asp:BoundField DataField="Pendiente" HeaderText="Pendiente:" />

            <asp:BoundField DataField="En Progreso" HeaderText="En Progreso:" />

            <asp:BoundField DataField="Completada" HeaderText="Completadas:" />

        </Columns>
    </asp:GridView>

    <asp:GridView ID="gvOrdenesCompletas" runat="server" AutoGenerateColumns="false" Width="95%" BorderWidth="2" BorderColor="Blue">
        <Columns>

            <asp:BoundField DataField="Estado" HeaderText="Estado:" />

            <asp:BoundField DataField="NumOrden" HeaderText="Numero de Orden:" />

            <asp:BoundField DataField="FechaFinalizada" HeaderText="Culminó en:" />

        </Columns>
    </asp:GridView>


</asp:Content>
