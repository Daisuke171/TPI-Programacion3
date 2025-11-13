using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        public Paciente() { }

        public Paciente(int dni, string nombre, string apellido, string sexo, int idNacionalidad, DateTime fechaNacimiento, string direccionPaciente, int idProvincia, int idLocalidad, string tipoSangre, string correo, string telefono, bool estado)
        {
            DniPaciente = dni;
            NombrePaciente = nombre;
            ApellidoPaciente = apellido;
            SexoPaciente = sexo;
            IdNacionalidad = idNacionalidad;
            FechaNacimiento = fechaNacimiento;
            DireccionPaciente = direccionPaciente;
            IdProvincia = idProvincia;
            IdLocalidad = idLocalidad;
            TipoSangre = tipoSangre;
            CorreoElectronico = correo;
            TelefonoPaciente = telefono;
            EstadoPaciente = estado;
        }
        public int DniPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string SexoPaciente { get; set; }
        public int IdNacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DireccionPaciente { get; set; }
        public int IdProvincia { get; set; }
        public int IdLocalidad { get; set; }
        public string TipoSangre { get; set; }
        public string CorreoElectronico { get; set; }
        public string TelefonoPaciente{ get; set; }
        public bool EstadoPaciente { get; set; } = true;
    }
}







