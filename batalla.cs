using personajes;
namespace personajes;
public class Batalla
{
    public static double CalcularDanio(Personaje atacante, Personaje defensor)
        {
            // Ataque del atacante
            double ataque = atacante.Caracteristica.Destreza * atacante.Caracteristica.Fuerza * atacante.Caracteristica.Nivel;
            // Efectividad
            double efectividad = fabricaDePersonajes.numAleatorio(1,100);
            // Defensa del defensor
            double defensa = defensor.Caracteristica.Armadura * defensor.Caracteristica.Velocidad;
            // Constante de ajuste
            const double constanteAjuste = 500;
            // Cálculo del daño provocado
            double danioProvocado = ((ataque * efectividad) - defensa) / constanteAjuste;
            return danioProvocado;
        }

        public static void Combate(Personaje personaje, List<Personaje> enemigos)
        {
            
            Persistencia persistencia = new Persistencia();
            foreach (var enemigo in enemigos)
            {
                string nombEnemigo= enemigo.Dato.Nombre;
                Console.WriteLine($"Te haz Encontrado con un {nombEnemigo}");
               
                while (personaje.Caracteristica.Salud > 0 && enemigo.Caracteristica.Salud > 0)
                {
                    string nombPersonaje= personaje.Dato.Nombre;
                    
                    // Primer golpe personaje a enemigo
                    double danioAlEnemigoDouble = CalcularDanio(personaje, enemigo);
                    int danioAlEnemigo = (int)Math.Round(danioAlEnemigoDouble);
                    Console.WriteLine($"{nombPersonaje} le hizo {danioAlEnemigo} de daño a {nombEnemigo}");
                    enemigo.Caracteristica.Salud -= (int)danioAlEnemigo;

                    if (enemigo.Caracteristica.Salud <= 0)
                    {
                        Console.WriteLine("¡Has derrotado al enemigo!");
                        // Subir el atributo al azar
                        personaje.SubirAtributoAleatorio();
                        personaje.Caracteristica.Salud+= fabricaDePersonajes.numAleatorio(5,20);
                        Console.WriteLine($"!Tus Estadisticas Subieron¡ {nombPersonaje}");
                        Console.WriteLine($"Salud: {personaje.Caracteristica.Salud}, Armadura: {personaje.Caracteristica.Armadura}, Fuerza: {personaje.Caracteristica.Fuerza} , Velocidad: {personaje.Caracteristica.Velocidad}, Nivel: {personaje.Caracteristica.Nivel}, Destreza: {personaje.Caracteristica.Destreza}");
                        break;
                    }

                    // Daño del enemigo al personaje
                    double danioAlPersonajeDouble = CalcularDanio(enemigo, personaje);
                    int danioAlPersonaje = (int)Math.Round(danioAlPersonajeDouble);
                    Console.WriteLine($"{nombEnemigo} le hizo {danioAlPersonaje} de daño a {nombPersonaje}");
                    personaje.Caracteristica.Salud -= (int)danioAlPersonaje;

                    // Verifico si el jugador está derrotado
                    if (personaje.Caracteristica.Salud <= 0)
                    {
                        Console.WriteLine("¡Te han derrotado!");
                        // Guardar la derrota
                        persistencia.MoverADerrotas(personaje);
                    }
                }
            }
        }
    }