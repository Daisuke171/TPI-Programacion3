using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
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
                CargarPacientes();
            }
        }

    private void CargarPacientes()
        {
            bool PacActivos = false;
            DataTable tablaPacientes = neg.listarPacientesActivos();
            gvPaciente.DataSource = tablaPacientes;
            gvPaciente.DataBind();
        }

        protected void gvPaciente_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPaciente.EditIndex = e.NewEditIndex;
            CargarPacientes();
        }

        protected void gvPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        protected void gvPaciente_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
           gvPaciente.EditIndex = -1;
           CargarPacientes();
        }

        protected void gvPaciente_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dni = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_DNI")).Text;
            string nombre = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_Nombre")).Text;
            string apellido = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text;
            string sexo = ((DropDownList)gvPaciente.Rows[e.RowIndex].FindControl("ddl_eit_Sexo")).SelectedValue;
            string nacionalidad = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_nacion")).Text;
            DateTime fechaNacimiento = Convert.ToDateTime(((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_nacimiento")).Text);
            string direccion = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_direccion")).Text;
            string localidad = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_Localidad")).Text;
            string provincia = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_provincia")).Text;
            string tipoSangre = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_sangre")).Text;
            string correo = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_email")).Text;
            string telefono = ((TextBox)gvPaciente.Rows[e.RowIndex].FindControl("txt_eit_celu")).Text;

            int idNacionalidad = negocioNacionalidad.getId(nacionalidad);
            int idProvincia = negocioProvincia.getIdProvinciaPorNombre(provincia);
            int idLocalidad = negocioLocalidad.getId(localidad);

            Paciente paciente = new Paciente (dni, nombre,  apellido,  sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, tipoSangre, correo, telefono, true);

            neg.modificarPaciente(paciente);
            gvPaciente.EditIndex = -1;
            CargarPacientes();
        }
    }
}