<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="webLogin.aspx.cs" Inherits="ObligatorioProg2EFLM.webLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">

        <div>
            <asp:Label runat="server" Text="LOGIN"></asp:Label>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtCedula" placeholder="Ingrese Cedula"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox runat="server" ID="txtContraseña" placeholder="Ingrese Contraseña"></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btnLogearme" Text="Logearme" OnClick="Logearme_Click" />
        </div>
    </div>
</asp:Content>
