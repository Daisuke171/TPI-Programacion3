using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        NegocioPaciente neg = new NegocioPaciente();
        NegocioNacionalidad negocioNacionalidad = new NegocioNacionalidad();
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        NegocioLocalidad negocioLocalidad = new NegocioLocalidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                    return;
                }

                CargarPacientes();
            }
        }

        private void CargarPacientes()
        {
            DataTable tablaPacientes = neg.listarPacientesActivos();
            gvPaciente.DataSource = tablaPacientes;
            gvPaciente.DataBind();
        }

        protected void gvPaciente_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPaciente.EditIndex = e.NewEditIndex;
            CargarPacientes();
        }

        protected void gvPaciente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           gvPaciente.EditIndex = -1;
           CargarPacientes();
        }

        protected void gvPaciente_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dni = ((Label)gvPaciente.Rows[e.RowIndex].FindControl("lbl_eit_dni")).Text;
            string nombre = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_nombre")).Text;
            string apellido = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text;
            string sexo = ((DropDownList)gvPaciente.Rows[e.RowIndex].FindControl("ddl_eit_sexo")).SelectedValue;
            int idNacionalidad = Convert.ToInt32(((DropDownList)gvPaciente.Rows[e.RowIndex].FindControl("ddl_eit_nacionalidad")).SelectedValue);
            DateTime fechaNacimiento = DateTime.Parse(((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_nacimiento")).Text);
            string direccion = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_direccion")).Text;
            int idLocalidad = Convert.ToInt32(((DropDownList)gvPaciente.Rows[e.RowIndex].FindControl("ddl_eit_localidad")).SelectedValue);
            int idProvincia = Convert.ToInt32(((DropDownList)gvPaciente.Rows[e.RowIndex].FindControl("ddl_eit_provincia")).SelectedValue);
            string tipoSangre = ((DropDownList)gvPaciente.Rows[e.RowIndex].FindControl("ddl_eit_tipoSangre")).SelectedValue;
            string correo = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_email")).Text;
            string telefono = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_celu")).Text;

            Paciente paciente = new Paciente (dni, nombre,  apellido,  sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, tipoSangre, correo, telefono, true);

            bool modifico = neg.modificarPaciente(paciente);
            if (modifico)
            {
                lbl_mensaje.ForeColor = Color.Green;
                lbl_mensaje.Text = "Modificación exitosa";
            }
            else
            {
                lbl_mensaje.ForeColor = Color.Red;
                lbl_mensaje.Text = "Error en la operacion";
            }
                gvPaciente.EditIndex = -1;
            CargarPacientes();
        }

        protected void gvPaciente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // SI ESTA EN MODO EDIT
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddList = (DropDownList)e.Row.FindControl("ddl_eit_nacionalidad");
                //CARGA DLL NACIONALIDAD
                DataTable dt = negocioNacionalidad.getTable();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreNacionalidad_Nac";
                ddList.DataValueField = "IdNacionalidad_Nac";
                ddList.DataBind();
                //SETEA EL VALOR SELECCIONADO AL VALOR QUE ESTÁ EN LA GV
                DataRowView dr = e.Row.DataItem as DataRowView;
                ddList.SelectedValue = dr["IdNacionalidad_Pac"].ToString();

                ddList = (DropDownList)e.Row.FindControl("ddl_eit_provincia");

                //CARGA DLL PROVINCIA
                dt = negocioProvincia.getTable();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreProvincia_Prov";
                ddList.DataValueField = "IdProvincia_Prov";
                ddList.DataBind();
                //SETEA EL VALOR SELECCIONADO AL VALOR QUE ESTÁ EN LA GV
                string idProvincia = dr["IdProvincia_Pac"].ToString();
                ddList.SelectedValue = idProvincia;

                ddList = (DropDownList)e.Row.FindControl("ddl_eit_localidad");
                //CARGA DLL LOCALIDAD CON LAS LOCALIDADES DE LA PCIA SELECCIONADA
                dt = negocioLocalidad.getTable(idProvincia);
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreLocalidad_Loc";
                ddList.DataValueField = "IdLocalidad_Loc";
                ddList.DataBind();
                //SETEA EL VALOR SELECCIONADO AL VALOR QUE ESTÁ EN LA GV
                ddList.SelectedValue = dr["IdLocalidad_Pac"].ToString();

                TextBox txtbox = (TextBox)e.Row.FindControl("txt_eit_nacimiento");
                txtbox.Text = (DateTime.Parse(dr["FechaNacimiento_Pac"].ToString())).ToString("yyyy-MM-dd");
                //TextBox1.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        protected void ddl_eit_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // BUSCA LA ID DE LA PROVINCIA SELECCIONADA
            string idProvincia = ((DropDownList)gvPaciente.Rows[gvPaciente.EditIndex].FindControl("ddl_eit_Provincia")).SelectedValue;
            // BUSCA LA DDL LOCALIDADES Y CARGA LAS LOCALIDADES
            DropDownList ddList = (DropDownList)gvPaciente.Rows[gvPaciente.EditIndex].FindControl("ddl_eit_Localidad");
            DataTable dt = negocioLocalidad.getTable(idProvincia);
            ddList.DataSource = dt;
            ddList.DataTextField = "NombreLocalidad_Loc";
            ddList.DataValueField = "IdLocalidad_Loc";
            ddList.DataBind();
        }

        protected void lbl_it_nacimiento_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }
    }
}