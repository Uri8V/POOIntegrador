using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POOIntegrador.Entidades
{
    public class DirectorTecnico : Persona
    {
        private static Tipo tipo;
        static DirectorTecnico()
        {
            tipo = Tipo.Tecnico;
        }
        public DirectorTecnico()
        {
            
        }

        public DirectorTecnico(string nombre, string apellido) : base(nombre, apellido)
        {
        }
       
        public override string FichaTecnica()
        {
            return $"{Apellido.ToUpper()} {Nombre.ToUpper()}, director ténico";
        }
    }
}
