<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.MenuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menu Admin</title>
    <link rel="stylesheet" href="Estilos/Base.css" />
    <link rel="stylesheet" href="Estilos/Navbar.css" />
    <link rel="stylesheet" href="Estilos/MenuAdmin.css" />
</head>
<body>
    <form id="form1" runat="server">
         <nav>
             <asp:HyperLink class="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/Inicio.aspx"></asp:HyperLink>
             <asp:Label class="lbl_Usuario" runat="server" Text="Username"></asp:Label>
         </nav>
        <main>
            <h1>Menu Administrador</h1>
            <h2>ALTA</h2>

            <asp:HyperLink ID="hlnkAltaPaciente" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
            <asp:HyperLink ID="hlnkAltaMedico" runat="server" NavigateUrl="~/Vistas/RegistrarMedico.aspx">Medico</asp:HyperLink>

            <h2>BAJA</h2>
            <asp:HyperLink ID="hlnkBajaPaciente" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
            <asp:HyperLink ID="hlnkBajaMedico" runat="server" NavigateUrl="~/Vistas/RegistrarMedico.aspx">Medico</asp:HyperLink>

            <h2>LISTADO</h2>
            <asp:HyperLink ID="hlnkListadoPaciente0" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
            <asp:HyperLink ID="hlnkListadoMedico0" runat="server" NavigateUrl="~/Vistas/ListarMedico.aspx">Medico</asp:HyperLink>

            <h2>MODIFICACION</h2>
            <asp:HyperLink ID="hlnkModificacionPaciente1" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
            <asp:HyperLink ID="hlnkModificacionMedico1" runat="server" NavigateUrl="~/Vistas/RegistrarMedico.aspx">Medico</asp:HyperLink>

        </main>
    </form>
</body>
</html>
