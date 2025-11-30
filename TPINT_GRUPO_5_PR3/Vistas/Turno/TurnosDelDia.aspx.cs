using Entidades;
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

                if (tipoUsuario == "Medico") // || tipoUsuario == "Admin")
                {
                    //DateTime.Now.ToString("yyyy-MM-dd");
                    cargarTurnos();
                }
                else
                {   
                    Response.Redirect("~/Vistas/Inicio.aspx"); 
                }


            }

        }

        private void cargarTurnos()
        {
            gvListarTurnosDelDia.DataSource = negocioTurno.ObtenerTablaTurnosDiaPuntual(Session["LegajoMedico"].ToString());
            gvListarTurnosDelDia.DataBind();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void gvListarTurnosDelDia_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvListarTurnosDelDia.EditIndex = e.NewEditIndex;
            cargarTurnos();
        }

        protected void gvListarTurnosDelDia_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvListarTurnosDelDia.EditIndex = -1;
            cargarTurnos();
        }

        protected void lbl_it_fechaTurno_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void lbl_eit_fechaTurno_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void ddl_eit_asistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlAsistencia = (DropDownList)gvListarTurnosDelDia.Rows[gvListarTurnosDelDia.EditIndex].FindControl("ddl_eit_asistencia");
            TextBox txtObservacion = (TextBox)gvListarTurnosDelDia.Rows[gvListarTurnosDelDia.EditIndex].FindControl("txt_eit_observacion");
            if (ddlAsistencia.SelectedValue == "Ausente")
            {
                txtObservacion.Text = "Ausente";
                txtObservacion.Enabled = false;
            }
            else
            {
                txtObservacion.Enabled = true;
                txtObservacion.Text = string.Empty;
            }
        }

        protected void gvListarTurnosDelDia_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string idTurno = ((Label)gvListarTurnosDelDia.Rows[e.RowIndex].FindControl("lbl_eit_idTurno")).Text;
            string asistencia = ((DropDownList)gvListarTurnosDelDia.Rows[e.RowIndex].FindControl("ddl_eit_asistencia")).SelectedValue;
            string observacion = ((TextBox)gvListarTurnosDelDia.Rows[e.RowIndex].FindControl("txt_eit_observacion")).Text;

            bool actualizo = negocioTurno.actualizarAsistenciaTurno(idTurno, asistencia, observacion);

            lblMensaje.Text = string.Empty;

            if (actualizo)
            {
                lblMensaje.Text = "Turno actualizado correctamente";
            }
            else lblMensaje.Text = "Error al actualizar el turno";

            gvListarTurnosDelDia.EditIndex = -1;
            cargarTurnos();
        }
    }
}