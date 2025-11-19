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
    public partial class WebForm6 : System.Web.UI.Page
    {
        NegocioMedico neg = new NegocioMedico();
        NegocioNacionalidad negocioNacionalidad = new NegocioNacionalidad();
        NegocioProvincia negocioProvincia = new NegocioProvincia();
        NegocioLocalidad negocioLocalidad = new NegocioLocalidad();
        NegocioEspecialidad negocioEspecialidad = new NegocioEspecialidad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("Inicio.aspx");
                    return;
                }

                CargarMedicos();
            }
        }

        private void CargarMedicos()
        {
            bool MedActivo = false;
            DataTable tablaMedico = neg.listarMedico(MedActivo);
            gvMedico.DataSource = tablaMedico;
            gvMedico.DataBind();
        }

        protected void gvMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMedico.EditIndex = e.NewEditIndex;
            CargarMedicos();
        }

        protected void gvMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedico.EditIndex = -1;
            CargarMedicos();
        }

        protected void gvMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string legajo = ((Label)gvMedico.Rows[e.RowIndex].FindControl("lbl_eit_legajo")).Text;
            string dni = ((Label)gvMedico.Rows[e.RowIndex].FindControl("lbl_eit_dni")).Text;
            string nombre = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_nombre")).Text;
            string apellido = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text;
            string sexo = ((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_sexo")).SelectedValue;
            string telefono = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_telefono")).Text;
            int idNacionalidad = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_nacionalidad")).SelectedValue);
            DateTime fechaNacimiento = Convert.ToDateTime(((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_nacimiento")).Text);
            string direccion = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_direccion")).Text;
            int idProvincia = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_provincia")).SelectedValue);
            int idLocalidad = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_localidad")).SelectedValue);
            string correo = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_correo")).Text;
            int idEspecialidad = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_especialidad")).SelectedValue);
            string estado = ((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_estado")).SelectedValue;

            Medico medico = new Medico(Convert.ToInt32(legajo), dni, nombre, apellido, sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, correo, telefono, idEspecialidad, "", "", true);

            bool modifico = neg.modificarMedico(medico);
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

            gvMedico.EditIndex = -1;
            CargarMedicos();
        }

        protected void gvMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // SI ESTA EN MODO EDIT
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddList = (DropDownList)e.Row.FindControl("ddl_eit_nacionalidad");
                //NACIONALIDADES
                DataTable dt = negocioNacionalidad.getTable();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreNacionalidad_Nac";
                ddList.DataValueField = "IdNacionalidad_Nac";
                ddList.DataBind();
                //SETEA EL VALOR SELECCIONADO AL VALOR QUE ESTÁ EN LA GV
                DataRowView dr = e.Row.DataItem as DataRowView;
                ddList.SelectedValue = dr["IdNacionalidad_Med"].ToString();


                //PROVINCIAS
                ddList = (DropDownList)e.Row.FindControl("ddl_eit_provincia");
                dt = negocioProvincia.getTable();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreProvincia_Prov";
                ddList.DataValueField = "IdProvincia_Prov";
                ddList.DataBind();
                //SETEA EL VALOR SELECCIONADO AL VALOR QUE ESTÁ EN LA GV
                string idProvincia = dr["IdProvincia_Med"].ToString();
                ddList.SelectedValue = idProvincia;

                //LOCALIDADES DE LA PCIA SELECCIONADA
                ddList = (DropDownList)e.Row.FindControl("ddl_eit_localidad");
                dt = negocioLocalidad.getTable(idProvincia);
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreLocalidad_Loc";
                ddList.DataValueField = "IdLocalidad_Loc";
                ddList.DataBind();
                //SETEA EL VALOR SELECCIONADO AL VALOR QUE ESTÁ EN LA GV
                ddList.SelectedValue = dr["IdLocalidad_Med"].ToString();

                // ESPECIALIDADES
                ddList = (DropDownList)e.Row.FindControl("ddl_eit_especialidad");
                dt = negocioEspecialidad.getTabla();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreEspecialidad_Esp";
                ddList.DataValueField = "IdEspecialidad_Esp";
                ddList.DataBind();
                //SETEA EL VALOR SELECCIONADO AL VALOR QUE ESTÁ EN LA GV
                ddList.SelectedValue = dr["IdEspecialidad_Med"].ToString();

                TextBox txtbox = (TextBox)e.Row.FindControl("txt_eit_nacimiento");
                txtbox.Text = (DateTime.Parse(dr["FechaNaciemiento_Med"].ToString())).ToString("yyyy-MM-dd");
                //TextBox1.Text = DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        protected void lbl_it_FechaNacimiento_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void ddl_eit_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // BUSCA LA ID DE LA PROVINCIA SELECCIONADA
            string idProvincia = ((DropDownList)gvMedico.Rows[gvMedico.EditIndex].FindControl("ddl_eit_provincia")).SelectedValue;
            // BUSCA LA DDL LOCALIDADES Y CARGA LAS LOCALIDADES
            DropDownList ddList = (DropDownList)gvMedico.Rows[gvMedico.EditIndex].FindControl("ddl_eit_localidad");
            DataTable dt = negocioLocalidad.getTable(idProvincia);
            ddList.DataSource = dt;
            ddList.DataTextField = "NombreLocalidad_Loc";
            ddList.DataValueField = "IdLocalidad_Loc";
            ddList.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}