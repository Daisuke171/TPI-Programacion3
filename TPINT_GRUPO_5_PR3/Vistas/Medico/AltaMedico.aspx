<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaMedico.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Alta Médico</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/AltaPaciente.css" />
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
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" />
            </div>
        </nav>

        <main>

            <asp:Label ID="lblTitulo" runat="server" CssClass="lblTitulo" Text="Alta del Médico"></asp:Label>

            <section class="formulario">

                <div class="campo">
                    <p>DNI:</p>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Nombre:</p>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Apellido:</p>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Sexo:</p>
                    <asp:DropDownList ID="ddlSexo" runat="server"></asp:DropDownList>
                </div>

                <div class="campo">
                    <p>Nacionalidad:</p>
                    <asp:DropDownList ID="ddlNacionalidad" runat="server"></asp:DropDownList>
                </div>

                <div class="campo">
                    <p>Fecha de Nacimiento:</p>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="txtBox" placeholder="DD-MM-AAAA"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Dirección:</p>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Correo Electrónico:</p>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Teléfono:</p>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Especialidad:</p>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                </div>

            </section>

            <asp:Button ID="btnRegistrarMedico" CssClass="btnEnviar" runat="server" Text="Registrar Médico" />

        </main>
    </form>
</body>
</html>
