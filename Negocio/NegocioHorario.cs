using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioHorario
    {
        DaoHorario daoHorario = new DaoHorario();
        public NegocioHorario() { }

        public bool existeHorario(string legajo, string dia)
        {
            return daoHorario.existeHorario(legajo, dia);
        }

        public bool registrarHorario(Horario horario)
        {
            return daoHorario.insertarHorario(horario);
        }
    }
}
