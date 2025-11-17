using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class NegocioInformes
    {
        DaoInformes dao = new DaoInformes();

        public DataTable getPromedioTiposSangre()
        {
            return dao.PromedioTiposDeSangre();
        }

        public DataTable getCantidadPacientesPorMedico(bool pacientesUnicos = true)
        {
            return dao.CantidadPacientesPorMedico(pacientesUnicos);
        }

        public DataTable getCantidadMedicosPorEspecialidad()
        {
            return dao.CantidadMedicosPorEspecialidad();
        }
    }
}
