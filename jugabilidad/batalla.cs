using personajes;
namespace personajes;
public class Batalla
{
    public static double CalcularDanio(Personaje atacante, Personaje defensor)
        {
            // Ataque del atacante
            double ataque = atacante.Caracteristica.Destreza * (atacante.Caracteristica.Fuerza + 2) * atacante.Caracteristica.Nivel;//aumento un poquito el daño
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
                bool bandera= false;
                string nombEnemigo= enemigo.Dato.Nombre;
                Console.WriteLine("\n");
                Console.WriteLine($"Te haz Encontrado con un {nombEnemigo}\n");
                if (nombEnemigo=="Pomberito")
                {
                    Ascii.mostrarPomberito();
                }else if (nombEnemigo=="Llorona")
                {
                    Ascii.mostrarLlorona();
                }else if (nombEnemigo=="Perro Familiar")
                {
                    Ascii.mostrarPerroFamiliar();
                }else if (nombEnemigo=="Luz mala")
                {
                    Ascii.mostrarLuzMala();
                }
                while (personaje.Caracteristica.Salud > 0 && enemigo.Caracteristica.Salud > 0)
                {
                    string nombPersonaje= personaje.Dato.Nombre;
                    
                    // Primer golpe personaje a enemigo
                    double danioAlEnemigoDouble = CalcularDanio(personaje, enemigo);
                    int danioAlEnemigo = (int)Math.Round(danioAlEnemigoDouble);
                    Console.WriteLine($"{nombPersonaje} le hizo {danioAlEnemigo} de daño a {nombEnemigo}");
                    enemigo.Caracteristica.Salud -= (int)danioAlEnemigo;
                    Console.ReadKey();

                    if (enemigo.Caracteristica.Salud <= 0)
                    {
                        Console.WriteLine("\n¡Has derrotado al enemigo!\n");
                        // Subir el atributo al azar
                        personaje.SubirAtributoAleatorio();
                        personaje.Caracteristica.Salud= 100; 
                        Console.WriteLine("\n!Tus Estadisticas Subieron¡\n");
                        Console.WriteLine($"\nSalud: {personaje.Caracteristica.Salud}\n Armadura: {personaje.Caracteristica.Armadura}\n Fuerza: {personaje.Caracteristica.Fuerza}\n Velocidad: {personaje.Caracteristica.Velocidad}\n Nivel: {personaje.Caracteristica.Nivel}\n Destreza: {personaje.Caracteristica.Destreza}");
                        Console.ReadKey();
                        break;
                    }

                    // Daño del enemigo al personaje
                    double danioAlPersonajeDouble = CalcularDanio(enemigo, personaje);
                    int danioAlPersonaje = (int)Math.Round(danioAlPersonajeDouble);
                    Console.WriteLine($"\n{nombEnemigo} le hizo {danioAlPersonaje} de daño a {nombPersonaje}\n");
                    personaje.Caracteristica.Salud -= (int)danioAlPersonaje;
                    Console.ReadKey();

                    // Verifico si el jugador está derrotado
                    if (personaje.Caracteristica.Salud <= 0)
                    {
                        Console.WriteLine("\n¡Te han derrotado!\n");   
                        // Guardar la derrota
                        persistencia.MoverADerrotas(personaje);
                        Console.ReadKey();
                        bandera= true;
                    }
                }
                if (bandera)
                {
                    break;
                }
            }
            // Verifico si el personaje ganó todas las batallas
            if (!enemigos.Any(e => e.Caracteristica.Salud > 0)) //si todos los enemigos tienen menos de 0 
            {
                Console.WriteLine("\n¡Has vencido a todos los enemigos y te has convertido en un campeón!\n");
                persistencia.MoverAGanadores(personaje);
            }
        }
    }