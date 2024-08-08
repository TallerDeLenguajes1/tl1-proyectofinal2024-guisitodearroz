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
            
            Console.WriteLine("\nSeleccionó el siguiente personaje:\n ");
            
            Console.ForegroundColor= ConsoleColor.Green; 
            
            Console.WriteLine($" Nombre: {personajeElegido.Dato.Nombre} \n Apodo: {personajeElegido.Dato.Apodo} \n Tipo: {personajeElegido.Dato.Tipo} \n Edad: {personajeElegido.Dato.Edad} \n Lugar De Nacimiento {personajeElegido.Dato.LugarNacimiento} \n Salud: {personajeElegido.Caracteristica.Salud}\n Armadura: {personajeElegido.Caracteristica.Armadura}\n Fuerza: {personajeElegido.Caracteristica.Fuerza}\n Velocidad: {personajeElegido.Caracteristica.Velocidad}\n Nivel: {personajeElegido.Caracteristica.Nivel}\n Destreza: {personajeElegido.Caracteristica.Destreza}\n");
            
            return personajeElegido;
        }

        private async Task<Personaje> crearYGuardarPersonaje(List<Personaje> personajes)
        {
            Personaje personajeNuevo = await fabricaDePersonajes.crearPersonaje();
            personajes.Add(personajeNuevo);
            persistencia.GuardarPersonajes(personajes);
            Console.WriteLine("\nSe creó y guardó exitosamente el personaje\n");
            Console.ForegroundColor= ConsoleColor.Green; 
            Console.WriteLine($" Nombre: {personajeNuevo.Dato.Nombre} \n Apodo: {personajeNuevo.Dato.Apodo} \n Tipo: {personajeNuevo.Dato.Tipo} \n Edad: {personajeNuevo.Dato.Edad} \n Lugar De Nacimiento {personajeNuevo.Dato.LugarNacimiento} \n Salud: {personajeNuevo.Caracteristica.Salud}\n Armadura: {personajeNuevo.Caracteristica.Armadura}\n Fuerza: {personajeNuevo.Caracteristica.Fuerza}\n Velocidad: {personajeNuevo.Caracteristica.Velocidad}\n Nivel: {personajeNuevo.Caracteristica.Nivel}\n Destreza: {personajeNuevo.Caracteristica.Destreza}\n");
            
            //Console.WriteLine(personajeNuevo);
            return personajeNuevo;
        }
    }
}
