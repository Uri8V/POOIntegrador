using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POOIntegrador.Entidades
{

    public class Equipo
    {
        public List<Jugador> jugadores;
        private DirectorTecnico directorTecnico;
        private string nombre;
        private static Deporte deporte;
        


        public Deporte Deporte
        {
            set { deporte = value; }
        }
        static Equipo()
        {
            deporte = Deporte.Futbol;
        }

        public Equipo()
        {
            jugadores = new List<Jugador>();
            deporte = Deporte.Futbol;
        }
        public Equipo(string nombre, DirectorTecnico director):this()
        {
            this.nombre = nombre;
            this.directorTecnico = director;
        }
        public Equipo(string nombre, DirectorTecnico director, Deporte deport):this(nombre, director)
        {
            Deporte = deport;
        }

        public static bool operator ==(Equipo equipo, Jugador j)
        {
            foreach (var item in equipo.jugadores)
            {
                if (item == j)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Equipo equipo, Jugador j)
        {
            return !(equipo == j);
        }

        public static bool operator +(Equipo equipo, Jugador j)
        {
            if(equipo == j)
            {
                return false;
            }
            if (j.GetEsCapitan())
            {
                if (!ExisteCapitan(equipo))
                {
                    equipo.jugadores.Add(j);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            equipo.jugadores.Add(j);
            return true;
        }

        private static bool ExisteCapitan(Equipo equipo)
        {
            foreach (var item in equipo.jugadores)
            {
                if (item.GetEsCapitan())
                {
                    return true;
                }
            }
            return false;
        }



        public static bool operator -(Equipo equipo, Jugador j)
        {
            if (equipo != j)
            {
                return false;
            }
            equipo.jugadores.Remove(j);
            return true;
        }

        public static implicit operator string(Equipo v)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(v.nombre);
            sb.AppendLine("Nómina jugadores: ");
            foreach (var item in v.jugadores)
            {
                sb.AppendLine(item.FichaTecnica());
            }
            sb.AppendLine(v.directorTecnico.FichaTecnica());
            return sb.ToString();
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> lista= new List<Persona>();
            lista.Add(directorTecnico);
            foreach (var item in jugadores)
            {
                lista.Add(item);
            }
            return lista;
        }
    }
}
