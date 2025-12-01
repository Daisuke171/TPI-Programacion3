using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPINT_GRUPO_5_PR3.Vistas
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblUsuario.Text = Session["usuario"]?.ToString();

                if (Session["TipoUsuario"] == null)
                {
                    Response.Redirect("~/Vistas/Inicio.aspx");
                    return;
                }

                Session["DNIABuscar"] = "";
                CargarPacientes();
            }
        }

        private void CargarPacientes()
        {
            string dni = Session["DNIABuscar"].ToString();
            DataTable dt = negPaciente.BuscarPacientes(dni);
            gvPaciente.DataSource = dt;
            gvPaciente.DataBind();
        }

        protected void gvPaciente_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            limpiarMensaje();

            string DNIAEliminar = ((Label)gvPaciente.Rows[e.RowIndex].FindControl("lbl_it_dni")).Text;

            ViewState["DNIAEliminar"] = DNIAEliminar;

            confirmModal.Visible = true;

            e.Cancel = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ViewState["DNIAEliminar"] != null)
            {
                string DNIAEliminar = ViewState["DNIAEliminar"].ToString();

                if (negPaciente.bajaPaciente(DNIAEliminar))
                {
                    gvPaciente.PageIndex = 0;
                    limpiarCampos();
                    lbl_confirmacion.ForeColor = Color.Green;
                    lbl_confirmacion.Text = "Paciente dado de baja correctamente";
                }
                else
                {
                    lbl_confirmacion.ForeColor = Color.Red;
                    lbl_confirmacion.Text = "Error al dar de baja al paciente";
                }

                // limpiar
                ViewState["DNIAEliminar"] = null;
                confirmModal.Visible = false;

                // mostrar grid inicial o mantiene los datos en caso de fallar
                CargarPacientes();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            confirmModal.Visible = false;
            ViewState["DNIAEliminar"] = null;
        }

        protected void lbl_it_nacimiento_DataBinding(object sender, EventArgs e)
        {
            // Conversion de la fecha para que no muestre hora (00:00:00)
            DateTime fecha = DateTime.Parse(((Label)sender).Text);
            ((Label)sender).Text = fecha.ToShortDateString();
        }

        protected void gvPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            limpiarMensaje();
            gvPaciente.PageIndex = e.NewPageIndex;
            CargarPacientes();
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            limpiarMensaje();
            Session["DNIABuscar"] = txtBoxDNI.Text;
            CargarPacientes();
        }
        protected void btnMostarTodos_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            limpiarMensaje();
            gvPaciente.PageIndex = 0;
            CargarPacientes();
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("~/Vistas/Login.aspx");
        }


        protected void limpiarCampos()
        {
            txtBoxDNI.Text = string.Empty;
            Session["DNIABuscar"] = "";
        }

        protected void limpiarMensaje()
        {
            lbl_confirmacion.Text = string.Empty;
        }
    }
}