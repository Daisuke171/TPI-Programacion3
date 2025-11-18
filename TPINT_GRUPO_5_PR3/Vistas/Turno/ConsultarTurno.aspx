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
            <h1>Consultar Turno</h1>

            <div class="container">
                <p>Consultar por DNI:</p>
                <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrarDni" runat="server" Text="Filtrar" CssClass="btnEnviar" />
            </div>
            <div class="container">
                <p>Consultar turnos de medico por LEGAJO:</p>
                <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrarLegajo" runat="server" Text="Filtrar" CssClass="btnEnviar" />
            </div>


            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gvTurnos">
                <Columns>
                    <asp:TemplateField HeaderText="Id Turno">
                        <ItemTemplate>
                            <asp:Label ID="lblIdTurno" runat="server" Text='<%# Bind("IdTurno") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtIdTurno" runat="server" Text='<%# Bind("IdTurno") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Legajo Medico">
                        <ItemTemplate>
                            <asp:Label ID="lblLegajoMedico" runat="server" Text='<%# Bind("LegajoMedico") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLegajoMedico" runat="server" Text='<%# Bind("LegajoMedico") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DNI Paciente">
                        <ItemTemplate>
                            <asp:Label ID="lblDNIPaciente" runat="server" Text='<%# Bind("DNIPaciente") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDNIPaciente" runat="server" Text='<%# Bind("DNIPaciente") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Especialidad">
                        <ItemTemplate>
                            <asp:Label ID="lblEspecialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEspecialidad" runat="server" Text='<%# Bind("Especialidad") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Asistencia">
                        <ItemTemplate>
                            <asp:Label ID="lblAsistencia" runat="server" Text='<%# Bind("Asistencia") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAsistencia" runat="server" Text='<%# Bind("Asistencia") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Observacion">
                        <ItemTemplate>
                            <asp:Label ID="lblObservacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtObservacion" runat="server" Text='<%# Bind("Observacion") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seleccionar Turno" />
                </Columns>
            </asp:GridView>

        </main>
    </form>
</body>
</html>
