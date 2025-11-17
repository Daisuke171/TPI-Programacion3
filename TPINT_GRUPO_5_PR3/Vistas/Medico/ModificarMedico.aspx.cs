using System;
using Negocio;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

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

        protected void gvMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMedicos();
        }

        protected void gvMedico_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedico.EditIndex = -1;
            CargarMedicos();
        }

        protected void gvMedico_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string legajo = ((Label)gvMedico.Rows[e.RowIndex].FindControl("lbl_it_legajo")).Text;
            string dni = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_DNI")).Text;
            string nombre = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_Nombre")).Text;
            string apellido = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text;
            string sexo = ((DropDownList)gvMedico.Rows[e.RowIndex].FindControl("ddl_eit_Sexo")).SelectedValue;
            string telefono = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_telefono")).Text;
            string nacionalidad = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_nacionalidad")).Text;
            DateTime fechaNacimiento = Convert.ToDateTime(((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_FechaNacimiento")).Text);
            string direccion = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_direccion")).Text;
            string localidad = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_Localidad")).Text;
            string provincia = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_provincia")).Text;
            string correo = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_email")).Text;
            string especialidad = ((TextBox)gvMedico.Rows[e.RowIndex].FindControl("txt_eit_especialidad")).Text;


            int idNacionalidad = negocioNacionalidad.getId(nacionalidad);
            int idProvincia = negocioProvincia.getIdProvinciaPorNombre(provincia);
            int idLocalidad = negocioLocalidad.getId(localidad);
            int idEspecialidad = negocioEspecialidad.getId(especialidad);

            Medico medico = new Medico(Convert.ToInt32(legajo), dni, nombre, apellido, sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, correo, telefono, idEspecialidad, "", "", true);

            neg.modificarMedico(medico);
            gvMedico.EditIndex = -1;
            CargarMedicos();
        }
    }
}