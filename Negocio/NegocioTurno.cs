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

        public DataTable ObtenerTablaTurnos(string legajoMedico = "LegajoMedico_Turno", string paciente = "", string asistencia = "Todos", string fechaI = "", string fechaF = "", int estado = 1)
        {
            return daoTurno.getTablaTurnos(legajoMedico, paciente, asistencia, fechaI, fechaF, estado);
        }

        //LA FECHA VA COMO AÑO-MES-DÍA

        public DataTable ObtenerTablaTurnosDiaPuntual(DateTime fecha, string legajoMedico)
        {
            return daoTurno.getTablaTurnosDiaPuntual(fecha, legajoMedico);
        }
        public DataTable ObtenerTablaTurnosDiaPuntual(string legajoMedico)
        {
            return daoTurno.getTablaTurnosDiaPuntual(legajoMedico);
        }

        public DataTable ObtenerTablaTurnosPorId(int id)
        {
            return daoTurno.getTablaTurnosPorId(id);
        }

        public bool ModificarTurno(Entidades.Turno turno)
        {
            return daoTurno.modificarTurno(turno);
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

        public bool actualizarAsistenciaTurno(string idTurno, string asistencia, string observacion)
        {
            return daoTurno.actualizarAsistenciaTurno(idTurno, asistencia, observacion);
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
