using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POOIntegrador.Entidades
{
    public class Jugador:Persona
    {
        private static Tipo tipo;
        //private  Tipo tipo;
        static Jugador()
        {
            tipo = Tipo.Jugador;
        }
        public Jugador()
        {
            
        }
        public Jugador(string nombre, string apellido):base(nombre,apellido)
        {
            //this.tipo=Tipo.Jugador;
            this.numero = 0;
            this.esCapitan = false;
        }
        public Jugador(string nombre, string apellido, int numerom, bool esCapitan) : this(nombre,apellido) 
        {
           
            this.numero = numerom;
            this.esCapitan = esCapitan;
        }
        private bool esCapitan;
        private int numero;

        public int GetNumero() => numero;
        public bool GetEsCapitan() => esCapitan;
        public Tipo GetTipo() => tipo;


        public override string FichaTecnica()
        {
            StringBuilder sb = new StringBuilder();
            if(esCapitan==true)
            {
                sb.AppendLine($"{Apellido.ToUpper()} {Nombre}, capitan del equipo, camiseta número {numero}");
            }
            else
            {
                sb.AppendLine($"{Apellido.ToUpper()} {Nombre}, camiseta número {numero}");
            }
            return sb.ToString();
        }

        public static bool operator == (Jugador j, Jugador j2)
        {
            if(j.Apellido==j2.Apellido && j.Nombre==j2.Nombre && j.numero==j2.numero) 
            { 
            return true;
            }
            return false;
        }
        
        public static bool operator !=(Jugador j, Jugador j2)
        {
            return !(j== j2);
        }

        public static explicit operator int(Jugador v)
        {
            return v.numero;
        }

        public override bool Equals(object obj)
        {
            Jugador jugador = obj as Jugador;
            if(jugador!= null && this==jugador)
            {
                return true;
            }
            return false;
        }
    }
}
