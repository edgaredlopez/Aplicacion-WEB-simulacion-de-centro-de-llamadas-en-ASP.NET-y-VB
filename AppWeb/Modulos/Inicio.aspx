<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Modulos/HeaderMaster.Master" CodeBehind="Inicio.aspx.vb" Inherits="AppWeb.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" style="font-size:40px; font-family:Arial; margin-top: 50px; margin-bottom: 50px; margin-left: 400px;" runat="server" Text="Label">Bienvenido a nuestra pagina WEB de CENTRO DE LLAMADAS, S.A.</asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" style="font-size:20px; font-family:Arial; margin-top: 50px; margin-bottom: 50px; margin-left: 20px;" runat="server" Text="Label">Le aparecera el menu de ABC o Reporte de tickets segun su rol de analista o interlocutor en nuestro sistema.</asp:Label>
    
    <br /><br />
    <asp:Label ID="Label3" style="font-size:20px; font-family:Arial; margin-top: 50px; margin-bottom: 50px; margin-left: 30px;" runat="server" Text="Label">Bienvenido estimado usuario:</asp:Label>
    
    <asp:TextBox ID="pruebasesion" runat="server" Enabled="False"></asp:TextBox>
        <br /><br />
    <asp:Image ID="Image1" runat="server" ImageUrl="../Imagenes/google.jpg" />
</asp:Content>
