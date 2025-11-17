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
    <form id="form1" runat="server">
        <nav>
            <div class="leftSide">
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Inicio" NavigateUrl="~/Vistas/InicioAdmin.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Pacientes" NavigateUrl="~/Vistas/HomePacientes.aspx"></asp:HyperLink>
                <asp:HyperLink CssClass="hlnk_Inicio" runat="server" Text="Medicos" NavigateUrl="~/Vistas/HomeMedicos.aspx"></asp:HyperLink>
            </div>
            <div class="rightSide">
                <asp:Label ID="lblUsuario" CssClass="lbl_Usuario" runat="server" Text="Username"></asp:Label>
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" CssClass="btn-logout" />
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </nav>
        <main>
            <asp:Label ID="lblTitulo" runat="server" Text="Modificar paciente" CssClass="lblTitulo"></asp:Label>

            <div class="campo">
                <p>Buscar DNI:</p>
                <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
            </div>

            <asp:GridView ID="gvPaciente" runat="server" AutoGenerateEditButton="True" AutoGenerateColumns="False" OnRowCancelingEdit="gvPaciente_RowCancelingEdit" OnRowEditing="gvPaciente_RowEditing" OnRowUpdating="gvPaciente_RowUpdating" OnRowDataBound="gvPaciente_RowDataBound">
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
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_nombre" runat="server" Text='<%# Bind("Nombre_Pac") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellido">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_apellido" runat="server" Text='<%# Bind("Apellido_Pac") %>'></asp:TextBox>
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
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_nacimiento" runat="server" Text='<%# Bind("FechaNacimiento_Pac") %>' OnDataBinding="lbl_it_nacimiento_DataBinding"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dirección">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_direccion" runat="server" Text='<%# Bind("Direccion_Pac") %>'></asp:TextBox>
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
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_email" runat="server" Text='<%# Bind("CorreoElectronico_Pac") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Teléfono">
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_eit_celu" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_celu" runat="server" Text='<%# Bind("Telefono_Pac") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </main>
    </form>
</body>
</html>
