<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Turno.ModificarTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mpdificar Turnos</title>
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
            <h1>Modificar Turno</h1>

            <div class="container">
                <p>Buscar por id turno:</p>
                <asp:TextBox ID="txtIdTurno" runat="server"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btnEnviar" />
            </div>
            <div class="validatorContainer">
                <asp:RegularExpressionValidator ID="rev_txtIdTurno" runat="server" ControlToValidate="txtIdTurno" ErrorMessage="Solo se admiten numeros" ForeColor="Red" ValidationExpression="^[0-9 ]+$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfv_txtIdTurno" runat="server" ControlToValidate="txtIdTurno" ErrorMessage="Ingrese un ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="gv-container">
                <asp:GridView ID="gvTurnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateEditButton="True" OnPageIndexChanging="gvTurnos_PageIndexChanging" OnRowDataBound="gvTurnos_RowDataBound" OnRowUpdating="gvTurnos_RowUpdating" PageSize="5" OnRowCancelingEdit="gvTurnos_RowCancelingEdit" OnRowEditing="gvTurnos_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_idTurno" runat="server" Text='<%# Eval("IdTurno_Tur") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_idTurno" runat="server" Text='<%# Bind("IdTurno_Tur") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha">
                            <EditItemTemplate>
                                <asp:Calendar ID="cl_eit_fechaTur" runat="server"></asp:Calendar>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_fechaTur" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Legajo Medico">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_legajoMedico" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_legajoMedico" runat="server" Text='<%# Bind("LegajoMedico_Tur") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DNI Paciente">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_DNIPac" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_DNIPac" runat="server" Text='<%# Bind("DNIPaciente_Tur") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Asistencia">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_asistencia" runat="server">
                                    <asp:ListItem Value="1">Confirmado</asp:ListItem>
                                    <asp:ListItem Value="2">Pendiente</asp:ListItem>
                                    <asp:ListItem Value="3">Cancelado</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_asistencia" runat="server" Text='<%# Bind("Asistencia_Tur") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Observaciones">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_observacion" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_observacion" runat="server" Text='<%# Bind("Observacion_Tur") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <asp:Label ID="lblConfirmacion" runat="server"></asp:Label>

        </main>
    </form>
</body>
</html>
