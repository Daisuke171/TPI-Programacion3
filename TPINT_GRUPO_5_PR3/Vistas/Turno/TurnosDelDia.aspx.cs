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

        protected void btn_it_Confirmar_Click(object sender, EventArgs e)
        {
            // 1. Obtener el botón clickeado
            Button btn = (Button)sender;

            // 2. Obtener la fila donde está ese botón
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            // 3. Buscar el label con el ID
            Label lblId = (Label)row.FindControl("lblIdTurno");

            // 4. Convertir a entero y usarlo
            int id = int.Parse(lblId.Text);
            
            negocioTurno.actualizarAsistenciaTurno(id, true);
        }

        protected void btn_it_ausente(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            Label lblId = (Label)row.FindControl("lblIdTurno");
            int id = int.Parse(lblId.Text);
            negocioTurno.actualizarAsistenciaTurno(id, false);
        }
    }
}