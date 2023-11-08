using POOIntegrador.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOIntegrador.Datos
{
    public class Repositorio : IRepositorio<Persona>
    {
        public List<Persona> lista { get; set; }

        public int GetCantidad()
        {
           return lista.Count;
        }

        public List<Persona> GetLista()
        {
            return lista;
        }
        public Repositorio()
        {
            lista = new List<Persona>();
            lista = ManejadorArchivoSecuencial.LeerDatos("Personas.txt");
        }
    }
}
