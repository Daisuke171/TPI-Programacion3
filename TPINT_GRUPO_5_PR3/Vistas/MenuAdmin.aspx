<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAdmin.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.MenuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menu Admin</title>
    <link runat="server" rel="stylesheet" href="~/Vistas/Estilos/Base.css" />
    <link runat="server" rel="stylesheet" href="~/Vistas/Estilos/NavBar.css" />
    <link runat="server" rel="stylesheet" href="~/Vistas/Estilos/MenuAdmin.css" />

</head>
<body>
    <form id="menuAdmin" runat="server">
        <nav>
            <div class="leftSide">
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/Inicio.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Pacientes" NavigateUrl="~/Vistas/HomePacientes.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Medicos" NavigateUrl="~/Vistas/HomeMedicos.aspx"></asp:HyperLink>
            </div>
            <div class="rightSide">
                <asp:Label ID="lblUsuario" CssClass="lbl_Usuario" runat="server" Text="Username"></asp:Label>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" />
            </div>
        </nav>
        <main>
            <h1>Menu Administrador</h1>

            <div class="gridRowMenu">
                <div class="gridRowElement">
                    <h2>ALTA</h2>
                    <asp:HyperLink ID="hlnkAltaPaciente" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkAltaMedico" runat="server" NavigateUrl="~/Vistas/RegistrarMedico.aspx">Medico</asp:HyperLink>
                </div>

                <div class="gridRowElement">
                    <h2>BAJA</h2>
                    <asp:HyperLink ID="hlnkBajaPaciente" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkBajaMedico" runat="server" NavigateUrl="~/Vistas/RegistrarMedico.aspx">Medico</asp:HyperLink>
                </div>
            </div>

            <div class="gridRowMenu">
                <div class="gridRowElement">
                    <h2>LISTADO</h2>
                    <asp:HyperLink ID="hlnkListadoPaciente0" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkListadoMedico0" runat="server" NavigateUrl="~/Vistas/ListarMedico.aspx">Medico</asp:HyperLink>
                </div>

                <div class="gridRowElement">
                    <h2>MODIFICACION</h2>
                    <asp:HyperLink ID="hlnkModificacionPaciente1" runat="server" NavigateUrl="~/Vistas/AltaPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkModificacionMedico1" runat="server" NavigateUrl="~/Vistas/RegistrarMedico.aspx">Medico</asp:HyperLink>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
