using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Informes
{
    public partial class Informes : System.Web.UI.Page
    {

        NegocioInformes negInf = new NegocioInformes();
        NegocioTurno negTurno = new NegocioTurno();
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
                    DataTable resultado = negInf.getCantidadPacientesPorMedico(true);
                    DataView dv = new DataView(resultado);
                    dv.RowFilter = "Cantidad > 0";

                    var series = chInformes.Series["Series1"];
                    var chartArea = chInformes.ChartAreas[0];

                    // Tipo de gráfico
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;  // Muestra los valores arriba de cada barra
                    series.XValueMember = "Medico";
                    series.YValueMembers = "Cantidad";

                    // Fuente del valor
                    series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    series.LabelForeColor = Color.White;

                    // Rotar textos del eje X
                    chartArea.AxisX.LabelStyle.Angle = -45;
                    chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    chartArea.AxisX.LabelStyle.ForeColor = Color.Black;

                    // Aplicar color degradado por barra
                    series.Color = Color.SteelBlue;
                    series.BackSecondaryColor = Color.LightSkyBlue;
                    series.BackGradientStyle = GradientStyle.VerticalCenter;

                    // Bordes suaves
                    series.BorderWidth = 2;
                    series.BorderColor = Color.FromArgb(50, 50, 50);

                    // ---- CONFIG VISUAL DEL ÁREA ----

                    // Fondo limpio minimalista
                    chartArea.BackColor = Color.FromArgb(245, 245, 245);

                    // Líneas de cuadrícula suaves
                    chartArea.AxisX.MajorGrid.Enabled = false;
                    chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                    // Títulos de los ejes
                    chartArea.AxisX.Title = "Médicos";
                    chartArea.AxisY.Title = "Cantidad de Pacientes";
                    chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                    chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);

                    // Fuente del eje
                    chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
                    chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

                    // Separación entre columnas
                    series["PointWidth"] = "0.5";

                    // Leyenda
                    chInformes.Legends.Clear();


                    chInformes.DataSource = dv;
                    chInformes.DataBind();

                    // GRIDVIEW
                    gvResultado.DataSource = dv;
                    gvResultado.DataBind();

                    chInformes.Visible = true;
                }

                else if(informe == "Cantidad de medicos por especialidad")
                {
                    DataTable resultado = negInf.getCantidadMedicosPorEspecialidad();

                    var series = chInformes.Series["Series1"];
                    var chartArea = chInformes.ChartAreas[0];

                    // Tipo de gráfico
                    series.ChartType = SeriesChartType.Column;
                    series.IsValueShownAsLabel = true;  // Muestra los valores arriba de cada barra
                    series.XValueMember = "Especialidades";
                    series.YValueMembers = "Cantidad de Medicos";

                    // Fuente del valor
                    series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    series.LabelForeColor = Color.White;

                    // Rotar textos del eje X
                    chartArea.AxisX.LabelStyle.Angle = -45;
                    chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    chartArea.AxisX.LabelStyle.ForeColor = Color.Black;

                    // Aplicar color degradado por barra
                    series.Color = Color.SteelBlue;
                    series.BackSecondaryColor = Color.LightSkyBlue;
                    series.BackGradientStyle = GradientStyle.VerticalCenter;

                    // Bordes suaves
                    series.BorderWidth = 2;
                    series.BorderColor = Color.FromArgb(50, 50, 50);

                    // ---- CONFIG VISUAL DEL ÁREA ----

                    // Fondo limpio minimalista
                    chartArea.BackColor = Color.FromArgb(245, 245, 245);

                    // Líneas de cuadrícula suaves
                    chartArea.AxisX.MajorGrid.Enabled = false;
                    chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                    // Títulos de los ejes
                    chartArea.AxisX.Title = "Médicos";
                    chartArea.AxisY.Title = "Cantidad de Pacientes";
                    chartArea.AxisX.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
                    chartArea.AxisY.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);

                    // Fuente del eje
                    chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
                    chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

                    // Separación entre columnas
                    series["PointWidth"] = "0.5";

                    series.Points.Clear();
                    chartArea.AxisX.Interval = 1;
                    chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.StaggeredLabels;

                    // Leyenda
                    chInformes.Legends.Clear();


                    chInformes.DataSource = resultado;
                    chInformes.DataBind();

                    gvResultado.DataSource = resultado;
                    gvResultado.DataBind();

                    chInformes.Visible = true;
                }
                else if (informe == "Dia con mas pacientes")
                {
                    DateTime desde = DateTime.Now.AddDays(-30);
                    DateTime hasta = DateTime.Now;

                    DataTable resultado = negTurno.getHeatmapTurnos(desde, hasta);

                    // Convertimos la tabla en formato calendario
                    DataTable calendario = ConvertirEnCalendario(resultado, desde, hasta);

                    // Mostramos en el GridView
                    gvResultado.DataSource = calendario;
                    gvResultado.DataBind();

                    // Aplicamos colores estilo GitHub
                    PintarHeatmap(gvResultado);

                    // Ocultamos el gráfico (ya no se usa para esta opción)
                    chInformes.Visible = false;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }



        public DataTable ConvertirEnCalendario(DataTable original, DateTime desde, DateTime hasta)
        {
            DataTable calendar = new DataTable();

            // columnas Lunes -> Domingo
            calendar.Columns.Add("Semana");
            calendar.Columns.Add("Lunes");
            calendar.Columns.Add("Martes");
            calendar.Columns.Add("Miércoles");
            calendar.Columns.Add("Jueves");
            calendar.Columns.Add("Viernes");
            calendar.Columns.Add("Sábado");
            calendar.Columns.Add("Domingo");

            int semana = 1;
            DataRow row = calendar.NewRow();
            row["Semana"] = "Semana " + semana;

            for (DateTime fecha = desde; fecha <= hasta; fecha = fecha.AddDays(1))
            {
                int dayIndex = ((int)fecha.DayOfWeek == 0) ? 7 : (int)fecha.DayOfWeek; // Domingo = 7

                // Buscar cantidad en la tabla original
                var match = original.AsEnumerable()
                    .FirstOrDefault(r => Convert.ToDateTime(r["Fecha"]).Date == fecha.Date);

                int cantidad = match != null ? Convert.ToInt32(match["CantidadTurnos"]) : 0;
                row[dayIndex] = cantidad;

                // Cuando llega a domingo → nueva semana
                if (dayIndex == 7)
                {
                    calendar.Rows.Add(row);
                    semana++;
                    row = calendar.NewRow();
                    row["Semana"] = "Semana " + semana;
                }
            }

            // Añadir última fila si no terminó en domingo
            if (row.ItemArray.Skip(1).Any(v => v != DBNull.Value))
                calendar.Rows.Add(row);

            return calendar;
        }

        public void PintarHeatmap(GridView grid)
        {
            foreach (GridViewRow row in grid.Rows)
            {
                for (int i = 1; i < row.Cells.Count; i++) // saltar columna "Semana"
                {
                    string valorStr = row.Cells[i].Text;
                    int valor = 0;

                    int.TryParse(valorStr, out valor);

                    Color color = Color.FromArgb(235, 237, 240); // base (gris claro)

                    if (valor == 0)
                        color = Color.FromArgb(235, 237, 240);
                    else if (valor < 3)
                        color = Color.FromArgb(198, 228, 139);
                    else if (valor < 6)
                        color = Color.FromArgb(123, 201, 111);
                    else if (valor < 10)
                        color = Color.FromArgb(35, 154, 59);
                    else
                        color = Color.FromArgb(25, 97, 39);

                    row.Cells[i].BackColor = color;
                    row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                    row.Cells[i].ForeColor = Color.Black;
                }
            }
        }

    }
}