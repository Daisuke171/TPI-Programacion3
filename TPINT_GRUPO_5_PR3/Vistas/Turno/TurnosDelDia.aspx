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
            
            <asp:GridView ID="gvListarTurnosDelDia" runat="server" AutoGenerateColumns="False" CssClass="gvTurnos" Width="1021px">
                <Columns>
                    <asp:TemplateField HeaderText="Id Turno">
                        <ItemTemplate>
                            <asp:Label ID="lblIdTurno" runat="server" Text='<%# Bind("IdTurno_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdTurno" runat="server" Text='<%# Bind("IdTurno_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Legajo Medico">
                        <ItemTemplate>
                            <asp:Label ID="lblLegajoMedico" runat="server" Text='<%# Bind("LegajoMedico_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLegajoMedico" runat="server" Text='<%# Bind("LegajoMedico_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DNI Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lblDNIPaciente" runat="server" Text='<%# Bind("DNIPaciente_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDNIPaciente" runat="server" Text='<%# Bind("DNIPaciente_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFecha" runat="server" Text='<%# Bind("Fecha_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Asistencia">
                        <ItemTemplate>
                            <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("Asistencia_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAsistencia" runat="server" Text='<%# Bind("Asistencia_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observacion">
                        <ItemTemplate>
                            <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("Observacion_Tur") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtObservacion" runat="server" Text='<%# Bind("Observacion_Tur") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>


            

        </main>
    </form>
</body>
</html>
