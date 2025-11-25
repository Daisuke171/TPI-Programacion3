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
        NegocioMedico negMedico = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarGridView();
            }
        }

        public void CargarGridView()
        {
            DataTable turnos = negTurno.ObtenerTablaTurnos();
            gvTurnos.DataSource = turnos;
            gvTurnos.DataBind();
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            CargarGridView();
        }

        protected void gvTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(((Label)gvTurnos.Rows[e.RowIndex].FindControl("lbl_eit_idTurno")).Text);
            DateTime fecha = Convert.ToDateTime(((Calendar)gvTurnos.Rows[e.RowIndex].FindControl("cl_eit_fechaTur")).SelectedDate);
            int legajo = Convert.ToInt32(((DropDownList)gvTurnos.Rows[e.RowIndex].FindControl("ddl_eit_legajoMedico")).SelectedValue);
            int dni = Convert.ToInt32(((TextBox)gvTurnos.Rows[e.RowIndex].FindControl("txt_eit_DNIPac")).Text);
            string asistencia = Convert.ToString(((DropDownList)gvTurnos.Rows[e.RowIndex].FindControl("ddl_eit_asistencia")).SelectedItem.Text);
            string observacion = Convert.ToString(((TextBox)gvTurnos.Rows[e.RowIndex].FindControl("txt_eit_observacion")).Text);

            

            if(negTurno.ModificarTurno(id, fecha, legajo, dni, asistencia, observacion))
            {
                lblConfirmacion.Text = "Se modifico el turno con exito";
                lblConfirmacion.ForeColor = Color.Green;
            }
            else
            {
                lblConfirmacion.Text = "No se pudo modificar el turno";
                lblConfirmacion.ForeColor = Color.Red;
            }
           

        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                ///Medicos
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddl_eit_legajoMedico");
                DataTable dataTable = negMedico.listarMedico(true);
                ddl.DataSource = dataTable;
                ddl.DataTextField = "Apellido_Med";
                ddl.DataValueField = "Legajo_Med";
                ddl.DataBind();
                DataRowView dr = e.Row.DataItem as DataRowView;
                ddl.SelectedValue = dr["LegajoMedico_Tur"].ToString();
            }
        }

        protected void gvTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            CargarGridView();
        }

        protected void gvTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            CargarGridView();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdTurno.Text.Trim());
            DataTable tablaTurno = negTurno.ObtenerTablaTurnosPorId(id);
            gvTurnos.DataSource = tablaTurno;
            gvTurnos.DataBind();
        }
    }
}