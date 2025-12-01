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
        NegocioUsuario negocioUsuario = new NegocioUsuario();
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
                    Response.Redirect("~/Vistas/Inicio.aspx");
                    return;
                }

                Session["legajoABuscar"] = "";

                cargarMedicos();
            }
        }

        private void cargarMedicos()
        {
            //Guarda el elemento a buscar y trae los legajos con coindicencias
            string legajo = Session["legajoABuscar"].ToString();

            DataTable tablaMedico = neg.buscarMedicos(legajo);
            gvMedico.DataSource = tablaMedico;
            gvMedico.DataBind();
        }

        protected void gvMedico_RowEditing(object sender, GridViewEditEventArgs e)
        {
            limpiarMensaje();
            gvMedico.EditIndex = e.NewEditIndex;
            cargarMedicos();
        }

        protected void gvMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedico.EditIndex = -1;
            cargarMedicos();
        }

        protected void gvMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Toma los valores de los Edit Item Templates y construye un objeto Medico
            //
            string legajo = ((Label)gvMedico.Rows[e.RowIndex].FindControl("lbl_eit_legajo")).Text;
            string dni = ((Label)gvMedico.Rows[e.RowIndex].FindControl("lbl_eit_dni")).Text;
            string nombre = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_nombre")).Text;
            string apellido = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text;
            string sexo = ((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_sexo")).SelectedValue;
            string telefono = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_telefono")).Text;
            int idNacionalidad = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_nacionalidad")).SelectedValue);
            DateTime fechaNacimiento = Convert.ToDateTime(((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_fechaNacimiento")).Text);
            string direccion = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_direccion")).Text;
            int idProvincia = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_provincia")).SelectedValue);
            int idLocalidad = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_localidad")).SelectedValue);
            string correo = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_correo")).Text;
            int idEspecialidad = Convert.ToInt32(((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_especialidad")).SelectedValue);

            Medico medico = new Medico(Convert.ToInt32(legajo), dni, nombre, apellido, sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, correo, telefono, idEspecialidad);

            string idUsuario = negocioUsuario.obtenerIdUsuarioConLegajo(legajo);
            string usuario = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_usuario")).Text;
            string contraseña = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_contraseña")).Text;

            bool modifico = neg.modificarMedico(medico);

            limpiarMensaje();

            // Ejecuta la transacción y muestra un mensaje con el resultado
            if (modifico)
            {
                lbl_mensaje.ForeColor = Color.Green;
                lbl_mensaje.Text = "Modificación de medico exitosa. ";

                modifico = negocioUsuario.actualizarUsuario(idUsuario, usuario, contraseña);
                
                if (modifico)
                {
                    lbl_mensaje.Text += "Modificacion de usuario exitosa";
                }
                else
                {
                    lbl_mensaje.Text += "Error al modificar usuario";
                }
            }
            else
            {
                lbl_mensaje.ForeColor = Color.Red;
                lbl_mensaje.Text = "Error en la operacion";
            }

            // Sale del modo edit, limpia el txt y carga la Grid
            gvMedico.EditIndex = -1;
            limpiarCampos();
            cargarMedicos();
        }

        protected void gvMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Si esta en modo edit
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                // ddl Para cargar los descolgables
                DropDownList ddList = (DropDownList)e.Row.FindControl("ddl_eit_nacionalidad");
                
                //Nacionalidades
                DataTable dt = negocioNacionalidad.getTable();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreNacionalidad_Nac";
                ddList.DataValueField = "IdNacionalidad_Nac";
                ddList.DataBind();

                //Iguala el valor seleccionado inicial al valor que está en la Grid normal
                DataRowView dr = (DataRowView)e.Row.DataItem;
                ddList.SelectedItem.Text = dr["NombreNacionalidad_Nac"].ToString();

                //Provincias
                ddList = (DropDownList)e.Row.FindControl("ddl_eit_provincia");
                dt = negocioProvincia.getTable();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreProvincia_Prov";
                ddList.DataValueField = "IdProvincia_Prov";
                ddList.DataBind();

                //Iguala el valor seleccionado inicial al valor que está en la Grid normal
                ddList.SelectedItem.Text = dr["NombreProvincia_Prov"].ToString();
                string idProvincia = ddList.SelectedValue;

                //Localidades de la Pcia seleccionada
                ddList = (DropDownList)e.Row.FindControl("ddl_eit_localidad");
                dt = negocioLocalidad.getTable(idProvincia);
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreLocalidad_Loc";
                ddList.DataValueField = "IdLocalidad_Loc";
                ddList.DataBind();

                //Iguala el valor seleccionado inicial al valor que está en la Grid normal
                ddList.SelectedItem.Text = dr["NombreLocalidad_Loc"].ToString();

                // Especialidades
                ddList = (DropDownList)e.Row.FindControl("ddl_eit_especialidad");
                dt = negocioEspecialidad.getTabla();
                ddList.DataSource = dt;
                ddList.DataTextField = "NombreEspecialidad_Esp";
                ddList.DataValueField = "IdEspecialidad_Esp";
                ddList.DataBind();

                //Iguala el valor seleccionado inicial al valor que está en la Grid normal
                ddList.SelectedItem.Text = dr["NombreEspecialidad_Esp"].ToString();

                //Convierte el formato de la fecha para que no muestre la parte horaria (00:00:00)
                TextBox txtbox = (TextBox)e.Row.FindControl("txt_eit_fechaNacimiento");
                txtbox.Text = (DateTime.Parse(dr["FechaNaciemiento_Med"].ToString())).ToString("yyyy-MM-dd");

                //Setea un valor maximo de fecha de nacimiento al valor de la fecha actual (hoy)
                RangeValidator rv = (RangeValidator)e.Row.FindControl("rv_eit_fechaNacimiento");
                rv.MaximumValue = DateTime.Now.ToShortDateString();
            }
        }

        protected void ddl_eit_provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Busca ID de la Provicia seleccionada
            string idProvincia = ((DropDownList)gvMedico.Rows[gvMedico.EditIndex].FindControl("ddl_eit_provincia")).SelectedValue;

            // Busca las localidades disponibles de la Provincia seleccionada y las carga en la ddl
            DropDownList ddList = (DropDownList)gvMedico.Rows[gvMedico.EditIndex].FindControl("ddl_eit_localidad");
            DataTable dt = negocioLocalidad.getTable(idProvincia);
            ddList.DataSource = dt;
            ddList.DataTextField = "NombreLocalidad_Loc";
            ddList.DataValueField = "IdLocalidad_Loc";
            ddList.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvMedico.EditIndex = -1;
            gvMedico.PageIndex = 0;
            
            limpiarMensaje();
            
            Session["LegajoABuscar"] = txtBuscar.Text;
            cargarMedicos();
        }
        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            limpiarMensaje();
            limpiarCampos();
            gvMedico.EditIndex = -1;
            gvMedico.PageIndex = 0;
            cargarMedicos();
        }

        protected void gvMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            limpiarMensaje();
            gvMedico.EditIndex = -1;
            gvMedico.PageIndex = e.NewPageIndex;
            cargarMedicos();
        }

        protected void lbl_it_fechaNacimiento_DataBinding1(object sender, EventArgs e)
        {
            // Conversión de formato para que no muestra hora (00:00:00)
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        private void limpiarCampos()
        {
            txtBuscar.Text = string.Empty;
            Session["legajoABuscar"] = "";
        }

        private void limpiarMensaje()
        {
            lbl_mensaje.Text = string.Empty;
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }
    }
}