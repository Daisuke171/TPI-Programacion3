using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();
        NegocioNacionalidad negNacionalidad = new NegocioNacionalidad();
        NegocioLocalidad negLocalidad = new NegocioLocalidad();
        NegocioProvincia negProvincia = new NegocioProvincia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar los dropdownlists de Nacionalidades, Localidades y Provincias
                CargarNacionalidades();
                CargarLocalidades();
                CargarProvincias();
            }
        }

        protected void btnAltaPaciente_Click(object sender, EventArgs e)
        {
            int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue.ToString());
            DateTime fechaNacimiento = Convert.ToDateTime(txtBoxFecha.Text);
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue.ToString());
            bool confirmacion = negPaciente.agregarPaciente(txtBoxDNI.Text, txtBoxNombre.Text, txtBoxApellido.Text, ddlSexo.SelectedValue, idNacionalidad, fechaNacimiento, txtBoxDirecc.Text, idProvincia,
                                                    idLocalidad, (ddlTipoSangre1.SelectedValue + ddlTipoSangre2.SelectedValue), txtBoxCorreo.Text, txtBoxTelefono.Text);
        }

        private void CargarNacionalidades()
        {
            DataTable dataTableNac = negNacionalidad.getTable();
            ddlNacionalidad.DataSource = dataTableNac;
            ddlNacionalidad.DataTextField = "NombreNacionalidad_Nac";
            ddlNacionalidad.DataValueField = "IdNacionalidad_Nac";
            ddlNacionalidad.DataBind();

            ddlNacionalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarLocalidades()
        {
            DataTable datatableLoc = negLocalidad.getTable();
            ddlLocalidad.DataSource = datatableLoc;
            ddlLocalidad.DataTextField = "NombreLocalidad_Loc";
            ddlLocalidad.DataValueField = "IdLocalidad_Loc";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarProvincias()
        {
            DataTable datatableProv = negProvincia.getTable();
            ddlProvincia.DataSource = datatableProv;
            ddlProvincia.DataTextField = "NombreProvincia_Prov";
            ddlProvincia.DataValueField = "IdProvincia_Prov";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        
        }
    }
 }