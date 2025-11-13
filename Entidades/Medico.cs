using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        
        public Medico() { }

        public Medico(int legajoMedico, string dniMedico, string nombreMedico, string apellidoMedico, string sexoMedico, string nacionalidadMedico, DateTime fechaNacimiento, string direccionMedico, int idLocalidad, int idProvincia, string correoElectronico, string telefonoMedico, int idEspecialidad, string diasAtencion, string horarioAtencion, bool estadoMedico)    
        {
            LegajoMedico = legajoMedico;
            DniMedico = dniMedico;
            NombreMedico = nombreMedico;
            ApellidoMedico = apellidoMedico;
            SexoMedico = sexoMedico;
            NacionalidadMedico = nacionalidadMedico;
            FechaNacimiento = fechaNacimiento;
            DireccionMedico = direccionMedico;
            IdLocalidad = idLocalidad;
            IdProvincia = idProvincia;
            CorreoElectronico = correoElectronico;
            TelefonoMedico = telefonoMedico;
            IdEspecialidad = idEspecialidad;
            DiasAtencion = diasAtencion;
            HorarioAtencion = horarioAtencion;
            EstadoMedico = estadoMedico;
        }

        public int LegajoMedico { get; set; }
        public string DniMedico { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public string SexoMedico { get; set; }
        public string NacionalidadMedico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DireccionMedico { get; set; }
        public int IdLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public string DiasAtencion { get; set; }
        public string HorarioAtencion { get; set; }
        public bool EstadoMedico { get; set; } = true; 
    }
}
