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
                Console.WriteLine("¿Quieres seleccionar un personaje guardado? (S/N)");
                string opcion = Console.ReadLine();
                if (opcion.ToLower() == "s")
                {
                    return seleccionarPersonajes(personajes); // Llamada sin await
                }
                else
                {
                    return await crearYGuardarPersonaje(personajes);
                }
            }
            else
            {
                // Si no hay personajes, se puede crear uno nuevo directamente
                return await crearYGuardarPersonaje(personajes);
            }
        }

        private Personaje seleccionarPersonajes(List<Personaje> personajes)
        {
            Console.WriteLine("Elija un personaje por número: ");
            int numPersonaje;
            while (!int.TryParse(Console.ReadLine(), out numPersonaje) || numPersonaje < 1 || numPersonaje > personajes.Count)
            {
                Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
            }
            Personaje personajeElegido = personajes[numPersonaje - 1];
            Console.WriteLine("Seleccionó el siguiente personaje: ");
            Console.WriteLine(personajeElegido);
            return personajeElegido;
        }

        private async Task<Personaje> crearYGuardarPersonaje(List<Personaje> personajes)
        {
            Personaje personajeNuevo = await fabricaDePersonajes.crearPersonaje();
            personajes.Add(personajeNuevo);
            persistencia.GuardarPersonajes(personajes);
            Console.WriteLine("Se creó y guardó exitosamente el personaje");
            Console.WriteLine(personajeNuevo);
            return personajeNuevo;
        }
    }
}
