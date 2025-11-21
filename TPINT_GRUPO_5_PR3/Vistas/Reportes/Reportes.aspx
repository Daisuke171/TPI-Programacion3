<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Reportes.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/Reportes.css" />
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
            <h1>Reportes</h1>

            <h2>Cantidad de turnos por medico:</h2>
            <section class="sectionTurnosMedicosCant">
                <asp:DropDownList ID="ddlMedicos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblCantTurnosPorMedico" runat="server" CssClass="information" ></asp:Label>
            </section>

            <section>
                <h2>Turnos en los dias seleccionados:</h2>
                <div class="calendar">
                    <asp:Calendar ID="clTurnos" runat="server" AutoPostBack="True" OnSelectionChanged="clTurnos_SelectionChanged"></asp:Calendar>
                </div>
                <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_fecha" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paciente">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_paciente" runat="server" Text='<%# Eval("Nombre_Pac") + " " + Eval("Apellido_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Medico">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_medico" runat="server" Text='<%# Eval("Nombre_Med") + " " + Eval("Apellido_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
        </main>
    </form>
</body>
</html>
