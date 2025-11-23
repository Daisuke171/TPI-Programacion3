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
using static System.Net.Mime.MediaTypeNames;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class ListarMedico : System.Web.UI.Page
    {

        NegocioMedico neg = new NegocioMedico();
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            lblErrorListarPacientes.Text = " ";
            if (ddlFiltros.SelectedIndex == 0)
            {
                lblErrorListarPacientes.Text = "Por favor seleccione un filtro";
                lblErrorListarPacientes.ForeColor = Color.Green;
            }
            int resultado;
            ////VALIDAR QUE SOLO ACEPTE NUMEROS
            if(ddlFiltros.SelectedIndex == 1)
            {   

                ////Si es un numero, el try parse da true y pasa, en caso contrario se pide que se ingrese nuevamente, y se hace un return.
                if (int.TryParse(txtboxNombreMedico.Text.ToString(), out resultado) == false){
                    lblErrorListarPacientes.Text = "Por favor ingrese solo numeros para buscar por legajo";
                    lblErrorListarPacientes.ForeColor = Color.Red;
                    return;
                }

                lblErrorListarPacientes.Text = " ";

                gvMedico.DataSource = neg.listarMedicoPorLegajo(int.Parse(txtboxNombreMedico.Text));
                gvMedico.DataBind();
            }
            ////VALIDAR QUE SOLO ACEPTE LETRAS
            else if(ddlFiltros.SelectedIndex == 2)
            {
                
                lblErrorListarPacientes.Text = " ";

                ////Si es un numero, el try parse da false y entra, se pide que se ingrese nuevamente, y se hace un return.
                ////En caso contrario, si el try parse da false, pasa de largo y busca.
                if (int.TryParse(txtboxNombreMedico.Text.ToString(), out resultado) == true)
                {
                    lblErrorListarPacientes.Text = "Por favor ingrese solo letras para buscar por nombre";
                    lblErrorListarPacientes.ForeColor = Color.Red;
                    return;
                }
                lblErrorListarPacientes.Text = " ";
                gvMedico.DataSource = neg.listarMedicoPorNombre(txtboxNombreMedico.Text);
                gvMedico.DataBind();
            }

        }

        protected void lbl_it_nacimiento_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }
    }
}