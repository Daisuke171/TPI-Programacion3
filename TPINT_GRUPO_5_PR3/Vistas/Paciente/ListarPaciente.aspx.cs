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
    public partial class ListarPaciente : System.Web.UI.Page
    {
        NegocioPaciente neg = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }
        private void CargarPacientes()
        {
            bool pacActivo = true;
            DataTable tablaPaciente = neg.listarPaciente(pacActivo);
            gvPacientes.DataSource = tablaPaciente;
            gvPacientes.DataBind();
        }

        protected void lbl_it_nacimiento_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            CargarPacientes();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtboxNombrePaciente.Text;

            bool pacienteExiste = neg.existeNombrePaciente(nombre);

            if (pacienteExiste)
            {
                if (ddlFiltros.SelectedValue == "0")
                {
                    gvPacientes.DataSource = neg.listarPaciente(nombre, true);
                    gvPacientes.DataBind();
                }
                else
                {
                    string filtro = ddlFiltros.SelectedValue;
                    gvPacientes.DataSource = neg.listarPaciente(nombre, filtro);
                    gvPacientes.DataBind();
                }
            
            }
            else
            {
                // ACA FALTARÍA UN LABEL ACLARATORIO QUE NO HAY NINGUN PACIENTE CON ESE NOMBRE
            }

            txtboxNombrePaciente.Text = string.Empty;

        }
    }
}