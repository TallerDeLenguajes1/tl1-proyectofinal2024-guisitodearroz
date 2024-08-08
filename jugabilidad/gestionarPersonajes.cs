using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace personajes
{
    public class gestionarPersonajes
    {
        Persistencia persistencia;

        public gestionarPersonajes()
        {
            persistencia = new Persistencia();
        }

        public async Task<Personaje> SeleccionarPersonajeOCrearlo()
        {
            List<Personaje> personajes = persistencia.LeerPersonajes();
            if (personajes.Count > 0)
            {
                Console.WriteLine("Se encontraron personajes: ");
                for (int i = 0; i < personajes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {personajes[i]}");
                }
                string opcion;
                do
                {
                    Console.WriteLine("¿Quieres seleccionar un personaje guardado? (S/N)");
                    opcion = Console.ReadLine();
                } while (opcion != "s" && opcion != "n");
                if (opcion.ToLower() == "s")
                {
                    return seleccionarPersonajes(personajes);
                }
                else
                {
                    return await crearYGuardarPersonaje(personajes);
                }
            }
            else
            {
                // Si no hay personajes, se crea uno nuevo directamente
                return await crearYGuardarPersonaje(personajes);
            }
        }

        private Personaje seleccionarPersonajes(List<Personaje> personajes)
        {
            Console.WriteLine("-------------Elija un personaje por número: -------------");
            int numPersonaje;
            while (!int.TryParse(Console.ReadLine(), out numPersonaje) || numPersonaje < 1 || numPersonaje > personajes.Count)
            {
                Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
            }
            Personaje personajeElegido = personajes[numPersonaje - 1];
            Console.WriteLine("\n");
            Console.WriteLine("Seleccionó el siguiente personaje: ");
            Console.WriteLine("\n");
            Console.ForegroundColor= ConsoleColor.Green; 
            Console.WriteLine(personajeElegido);
            Console.WriteLine("\n");
            return personajeElegido;
        }

        private async Task<Personaje> crearYGuardarPersonaje(List<Personaje> personajes)
        {
            Personaje personajeNuevo = await fabricaDePersonajes.crearPersonaje();
            personajes.Add(personajeNuevo);
            persistencia.GuardarPersonajes(personajes);
            Console.WriteLine("\n");
            Console.WriteLine("Se creó y guardó exitosamente el personaje");
            Console.WriteLine("\n");
            Console.ForegroundColor= ConsoleColor.Green; 
            Console.WriteLine($" Nombre: {personajeNuevo.Dato.Nombre} \n Apodo: {personajeNuevo.Dato.Apodo} \n Tipo: {personajeNuevo.Dato.Tipo} \n Edad: {personajeNuevo.Dato.Edad} \n Lugar De Nacimiento {personajeNuevo.Dato.LugarNacimiento} \n Salud: {personajeNuevo.Caracteristica.Salud}\n Armadura: {personajeNuevo.Caracteristica.Armadura}\n Fuerza: {personajeNuevo.Caracteristica.Fuerza}\n Velocidad: {personajeNuevo.Caracteristica.Velocidad}\n Nivel: {personajeNuevo.Caracteristica.Nivel}\n Destreza: {personajeNuevo.Caracteristica.Destreza}\n");
            
            //Console.WriteLine(personajeNuevo);
            return personajeNuevo;
        }
    }
}
