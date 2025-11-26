using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using System.Security.Permissions;

namespace Negocio
{
    public class NegocioTurno
    {
        DaoTurno daoTurno = new DaoTurno();

        public DataTable ObtenerHorariosDisponibles(int legajo, DateTime fecha)
        {
            return daoTurno.GetHorariosDisponibles(legajo, fecha);
        }

        public bool RegistrarTurno(int dniPaciente, int legajoMedico, DateTime fecha)
        {
            int filas = daoTurno.InsertarTurno(dniPaciente, legajoMedico, fecha);
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

        public DataTable obtenerTurnoPorDni(int DNI)
        {
            DataTable dtDNI = daoTurno.getTablaTurnosPorDNI(DNI);
            if (EstaDadoDeBaja(dtDNI) == false)
            {
                return dtDNI;
            }
            else
                {
                return null;
                }
        }

        public bool EstaDadoDeBaja(DataTable dataTable)
        {
            // Verifica si el DataTable es nulo primero,
            // lo que también puede considerarse "vacío".
            if (dataTable == null)
            {
                return true;
            }

            // Si el conteo de filas es 0, está vacía.
            if (dataTable.Rows.Count == 0)
            {
                return true;
            }

            // Si el conteo de filas es mayor que 0, no está vacía.
            return false;
        }

        public DataTable obtenerTurnoPorLegajoMedico(int legajo)
        {
            return daoTurno.getTablaTurnosPorLegajoMedico(legajo);
        }

        public DataTable getHeatmapTurnos(DateTime desde, DateTime hasta)
        {
            return daoTurno.GetCantidadTurnosPorDia(desde, hasta);
        }

    }
}
