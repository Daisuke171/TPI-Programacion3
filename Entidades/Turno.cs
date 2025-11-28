using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        public Turno() { }
        public Turno(int id, DateTime fecha, int legajoMedico, int dniPaciente, string asistencia, string observacion)
        {
            _id = id;
            _fecha = fecha;
            _legajoMedico = legajoMedico;
            _dniPaciente = dniPaciente;
            _asistencia = asistencia;
            _observacion = observacion;
        }

        public int _id { get; set; }
        public DateTime _fecha { get; set; }
        public int _legajoMedico { get; set; }
        public int _dniPaciente { get; set; }
        public string _asistencia { get; set; }
        public string _observacion { get; set; }
        public bool _estadoTurno { get; set; } = true;
    }
}
