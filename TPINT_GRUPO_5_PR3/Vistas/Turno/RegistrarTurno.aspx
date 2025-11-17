<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.RegistrarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registrar Turno</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/RegistrarTurno.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <div class="leftSide">
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/InicioAdmin.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Pacientes" NavigateUrl="~/Vistas/HomePacientes.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Medicos" NavigateUrl="~/Vistas/HomeMedicos.aspx"></asp:HyperLink>
            </div>
            <div class="rightSide"> 
                <asp:Label ID="lblUsuario" CssClass="lbl_Usuario" runat="server" Text="Username"></asp:Label>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" />
            </div>
        </nav>
        <main>
            <h1>Registrar Turno</h1>

            <div class="buscarDni">
                <p>DNI:</p>
                <asp:TextBox ID="txt_Dni" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btn_buscarPaciente" runat="server" Text="Buscar paciente" CssClass="btnEnviar" OnClick="btn_buscarPaciente_Click" />

            <h2>Datos del Paciente</h2>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Dni" ErrorMessage="* Ingrese un DNI" Visible="False"></asp:RequiredFieldValidator>

            <div class="container">
                <p>Nombre:</p>
                <asp:Label ID="lbl_Nombre" runat="server"></asp:Label>
            </div>

            <div class="container">
                <p>Apellido:</p>
                <asp:Label ID="lbl_Apellido" runat="server"></asp:Label>
            </div>

            <div class="container">
                <p>Sexo:</p>
                <asp:Label ID="lbl_Sexo" runat="server"></asp:Label>
            </div>

            <div class="container">
                <p>Telefono</p>
                <asp:Label ID="lbl_Telefono" runat="server"></asp:Label>

            </div>
            <div class="container">
                <p>Correo electrónico</p>
                <asp:Label ID="lbl_Correo" runat="server"></asp:Label>
            </div>

            <hr />

            <h2 class="sectionTurno">Datos del Turno</h2>

            <div class="container">
                <p>Especialidad:</p>
                <asp:DropDownList ID="ddl_Especialidades" runat="server">
                </asp:DropDownList>
            </div>

            <div class="container">

                <p>Medico:</p>

                <asp:DropDownList ID="ddl_Medicos" runat="server">
                </asp:DropDownList>
            </div>

            <p>Fecha:</p>
            <div class="calendarioContainer">
            <asp:Calendar ID="cal_Fechas" runat="server"></asp:Calendar>

           
                <asp:RadioButtonList ID="rbtnl_Horarios" runat="server">
                </asp:RadioButtonList>

           
            </div>

            <asp:Button ID="btn_Confirmar" runat="server" Text="Confirmar turno" CssClass="btnEnviar" />


            <asp:Label ID="lbl_Mensaje" runat="server"></asp:Label>

        </main>
    </form>
</body>
</html>
