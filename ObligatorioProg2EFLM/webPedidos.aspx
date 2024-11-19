<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="webPedidos.aspx.cs" Inherits="ObligatorioProg2EFLM.webPedidos" %>
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
            Pedidos
        </h1>
    </header>
    <asp:DropDownList runat="server" ID="ClienteAsociado"></asp:DropDownList>
    <dropdownlist runat="server" ID="TecnicoAsociado"></dropdownlist>
    <textarea runat="server" ID="DescripcionProblema"></textarea>

    	Número de orden (generado automáticamente, único)
	Cliente asociado (seleccionar de la lista de clientes)
	Técnico asignado (seleccionar de la lista de técnicos)
	Descripción del problema (obligatorio)
	Fecha de creación (automática)
	Estado (Pendiente, En Progreso, Completada)
	Lista de comentarios del técnico (pueden ser múltiples comentarios agregados en diferentes momentos)

</asp:Content>
