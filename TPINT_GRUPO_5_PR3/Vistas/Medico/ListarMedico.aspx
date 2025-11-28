<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarMedico.aspx.cs" Inherits="TPINT_GRUPO_5_PR3.Vistas.ListarMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Listar Medico</title>
    <link rel="stylesheet" href="../Estilos/NavBar.css" />
    <link rel="stylesheet" href="../Estilos/Base.css" />
    <link rel="stylesheet" href="../Estilos/ListarMedico.css" />
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
            <asp:Label ID="lblTitulo" runat="server" Text="Listado de medicos"></asp:Label>

            <section class="separador">
                <p>Buscar Legajo:</p>
                <asp:TextBox ID="txtLegajo" runat="server" ValidationGroup="1" MaxLength="4"></asp:TextBox>
            </section>

            <div class="validatorContainer">
                <asp:RegularExpressionValidator ID="rev_legajo" runat="server" ControlToValidate="txtLegajo" ValidationExpression="^[0-9,$]*$" ForeColor="Red" Visible="False" Display="Dynamic" Font-Bold="True"></asp:RegularExpressionValidator>
            </div>

            <section class="separador">
                <p>Buscar Apellido:</p>
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>                
            </section>
            
            <div class="validatorContainer">
                <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ' ]+$" Display="Dynamic" Font-Bold="True" ForeColor="Red">* Error. Ingresar caracteres alfabéticos</asp:RegularExpressionValidator>
            </div>

            <section class="separador">
                <p>Ordenar por:</p>
                <asp:DropDownList ID="ddlOrdenListado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOrdenListado_SelectedIndexChanged">
                    <asp:ListItem Value="Legajo_Med" Selected="True">Legajo</asp:ListItem>
                    <asp:ListItem Value="NombreEspecialidad_Esp">Especialidad</asp:ListItem>
                    <asp:ListItem Value="Apellido_Med">Apellido</asp:ListItem>
                    <asp:ListItem Value="Sexo_Med">Sexo</asp:ListItem>
                    <asp:ListItem Value="NombreNacionalidad_Nac">Nacionalidad</asp:ListItem>
                    <asp:ListItem Value="NombreProvincia_Prov">Provincia</asp:ListItem>
                    <asp:ListItem Value="NombreLocalidad_Loc">Localidad</asp:ListItem>
                </asp:DropDownList>
            </section>
            
            <section class="separador">
                <p>Filtrar por Especialidad:</p>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                </asp:DropDownList>
            </section>

            <asp:Button ID="btnBuscar" runat="server" Text="Buscar Medico" ValidationGroup="1" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnMostrarTodos" runat="server" Text="Mostrar Todos" CssClass="btnEnviar" ValidationGroup="1" OnClick="btnMostrarTodos_Click" />

            <section id="tablaMedico">
                <asp:GridView ID="gvMedico" runat="server" EmptyDataText="No se encontraron registros" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="gvMedico_PageIndexChanging" PageSize="5">
                    <Columns>
                        
                        <asp:TemplateField HeaderText="Legajo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_legajo" runat="server" Text='<%# Bind("Legajo_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Especialidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_especialidad" runat="server" Text='<%# Bind("NombreEspecialidad_Esp") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DNI">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_dni" runat="server" Text='<%# Bind("DNI_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Bind("Nombre_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Apellido">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_apellido" runat="server" Text='<%# Bind("Apellido_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Sexo">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_sexo" runat="server" Text='<%# Bind("Sexo_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Nacionalidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_nacionalidad" runat="server" Text='<%# Bind("NombreNacionalidad_Nac") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fecha Nacimiento">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_fechaNacimiento" runat="server" Text='<%# Bind("FechaNaciemiento_Med") %>' OnDataBinding="lbl_it_nacimiento_DataBinding"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Provincia">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_provincia" runat="server" Text='<%# Bind("NombreProvincia_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Localidad">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_localidad" runat="server" Text='<%# Bind("NombreLocalidad_Loc") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Dirección">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_direccion" runat="server" Text='<%# Bind("Direccion_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Teléfono">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_telefono" runat="server" Text='<%# Bind("Telefono_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Correo Electrónico">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_correo" runat="server" Text='<%# Bind("CorreoElectronico_Med") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_estado" runat="server" Text='<%# Bind("NombreUsuario_U") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </section>
        </main>
    </form>
</body>
</html>
