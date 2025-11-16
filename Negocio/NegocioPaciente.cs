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

        public DataTable listarPaciente(string nombre, bool pacActivo)
        {
            return daoPaciente.getTablePaciente(pacActivo, nombre);
        }

        public DataTable listarPaciente(string nombre, string filtro)
        {
            return daoPaciente.getTablePaciente(filtro, nombre);
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
