<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="AppWeb.WebForm1" %>

<!DOCTYPE html>
<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login </title>

    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelUsuario" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="CajaUsuario" runat="server" Height="19px"></asp:TextBox>
             <asp:TextBox ID="CajaPrueba" runat="server" Height="19px"></asp:TextBox>


             <br /> <br />

            <asp:Label ID="LabelContrasena" runat="server" Text="Contraseña:"></asp:Label>
            <input id="CajaPassword" type="password" class="auto-style1" />

             <br />
             <br />
             <asp:HyperLink ID="BotonIniciarSesion" runat="server" CssClass="ClaseBotonIniciarSesion" NavigateUrl="~/Modulos/Inicio.aspx">INICIO</asp:HyperLink>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
