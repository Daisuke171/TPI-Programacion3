using Entidades;
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
    public partial class WebForm4 : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarPacientes();
            }
        }

        private void CargarPacientes()
        {
            bool pacActivo = true;
            DataTable tablaPaciente = negPaciente.listarPaciente(pacActivo);
            gvPaciente.DataSource = tablaPaciente;
            gvPaciente.DataBind();
        }

        protected void gvPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvPaciente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dni = ((Label)gvPaciente.Rows[e.RowIndex].FindControl("lbl_it_dni")).Text;
            if (negPaciente.bajaPaciente(dni))
            {
                lbl_confirmacion.Text = "Paciente dado de baja correctamente";
            }
            else
            {
                lbl_confirmacion.Text = "Error al dar de baja al paciente";
            }
            CargarPacientes();
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            string dni = txtBoxDNI.Text;
            if (negPaciente.bajaPaciente(dni))
            {
                lbl_confirmacion.Text = "Paciente dado de baja correctamente";
            }
            else
            {
                lbl_confirmacion.Text = "Error al dar de baja al paciente";
            }
            CargarPacientes();
        }
    }
}