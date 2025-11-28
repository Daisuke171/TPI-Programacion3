using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoTurno
    {
        AccesoDatos ad = new AccesoDatos();


        // obtener los horarios disponibles para un medico en una fecha dada
        public DataTable GetHorariosDisponibles(int legajoMedico, DateTime fecha)
        {
            SqlConnection cn = ad.obtenerConexion();

            string consulta = @"
                SELECT 
                    dxm.HoraEntrada_DiaXMed,
                    dxm.HoraSalida_DiaXMed
                FROM DiasXMedico dxm
                WHERE dxm.LegajoMedico_DiaXMed = @legajo
                AND dxm.Dia_DiaXMed = DATEPART(WEEKDAY, @fecha)-1
            ";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@legajo", legajoMedico);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

        
            //si el medico no puede atender en ese dia, devolveria tabla vacia
            if (tabla.Rows.Count == 0)
            {
                cn.Close();
                return tabla;
            }

            // generar LISTA DE HORARIOS disponibles
            DataRow row = tabla.Rows[0];
            TimeSpan horaInicio = (TimeSpan)row["HoraEntrada_DiaXMed"];
            TimeSpan horaFin = (TimeSpan)row["HoraSalida_DiaXMed"];

            DataTable horarios = new DataTable();
            horarios.Columns.Add("Horario");

            for (TimeSpan h = horaInicio; h < horaFin; h = h.Add(TimeSpan.FromHours(1)))
            {
                horarios.Rows.Add(h.ToString());
            }

            // sacar horarios ya ocupados
            string consultaOcupados = @"
                SELECT CAST (Fecha_Turno AS TIME) AS HoraTurno
                FROM TurnosPrueba
                WHERE LegajoMedico_Turno = @legajo
                AND CAST (Fecha_Turno AS DATE) = @fecha
                AND Estado_Turno = 1
            ";

            SqlCommand cmdOcupados = new SqlCommand(consultaOcupados, cn);
            cmdOcupados.Parameters.AddWithValue("@legajo", legajoMedico);
            cmdOcupados.Parameters.AddWithValue("@fecha", fecha);

            SqlDataReader reader = cmdOcupados.ExecuteReader();

            List<string> ocupados = new List<string>();
            while (reader.Read())
            {
                ocupados.Add(reader["HoraTurno"].ToString());
            }
            reader.Close();

            // eliminar los horarios ocupados
            for (int i = horarios.Rows.Count - 1; i >= 0; i--)
            {
                if (ocupados.Contains(horarios.Rows[i]["Horario"].ToString()))
                {
                    horarios.Rows.RemoveAt(i);
                }
            }

            cn.Close();
            return horarios;
        }


        //insertar turno 
        public int InsertarTurno(int dni, int legajo, DateTime fecha)
        {
            SqlConnection cn = ad.obtenerConexion();

            /*
            // valida q no haya superposicion de turnos
            string validar = @"
                SELECT * 
                FROM Turnos 
                WHERE LegajoMedico_Tur = @legajo
                AND Fecha_Tur = @fecha
                AND Observacion_Tur = @horario
                AND Estado_Tur = 1
            ";

            SqlCommand cmdValidar = new SqlCommand(validar, cn);
            cmdValidar.Parameters.AddWithValue("@legajo", legajo);
            cmdValidar.Parameters.AddWithValue("@fecha", fecha);
            cmdValidar.Parameters.AddWithValue("@horario", horario);

            SqlDataReader reader = cmdValidar.ExecuteReader();

            if (reader.Read())
            {
                cn.Close();
                return 0; // turno ocupado
            }
            reader.Close();
            */

            // aca se inserta el turno
            string insertar = @"
                INSERT INTO TurnosPrueba (Fecha_Turno, LegajoMedico_Turno, DNIPaciente_Turno, Asistencia_Turno, Estado_Turno)
                VALUES (@fecha, @legajo, @dni, 'Pendiente', 1)
            ";

            SqlCommand cmdInsert = new SqlCommand(insertar, cn);
            cmdInsert.Parameters.AddWithValue("@fecha", fecha);
            cmdInsert.Parameters.AddWithValue("@legajo", legajo);
            cmdInsert.Parameters.AddWithValue("@dni", dni);

            int filas = cmdInsert.ExecuteNonQuery();

            cn.Close();
            return filas;
        }

        //TRAER LA TABLA DE TURNOS
        public DataTable getTablaTurnos()
        {
            DataTable tablaTurnos = ad.obtenerTabla("Turnos", "SELECT * FROM TURNOS");
            return tablaTurnos;
        }


        //LA FECHA VA COMO AÑO, MES, DÍA
        public DataTable getTablaTurnosDiaPuntual(DateTime fecha, string legajoMedico)
        {

            SqlConnection cn = ad.obtenerConexion();

            string consulta = @"SELECT * FROM TURNOS WHERE Fecha_Tur = @fecha AND Asistencia_Tur = 'Pendiente' AND LegajoMedico_Tur = @legajoMedico";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@fecha", fecha.Date);
            cmd.Parameters.AddWithValue("@legajoMedico", Convert.ToInt32(legajoMedico));


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tablaTurnos = new DataTable();
            da.Fill(tablaTurnos);

            cn.Close();
            return tablaTurnos;

        }

        public DataTable getTablaTurnosPorId(int id)
        {
            DataTable tablaTurnos = ad.obtenerTabla("Turnos", "SELECT * FROM TURNOS WHERE IdTurno_Tur = " + id);
            return tablaTurnos;
        }

        public bool modificarTurno(Entidades.Turno turno)
        {
            SqlConnection cn = ad.obtenerConexion();

            string consulta = @"UPDATE Turnos SET
                        Fecha_Tur = @Fecha,
                        LegajoMedico_Tur = @Legajo,
                        DNIPaciente_Tur = @Dni,
                        Asistencia_Tur = @Asistencia,
                        Observacion_Tur = @Observacion";

            if(turno._asistencia != "Cancelado")
            {
                consulta += ", Estado_Tur = 1 WHERE IdTurno_Tur = @idTurno";
            }
            else
            {
                consulta += ", Estado_Tur = 0 WHERE IdTurno_Tur = @idTurno";    
            }
                SqlCommand cmd = new SqlCommand(consulta, cn);

            cmd.Parameters.AddWithValue("@idTurno", turno._id);
            cmd.Parameters.AddWithValue("@Fecha", turno._fecha);
            cmd.Parameters.AddWithValue("@Legajo", turno._legajoMedico);
            cmd.Parameters.AddWithValue("@Dni", turno._dniPaciente);
            cmd.Parameters.AddWithValue("@Asistencia", turno._asistencia);
            cmd.Parameters.AddWithValue("@Observacion", turno._observacion);
            

            int filas = cmd.ExecuteNonQuery();
            cn.Close();

            return filas > 0;
        }

        public DataTable getTablaTurnosPorDNI(int DNI)
        {
            DataTable tablaTurnos = ad.obtenerTabla("Turnos", "SELECT * FROM Turnos t INNER JOIN Pacientes p ON t.DNIPaciente_Tur = p.DNI_Pac WHERE t.DNIPaciente_Tur = " + DNI + "AND p.Estado_Pac = 1");
            return tablaTurnos;
        }

        public DataTable getTablaTurnosPorLegajoMedico(int legajo)
        {
            DataTable tablaTurnos = ad.obtenerTabla("Turnos", "SELECT * FROM TURNOS WHERE LegajoMedico_Tur = " + legajo);
            return tablaTurnos;
        }

        public DataTable GetCantidadTurnosPorDia(DateTime desde, DateTime hasta)
        {
            SqlConnection cn = ad.obtenerConexion();

            string consulta = @"
                            SELECT 
                                Fecha_Tur AS Fecha,
                                COUNT(*) AS CantidadTurnos
                            FROM Turnos
                            WHERE Estado_Tur = 1
                            AND Fecha_Tur BETWEEN @desde AND @hasta
                            GROUP BY Fecha_Tur
                            ORDER BY Fecha_Tur";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            da.Fill(tabla);

            cn.Close();
            return tabla;
        }
    }
}
