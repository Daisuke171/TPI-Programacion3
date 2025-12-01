<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Turno.ModificarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modificar Turnos</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/ModificarTurno.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnBuscar">
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
            <h1>Reprogramar Turno</h1>
        
            <div class="container">
                <p>Buscar por NOMBRE / APELLIDO Paciente:</p>
                <asp:TextBox ID="txtPaciente" runat="server" ValidationGroup="2"></asp:TextBox>
            </div>
            <div class="validatorContainer">
                <asp:RegularExpressionValidator ID="revPaciente" runat="server" ControlToValidate="txtPaciente" Font-Bold="True" ForeColor="Red" ValidationExpression="^[a-zA-Z\s]+$" ValidationGroup="2">* Nombre invalido</asp:RegularExpressionValidator>
            </div>
        
            <div class="container">
                <p>Buscar por DNI Paciente:</p>
                <asp:TextBox ID="txtDni" runat="server" ValidationGroup="2"></asp:TextBox>
            </div>
            <div class="validatorContainer">
                <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtDni" Font-Bold="True" ForeColor="Red" ValidationExpression="^[0-9,$]*$" ValidationGroup="2">* DNI invalido</asp:RegularExpressionValidator>
            </div>
        
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btnEnviar" ValidationGroup="2" />
            <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" OnClick="btnMostrarTodos_Click" CssClass="btnEnviar" ValidationGroup="1" />
        
            <div class="gv-container">
                <asp:GridView ID="gvTurnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnPageIndexChanging="gvTurnos_PageIndexChanging" OnRowDataBound="gvTurnos_RowDataBound" OnRowUpdating="gvTurnos_RowUpdating" PageSize="5" OnRowCancelingEdit="gvTurnos_RowCancelingEdit" OnRowEditing="gvTurnos_RowEditing" EmptyDataText="No se encontraron registros">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_idTurno" runat="server" Text='<%# Eval("IdTurno_Turno") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_idTurno" runat="server" Text='<%# Eval("IdTurno_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Legajo Medico">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_legajo" runat="server" Text='<%# Eval("LegajoMedico_Turno") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_legajo" runat="server" Text='<%# Bind("LegajoMedico_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Medico">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_medico" runat="server" Text='<%# Eval("Medico") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_medico" runat="server" Text='<%# Eval("Medico") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DNI Paciente">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_dniPaciente" runat="server" Text='<%# Eval("DNIPaciente_Turno") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_dniPaciente" runat="server" Text='<%# Eval("DNIPaciente_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Paciente">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_paciente" runat="server" Text='<%# Eval("Paciente") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_paciente" runat="server" Text='<%# Eval("Paciente") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asistencia">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_asistencia" runat="server" Text='<%# Eval("Asistencia_Turno") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_asistencia" runat="server" Text='<%# Eval("Asistencia_Turno") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha">
                            <EditItemTemplate>
                                <asp:Calendar ID="cl_eit_fechaTur" runat="server" SelectedDate='<%# Eval("Fecha") %>' OnDayRender="cl_eit_fechaTur_DayRender" OnSelectionChanged="cl_eit_fechaTur_SelectionChanged"></asp:Calendar>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_fecha" runat="server" Text='<%# Eval("Fecha") %>' OnDataBinding="lbl_it_fecha_DataBinding"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Horario">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_horario" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvHorario" runat="server" ControlToValidate="ddl_eit_horario" Display="Dynamic" Font-Bold="True" ForeColor="Red" InitialValue="0">* Campo obligatorio</asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_horario" runat="server" Text='<%# Eval("Horario") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        
        <asp:Label ID="lblConfirmacion" runat="server" Font-Bold="True"></asp:Label>
        
        </main>
    </form>
</body>
</html>
