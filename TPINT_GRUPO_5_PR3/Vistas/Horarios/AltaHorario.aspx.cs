using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas.Horarios
{
    public partial class AltaHorario : System.Web.UI.Page
    {
        NegocioMedico negMedico = new NegocioMedico();
        NegocioHorario negHorario = new NegocioHorario();
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

            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }

        protected void btnBuscarLegajo_Click(object sender, EventArgs e)
        {
            lbl_mensaje2.Text = string.Empty;
            lbl_mensaje1.Text = string.Empty;

            int legajo = Convert.ToInt32(txtLegajo.Text);
            lbl_mensaje1.Text = string.Empty;

            if (negMedico.existeLegajoMedico(legajo.ToString()))
            {
                txtLegajo.Text = string.Empty;

                DataTable dt = negMedico.listarMedicoPorLegajo(legajo);
                DataRow dr = dt.Rows[0];

                lblLegajo.Text = dr["Legajo_Med"].ToString();
                lblMedico.Text = dr["Nombre_Med"].ToString() + " " + dr["Apellido_Med"].ToString();
                lblEspecialidad.Text = dr["NombreEspecialidad_Esp"].ToString();
            }
            else
            {
                lbl_mensaje1.Text = "El legajo no está registrado en el sistema";
            }
        }

        protected void btnRegistrarHorario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblLegajo.Text.Trim()))
            {
                lbl_mensaje2.Text = "Error. Ingrese un legajo";
                return;
            }

            string legajo = lblLegajo.Text;
            string dia = ddl_dia.SelectedValue;
            TimeSpan horaEntrada = TimeSpan.Parse(ddl_horaEntrada.SelectedValue);
            TimeSpan horaSalida = TimeSpan.Parse(ddl_horaSalida.SelectedValue);

            if (negHorario.existeHorario(legajo, dia))
            {
                lbl_mensaje2.Text = "Error. El medico ya tiene un horario registrado para ese dia";
                return;
            }

            Horario horario = new Horario(Convert.ToInt32(dia), Convert.ToInt32(legajo), horaEntrada, horaSalida);

            if (negHorario.registrarHorario(horario))
            {
                lbl_mensaje2.ForeColor = Color.Green;
                lbl_mensaje2.Text = "Horario registrado correctamente";
                limpiarCampos();
            }
            else
            {
                lbl_mensaje2.ForeColor = Color.Red;
                lbl_mensaje2.Text = "Error al registrar el horario";
            }
        }

        private void limpiarCampos()
        {
            ddl_dia.SelectedIndex = 0;
            ddl_horaEntrada.SelectedIndex = 0;
            ddl_horaSalida.SelectedIndex = 0;
        }
    }
}