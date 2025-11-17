using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMedico
    {
        DaoMedico daoMedico = new DaoMedico();
        public bool agregarMedico(Medico med)
        {
            DaoMedico dao = new DaoMedico();

            // esto es una validación combinada de DNI + Legajo único
            string consulta = $"SELECT * FROM Medicos WHERE DNI_Med = '{med._dni}' OR Legajo_Med = {med._legajoMedico}";
            if (new AccesoDatos().existe(consulta))
            {
                return false; // existe, no se puede cargar
            }

            return dao.insertarMedico(med);
        }

        public DataTable listarMedico(bool medActivo)
        {
            return daoMedico.getTableMedico(medActivo);
        }

        public bool existeDniMedico(string dni)
        {
            return daoMedico.existeDniMedico(dni);
        }

        public int getNuevoLegajo()
        {
            return daoMedico.generarLegajoMedico();
        }

        public bool bajaMedico(int legajo)
        {
            Medico medico = new Medico();
            medico._legajoMedico= legajo;
            if (daoMedico.eliminarMedico(medico) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool modificarMedico(Medico med)
        {
            return daoMedico.modificarMedico(med);
        }

        public DataTable listarMedicoPorEspecialidad(int idEspecialidad)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getMedicosPorEspecialidad(idEspecialidad);
        }


    }
}
