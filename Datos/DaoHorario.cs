using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoHorario
    {
        AccesoDatos ad = new AccesoDatos();
        public DaoHorario() { }

        public bool existeHorario(string legajo, string dia)
        {
            string consulta = $"SELECT * FROM DiasXMedico WHERE LegajoMedico_DiaXMed = '{legajo}' AND Dia_DiaXMed = '{dia}'";
            return ad.existe(consulta);
        }

        public bool insertarHorario(Horario horario)
        {
            SqlConnection cn = ad.obtenerConexion();

            string consulta = @"INSERT INTO DiasXMedico 
        (LegajoMedico_DiaXMed, Dia_DiaXMed, HoraEntrada_DiaXMed, HoraSalida_DiaXMed)
        VALUES
        (@Legajo, @Dia, @HoraEntrada, @HoraSalida);";

            SqlCommand cmd = new SqlCommand(consulta, cn);
            cmd.Parameters.AddWithValue("@Legajo", horario._legajo);
            cmd.Parameters.AddWithValue("@Dia", horario._dia);
            cmd.Parameters.AddWithValue("@HoraEntrada", horario._horaEntrada);
            cmd.Parameters.AddWithValue("@HoraSalida", horario._horaSalida);

            int filas = cmd.ExecuteNonQuery();
            cn.Close();

            return filas > 0;
        }
    }
}
