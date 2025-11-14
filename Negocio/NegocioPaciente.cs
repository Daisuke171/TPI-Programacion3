using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPaciente
    {
        public bool agregarPaciente(string dni, string nombre, string apellido, string sexo, int idNacionalidad, DateTime fechaNacimiento, string direccion, int idProvincia, int idLocalidad, string tipoSangre, string correo, string telefono)
        {
            Paciente paciente = new Paciente(dni, nombre, apellido, sexo, idNacionalidad, fechaNacimiento, direccion, idProvincia, idLocalidad, tipoSangre, correo, telefono);
            DaoPaciente dao = new DaoPaciente();
            if(dao.insertarPaciente(paciente) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
