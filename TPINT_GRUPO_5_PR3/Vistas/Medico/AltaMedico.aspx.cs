using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioMedico negMedico = new NegocioMedico();
        NegocioNacionalidad negNacionalidad = new NegocioNacionalidad();
        NegocioLocalidad negLocalidad = new NegocioLocalidad();
        NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
        NegocioProvincia negProvincia = new NegocioProvincia();
        NegocioUsuario negUsuario = new NegocioUsuario();

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

                // Cargar los dropdownlists de Nacionalidades y Especialidades
                CargarNacionalidades();
                CargarEspecialidades();
                CargarProvincias();
                CargarLocalidades();
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

        private void CargarProvincias()
        {
            DataTable datatableProv = negProvincia.getTable();
            ddlProvincia.DataSource = datatableProv;
            ddlProvincia.DataTextField = "NombreProvincia_Prov";
            ddlProvincia.DataValueField = "IdProvincia_Prov";
            ddlProvincia.DataBind();

            ddlProvincia.Items.Insert(0, new ListItem("--Seleccione--", "0"));

        }

        private void CargarLocalidades()
        {
            string idProvincia = ddlProvincia.SelectedValue;
            DataTable datatableLoc = negLocalidad.getTable(idProvincia);
            ddlLocalidad.DataSource = datatableLoc;
            ddlLocalidad.DataTextField = "NombreLocalidad_Loc";
            ddlLocalidad.DataValueField = "IdLocalidad_Loc";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void CargarEspecialidades()
        {
            DataTable dataTableEsp = negEspecialidad.getTabla();
            ddlEspecialidad.DataSource = dataTableEsp;
            ddlEspecialidad.DataTextField = "NombreEspecialidad_Esp";
            ddlEspecialidad.DataValueField = "IdEspecialidad_Esp";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccione--", "0"));
        }

        private void limpiarCampos()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlSexo.SelectedIndex = 0;
            ddlNacionalidad.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            txtBoxFecha.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            ddlEspecialidad.SelectedIndex = 0;
        }

        protected void btnRegistrarMedico_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string sexo = ddlSexo.SelectedValue;
            int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue.ToString());
            DateTime fechaNacimiento = DateTime.Parse(txtBoxFecha.Text);
            string direccion = txtDireccion.Text;
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue.ToString());
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue.ToString());

            Medico medico = new Medico(negMedico.getNuevoLegajo(), dni, nombre, apellido, sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, correo, telefono, idEspecialidad, "", "", true);

            if (negMedico.existeDniMedico(medico._dni))
            {
                lblConfirmarSubirMedico.ForeColor = Color.Red;
                lblConfirmarSubirMedico.Text = "Error. El DNI " + medico._dni + " ya se encuentra registrado";
                return;
            }

            bool confirmacion = negMedico.agregarMedico(medico);

            if (confirmacion)
            {
                lblConfirmarSubirMedico.Text = "Medico  Subido Correctamente!";
                lblConfirmarSubirMedico.ForeColor = Color.Green;
                limpiarCampos();
                if (negUsuario.agregarUsuarioMedico(medico))
                {
                    negMedico.asignarUsuarioMedico(medico);
                    lblConfirmacionUsuarioMedico.Text = "Usuario " + medico._apellido + " registrado correctamente";
                    lblConfirmacionUsuarioMedico.ForeColor = Color.Green;
                }
            }
            else
            {
                lblConfirmarSubirMedico.Text = "El Medico  no se pudo subir";
                lblConfirmarSubirMedico.ForeColor = Color.Red;
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }
    }
}