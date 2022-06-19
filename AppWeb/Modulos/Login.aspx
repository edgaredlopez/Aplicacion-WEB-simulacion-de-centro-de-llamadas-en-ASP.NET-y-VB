<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="AppWeb.WebForm1" %>

<!DOCTYPE html>
<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link href="EstilosLogin.css" rel="stylesheet" type="text/css" />
    <title>Login </title>


</head>
<body>
    <form id="form1" runat="server">
        <div ID="ContenedorPadre">

            <asp:Label ID="TituloLogin" Class="TituloLogin" runat="server" Text="Bienvenido a la página, inicie sesión con sus credenciales para ver sus datos:"></asp:Label>
            <div id="ContenedorHijo">
                  <br /> <br />
                <asp:Label ID="LabelUsuario" CssClass="LabelLogin" runat="server" Text="Usuario:"></asp:Label>
                <asp:TextBox ID="CajaUsuario" Class="CajasInput" runat="server" ></asp:TextBox>
           


                <br /> <br />

                <asp:Label ID="LabelContrasena" Class="LabelLogin" runat="server" Text="Contraseña:"></asp:Label>
               
                <asp:TextBox ID="CajaPassword"  Class="CajasInput" runat="server" ></asp:TextBox>

                <br />
                <br />
               
                <asp:Button ID="BotonIniciarSesion" runat="server" Text="Iniciar sesion" />

            </div>
           
        </div>
    </form>
</body>
</html>
