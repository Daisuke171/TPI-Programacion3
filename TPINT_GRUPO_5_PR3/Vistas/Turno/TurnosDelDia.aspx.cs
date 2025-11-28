using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Turno
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();
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

                lblUsuarioTurnosDelDia.Text = Session["usuario"]?.ToString();
                string tipoUsuario = negUsuario.validarTipoUsuario(Session["usuario"]?.ToString());

                if (tipoUsuario == "Medico" || tipoUsuario == "Admin")
                {
                    //DateTime.Now.ToString("yyyy-MM-dd");
                    gvListarTurnosDelDia.DataSource = negocioTurno.ObtenerTablaTurnosDiaPuntual(DateTime.Now, Session["LegajoMedico"].ToString());
                    gvListarTurnosDelDia.DataBind();
                }
                else
                {   
                    Response.Redirect("~/Vistas/Inicio.aspx"); 
                }


            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }
    }
}