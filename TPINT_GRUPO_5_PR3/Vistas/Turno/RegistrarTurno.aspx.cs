using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;  

namespace TPINT_GRUPO_5_PR3
{
    public partial class RegistrarTurno : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();
        NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
        NegocioMedico negMedico = new NegocioMedico();
        NegocioTurno negTurno = new NegocioTurno();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
                ddl_Especialidades.AutoPostBack = true;
                cal_Fechas.VisibleDate = DateTime.Today;
            }
        }

        private void CargarEspecialidades()
        {
            ddl_Especialidades.DataSource = negEspecialidad.getTabla();
            ddl_Especialidades.DataTextField = "NombreEspecialidad_Esp";
            ddl_Especialidades.DataValueField = "IdEspecialidad_Esp";
            ddl_Especialidades.DataBind();

            ddl_Especialidades.Items.Insert(0, "Seleccione una especialidad");
        }

        protected void btn_buscarPaciente_Click(object sender, EventArgs e)
        {
            string dni = txt_Dni.Text.Trim();

            if (dni == "")
            {
                lbl_Mensaje.Text = "Ingrese un DNI.";
                return;
            }

            DataTable dt = negPaciente.BuscarPacientePorDNI(dni);

            if (dt == null || dt.Rows.Count == 0)
            {
                lbl_Mensaje.Text = "No existe un paciente con ese DNI.";
                LimpiarLabelsPaciente();
                return;
            }

            DataRow row = dt.Rows[0];

            lbl_Nombre.Text = row["Nombre_Pac"].ToString();
            lbl_Apellido.Text = row["Apellido_Pac"].ToString();
            lbl_Sexo.Text = row["Sexo_Pac"].ToString();
            lbl_Telefono.Text = row["Telefono_Pac"].ToString();
            lbl_Correo.Text = row["CorreoElectronico_Pac"].ToString();

            lbl_Mensaje.Text = "";
        }

        private void LimpiarLabelsPaciente()
        {
            lbl_Nombre.Text = "";
            lbl_Apellido.Text = "";
            lbl_Sexo.Text = "";
            lbl_Telefono.Text = "";
            lbl_Correo.Text = "";
        }

        protected void ddl_Especialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Especialidades.SelectedIndex <= 0)
                return;

            int idEsp = int.Parse(ddl_Especialidades.SelectedValue);

            ddl_Medicos.DataSource = negMedico.listarMedicoPorEspecialidad(idEsp);
            ddl_Medicos.DataTextField = "Apellido_Med";
            ddl_Medicos.DataValueField = "Legajo_Med";
            ddl_Medicos.DataBind();

            ddl_Medicos.Items.Insert(0, "Seleccione un médico");

            rbtnl_Horarios.Items.Clear();
        }

        protected void cal_Fechas_SelectionChanged(object sender, EventArgs e)
        {
            if (ddl_Medicos.SelectedIndex <= 0)
            {
                lbl_Mensaje.Text = "Seleccione un médico primero.";
                return;
            }

            int legajo = int.Parse(ddl_Medicos.SelectedValue);
            DateTime fecha = cal_Fechas.SelectedDate;

            DataTable horarios = negTurno.ObtenerHorariosDisponibles(legajo, fecha);

            rbtnl_Horarios.Items.Clear();

            foreach (DataRow row in horarios.Rows)
            {
                rbtnl_Horarios.Items.Add(row["Horario"].ToString());
            }

            if (rbtnl_Horarios.Items.Count == 0)
                lbl_Mensaje.Text = "Sin horarios disponibles para esta fecha.";
            else
                lbl_Mensaje.Text = "";
        }

        protected void btn_Confirmar_Click(object sender, EventArgs e)
        {
            if (lbl_Nombre.Text == "")
            {
                lbl_Mensaje.Text = "Busque un paciente primero.";
                return;
            }

            if (ddl_Especialidades.SelectedIndex == 0 ||
                ddl_Medicos.SelectedIndex == 0 ||
                rbtnl_Horarios.SelectedIndex == -1)
            {
                lbl_Mensaje.Text = "Complete todos los datos del turno.";
                return;
            }

            int legajo = int.Parse(ddl_Medicos.SelectedValue);
            int dni = int.Parse(txt_Dni.Text);
            DateTime fecha = cal_Fechas.SelectedDate;
            string horario = rbtnl_Horarios.SelectedValue;

            bool ok = negTurno.RegistrarTurno(dni, legajo, fecha, horario);

            if (ok)
            {
                lbl_Mensaje.Text = "Turno registrado correctamente.";
                LimpiarTodo();
            }
            else
            {
                lbl_Mensaje.Text = "No se pudo registrar el turno. Puede estar ocupado.";
            }
        }

        private void LimpiarTodo()
        {
            txt_Dni.Text = "";
            LimpiarLabelsPaciente();
            ddl_Especialidades.SelectedIndex = 0;
            ddl_Medicos.Items.Clear();
            rbtnl_Horarios.Items.Clear();
            lbl_Mensaje.Text = "";
        }
    }
}