using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Datos
{
    public class DaoInformes
    {
        DaoPaciente daoPaciente = new DaoPaciente();
        AccesoDatos accesoDatos = new AccesoDatos();

        public DataTable PromedioTiposDeSangre()
        {
            DataTable pacientes = daoPaciente.getTablaPacientesActivos();

            // crear tabla resultado
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Tipo_Sangre");
            resultado.Columns.Add("Cantidad", typeof(int));
            resultado.Columns.Add("Porcentaje", typeof(double));

            if (pacientes.Rows.Count == 0)
                return resultado;

            // se agrupa x IDTipoSangre
            var grupos = pacientes.AsEnumerable()
                .GroupBy(r => r["TipoSangre_Pac"])
                .Select(g => new
                {
                    Tipo = g.Key.ToString(),
                    Cantidad = g.Count(),
                    Porcentaje = (g.Count() * 100.0) / pacientes.Rows.Count
                });

            // se pasa a tabla
            foreach (var g in grupos)
            {
                resultado.Rows.Add(g.Tipo, g.Cantidad, g.Porcentaje);
            }

            return resultado;
        }

        // Cantidad de pacientes por médico
        // pacientesUnicos = true => COUNT(DISTINCT DNIPaciente_Tur)
        // pacientesUnicos = false => COUNT(DNIPaciente_Tur) (total de turnos)
        public DataTable CantidadPacientesPorMedico(bool pacientesUnicos = true)
        {
            string countExpr = pacientesUnicos
                ? "COUNT(DISTINCT t.DNIPaciente_Tur)"
                : "COUNT(t.DNIPaciente_Tur)";

            string sql = $@"
                SELECT 
                    m.Legajo_Med         AS Legajo,
                    (m.Nombre_Med + ' ' + m.Apellido_Med) AS Medico,
                    {countExpr}          AS Cantidad
                FROM Medicos m
                LEFT JOIN Turnos t 
                    ON t.LegajoMedico_Tur = m.Legajo_Med
                    AND t.Estado_Tur = 1
                WHERE m.Estado_Med = 1
                GROUP BY m.Legajo_Med, m.Nombre_Med, m.Apellido_Med
                ORDER BY Cantidad DESC, Medico ASC;";

            return accesoDatos.obtenerTabla("PacientesPorMedico", sql);
        }

        //Cantidad de Medicos por Especialidad
        public DataTable CantidadMedicosPorEspecialidad()
        {
            string consultaSql = @"SELECT NombreEspecialidad_Esp AS 'Especialidades', COUNT(DISTINCT Legajo_Med) AS 'Cantidad de Medicos' FROM Medicos 
                                  INNER JOIN Especialidades ON Medicos.IDEspecialidad_Med = Especialidades.IdEspecialidad_Esp
                                  GROUP BY NombreEspecialidad_Esp";
            return accesoDatos.obtenerTabla("MedicosPorEspecialidad", consultaSql);
        }
    }
}

