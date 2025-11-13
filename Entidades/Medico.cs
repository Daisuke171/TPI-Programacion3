using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico : Persona
    {
        
        public Medico() { }

        public Medico(int legajoMedico, string dniMedico, string nombreMedico, string apellidoMedico, string sexoMedico, int idNacionalidadMedico, DateTime fechaNacimiento, string direccionMedico, int idProvincia, int idLocalidad, string correoElectronico, string telefonoMedico, int idEspecialidad, string diasAtencion, string horarioAtencion, bool estadoMedico)
            : base(dniMedico, nombreMedico, apellidoMedico, sexoMedico, idNacionalidadMedico, fechaNacimiento, direccionMedico, idProvincia, idLocalidad, correoElectronico, telefonoMedico)
        {
            _legajoMedico = legajoMedico;
            _idEspecialidad = idEspecialidad;
            _diasAtencion = diasAtencion;
            _horarioAtencion = horarioAtencion;
            _estadoMedico = estadoMedico;
        }
        public int _legajoMedico { get; set; }
        public int _idEspecialidad { get; set; }
        public string _diasAtencion { get; set; }
        public string _horarioAtencion { get; set; }
        public bool _estadoMedico { get; set; } = true; 
    }
}