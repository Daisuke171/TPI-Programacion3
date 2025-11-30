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

            <h2>Elegir Especialidad:</h2>
            <section class="sectionTurnosMedicosCant">
                <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged"></asp:DropDownList>
            </section>

            <h2>Elegir Médico:</h2>
            <section class="sectionTurnosMedicosCant">
                <asp:DropDownList ID="ddlMedico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged"></asp:DropDownList>
            </section>

            <h2>Elegir rango de Fechas:</h2>
            <section>
                Desde
                <asp:TextBox ID="txtFechaI" runat="server" TextMode="Date"></asp:TextBox>
                Hasta
                <asp:TextBox ID="txtFechaF" runat="server" TextMode="Date"></asp:TextBox>
            </section>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Fechas" CssClass="btnEnviar" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Mostrar Todos" CssClass="btnEnviar" OnClick="btnLimpiar_Click" />

            <div class="container">
                <h2>Turnos Totales: </h2>

                <asp:Label ID="lblTurnosTotal" runat="server" CssClass="container_label"></asp:Label>

            </div>

            <div class="container">
                <h2>Porcentaje Presentismo: </h2>

                <asp:Label ID="lblTurnosPres" runat="server" CssClass="container_label"></asp:Label>

            </div>

            <div class="container">
                <h2>Porcentaje Ausentismo: </h2>

                <asp:Label ID="lblTurnosAu" runat="server" CssClass="container_label"></asp:Label>

            </div>


            <h2>Turnos</h2>
            <section>
                <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField HeaderText="ID Turno">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_idTurno" runat="server" Text='<%# Eval("IdTurno_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_especialidad" runat="server" Text='<%# Eval("NombreEspecialidad_Esp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Medico">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_medico" runat="server" Text='<%# Eval("Medico") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Legajo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_legajo" runat="server" Text='<%# Eval("LegajoMedico_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_fecha" runat="server" Text='<%# Eval("Fecha") %>' OnDataBinding="lbl_it_fecha_DataBinding"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paciente">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_paciente" runat="server" Text='<%# Eval("Paciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DNI Paciente">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_dniPaciente" runat="server" Text='<%# Eval("DNIPaciente_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asistencia">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_asistencia" runat="server" Text='<%# Eval("Asistencia_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
        </main>
    </form>
</body>
</html>
