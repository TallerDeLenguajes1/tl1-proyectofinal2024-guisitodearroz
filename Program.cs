using personajes;

try
{
  // Personaje personaje= await fabricaDePersonajes.crearPersonaje();
  // Console.WriteLine(personaje);
  Personaje persona= await fabricaDePersonajes.crearPersonaje();
  Console.WriteLine(persona);
}
catch (Exception ex)
{
  Console.WriteLine($"Error: {ex.Message}");
  throw;
}