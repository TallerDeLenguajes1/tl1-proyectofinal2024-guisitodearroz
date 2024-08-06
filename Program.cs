using personajes;
try
{
  Persistencia persistencia= new Persistencia();
  List<Personaje> personajes= persistencia.LeerPersonajes();
  if (personajes.Count > 0)
  {
    Console.WriteLine("Se encontraron Personajes Guardados");
    for (int i = 0; i < personajes.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {personajes[i]}");
    }
    Console.WriteLine("Quieres Seleccionar un personaje guardado? (S/N)");
    string opcion= Console.ReadLine();
    if (opcion.ToLower()== "s")
    {
      Console.WriteLine("Elija su Personaje por numero");
      int numPersonaje;
      while (!int.TryParse(Console.ReadLine(),out numPersonaje) || numPersonaje < 1 || numPersonaje > personajes.Count )
      {
        Console.WriteLine("Seleccion invalida");
      }
      Personaje personajeElegido= personajes[numPersonaje - 1];
      Console.WriteLine("A seleccionado el siguiente personaje: ");
      Console.WriteLine(personajeElegido);
    }else
    {
      Personaje personajeNuevo= await fabricaDePersonajes.crearPersonaje();
      personajes.Add(personajeNuevo);
      persistencia.GuardarPersonajes(personajes);
      Console.WriteLine("Se creo y guardo en la memoria un nuevo personaje: ");
      Console.WriteLine(personajeNuevo);
    }
  }else
  {
    Personaje personajeNuevo= await fabricaDePersonajes.crearPersonaje();
    personajes.Add(personajeNuevo);
    persistencia.GuardarPersonajes(personajes);
    Console.WriteLine("Se creo y guardo en la memoria un nuevo personaje: ");
    Console.WriteLine(personajeNuevo);
  }
}
catch (Exception ex)
{
  Console.WriteLine($"Error: {ex.Message}");
  throw;
}