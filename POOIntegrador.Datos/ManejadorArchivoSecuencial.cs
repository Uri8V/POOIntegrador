using POOIntegrador.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOIntegrador.Datos
{
    public class ManejadorArchivoSecuencial
    {
        public static void Guardar(List<Persona> lista, string archivo)
        {
            using (var escritor = new StreamWriter(archivo, true))
            {
                foreach (var persona in lista)
                {
                    var linea = ConstruirLinea(persona);
                    escritor.WriteLine(linea);

                }
            }
        }

        private static string ConstruirLinea(Persona persona)
        {
            if (persona.GetType() == typeof(Jugador))
            {
                return
                    $"{persona.Nombre}|{persona.Apellido}|{((Jugador)persona).GetNumero()}|{((Jugador)persona).GetEsCapitan()}|{Tipo.Jugador}";
            }
            return $"{persona.Nombre}|{persona.Apellido}|{Tipo.Tecnico}";
        }

        public static List<Persona> LeerDatos(string archivo)
        {
            List<Persona> lista = new List<Persona>();
            if (!File.Exists(archivo))
            {
                return lista;
            }

            using (var lector = new StreamReader(archivo))
            {
                while (!lector.EndOfStream)
                {
                    var linea = lector.ReadLine();
                    Persona a = ConstruirPersona(linea);
                    lista.Add(a);
                }
            }

            return lista;
        }

        private static Persona ConstruirPersona(string linea)
        {
            Persona p;
            var campos = linea.Split('|');

            if (campos.Length == 5)
            {
                var nombre = campos[0];
                var apellido = campos[1];                
                var numero = int.Parse(campos[2]);
                var esCapitan = bool.Parse(campos[3]);
                var tipo = campos[4];
                p = new Jugador(nombre, apellido, numero, esCapitan);

            }
            else
            {
                var nombre = campos[0];
                var apellido = campos[1];
                var tipo = campos[2];
                p = new DirectorTecnico(nombre, apellido);
            }

            return p;
        }
    }
}
