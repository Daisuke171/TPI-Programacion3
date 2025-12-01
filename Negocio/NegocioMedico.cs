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
            // esto es una validación combinada de DNI + Legajo único
            string consulta = $"SELECT * FROM Medicos WHERE DNI_Med = '{med._dni}' OR Legajo_Med = {med._legajoMedico}";
            if (new AccesoDatos().existe(consulta))
            {
                return false; // existe, no se puede cargar
            }
            return daoMedico.insertarMedico(med);
        }

        public DataTable buscarMedicos(string dni = "", string apellido = "", string especialidad = "Todos", string orden = "Legajo_Med")
        {
            return daoMedico.getTablaMedicos(dni, apellido, especialidad, orden);
        }

        public bool existeDniMedico(string dni)
        {
            return daoMedico.existeDniMedico(dni);
        }

        public bool existeLegajoMedico(string legajo)
        {
            return daoMedico.existeLegajoMedico(legajo);
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

        public DataTable listarMedicoPorLegajo( int legajo)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getMedicoPorLegajo(legajo);
        }

        public DataTable listarMedicoPorNombre(string nombre)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getMedicoPorNombre(nombre);
        }

        public void asignarUsuarioMedico(Medico med)
        {
            daoMedico.asignarUsuario(med);
        }
    }
}
