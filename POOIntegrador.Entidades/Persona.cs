using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POOIntegrador.Entidades
{
    [XmlInclude(typeof(Jugador))]
    [XmlInclude(typeof(DirectorTecnico))]
    public class Persona
    {
        private string nombre;
        public string Apellido { get; set; }
        private string apellido;
        public string Nombre { get; set; }

        public Persona()
        {
        }
        public Persona(string nombre, string apellido)
        {
           Nombre = nombre;
           Apellido = apellido;
        }

        public virtual string FichaTecnica() {
            return "";
        }
        public virtual string NombreCompleto()
        {
            return $"La persona se llama {nombre}, {apellido} ";
        }
    }
}
