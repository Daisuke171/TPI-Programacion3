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

            <asp:Label ID="labelAltaPaciente" runat="server" CssClass="lblTitulo" Text="Alta del Paciente"></asp:Label>

            <section class="formulario">

                <div class="campo">
                    <p>DNI:</p>
                    <asp:TextBox ID="txtBoxDNI" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtBoxDNI" CssClass="validator" Display="Dynamic" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Nombre:</p>
                    <asp:TextBox ID="txtBoxNombre" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtBoxNombre" CssClass="validator" Display="Dynamic" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Apellido:</p>
                    <asp:TextBox ID="txtBoxApellido" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtBoxApellido" CssClass="validator" Display="Dynamic" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Sexo:</p>
                    <asp:DropDownList ID="ddlSexo" runat="server">
                        <asp:ListItem Value="0">-- Seleccione --</asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" CssClass="validator" Display="Dynamic" InitialValue="0" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Nacionalidad:</p>
                    <asp:DropDownList ID="ddlNacionalidad" runat="server"></asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidad" CssClass="validator" Display="Dynamic" InitialValue="0" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Fecha de Nacimiento:</p>
                    <asp:TextBox ID="txtBoxFecha" runat="server" CssClass="txtBox" placeholder="DD-MM-AAAA"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtBoxFecha" CssClass="validator" Display="Dynamic" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Dirección:</p>
                    <asp:TextBox ID="txtBoxDirecc" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtBoxDirecc" CssClass="validator" Display="Dynamic" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Provincia:</p>
                    <asp:DropDownList ID="ddlProvincia" runat="server"></asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" CssClass="validator" Display="Dynamic" InitialValue="0" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Localidad:</p>
                    <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" CssClass="validator" Display="Dynamic" InitialValue="0" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Tipo de Sangre:</p>
                    <asp:DropDownList ID="ddlTipoSangre" runat="server" Width="200px">
                        <asp:ListItem Value="0">-- Seleccione --</asp:ListItem>
                        <asp:ListItem>A+</asp:ListItem>
                        <asp:ListItem>A-</asp:ListItem>
                        <asp:ListItem>B+</asp:ListItem>
                        <asp:ListItem>B-</asp:ListItem>
                        <asp:ListItem>AB+</asp:ListItem>
                        <asp:ListItem>AB-</asp:ListItem>
                        <asp:ListItem>O+</asp:ListItem>
                        <asp:ListItem>O-</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvTipoSangre" runat="server" ControlToValidate="ddlTipoSangre" CssClass="validator" Display="Dynamic" InitialValue="0" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Correo Electrónico:</p>
                    <asp:TextBox ID="txtBoxCorreo" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtBoxCorreo" CssClass="validator" Display="Dynamic" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Teléfono:</p>
                    <asp:TextBox ID="txtBoxTelefono" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtBoxTelefono" CssClass="validator" Display="Dynamic" >* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

            </section>

            <asp:Button ID="btnAltaPaciente" CssClass="btnEnviar" runat="server" Text="Registrarse" OnClick="btnAltaPaciente_Click" />
        <asp:Label ID="lblConfirmarSubirPaciente" runat="server" Font-Size="Large" ForeColor="#00CC00"></asp:Label>
        </main>
    </form>
</body>
</html>
