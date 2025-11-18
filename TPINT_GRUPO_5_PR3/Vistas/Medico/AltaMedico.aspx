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
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/InicioAdmin.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Pacientes" NavigateUrl="~/Vistas/HomePacientes.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Medicos" NavigateUrl="~/Vistas/HomeMedicos.aspx"></asp:HyperLink>
            </div>
            <div class="rightSide">
                <asp:Label ID="lblUsuario" CssClass="lbl_Usuario" runat="server" Text="Username"></asp:Label>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" OnClick="btnLogout_Click" />
            </div>
        </nav>

        <main>
            <asp:Label ID="lblTitulo" runat="server" CssClass="lblTitulo" Text="Alta del Médico"></asp:Label>

            <section class="formulario">
                <div class="campo">
                    <p>DNI:</p>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvDni" runat="server" ErrorMessage="* Requerido" ControlToValidate="txtDni" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDni" runat="server" ErrorMessage="* Solo se acepta 8 numeros" ControlToValidate="txtDni" ValidationExpression="^\d{8}$" EnableClientScript="True" CssClass="validator" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>

                <div class="campo">
                    <p>Nombre:</p>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="* Requerido" ControlToValidate="txtNombre" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Apellido:</p>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="* Requerido" ControlToValidate="txtApellido" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Sexo:</p>
                    <asp:DropDownList ID="ddlSexo" runat="server" ValidationGroup="1">
                        <asp:ListItem Value="0">-- Seleccione --</asp:ListItem>
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Femenino</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" CssClass="validator" Display="Dynamic" InitialValue="0" ValidationGroup="1">* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Nacionalidad:</p>
                    <asp:DropDownList ID="ddlNacionalidad" runat="server"></asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="ddlNacionalidad" CssClass="validator" Display="Dynamic" InitialValue="0" ValidationGroup="1">* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Provincia:</p>
                    <asp:DropDownList ID="ddlProvincia" runat="server" ValidationGroup="1" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" CssClass="validator" Display="Dynamic" InitialValue="0" ValidationGroup="1">* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Localidad:</p>
                    <asp:DropDownList ID="ddlLocalidad" runat="server" ValidationGroup="1"></asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" CssClass="validator" Display="Dynamic" InitialValue="0" ValidationGroup="1">* Campo obligatorio</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Fecha de Nacimiento:</p>
                    <asp:TextBox ID="txtBoxFecha" runat="server" CssClass="txtBox" placeholder="DD-MM-AAAA" ValidationGroup="1" TextMode="Date"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvNacimiento" runat="server" ErrorMessage="* Requerido" CssClass="validator" Display="Dynamic" ControlToValidate="txtBoxFecha" ValidationGroup="1"></asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Dirección:</p>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ErrorMessage="* Requerido" ControlToValidate="txtDireccion" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Correo Electrónico:</p>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="* Requerido" ControlToValidate="txtCorreo" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Teléfono:</p>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="txtBox"></asp:TextBox>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="* Requerido" ControlToValidate="txtTelefono" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Especialidad:</p>
                    <asp:DropDownList ID="ddlEspecialidad" runat="server"></asp:DropDownList>
                </div>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="* Requerido" ControlToValidate="ddlEspecialidad" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RequiredFieldValidator>
                </div>

            </section>

            <asp:Button ID="btnRegistrarMedico" CssClass="btnEnviar" runat="server" Text="Registrar Médico" OnClick="btnRegistrarMedico_Click" />
            <asp:Label ID="lblConfirmarSubirMedico" runat="server" Font-Size="Large" ForeColor="#00CC00"></asp:Label>

        </main>
    </form>
</body>
</html>
