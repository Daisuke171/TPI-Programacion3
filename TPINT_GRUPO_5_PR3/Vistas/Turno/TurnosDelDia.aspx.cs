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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuarioTurnosDelDia.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                }
                else
                {   
                    //DateTime.Now.ToString("yyyy-MM-dd");
                    gvListarTurnosDelDia.DataSource = negocioTurno.ObtenerTablaTurnosDiaPuntual(DateTime.Now);
                    gvListarTurnosDelDia.DataBind();
                }


            }
        }
    }
}