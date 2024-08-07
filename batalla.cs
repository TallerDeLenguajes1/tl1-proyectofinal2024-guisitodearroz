using personajes;
namespace personajes;
public class Batalla
{
    public static double CalcularDanio(Personaje atacante, Personaje defensor)
        {
            Random random = new Random();
            // Ataque del atacante
            double ataque = atacante.Caracteristica.Destreza * atacante.Caracteristica.Fuerza * atacante.Caracteristica.Nivel;
            // Efectividad
            double efectividad = random.Next(1, 101);
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
                while (personaje.Caracteristica.Salud > 0 && enemigo.Caracteristica.Salud > 0)
                {
                    // Primer golpe personaje a enemigo
                    double danioAlEnemigo = CalcularDanio(personaje, enemigo);
                    enemigo.Caracteristica.Salud -= (int)danioAlEnemigo;

                    if (enemigo.Caracteristica.Salud <= 0)
                    {
                        Console.WriteLine("¡Has derrotado al enemigo!");
                        // Subir el atributo al azar
                        personaje.SubirAtributoAleatorio();
                        break;
                    }

                    // Daño del enemigo al personaje
                    double danioAlPersonaje = CalcularDanio(enemigo, personaje);
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