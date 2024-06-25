using personajes;

try
{
  Personaje personaje= await fabricaDePersonajes.crearPersonaje();
  Console.WriteLine(personaje);
}
catch (Exception ex)
{
  Console.WriteLine($"Error: {ex.Message}");
  throw;
}