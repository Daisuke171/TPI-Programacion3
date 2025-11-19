<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio</title>
    <link rel="stylesheet" href="Estilos/Base.css" />
    <link rel="stylesheet" href="Estilos/Navbar.css" />
    <link rel="stylesheet" href="Estilos/Inicio.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <div class="leftSide">
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/Inicio.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Pacientes" NavigateUrl="~/Vistas/HomePacientes.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Medicos" NavigateUrl="~/Vistas/HomeMedicos.aspx"></asp:HyperLink>
            </div>
            <div class="rightSide">
                <asp:Label ID="lblUsuario" CssClass="lbl_Usuario" runat="server" ></asp:Label>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" OnClick="btnLogout_Click" />
                <asp:Button ID="btnLogin" runat="server" Text="iniciar Sesion" CssClass="btn-login" OnClick="btnLogin_Click" />
            </div>
        </nav>
        <main>
            <h1>Bienvenido</h1>
            <div class="container">
                <section>
                    <h2>Menu</h2>
                    <asp:HyperLink ID="hlnkMenuPacientes" runat="server" NavigateUrl="~/Vistas/HomePacientes.aspx" Visible="False">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkMenuMedicos" runat="server" NavigateUrl="~/Vistas/HomeMedicos.aspx" Visible="False">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkMenuAdmin" runat="server" NavigateUrl="~/Vistas/InicioAdmin.aspx" Visible="False">Paciente</asp:HyperLink>
                </section>
                <aside>
                    <asp:Image ID="img" runat="server" ImageUrl="~/Vistas/Imagenes/doctor-symbol-universal-png-2.png" />
                </aside>
            </div>
        </main>
    </form>
</body>
</html>
