<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaPaciente.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Alta Paciente</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/AltaPaciente.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <asp:HyperLink class="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/Inicio.aspx"></asp:HyperLink>
            <asp:Label class="lbl_Usuario" runat="server" Text="Username"></asp:Label>
        </nav>
        <main>

            <asp:Label ID="labelAltaPaciente" runat="server" CssClass="lblTitulo" Text="Alta del Paciente"></asp:Label>

            <section class="formulario">

                <div class="campo">
                    <p>DNI:</p>
                    <asp:TextBox ID="txtBoxDNI" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Nombre:</p>
                    <asp:TextBox ID="txtBoxNombre" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Apellido:</p>
                    <asp:TextBox ID="txtBoxApellido" runat="server" CssClass="txtBox"></asp:TextBox>
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
                    <asp:TextBox ID="txtBoxFecha" runat="server" CssClass="txtBox" placeholder="DD-MM-AAAA"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Dirección:</p>
                    <asp:TextBox ID="txtBoxDirecc" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Localidad:</p>
                    <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
                </div>

                <div class="campo">
                    <p>Provincia:</p>
                    <asp:DropDownList ID="ddlProvincia" runat="server"></asp:DropDownList>
                </div>

                <div class="campo">
                    <p>Tipo de Sangre:</p>
                    <asp:DropDownList ID="ddlTipoSangre1" runat="server" Width="85px"></asp:DropDownList>
                    <asp:DropDownList ID="ddlTipoSangre2" runat="server" Width="75px"></asp:DropDownList>
                </div>

                <div class="campo">
                    <p>Correo Electrónico:</p>
                    <asp:TextBox ID="txtBoxCorreo" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

                <div class="campo">
                    <p>Teléfono:</p>
                    <asp:TextBox ID="txtBoxTelefono" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>

            </section>

            <asp:Button ID="btnAltaPaciente" CssClass="btnEnviar" runat="server" Text="Registrarse" />
        </main>
    </form>
</body>
</html>
