using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Informes
{
    public partial class Informes : System.Web.UI.Page
    {

        NegocioInformes negInf = new NegocioInformes();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("Inicio.aspx");
                    return;
                }

                CargarInformes();
            }
        }

        private void CargarInformes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Informes");

            dt.Rows.Add("Cantidad de pacientes por medico");
            dt.Rows.Add("Cantidad de medicos por especialidad");
            dt.Rows.Add("Promedios tipo de sangre");
            dt.Rows.Add("Dia con mas pacientes");

            gvInformes.DataSource = dt;
            gvInformes.DataBind();
        }

        protected void gvInformes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerInforme")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string informe = gvInformes.Rows[index].Cells[1].Text;

                if (informe == "Promedios tipo de sangre")
                {
                    DataTable resultado = negInf.getPromedioTiposSangre();
                    gvResultado.DataSource = resultado;
                    gvResultado.DataBind();

                    chInformes.Series["Series1"].Points.Clear();
                    chInformes.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;
                    chInformes.Series["Series1"].IsValueShownAsLabel = true;
                    chInformes.Series["Series1"].LabelForeColor = System.Drawing.Color.Black;
                    chInformes.Series["Series1"].Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
                    chInformes.Series["Series1"].Label = "#PERCENT{P1}";
                    chInformes.Series["Series1"].LegendText = "#VALX";

                    chInformes.Series["Series1"]["LabelStyle"] = "Outside";
                    chInformes.Series["Series1"]["LabelBorderColor"] = "Black";
                    chInformes.Series["Series1"]["LabelBorderWidth"] = "2";
                    chInformes.Series["Series1"]["LabelBackColor"] = "White";

                    chInformes.Series["Series1"].ShadowOffset = 2;

                    if (chInformes.Legends.Count == 0)
                    {
                        chInformes.Legends.Add("Leyenda");
                    }

                    chInformes.Legends[0].Enabled = true;
                    chInformes.Legends[0].Font = new Font("Segoe UI", 10);
                    chInformes.Legends[0].ForeColor = Color.Black;

                    chInformes.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.BrightPastel;
                    chInformes.Titles.Clear();
                    chInformes.Titles.Add("Promedio tipos de sangre");
                    chInformes.Titles[0].ForeColor = System.Drawing.Color.DarkBlue;
                    chInformes.Titles[0].Font = new System.Drawing.Font("Segoe UI", 15, System.Drawing.FontStyle.Bold);
                    chInformes.Series["Series1"].BorderColor = Color.Black;
                    chInformes.Series["Series1"].BorderWidth = 2;

                    foreach (DataRow r in resultado.Rows)
                    {
                        string tipo = r["Tipo_Sangre"].ToString();
                        double porcentaje = Convert.ToDouble(r["Porcentaje"]);

                        chInformes.Series["Series1"].Points.AddXY(tipo, porcentaje);
                    }

                    // Formatear porcentaje en la grilla después de bind
                    foreach (GridViewRow row in gvResultado.Rows)
                    {
                        double p = Convert.ToDouble(row.Cells[2].Text);
                        row.Cells[2].Text = p.ToString("0.00") + "%";
                    }

                    chInformes.Visible = true;
                }

                else if (informe == "Cantidad de pacientes por medico")
                {
                    DataTable resultado = negInf.getCantidadPacientesPorMedico(true); // true para pacientes únicos
                    gvResultado.DataSource = resultado;
                    gvResultado.DataBind();
                }

                else if(informe == "Cantidad de medicos por especialidad")
                {
                    DataTable resultado = negInf.getCantidadMedicosPorEspecialidad();
                    gvResultado.DataSource = resultado;
                    gvResultado.DataBind();
                }
                // if (informe == "Dia con mas pacientes") { ... }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}