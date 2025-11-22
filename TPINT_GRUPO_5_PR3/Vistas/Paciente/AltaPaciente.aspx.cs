using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                    return;
                }

                // Cargar los dropdownlists de Nacionalidades, Localidades y Provincias
                CargarNacionalidades();
                CargarProvincias();
                CargarLocalidades();
            }
        }

        protected void btnAltaPaciente_Click(object sender, EventArgs e)
        {
            // CREA OBJ PACIENTE CON LOS DATOS INGRESADOS
            string dni = txtBoxDNI.Text;
            string nombre = txtBoxNombre.Text;
            string apellido = txtBoxApellido.Text;
            string sexo = ddlSexo.SelectedValue;
            int idNacionalidad = Convert.ToInt32(ddlNacionalidad.SelectedValue.ToString());
            DateTime fechaNacimiento = DateTime.Parse(txtBoxFecha.Text);
            string direccion = txtBoxDirecc.Text;
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue.ToString());
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue.ToString());
            string tipoSangre = ddlTipoSangre.SelectedValue;
            string correo = txtBoxCorreo.Text;
            string telefono = txtBoxTelefono.Text;

            Paciente paciente = new Paciente(dni, nombre, apellido, sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, tipoSangre, correo, telefono);

            // BUSCA SI EL DNI YA EXISTE Y CORTA SI SÍ
            if (negPaciente.existeDniPaciente(paciente._dni))
            {
                lblConfirmarSubirPaciente.ForeColor = Color.Red;
                lblConfirmarSubirPaciente.Text = "Error. El DNI " + paciente._dni + " ya se encuentra registrado";
                return;
            }

            // REGISTRO DEL PACIENTE
            bool confirmacion = negPaciente.agregarPaciente(paciente);

            if (confirmacion)
            {
                lblConfirmarSubirPaciente.Text = "Paciente Subido Correctamente!";
                lblConfirmarSubirPaciente.ForeColor = Color.Green;
                LimpiarCampos();
            }
            else
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


        public void LimpiarCampos()
        {
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