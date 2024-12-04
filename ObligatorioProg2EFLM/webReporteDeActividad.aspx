<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webReporteDeActividad.aspx.cs" Inherits="ObligatorioProg2EFLM.webReporteDeActividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        h1 {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            margin-bottom: 25px;
        }
    </style>

    <header>
        <h1>Reporte de actividad
        </h1>
    </header>

    <asp:GridView ID="gvContabilidadxTecnico" runat="server" AutoGenerateColumns="false" Width="95%" BorderWidth="2" BorderColor="Red">
        <Columns>

            <asp:BoundField DataField="TecAsociado" HeaderText="Tecnico:" />

            <asp:BoundField DataField="OrTotal" HeaderText="Total:"/>

            <asp:BoundField DataField="OrPendiente" HeaderText="Pendiente:" />

            <asp:BoundField DataField="OrEnProgreso" HeaderText="En Progreso:" />

            <asp:BoundField DataField="OrCompletada" HeaderText="Completadas:" />


        </Columns>
    </asp:GridView>

    <asp:GridView ID="gvOrdenesCompletas" runat="server" AutoGenerateColumns="false" Width="95%" BorderWidth="2" BorderColor="Red">
        <Columns>

            <asp:BoundField DataField="Estado" HeaderText="Estado:" />

            <asp:BoundField DataField="NumOrden" HeaderText="Numero de Orden:" />

            <asp:BoundField DataField="FechaFinalizada" HeaderText="Culminó el:" />

        </Columns>
    </asp:GridView>


</asp:Content>
