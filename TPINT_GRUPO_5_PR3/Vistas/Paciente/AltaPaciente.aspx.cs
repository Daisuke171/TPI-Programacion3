using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
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

            if (DateTime.TryParse(txtBoxFecha.Text, out DateTime fechaNacimiento))
            {
                fechaNacimiento = Convert.ToDateTime(txtBoxFecha.Text);
                lblFechaError.Text = string.Empty;
            }
            else
            {
                lblFechaError.Text = "Fecha invalida";
                return;
            }    

            int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue.ToString());
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue.ToString());
            bool confirmacion = negPaciente.agregarPaciente(txtBoxDNI.Text, txtBoxNombre.Text, txtBoxApellido.Text, ddlSexo.SelectedValue, idNacionalidad, fechaNacimiento, txtBoxDirecc.Text, idProvincia,
            idLocalidad, ddlTipoSangre.SelectedValue, txtBoxCorreo.Text, txtBoxTelefono.Text);

            

            if (confirmacion)
            {
                lblConfirmarSubirPaciente.Text = "Paciente Subido Correctamente!";
                lblConfirmarSubirPaciente.ForeColor = Color.Green;


                txtBoxDNI.Text = string.Empty;
                txtBoxNombre.Text = string.Empty;
                txtBoxApellido.Text = string.Empty;
                ddlSexo.SelectedIndex = 0;
                ddlNacionalidad.SelectedIndex = 0;
                txtBoxFecha.Text = string.Empty;
                txtBoxDirecc.Text = string.Empty;
                ddlProvincia.SelectedIndex = 0;
                ddlLocalidad.SelectedIndex = 0;
                ddlTipoSangre.SelectedIndex = 0;
                txtBoxCorreo.Text = string.Empty;
                txtBoxTelefono.Text = string.Empty;

            }
            else if (!confirmacion)
            {
                lblConfirmarSubirPaciente.Text = "El paciente no se pudo subir";
                lblConfirmarSubirPaciente.ForeColor = Color.Red;
            }
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