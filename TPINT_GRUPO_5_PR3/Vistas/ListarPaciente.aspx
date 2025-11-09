<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarPaciente.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ListarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Estilos/ListarPaciente.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <asp:HyperLink ID="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/Inicio.aspx"></asp:HyperLink>
            <asp:Label ID="lbl_Usuario" runat="server" Text="Username"></asp:Label>
        </nav>
        <main>
            <asp:Label ID="lblTitulo" runat="server" Text="Listado de pacientes"></asp:Label>  

            <section class="separador">
                <p>Buscar Paciente:</p>
                <asp:TextBox ID="txtboxNombrePaciente" runat="server" ValidationGroup="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTxtboxNombrePaciente" runat="server" ErrorMessage="* Ingrese el nombre de un paciente" ControlToValidate="txtboxNombrePaciente" Visible="False"></asp:RequiredFieldValidator>
            </section>

            <section class="separador">
                <p>Filtrar por:</p>
                <asp:DropDownList ID="ddlFiltros" runat="server">
                    <asp:ListItem>Seleccione un filtro</asp:ListItem>
                </asp:DropDownList>
            </section>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Paciente" ValidationGroup="1" />

            <section id="tablaPaciente">
                <asp:GridView ID="gvPacientes" runat="server" EmptyDataText="asd">
                </asp:GridView>
            </section>

        </main>
                
    </form>
</body>
</html>
