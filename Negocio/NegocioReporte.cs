using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioReporte
    {
        DaoReporte daoReporte = new DaoReporte();
        public DataTable getCantTurnosMedicos(int legajo)
        {
            return daoReporte.TurnosPorMedico(legajo);
        }

        public DataTable getTurnosPorFecha(string fecha)
        {
            return daoReporte.TurnosPorDia(fecha);
        }
    }
}
