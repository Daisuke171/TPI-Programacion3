using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
                AND dxm.Dia_DiaXMed = DATEPART(WEEKDAY, @fecha)
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
                horarios.Rows.Add(h.ToString(@"hh\:mm"));
            }

            // sacar horarios ya ocupados
            string consultaOcupados = @"
                SELECT Observacion_Tur
                FROM Turnos
                WHERE LegajoMedico_Tur = @legajo
                AND Fecha_Tur = @fecha
                AND Estado_Tur = 1
            ";

            SqlCommand cmdOcupados = new SqlCommand(consultaOcupados, cn);
            cmdOcupados.Parameters.AddWithValue("@legajo", legajoMedico);
            cmdOcupados.Parameters.AddWithValue("@fecha", fecha);

            SqlDataReader reader = cmdOcupados.ExecuteReader();

            List<string> ocupados = new List<string>();
            while (reader.Read())
            {
                ocupados.Add(reader["Observacion_Tur"].ToString());
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
        public int InsertarTurno(int dni, int legajo, DateTime fecha, string horario)
        {
            SqlConnection cn = ad.obtenerConexion();

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

            // aca se inserta el turno
            string insertar = @"
                INSERT INTO Turnos (Fecha_Tur, LegajoMedico_Tur, DNIPaciente_Tur, Observacion_Tur, Asistencia_Tur, Estado_Tur)
                VALUES (@fecha, @legajo, @dni, @horario, 'Pendiente', 1)
            ";

            SqlCommand cmdInsert = new SqlCommand(insertar, cn);
            cmdInsert.Parameters.AddWithValue("@fecha", fecha);
            cmdInsert.Parameters.AddWithValue("@legajo", legajo);
            cmdInsert.Parameters.AddWithValue("@dni", dni);
            cmdInsert.Parameters.AddWithValue("@horario", horario);

            int filas = cmdInsert.ExecuteNonQuery();

            cn.Close();
            return filas;
        }
    }
}
