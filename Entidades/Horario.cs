using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario
    {
        public Horario() { }

        public Horario(int dia, int legajo, TimeSpan horaEntrada, TimeSpan horaSalida)
        {
            _dia = dia;
            _legajo = legajo;
            _horaEntrada = horaEntrada;
            _horaSalida = horaSalida;
        }

        public int _dia { get; set; }
        public int _legajo { get; set; }
        public TimeSpan _horaEntrada { get; set; }
        public TimeSpan _horaSalida { get; set; }

    }
}
