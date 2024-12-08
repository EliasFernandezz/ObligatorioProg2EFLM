<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="webLogin.aspx.cs" Inherits="ObligatorioProg2EFLM.webLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #cedula {
            margin-bottom: 15px
        }

        #contraseña {
            margin-bottom: 15px
        }
    </style>

    <div align="center">

        <div id="cedula">
            <asp:TextBox runat="server" ID="txtCedula" placeholder="Ingrese Cedula"></asp:TextBox>
        </div>

        <div id="contraseña">
            <asp:TextBox runat="server" ID="txtContraseña" placeholder="Ingrese Contraseña"></asp:TextBox>
        </div>

        <asp:Label ID="lblAvisoLogin" runat="server" Text="IMPORTANTE: Tanto la cedula como la contraseña son su misma cedula" ForeColor="Blue"></asp:Label>
        <br />
        <asp:Button runat="server" ID="btnLogearme" Text="Logearme" OnClick="Logearme_Click" />
        <br />
        <br />
        <asp:Label ID="lblErrorIngreso" runat="server" Visible="false" Text="* Alguno de los campos ingresados es invalido" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
