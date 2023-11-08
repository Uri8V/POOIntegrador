using POOIntegrador.Datos;
using POOIntegrador.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace POOIntegrador.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DirectorTecnico director = new DirectorTecnico("Jorge", "Habeger");
            Equipo equipo1 = new Equipo("Huracán de San Rafael Futbol", director, Deporte.Futbol);
            Jugador j = new Jugador("NAVAS", "Jose", 23, false);
            Jugador j2 = new Jugador("Maibel", "Americo", 3, false);
            Jugador j3 = new Jugador("Sebastian", "Muirel", 45, false);
            Jugador j4 = new Jugador("Esteban", "Esi", 10, true);
            Jugador j5 = new Jugador("Romero", "Ezequiel", 20, true);
            var ingresar = equipo1 + j;
            var ingresar2 = equipo1 + j2;
            var ingresar3 = equipo1 + j3;
            var ingresar4 = equipo1 + j4;


            if (!(equipo1 + j5))
            {
                Console.WriteLine("No se puede ingresar capitan");
            }
            //string valor = equipo1;
            //Serializador<List<Jugador>>.GuardarXml("Jugadores.xml", equipo1.jugadores);
            //Console.WriteLine(valor);
            Repositorio repositorio= new Repositorio();
            if (repositorio.GetCantidad() > 0)
            {
                foreach (var item in repositorio.GetLista())
                {
                    Console.WriteLine(item.Apellido);
                }
            }
       
            Console.ReadLine();
        }
    }
}
