<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedico.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ListarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listar Medico</title>
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/ListarMedico.css" />
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
            <asp:Label ID="lblTitulo" runat="server" Text="Listado de medicos"></asp:Label>

            <section class="separador">
                <p>Buscar Medico:</p>
                <asp:TextBox ID="txtboxNombreMedico" runat="server" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTxtboxNombrePaciente" runat="server" ErrorMessage="* Ingrese el nombre de un paciente" ControlToValidate="txtboxNombrePaciente" Visible="False"></asp:RequiredFieldValidator>
            </section>

            <section class="separador">
                <p>Filtrar por:</p>
                <asp:DropDownList ID="ddlFiltros" runat="server">
                    <asp:ListItem>Seleccione un filtro</asp:ListItem>
                </asp:DropDownList>
            </section>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Paciente" ValidationGroup="1" />

            <section id="tablaMedico">
                <asp:GridView ID="gvMedico" runat="server" EmptyDataText="asd">
                </asp:GridView>
            </section>
        </main>
    </form>
</body>
</html>
