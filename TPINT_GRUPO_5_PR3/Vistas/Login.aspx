<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login Sistema Médico</title>
    <link rel="stylesheet" href="Estilos/Login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <main>

            <asp:Label ID="LlbSistema" runat="server" Text="Sistema Medico"></asp:Label>

            <asp:Label ID="LblUsuario" runat="server" Text="Usuario: "></asp:Label>
 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            <asp:Label ID="LblContrasenia" runat="server" Text="Contraseña:"></asp:Label>
 
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            <asp:Button ID="buttonIniciarSesion" runat="server" Text="Iniciar Sesión" />

            <asp:Label ID="LblError" runat="server"></asp:Label>

        </main>
    </form>
</body>
</html>
