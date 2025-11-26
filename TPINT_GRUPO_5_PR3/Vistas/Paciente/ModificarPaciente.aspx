<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modificar Paciente</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/ModificarPaciente.css" />
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
            <asp:Label ID="lblTitulo" runat="server" Text="Modificar paciente" CssClass="lblTitulo"></asp:Label>

            <div class="campo">
                <p>Buscar DNI:</p>
                <asp:TextBox ID="txtBuscar" runat="server" ValidationGroup="2"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revDNI" runat="server" ControlToValidate="txtBuscar" Font-Bold="True" ForeColor="Red" ValidationExpression="^[0-9,$]*$" ValidationGroup="2">DNI invalido</asp:RegularExpressionValidator>
            </div>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btnEnviar" OnClick="btnBuscar_Click" ValidationGroup="2" />
            <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todos" CssClass="btnEnviar" OnClick="btnMostrarTodos_Click" />

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" />

            <div class="campo">
                <asp:Label ID="lbl_mensaje" runat="server" Font-Bold="True"></asp:Label>
            </div>

            <section id="tablaPaciente">
                <asp:GridView ID="gvPaciente" runat="server" AutoGenerateEditButton="True" AutoGenerateColumns="False" OnRowCancelingEdit="gvPaciente_RowCancelingEdit" OnRowEditing="gvPaciente_RowEditing" OnRowUpdating="gvPaciente_RowUpdating" OnRowDataBound="gvPaciente_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvPaciente_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:TemplateField HeaderText="DNI">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_dni" runat="server" Text='<%# Eval("DNI_Pac") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_nombre" runat="server" Text='<%# Bind("Nombre_Pac") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_nombre" runat="server" ControlToValidate="txt_eit_nombre" Display="None" ErrorMessage="* Campo obligatorio: Nombre"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_eit_nombre" runat="server" ControlToValidate="txt_eit_nombre" Display="None" ErrorMessage="* Nombre invalido" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Bind("Nombre_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_apellido" runat="server" Text='<%# Bind("Apellido_Pac") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_apellido" runat="server" ControlToValidate="txt_eit_apellido" Display="None" ErrorMessage="* Campo obligatorio: Apellido"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_eit_apellido" runat="server" ControlToValidate="txt_eit_apellido" Display="None" ErrorMessage="* Apellido invalido" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_apellido" runat="server" Text='<%# Bind("Apellido_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_Sexo" runat="server" SelectedValue='<%# Bind("Sexo_Pac") %>'>
                                    <asp:ListItem>Masculino</asp:ListItem>
                                    <asp:ListItem>Femenino</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_sexo" runat="server" Text='<%# Bind("Sexo_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_nacionalidad" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nacion" runat="server" Text='<%# Bind("NombreNacionalidad_Nac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha de Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_nacimiento" runat="server" Text='<%# Bind("FechaNacimiento_Pac") %>' TextMode="Date"></asp:TextBox>
                                <asp:RangeValidator ID="rv_eit_FechaNacimiento" runat="server" ControlToValidate="txt_eit_nacimiento" ErrorMessage="* Fecha invalida" MinimumValue="1-1-1900" Type="Date" Display="None"></asp:RangeValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nacimiento" runat="server" Text='<%# Bind("FechaNacimiento_Pac") %>' OnDataBinding="lbl_it_nacimiento_DataBinding"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dirección">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_direccion" runat="server" Text='<%# Bind("Direccion_Pac") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_direccion" runat="server" ControlToValidate="txt_eit_direccion" Display="None" ErrorMessage="* Campo obligatorio: Direccion"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_direccion" runat="server" Text='<%# Bind("Direccion_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Provincia">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_provincia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_eit_provincia_SelectedIndexChanged">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_provincia" runat="server" Text='<%# Bind("NombreProvincia_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Localidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_localidad" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_localidad" runat="server" Text='<%# Bind("NombreLocalidad_Loc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo de Sangre">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_tipoSangre" runat="server" SelectedValue='<%# Bind("TipoSangre_Pac") %>'>
                                    <asp:ListItem>A+</asp:ListItem>
                                    <asp:ListItem>A-</asp:ListItem>
                                    <asp:ListItem>B+</asp:ListItem>
                                    <asp:ListItem>B-</asp:ListItem>
                                    <asp:ListItem>AB+</asp:ListItem>
                                    <asp:ListItem>AB-</asp:ListItem>
                                    <asp:ListItem>O+</asp:ListItem>
                                    <asp:ListItem>O-</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_sangre" runat="server" Text='<%# Bind("TipoSangre_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Correo Electrónico">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_email" runat="server" Text='<%# Bind("CorreoElectronico_Pac") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_correo" runat="server" ControlToValidate="txt_eit_email" Display="None" ErrorMessage="*Campo obligatorio: correo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_eit_correo" runat="server" ControlToValidate="txt_eit_email" Display="None" ErrorMessage="* Direccion de correo invalida" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_email" runat="server" Text='<%# Bind("CorreoElectronico_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Teléfono">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_celu" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rev_eit_telefono" runat="server" ControlToValidate="txt_eit_celu" Display="None" ErrorMessage="* Telefono invalido" ValidationExpression="^[0-9,$]*$"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfv_eit_telefono" runat="server" ControlToValidate="txt_eit_celu" Display="None" ErrorMessage="* Campo obligatorio: Telefono"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_celu" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </section>
        </main>
    </form>
</body>
</html>

