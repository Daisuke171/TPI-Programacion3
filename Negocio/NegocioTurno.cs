using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Negocio
{
    public class NegocioTurno
    {
        DaoTurno daoTurno = new DaoTurno();

        public DataTable ObtenerHorariosDisponibles(int legajo, DateTime fecha)
        {
            return daoTurno.GetHorariosDisponibles(legajo, fecha);
        }

        public bool RegistrarTurno(int dniPaciente, int legajoMedico, DateTime fecha, string horario)
        {
            int filas = daoTurno.InsertarTurno(dniPaciente, legajoMedico, fecha, horario);
            return filas > 0;
        }

        public DataTable ObtenerTablaTurnos()
        {
            return daoTurno.getTablaTurnos();
        }
        
        public DataTable ObtenerTablaTurnosPorId(int id)
        {
            return daoTurno.getTablaTurnosPorId(id);
        }

        public bool ModificarTurno(int id, DateTime fecha, int legajo, int dni, string asistencia, string observacion)
        {
            return daoTurno.modificarTurno(id, fecha, legajo, dni, asistencia, observacion);
        }

        public DataTable obtenerTurnoPorDNI(int DNI)
        {
            return daoTurno.getTablaTurnosPorDNI(DNI);
        }

        public DataTable obtenerTurnoPorLegajoMedico(int legajo)
        {
            return daoTurno.getTablaTurnosPorLegajoMedico(legajo);
        }
    }
}
