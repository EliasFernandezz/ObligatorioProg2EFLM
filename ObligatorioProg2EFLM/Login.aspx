<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ObligatorioProg2EFLM.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div align="center">
        <div>
            <asp:Label>LOGIN</asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="Cedula" placeholder="Ingrese Cedula"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox runat="server" ID="CedContraseña" placeholder="Ingrese Contraseña"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="Logearme" Text="Logearme" OnClick="Logearme_Click"/>
        </div>
    </div>







</asp:Content>
