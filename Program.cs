using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using personajes;
try
{
  while (true)
  {
    Console.WriteLine("¡Bienvenido a batallas de Fantasia!");
    Console.WriteLine("1-Seleccionar o crear un Personaje");
    Console.WriteLine("2-Salir");
    Console.WriteLine("Elija una opcion: ");
    string opcion= Console.ReadLine();
    if (opcion == "1")
    {
      gestionarPersonajes gestorPersonaje= new gestionarPersonajes();
      Personaje personaje= await gestorPersonaje.SeleccionarPersonajeOCrearlo();
      if (personaje != null)
      {
        List<Personaje> enemigos= new List<Personaje>();
        for (int i = 0; i < 10; i++)
        {
          Personaje enemigo= await fabricaDePersonajes.crearEnemigo();
          enemigos.Add(enemigo);
        }
        Batalla.Combate(personaje,enemigos);

        Console.WriteLine("Combate Finalizado");
        Console.WriteLine(personaje.ToString());
      }
    }else if(opcion == "2")
    {
      break;
    }else{
      Console.WriteLine("opcion incorrecta");
    }
  }
}
catch (Exception ex)
{
  Console.WriteLine($"Error: {ex.Message}"); 
  throw;
}







//try
//   Persistencia persistencia= new Persistencia();
//   List<Personaje> personajes= persistencia.LeerPersonajes();
//   if (personajes.Count > 0)
//   {
//     Console.WriteLine("Se encontraron Personajes Guardados");
//     for (int i = 0; i < personajes.Count; i++)
//     {
//       Console.WriteLine($"{i + 1}. {personajes[i]}");
//     }
//     Console.WriteLine("Quieres Seleccionar un personaje guardado? (S/N)");
//     string opcion= Console.ReadLine();
//     if (opcion.ToLower()== "s")
//     {
//       Console.WriteLine("Elija su Personaje por numero");
//       int numPersonaje;
//       while (!int.TryParse(Console.ReadLine(),out numPersonaje) || numPersonaje < 1 || numPersonaje > personajes.Count )
//       {
//         Console.WriteLine("Seleccion invalida");
//       }
//       Personaje personajeElegido= personajes[numPersonaje - 1];
//       Console.WriteLine("A seleccionado el siguiente personaje: ");
//       Console.WriteLine(personajeElegido);
//     }else
//     {
//       Personaje personajeNuevo= await fabricaDePersonajes.crearPersonaje();
//       personajes.Add(personajeNuevo);
//       persistencia.GuardarPersonajes(personajes);
//       Console.WriteLine("Se creo y guardo en la memoria un nuevo personaje: ");
//       Console.WriteLine(personajeNuevo);
//     }
//   }else
//   {
//     Personaje personajeNuevo= await fabricaDePersonajes.crearPersonaje();
//     personajes.Add(personajeNuevo);
//     persistencia.GuardarPersonajes(personajes);
//     Console.WriteLine("Se creo y guardo en la memoria un nuevo personaje: ");
//     Console.WriteLine(personajeNuevo);
//   }
// }
// catch (Exception ex)
// {
//   Console.WriteLine($"Error: {ex.Message}");
//   throw;
// }