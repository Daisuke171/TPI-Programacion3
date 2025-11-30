<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnosDelDia.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Turno.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Turnos del Dia</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <style>
        #gvListarTurnosDelDia {
            width: 100%;
            min-width: 900px;
            border-collapse: collapse;
            border-radius: 10px;
            overflow: hidden;
            margin-top: 10px;
            background: rgba(255, 255, 255, 0.15);
        }

            #gvListarTurnosDelDia th {
                background: #0078d4;
                color: #fff;
                font-weight: bold;
                text-align: left;
                padding: 10px;
            }

            #gvListarTurnosDelDia td {
                padding: 10px;
                border-bottom: 1px solid rgba(255, 255, 255, 0.2);
                color: #000;
            }

            #gvListarTurnosDelDia tr:hover {
                background: rgba(255, 255, 255, 0.1);
            }

            #gvListarTurnosDelDia a {
                background-color: #0078d4;
                color: white;
                padding: 6px 10px;
                border-radius: 6px;
                text-decoration: none;
                font-size: 13px;
                transition: background-color 0.2s ease;
            }
    </style>

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
            <h1>Turnos del Dia de <asp:Label ID="lblUsuarioTurnosDelDia" runat="server"></asp:Label></h1>
            
            <asp:GridView ID="gvListarTurnosDelDia" runat="server" AutoGenerateColumns="False" CssClass="gvTurnos" Width="1021px" AutoGenerateEditButton="True" OnRowCancelingEdit="gvListarTurnosDelDia_RowCancelingEdit" OnRowEditing="gvListarTurnosDelDia_RowEditing" OnRowUpdating="gvListarTurnosDelDia_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Id Turno">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_idTurno" runat="server" Text='<%# Bind("IdTurno_Turno") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_idTurno" runat="server" Text='<%# Bind("IdTurno_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Legajo Medico">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_legajo" runat="server" Text='<%# Bind("LegajoMedico_Turno") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_legajo" runat="server" Text='<%# Bind("LegajoMedico_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DNI Paciente">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_dniPaciente" runat="server" Text='<%# Bind("DNIPaciente_Turno") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_dniPaciente" runat="server" Text='<%# Bind("DNIPaciente_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_fechaTurno" runat="server" Text='<%# Bind("Fecha") %>' OnDataBinding="lbl_eit_fechaTurno_DataBinding"></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_fechaTurno" runat="server" Text='<%# Bind("Fecha") %>' OnDataBinding="lbl_it_fechaTurno_DataBinding"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Horario">
                        <EditItemTemplate>
                            <asp:Label ID="lbl_eit_horarioTurno" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_horarioTurno" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Asistencia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddl_eit_asistencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_asistencia_SelectedIndexChanged">
                                <asp:ListItem Selected="True">Presente</asp:ListItem>
                                <asp:ListItem>Ausente</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_Asistencia" runat="server" Text='<%# Bind("Asistencia_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observacion">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_observacion" runat="server" Text='<%# Bind("Observacion_Turno") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_observacion" runat="server" Text='<%# Bind("Observacion_Turno") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>


            

        </main>
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    </form>
</body>
</html>
