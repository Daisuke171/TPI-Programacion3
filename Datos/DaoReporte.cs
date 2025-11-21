using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoReporte
    {
        AccesoDatos accesoDatos = new AccesoDatos();
        DaoTurno daoTurnos = new DaoTurno();


        public DataTable TurnosPorMedico(int legajo)
        {
                string consultaSql = "SELECT COUNT(LegajoMedico_Tur) AS 'CantidadTurnos' FROM Turnos" +
                                     " WHERE LegajoMedico_Tur = " + legajo +
                                     " GROUP BY LegajoMedico_Tur";

                return accesoDatos.obtenerTabla("tablaTurnos", consultaSql);
        }

        public DataTable TurnosPorDia(string fecha)
        {
            string consultaSql = "SELECT Fecha_Tur, Nombre_Pac, Apellido_Pac, Nombre_Med, Apellido_Med" +
                                " FROM Turnos "+
                                " INNER JOIN Medicos ON Turnos.LegajoMedico_Tur = Medicos.Legajo_Med" +
                                " INNER JOIN Pacientes ON Turnos.DNIPaciente_Tur = Pacientes.DNI_Pac WHERE Fecha_Tur = '" + fecha + "'";

            return accesoDatos.obtenerTabla("turnosPorFecha", consultaSql);

        }

    }
}
