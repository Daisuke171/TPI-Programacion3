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
    public partial class WebForm4 : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();
                CargarPacientes();
            }
        }

        private void CargarPacientes()
        {
            DataTable tablaPaciente = negPaciente.listarPacientesActivos();
            gvPaciente.DataSource = tablaPaciente;
            gvPaciente.DataBind();
        }

        protected void gvPaciente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dni = ((Label)gvPaciente.Rows[e.RowIndex].FindControl("lbl_it_dni")).Text;
            if (negPaciente.bajaPaciente(dni))
            {
                lbl_confirmacion.ForeColor = Color.Green;
                lbl_confirmacion.Text = "Paciente dado de baja correctamente";
            }
            else
            {
                lbl_confirmacion.ForeColor = Color.Red;
                lbl_confirmacion.Text = "Error al dar de baja al paciente";
            }
            CargarPacientes();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string dni = txtBoxDNI.Text;

            if (negPaciente.existeDniPaciente(dni))
            {
                bool elimino = negPaciente.bajaPaciente(dni);
                
                if (elimino)
                {
                    lbl_confirmacion.ForeColor = Color.Green;
                    lbl_confirmacion.Text = "Paciente dado de baja correctamente";
                }
                else
                {
                    lbl_confirmacion.ForeColor = Color.Red;
                    lbl_confirmacion.Text = "Error al dar de baja al paciente";
                }
                CargarPacientes();
            }
            else
            {
                lbl_confirmacion.ForeColor = Color.Red;
                lbl_confirmacion.Text = "El DNI ingresado no está registrado";
            }

            lblUsuario.Text = string.Empty;
        }

        protected void lbl_it_nacimiento_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void gvPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaciente.PageIndex = e.NewPageIndex;
            CargarPacientes();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}