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

    
    public partial class ConsultarTurno : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                }
                else
                {
                    CargarTurnos();
                }


            }
        }

        private void CargarTurnos()
        {
           
            gvConsultarTurnos.DataSource = negocioTurno.ObtenerTablaTurnos();
            gvConsultarTurnos.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void btnFiltrarDni_Click(object sender, EventArgs e)
        {
            int resultado;
            if (txtDni.Text == "" || int.TryParse(txtDni.Text.ToString(), out resultado) == false)
            {
                lblErrorDni.Text = "Por favor ingrese valores validos";
                txtDni.Text = null;
                return;
            }

            lblErrorLegajo.Text = " ";
            txtLegajo.Text = "";


            lblErrorDni.Text = " ";
            int dniBuscar = Convert.ToInt32(txtDni.Text);
            txtDni.Text = null;
            gvConsultarTurnos.DataSource = negocioTurno.obtenerTurnoPorDNI(dniBuscar);
            gvConsultarTurnos.DataBind();


        }

        protected void btnFiltrarLegajo_Click1(object sender, EventArgs e)
        {
            int resultado;
            if (txtLegajo.Text == "" || int.TryParse(txtLegajo.Text.ToString(), out resultado) == false)
            {
                lblErrorLegajo.Text = "Por favor ingrese valores validos";

                txtLegajo.Text = null;
            return;
            }


            lblErrorDni.Text = " ";
            txtDni.Text = "";


            lblErrorLegajo.Text = "";
            int legajoBuscar = Convert.ToInt32(txtLegajo.Text);
            txtLegajo.Text = null;
            gvConsultarTurnos.DataSource = negocioTurno.obtenerTurnoPorLegajoMedico(legajoBuscar);
            gvConsultarTurnos.DataBind();
            
        }


    }
}