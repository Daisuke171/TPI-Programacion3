<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ConsultarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consultar Turno</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/ConsultarTurno.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnFiltrarPaciente">
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
            <h1>Consultar Turno</h1>

            <div class="container">
                <p>Consultar por NOMBRE / APELLIDO Paciente:</p>
                <asp:TextBox ID="txtPaciente" runat="server" ValidationGroup="1"></asp:TextBox>
                <asp:Button ID="btnFiltrarPaciente" runat="server" Text="Filtrar" CssClass="btnEnviar" OnClick="btnFiltrarPaciente_Click" ValidationGroup="1" />
            </div>

            <div class="validatorContainer">
                <asp:RegularExpressionValidator ID="revPaciente" runat="server" ControlToValidate="txtPaciente" Font-Bold="True" ForeColor="Red" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="1">* Nombre / Apellido invalidos</asp:RegularExpressionValidator>
            </div>

            <div class="container">
                <p>Consultar turnos de medico por FECHA:</p>
                <div class="dateContainer">
                    <p>DESDE</p>
                    <asp:TextBox ID="txtFechaInicial" runat="server" TextMode="Date"></asp:TextBox>
                </div>

                <div class="dateContainer">
                    <p>HASTA</p>
                    <asp:TextBox ID="txtFechaFinal" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <asp:Button ID="btnFiltrarLegajo" runat="server" Text="Filtrar" CssClass="btnEnviar" OnClick="btnFiltrarLegajo_Click" ValidationGroup="2" />
            </div>

            <div class="container">
                <p>Filtrar ASISTENCIA:</p>
                <asp:DropDownList ID="ddl_asistencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="Todos">Todos</asp:ListItem>
                    <asp:ListItem>Presente</asp:ListItem>
                    <asp:ListItem>Pendiente</asp:ListItem>
                    <asp:ListItem>Ausente</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="container">
                <asp:Button ID="btnLimpiarBusqueda" runat="server" Text="Limpiar Búsqueda" CssClass="btnEnviar" OnClick="btnLimpiarBusqueda_Click" />
            </div>


            <asp:GridView ID="gvConsultarTurnos" runat="server" AutoGenerateColumns="False" CssClass="gvTurnos" AllowPaging="True" OnPageIndexChanging="gvConsultarTurnos_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="Id Turno">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_idTurno" runat="server" Text='<%# Bind("IdTurno_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_nombrePaciente" runat="server" Text='<%# Bind("Paciente") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_fecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Horario">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_horario" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Asistencia">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_asistencia" runat="server" Text='<%# Bind("Asistencia_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observacion">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_observacion" runat="server" Text='<%# Bind("Observacion_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </main>
    </form>
</body>
</html>
