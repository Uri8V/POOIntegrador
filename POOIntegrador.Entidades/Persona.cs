using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POOIntegrador.Entidades
{
    [XmlInclude(typeof(Jugador))]
    [XmlInclude(typeof(DirectorTecnico))]
    public abstract class Persona
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
        }
        private string apellido;
        public string Apellido
        {
            get { return apellido; }
        }

        public Persona()
        {
            
        }
        public Persona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public abstract string FichaTecnica();
        public virtual string NombreCompleto()
        {
            return $"La persona se llama {nombre}, {apellido} ";
        }
    }
}
