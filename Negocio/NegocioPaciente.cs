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

        public DataTable listarPacientesActivos()
        {
            return daoPaciente.getTablaPacientesActivos();
        }

        public DataTable listarPacientesActivos(string nombre, string orden, string filtroTSangre)
        {
            return daoPaciente.getTablaPacientesActivos(nombre, orden, filtroTSangre);
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

        public bool existeDniPaciente(string dni)
        {
            bool existe = daoPaciente.existeDniPaciente(dni);
            return existe;
        }

        public bool existeNombrePaciente(string nombre)
        {
            bool existe = daoPaciente.existeNombrePaciente(nombre);
            return existe;
        }

    }
}
