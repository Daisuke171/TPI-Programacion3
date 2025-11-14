using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente : Persona
    {
        public Paciente() { }

        public Paciente(int id, string dni, string nombre, string apellido, string sexo, int idNacionalidad, DateTime fechaNacimiento, string direccionPaciente, int idProvincia, int idLocalidad, string tipoSangre, string correo, string telefono, bool estado)
            : base(dni, nombre, apellido, sexo, idNacionalidad, fechaNacimiento, direccionPaciente, idProvincia, idLocalidad, correo, telefono)
        {   
            
            _tipoSangre = tipoSangre;
            _estadoPaciente = estado;
            _id = id;

        }
        public int _id { get; set; }
        public string _tipoSangre { get; set; }
        public bool _estadoPaciente { get; set; } = true;

       
       
    }
}