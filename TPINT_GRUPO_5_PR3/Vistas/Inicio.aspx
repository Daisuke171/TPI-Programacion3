<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Inicio" %>

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
            <asp:HyperLink class="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/Inicio.aspx"></asp:HyperLink>
            <asp:Label class="lbl_Usuario" runat="server" Text="Username"></asp:Label>
        </nav>
        <main>
            <h1>Clínica Medica</h1>
            <div class="container">
                <section>
                    <h2>TURNOS</h2>

                    <asp:HyperLink ID="hlnkRegistrarTurno" runat="server" NavigateUrl="~/Vistas/RegistrarTurno.aspx">Registrar Turno</asp:HyperLink>

                    <asp:HyperLink ID="hlnkConsultarTurno" runat="server" NavigateUrl="~/Vistas/ConsultarTurno.aspx">Consultar Turno</asp:HyperLink>

                    <h2>PACIENTES</h2>

                    <asp:HyperLink ID="hlnkListarPaciente" runat="server" NavigateUrl="~/Vistas/ListarPaciente.aspx">Listar Pacientes</asp:HyperLink>

                    <h2>ADMINISTRADORES</h2>

                    <asp:HyperLink ID="hlnkMenuAdministrador" runat="server" NavigateUrl="~/Vistas/MenuAdmin.aspx">Menu Administrador</asp:HyperLink>
                </section>
                <aside>
                    <asp:Image ID="img" runat="server" ImageUrl="~/Vistas/Imagenes/doctor-symbol-universal-png-2.png" />
                </aside>
            </div>
        </main>
    </form>
</body>
</html>
