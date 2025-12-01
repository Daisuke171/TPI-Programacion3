using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TPINT_GRUPO_5_PR3.Vistas.Turno
{
    public partial class ModificarTurno : System.Web.UI.Page
    {
        NegocioTurno negTurno = new NegocioTurno();
        NegocioHorario negHorario = new NegocioHorario();
        NegocioMedico negMedico = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["usuario"]?.ToString();

            if (Session["TipoUsuario"] == null)
            {
                Response.Redirect("~/Vistas/Inicio.aspx");
            }

            if (!IsPostBack)
            {
                Session["apellidoABuscar"] = "";
                Session["DNIABuscar"] = "";
                cargarTurnos();
            }
        }

        public void cargarTurnos()
        {
            string apellido = Session["apellidoABuscar"].ToString();
            string dni = Session["DNIABuscar"].ToString();

            DataTable turnos = negTurno.ObtenerTurnosPorPaciente(apellido, dni);
            gvTurnos.DataSource = turnos;
            gvTurnos.DataBind();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            gvTurnos.EditIndex = -1;
            limpiarConfirmacion();
            cargarTurnos();
        }

        protected void gvTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(((Label)gvTurnos.Rows[e.RowIndex].FindControl("lbl_eit_idTurno")).Text);
            int anio = Convert.ToInt32(((Calendar)gvTurnos.Rows[e.RowIndex].FindControl("cl_eit_fechaTur")).SelectedDate.Year);
            int mes = Convert.ToInt32(((Calendar)gvTurnos.Rows[e.RowIndex].FindControl("cl_eit_fechaTur")).SelectedDate.Month); ;
            int dia = Convert.ToInt32(((Calendar)gvTurnos.Rows[e.RowIndex].FindControl("cl_eit_fechaTur")).SelectedDate.Day);
            int hora = Convert.ToInt32(((DropDownList)gvTurnos.Rows[e.RowIndex].FindControl("ddl_eit_horario")).SelectedItem.Text.Split(':')[0]);

            DateTime fecha = new DateTime(anio, mes, dia, hora, 0, 0);

            if (negTurno.ReprogramarTurno(id, fecha))
            {
                limpiarCampos();
                gvTurnos.PageIndex = 0;
                lblConfirmacion.Text = "Se modifico el turno con exito";
                lblConfirmacion.ForeColor = Color.Green;
            }
            else
            {
                lblConfirmacion.Text = "No se pudo modificar el turno";
                lblConfirmacion.ForeColor = Color.Red;
            }

            
            gvTurnos.EditIndex = -1;
            cargarTurnos();

        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                string legajo = ((Label)(e.Row.FindControl("lbl_eit_legajo"))).Text;
                Session["horariosMedico"] = negHorario.buscarHorarioXLegajo(legajo);

                ///Medicos
                Calendar calendario = (Calendar)e.Row.FindControl("cl_eit_fechaTur");

                DataRowView dr = e.Row.DataItem as DataRowView;
                calendario.SelectedDate = DateTime.Parse(dr["Fecha"].ToString());

                DropDownList ddlHorario = (DropDownList)e.Row.FindControl("ddl_eit_horario");
                DateTime fecha = calendario.SelectedDate;
                DataTable horarios = negTurno.ObtenerHorariosDisponibles(Convert.ToInt32(legajo), fecha);
                ddlHorario.DataSource = horarios;
                if (horarios.Rows.Count > 0)
                {
                    ddlHorario.Enabled = true;
                    ddlHorario.DataTextField = "Horario";
                    ddlHorario.DataValueField = "Horario";
                    ddlHorario.DataBind();
                    ddlHorario.SelectedItem.Text = dr["Horario"].ToString();

                }
                else
                {
                    ddlHorario.Items.Clear();
                    ddlHorario.Items.Insert(0, new ListItem("-- Sin horarios disponibles --", "0"));
                    ddlHorario.Enabled = false;
                }
            }
        }

        protected void gvTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            limpiarConfirmacion();

            cargarTurnos();
        }

        protected void gvTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            cargarTurnos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Session["apellidoABuscar"] = txtPaciente.Text;
            Session["DNIABuscar"] = txtDni.Text;

            limpiarConfirmacion();
            gvTurnos.EditIndex = -1;
            gvTurnos.PageIndex = 0;
            cargarTurnos();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            gvTurnos.PageIndex = 0;
            gvTurnos.EditIndex = -1;
            limpiarCampos();
            limpiarConfirmacion();
            cargarTurnos();
        }

        protected void cl_eit_fechaTur_DayRender(object sender, DayRenderEventArgs e)
        {
            DateTime fechaRender = e.Day.Date;
            bool diaSeleccionable = false;


            if (fechaRender > DateTime.Today)
            {
                foreach (DataRow row in ((DataTable)Session["horariosMedico"]).Rows)
                {
                    if (Convert.ToInt32(fechaRender.DayOfWeek) == Convert.ToInt32(row[2]))
                    {
                        diaSeleccionable = true;
                        break;
                    }
                }
            }

            e.Day.IsSelectable = diaSeleccionable;
        }

        protected void cl_eit_fechaTur_SelectionChanged(object sender, EventArgs e)
        {
            string legajo = ((Label)(gvTurnos.Rows[gvTurnos.EditIndex].FindControl("lbl_eit_legajo"))).Text;

            ///Medico

            DropDownList ddlHorario = (DropDownList)gvTurnos.Rows[gvTurnos.EditIndex].FindControl("ddl_eit_horario");
            DateTime fecha = ((Calendar)sender).SelectedDate;
            DataTable horarios = negTurno.ObtenerHorariosDisponibles(Convert.ToInt32(legajo), fecha);
            if (horarios.Rows.Count > 0)
            {
                ddlHorario.Enabled = true;
                ddlHorario.DataSource = horarios;
                ddlHorario.DataTextField = "Horario";
                ddlHorario.DataValueField = "Horario";
                ddlHorario.DataBind();
            }
            else
            {
                ddlHorario.Items.Clear();
                ddlHorario.Items.Insert(0, new ListItem("-- Sin horarios disponibles --", "0"));
                ddlHorario.Enabled = false;
            }
        }

        private void limpiarCampos()
        {
            txtDni.Text = string.Empty;
            txtPaciente.Text = string.Empty;
            Session["apellidoABuscar"] = "";
            Session["DNIABuscar"] = "";
        }

        private void limpiarConfirmacion()
        {
            lblConfirmacion.Text = string.Empty;
        }

        protected void lbl_it_fecha_DataBinding(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }
    }
}