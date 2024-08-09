using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using personajes;
try
{ 
    Persistencia persistencia= new Persistencia();
    string opcion;
    string titulo= "¡Bienvenido a batallas de Fantasia!\n";
    string combateF="Combate Finalizado";
    do
    {
        Console.ForegroundColor= ConsoleColor.DarkBlue;
        Console.WriteLine("\n");
        Texto.ImprimirTituloResaltado(titulo);
        Console.WriteLine("\n");
        Console.WriteLine("1-Seleccionar o crear un Personaje");
        Console.WriteLine("2-Salon de la Fama");
        Console.WriteLine("3-Panteon de los caidos");
        Console.WriteLine("4-Salir");
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
                Texto.ImprimirTituloResaltado(combateF);
                Console.WriteLine("\n");
                Thread.Sleep(3000);
            }
        }else if(opcion=="2")
        {
          persistencia.mostrarSalonDeLaFama();
        }
        else if (opcion == "3")
        {
            persistencia.mostrarPanteonDeLosCaidos();
        }else if(opcion == "4")
        {
            Texto.ImprimirTextoCentrado("Nos vemos pronto\n");
        }

    } while (opcion != "4");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    throw;
}
