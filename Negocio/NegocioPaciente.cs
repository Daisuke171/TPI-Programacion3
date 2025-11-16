using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPaciente
    {
        DaoPaciente daoPaciente = new DaoPaciente();
        public bool agregarPaciente(Paciente paciente)
        {
            if(daoPaciente.insertarPaciente(paciente) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable listarPaciente(bool pacActivo)
        {
            return daoPaciente.getTablePaciente(pacActivo);
        }

        public bool bajaPaciente(string dni)
        {
            Paciente paciente = new Paciente();
            paciente._dni = dni;
            if (daoPaciente.eliminarPaciente(paciente) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool buscarPaciente(string dni)
        {
            bool existe = daoPaciente.existePaciente(dni);
            return existe;
        }


    }
}
