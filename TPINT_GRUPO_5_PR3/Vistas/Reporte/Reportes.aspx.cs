using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Reporte
{
    public partial class Reportes : System.Web.UI.Page
    {
        NegocioTurno negTurno = new NegocioTurno();
        NegocioMedico negMedico = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) CargarGridView();
        }

        public void CargarGridView()
        {
            DataTable turnos = negTurno.ObtenerTablaTurnos();
            gvModificarTurno.DataSource = turnos;
            gvModificarTurno.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvModificarTurno_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DropDownList dl = (DropDownList)e.Row.FindControl("ddl_eit_legajoMedico");
            DataTable medicos = negMedico.listarMedico(true);
            dl.DataSource = medicos;
            dl.DataTextField = "NombreMedico_Med";
            dl.DataValueField = "Legajo_Med";
            dl.DataBind();
            DataRowView dr = e.Row.DataItem as DataRowView;
            dl.SelectedValue = dr["Legajo_Med"].ToString();
        }

        protected void gvModificarTurno_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}