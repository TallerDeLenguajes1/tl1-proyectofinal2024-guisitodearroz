using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using personajes;
try
{ 
    Persistencia persistencia= new Persistencia();
    string opcion;
    do
    {
        Console.ForegroundColor= ConsoleColor.DarkBlue;
        Console.WriteLine("¡Bienvenido a batallas de Fantasia!");
        Console.WriteLine("1-Seleccionar o crear un Personaje");
        Console.WriteLine("2-Salir");
        Console.WriteLine("3-Salon de la Fama");
        Console.WriteLine("Elija una opcion: ");
        opcion = Console.ReadLine();

        if (opcion == "1")
        {
            gestionarPersonajes gestorPersonaje = new gestionarPersonajes();
            Personaje personaje = await gestorPersonaje.SeleccionarPersonajeOCrearlo();

            if (personaje != null)
            {
                List<Personaje> enemigos = new List<Personaje>();
                for (int i = 0; i < 10; i++)
                {
                    Personaje enemigo = await fabricaDePersonajes.crearEnemigo();
                    enemigos.Add(enemigo);
                }

                Batalla.Combate(personaje, enemigos);

                Console.WriteLine("Combate Finalizado");
                //Console.WriteLine(personaje.ToString());
            }
        }else if(opcion=="3")
        {
          persistencia.mostrarSalonDeLaFama();
        }
        else if (opcion != "2")
        {
            Console.WriteLine("Opción incorrecta");
        }

    } while (opcion != "2");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    throw;
}
