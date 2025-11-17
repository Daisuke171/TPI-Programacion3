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

        public DataTable PromedioTiposDeSangre()
        {
            DataTable pacientes = daoPaciente.getTablaPacientesActivos();

            // crear tabla resultado
            DataTable resultado = new DataTable();
            resultado.Columns.Add("Tipo_Sangre");
            resultado.Columns.Add("Cantidad", typeof(int));
            resultado.Columns.Add("Porcentaje", typeof(string));

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
                resultado.Rows.Add(g.Tipo, g.Cantidad, g.Porcentaje.ToString("0.00") + "%");
            }

            return resultado;
        }
    }
}

