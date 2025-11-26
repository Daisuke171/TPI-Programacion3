<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaHorario.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.Horarios.AltaHorario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Alta Horario</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/AltaPaciente.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnBuscarLegajo">
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
            <asp:Label ID="lblTitulo" runat="server" CssClass="lblTitulo" Text="Alta de Horario"></asp:Label>

            <section class="formulario">
                <div class="campo">
                    <p>Legajo:</p>
                    <asp:TextBox ID="txtLegajo" runat="server" CssClass="txtBox" MaxLength="4" ValidationGroup="1"></asp:TextBox>        
                </div>
            <asp:Label ID="lbl_mensaje1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" CssClass="validator" Display="Dynamic" ValidationGroup="1">* Requerido</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revLegajo" runat="server" ErrorMessage="* Legajo invalido" ControlToValidate="txtLegajo" ValidationExpression="^\d{4}$" EnableClientScript="True" CssClass="validator" Display="Dynamic" ValidationGroup="1"></asp:RegularExpressionValidator>
                </div>

                <div class="campo">
                    <p>Legajo:</p>
                    <asp:Label ID="lblLegajo" runat="server" ></asp:Label>
                </div>

                <div class="campo">
                    <p>Medico:</p>
                    <asp:Label ID="lblMedico" runat="server" ></asp:Label>
                </div>

                <div class="campo">
                    <p>Especialidad:</p>
                    <asp:Label ID="lblEspecialidad" runat="server" ></asp:Label>
                </div>

           </section>

                <asp:Button ID="btnBuscarLegajo" CssClass="btnEnviar" runat="server" Text="Buscar Legajo" ValidationGroup="1" OnClick="btnBuscarLegajo_Click" />

            <section class="formulario">

                <div class="campo">
                    <p>Dia:</p>
                    <asp:DropDownList ID="ddl_dia" runat="server" ValidationGroup="2">
                    <asp:ListItem>-- Seleccionar  dia -- </asp:ListItem>
                    <asp:ListItem Value="1">Lunes</asp:ListItem>
                    <asp:ListItem Value="2">Martes</asp:ListItem>
                    <asp:ListItem Value="3">Miercoles</asp:ListItem>
                    <asp:ListItem Value="4">Jueves</asp:ListItem>
                    <asp:ListItem Value="5">Viernes</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfv_ddl_dia" runat="server" ControlToValidate="ddl_dia" CssClass="validator" Display="Dynamic" ValidationGroup="2" InitialValue="-- Seleccionar  dia -- ">* Requerido</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Horario Entrada:</p>
                    <asp:DropDownList ID="ddl_horaEntrada" runat="server" ValidationGroup="2">
                    <asp:ListItem>-- Seleccionar horario --</asp:ListItem>
                    <asp:ListItem>07:00:00</asp:ListItem>
                    <asp:ListItem>08:00:00</asp:ListItem>
                    <asp:ListItem>09:00:00</asp:ListItem>
                    <asp:ListItem>10:00:00</asp:ListItem>
                    <asp:ListItem>11:00:00</asp:ListItem>
                    <asp:ListItem>12:00:00</asp:ListItem>
                    <asp:ListItem>13:00:00</asp:ListItem>
                    <asp:ListItem>14:00:00</asp:ListItem>
                    <asp:ListItem>15:00:00</asp:ListItem>
                    <asp:ListItem>16:00:00</asp:ListItem>
                    <asp:ListItem>17:00:00</asp:ListItem>
                    <asp:ListItem>18:00:00</asp:ListItem>
                    <asp:ListItem>19:00:00</asp:ListItem>
                    <asp:ListItem>20:00:00</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfv_ddl_horaEntrada" runat="server" ControlToValidate="ddl_horaEntrada" CssClass="validator" Display="Dynamic" ValidationGroup="2" InitialValue="-- Seleccionar horario --">* Requerido</asp:RequiredFieldValidator>
                </div>

                <div class="campo">
                    <p>Horario Salida:</p>
                    <asp:DropDownList ID="ddl_horaSalida" runat="server" ValidationGroup="2">
                    <asp:ListItem>-- Seleccionar horario --</asp:ListItem>
                    <asp:ListItem>07:00:00</asp:ListItem>
                    <asp:ListItem>08:00:00</asp:ListItem>
                    <asp:ListItem>09:00:00</asp:ListItem>
                    <asp:ListItem>10:00:00</asp:ListItem>
                    <asp:ListItem>11:00:00</asp:ListItem>
                    <asp:ListItem>12:00:00</asp:ListItem>
                    <asp:ListItem>13:00:00</asp:ListItem>
                    <asp:ListItem>14:00:00</asp:ListItem>
                    <asp:ListItem>15:00:00</asp:ListItem>
                    <asp:ListItem>16:00:00</asp:ListItem>
                    <asp:ListItem>17:00:00</asp:ListItem>
                    <asp:ListItem>18:00:00</asp:ListItem>
                    <asp:ListItem>19:00:00</asp:ListItem>
                    <asp:ListItem>20:00:00</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="validatorContainer">
                    <asp:RequiredFieldValidator ID="rfv_ddl_horaSalida" runat="server" ControlToValidate="ddl_horaSalida" CssClass="validator" Display="Dynamic" ValidationGroup="2" InitialValue="-- Seleccionar horario --">* Requerido</asp:RequiredFieldValidator>
                </div>

            <asp:Label ID="lbl_mensaje2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>

            </section>

            <asp:Button ID="btnRegistrarHorario" CssClass="btnEnviar" runat="server" Text="Registrar Horario" OnClick="btnRegistrarHorario_Click" ValidationGroup="2"/>
            
        </main>
    </form>
</body>
</html>

