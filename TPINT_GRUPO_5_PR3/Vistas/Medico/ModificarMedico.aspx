<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modificar Médico</title>
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/ModificarMedico.css" />
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
            <asp:Label ID="lblTitulo" runat="server" Text="Modificar médico" CssClass="lblTitulo"></asp:Label>

            <div class="campo">
                <p>Buscar Legajo:</p>
                <asp:TextBox ID="txtBuscar" runat="server" ValidationGroup="2"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revLegajo" runat="server" ControlToValidate="txtBuscar" ErrorMessage="* Legajo invalido" ValidationExpression="^[0-9,$]*$"></asp:RegularExpressionValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" Font-Bold="True" ForeColor="Red" />
            </div>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btnEnviar" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar todos" CssClass="btnEnviar" OnClick="btnMostrarTodos_Click" />

            <div class="campo">

                <asp:Label ID="lbl_mensaje" runat="server" Font-Bold="True"></asp:Label>

            </div>

            <section id="tablaMedico">
                <asp:GridView ID="gvMedico" runat="server" AutoGenerateEditButton="True" AutoGenerateColumns="False" OnRowEditing="gvMedico_RowEditing" OnRowCancelingEdit="gvMedico_RowCancelingEdit" OnRowUpdating="gvMedico_RowUpdating" OnRowDataBound="gvMedico_RowDataBound" AllowPaging="True" OnPageIndexChanging="gvMedico_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:TemplateField HeaderText="Legajo">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_legajo" runat="server" Text='<%# Eval("Legajo_Med") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_legajo" runat="server" Text='<%# Bind("Legajo_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Especialidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_especialidad" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_especialidad" runat="server" Text='<%# Bind("NombreEspecialidad_Esp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DNI">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_eit_dni" runat="server" Text='<%# Eval("DNI_Med") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_nombre" runat="server" Text='<%# Bind("Nombre_Med") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_nombre" runat="server" ControlToValidate="txt_eit_nombre" Display="None" ErrorMessage="* Campo obligatorio: Nombre"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_eit_nombre" runat="server" ControlToValidate="txt_eit_nombre" Display="None" ErrorMessage="* Nombre invalido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ' ]+$"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_Nombre" runat="server" Text='<%# Bind("Nombre_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Apellido">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_apellido" runat="server" Text='<%# Bind("Apellido_Med") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_apellido" runat="server" ControlToValidate="txt_eit_apellido" Display="None" ErrorMessage="* Campo obligatorio: Apellido"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_eit_apellido" runat="server" ControlToValidate="txt_eit_apellido" Display="None" ErrorMessage="* Apellido invalido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ' ]+$"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_apellido" runat="server" Text='<%# Bind("Apellido_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sexo">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_sexo" runat="server" SelectedValue='<%# Bind("Sexo_Med") %>'>
                                    <asp:ListItem Value="Femenino" Text="Femenino">Femenino</asp:ListItem>
                                    <asp:ListItem Value="Masculino" Text="Masculino"></asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_sexo" runat="server" Text='<%# Bind("Sexo_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nacionalidad">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddl_eit_nacionalidad" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nacionalidad" runat="server" Text='<%# Bind("NombreNacionalidad_Nac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Nacimiento">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_fechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
                                <asp:RangeValidator ID="rv_eit_fechaNacimiento" runat="server" ControlToValidate="txt_eit_fechaNacimiento" ErrorMessage="* Fecha invalida" MinimumValue="1-1-1900" Type="Date" Display="None"></asp:RangeValidator>
                                <asp:RequiredFieldValidator ID="rfv_eit_fechaNacimiento" runat="server" ControlToValidate="txt_eit_fechaNacimiento" Display="None" EnableTheming="True" ErrorMessage="* Campo obligatorio: Fecha"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_fechaNacimiento" runat="server" Text='<%# Bind("FechaNaciemiento_Med") %>' OnDataBinding="lbl_it_fechaNacimiento_DataBinding1"></asp:Label>
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

                        <asp:TemplateField HeaderText="Dirección">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_direccion" runat="server" Text='<%# Bind("Direccion_Med") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_direccion" runat="server" ControlToValidate="txt_eit_direccion" Display="None" ErrorMessage="* Campo obligatorio: Direccion"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_direccion" runat="server" Text='<%# Bind("Direccion_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Correo Electrónico">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_correo" runat="server" Text='<%# Bind("CorreoElectronico_Med") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_correo" runat="server" ControlToValidate="txt_eit_correo" Display="None" ErrorMessage="*Campo obligatorio: correo"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rev_eit_correo" runat="server" ControlToValidate="txt_eit_correo" Display="None" ErrorMessage="* Direccion de correo invalida" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_correo" runat="server" Text='<%# Bind("CorreoElectronico_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Teléfono">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_telefono" runat="server" Text='<%# Bind("Telefono_Med") %>'></asp:TextBox>
                                <asp:RegularExpressionValidator ID="rev_eit_telefono" runat="server" ControlToValidate="txt_eit_telefono" Display="None" ErrorMessage="* Telefono invalido" ValidationExpression="^[0-9,$]*$"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="rfv_eit_telefono" runat="server" ControlToValidate="txt_eit_telefono" Display="None" ErrorMessage="* Campo obligatorio: Telefono"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_telefono" runat="server" Text='<%# Bind("Telefono_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre Usuario">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_eit_usuario" runat="server" Text='<%# Eval("NombreUsuario_U") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_Usuario" runat="server" ControlToValidate="txt_eit_usuario" Display="None" ErrorMessage="* Campo obligatorio: Usuario"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_usuario" runat="server" Text='<%# Eval("NombreUsuario_U") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Contraseña Usuario">
                            <EditItemTemplate>
                                Contraseña:
                                <asp:TextBox ID="txt_eit_contraseña" runat="server" Text='<%# Eval("ContraseniaUsuario_U") %>'></asp:TextBox>
                                <br />
                                Repetir Contraseña:<asp:TextBox ID="txt_eit_repetirContraseña" runat="server" Text='<%# Eval("ContraseniaUsuario_U") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_eit_contraseña" runat="server" ControlToValidate="txt_eit_contraseña" Display="None" ErrorMessage="* Campo obligatorio: Contraseña"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cv_eit_contraseña" runat="server" ControlToCompare="txt_eit_contraseña" ControlToValidate="txt_eit_repetirContraseña" Display="None" ErrorMessage="Las contraseñas no coinciden"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="rfv_eit_repetirContraseña" runat="server" ControlToValidate="txt_eit_repetirContraseña" Display="None" ErrorMessage="*Campo obligatorio: Repetir Contraseña"></asp:RequiredFieldValidator>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_contraseña" runat="server" Text='<%# Eval("ContraseniaUsuario_U") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </section>
        </main>
    </form>
</body>
</html>
