<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.MenuAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menu Admin</title>
    <link rel="stylesheet" href="Estilos/Base.css" />
    <link rel="stylesheet" href="Estilos/NavBar.css" />
    <link rel="stylesheet" href="Estilos/MenuAdmin.css" />
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
                <asp:Label ID="lblUsuario" CssClass="lbl_Usuario" runat="server" Text="Username"></asp:Label>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" OnClick="btnLogout_Click" />
            </div>
        </nav>
        <main>
            <h1>Menu Administrador</h1>

            <div class="gridRowMenu">
                <div class="gridRowElement">
                    <h2>ALTA</h2>
                    <asp:HyperLink ID="hlnkAltaPaciente" runat="server" NavigateUrl="~/Vistas/Paciente/AltaPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkAltaMedico" runat="server" NavigateUrl="~/Vistas/Medico/AltaMedico.aspx">Medico</asp:HyperLink>
                    <asp:HyperLink ID="hlAltaTurno" runat="server" NavigateUrl="~/Vistas/Turno/RegistrarTurno.aspx">Turno</asp:HyperLink>
                </div>

                <div class="gridRowElement">
                    <h2>BAJA</h2>
                    <asp:HyperLink ID="hlnkBajaPaciente" runat="server" NavigateUrl="~/Vistas/Paciente/BajaPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkBajaMedico" runat="server" NavigateUrl="~/Vistas/Medico/BajaMedico.aspx">Medico</asp:HyperLink>
                </div>
            </div>

            <div class="gridRowMenu">
                <div class="gridRowElement">
                    <h2>LISTADO</h2>
                    <asp:HyperLink ID="hlnkListadoPaciente0" runat="server" NavigateUrl="~/Vistas/Paciente/ListarPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkListadoMedico0" runat="server" NavigateUrl="~/Vistas/Medico/ListarMedico.aspx">Medico</asp:HyperLink>
                    <asp:HyperLink ID="hlListadoTurno" runat="server" NavigateUrl="~/Vistas/Turno/ConsultarTurno.aspx">Turno</asp:HyperLink>
                </div>

                <div class="gridRowElement">
                    <h2>MODIFICACION</h2>
                    <asp:HyperLink ID="hlnkModificacionPaciente1" runat="server" NavigateUrl="~/Vistas/Paciente/ModificarPaciente.aspx">Paciente</asp:HyperLink>
                    <asp:HyperLink ID="hlnkModificacionMedico1" runat="server" NavigateUrl="~/Vistas/Medico/ModificarMedico.aspx">Medico</asp:HyperLink>
                </div>
            </div>
            <div class="gridRowMenu">
                <div class="gridRowElement">
                    <h2>INFORMES</h2>
                    <asp:HyperLink ID="hlInformes" runat="server" NavigateUrl="~/Vistas/Informes/Informes.aspx">Informes</asp:HyperLink>
                </div>
   
                <div class="gridRowElement">
                    <h2>REPORTES</h2>
                    <asp:HyperLink ID="hlReportes" runat="server" NavigateUrl="~/Vistas/Reportes/Reportes.aspx">Reportes</asp:HyperLink>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
