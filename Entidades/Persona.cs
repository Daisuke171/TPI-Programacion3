using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public Persona() { }

        public Persona(string dni, string nombre, string apellido, string sexo, int idNacionalidad, DateTime fechaNacimiento, string direccion, int idProvincia, int idLocalidad, string correoElectronico, string telefono)
        {
            _dni = dni;
            _nombre = nombre;
            _apellido = apellido;
            _sexo = sexo;
            _idNacionalidad = idNacionalidad;
            _fechaNacimiento = fechaNacimiento;
            _direccion = direccion;
            _idProvincia = idProvincia;
            _idLocalidad = idLocalidad;
            _correoElectronico = correoElectronico;
            _telefono = telefono;
        }

        public string _dni { get; set; }
        public string _nombre { get; set; }
        public string _apellido { get; set; }
        public string _sexo { get; set; }
        public int _idNacionalidad { get; set; }
        public DateTime _fechaNacimiento { get; set; }
        public string _direccion { get; set; }
        public int _idLocalidad { get; set; }
        public int _idProvincia { get; set; }
        public string _correoElectronico { get; set; }
        public string _telefono { get; set; }
    }
}
