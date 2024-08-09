using personajes;
using System.Threading;
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
                Texto.ImprimirTextoCentrado($"Te haz Encontrado con un {nombEnemigo}");
                Console.WriteLine("\n");
                Thread.Sleep(2000);
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
                    mostrarEstadisticas(personaje,enemigo);
                    Texto.ImprimirTextoCentrado($"{nombPersonaje} le hizo {danioAlEnemigo} de daño a {nombEnemigo}");
                    Console.WriteLine("\n");
                    enemigo.Caracteristica.Salud -= (int)danioAlEnemigo;
                    Console.ReadKey();

                    if (enemigo.Caracteristica.Salud <= 0)
                    {
                        Texto.ImprimirTituloResaltado("¡Has derrotado al enemigo!");
                        Console.WriteLine("\n");
                        // Subir el atributo al azar
                        personaje.SubirAtributoAleatorio();
                        personaje.Caracteristica.Salud= 100;
                        Texto.ImprimirTituloResaltado("¡Tus Estadisticas Subieron!");
                        Console.WriteLine("\n");
                        mostrarEstadisticasPersonaje(personaje);
                        Console.ReadKey();
                        break;
                    }

                    // Daño del enemigo al personaje
                    double danioAlPersonajeDouble = CalcularDanio(enemigo, personaje);
                    int danioAlPersonaje = (int)Math.Round(danioAlPersonajeDouble);
                    mostrarEstadisticas(personaje,enemigo);
                    
                    Texto.ImprimirTextoCentrado($"{nombEnemigo} le hizo {danioAlPersonaje} de daño a {nombPersonaje}");
                    Console.WriteLine("\n");
                    
                    personaje.Caracteristica.Salud -= (int)danioAlPersonaje;
                    
                    Console.ReadKey();

                    // Verifico si el jugador está derrotado
                    if (personaje.Caracteristica.Salud <= 0)
                    {
                        Texto.ImprimirTextoCentrado("¡Te han derrotado!");
                        Console.WriteLine("\n");  
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
                Console.WriteLine("\n");
                Texto.ImprimirTituloResaltado("¡Has vencido a todos los enemigos y te has convertido en un campeón!");
                Console.WriteLine("\n");
                persistencia.MoverAGanadores(personaje);
            }
        }

        public static void mostrarEstadisticas(Personaje personaje, Personaje enemigo)
        {
            string[] estadisticasPersonaje = {
                $"Nombre: {personaje.Dato.Nombre}",
                $"Salud: {personaje.Caracteristica.Salud}",
                $"Fuerza: {personaje.Caracteristica.Fuerza}",
                $"Armadura: {personaje.Caracteristica.Armadura}",
                $"Destreza: {personaje.Caracteristica.Destreza}",
                $"Velocidad: {personaje.Caracteristica.Velocidad}",
                $"Nivel: {personaje.Caracteristica.Nivel}"
            };

            string[] estadisticasEnemigo = {
                $"Nombre: {enemigo.Dato.Nombre}",
                $"Salud: {enemigo.Caracteristica.Salud}",
                $"Fuerza: {enemigo.Caracteristica.Fuerza}",
                $"Armadura: {enemigo.Caracteristica.Armadura}",
                $"Destreza: {enemigo.Caracteristica.Destreza}",
                $"Velocidad: {enemigo.Caracteristica.Velocidad}",
                $"Nivel: {enemigo.Caracteristica.Nivel}"
            };

            int lineasMaximas = Math.Max(estadisticasPersonaje.Length, estadisticasEnemigo.Length);
            int anchoMaximoPersonaje = estadisticasPersonaje.Max(linea => linea.Length);
            int anchoMaximoEnemigo = estadisticasEnemigo.Max(linea => linea.Length);
            
            // Calculamos el espacio para centrar los cuadros en la consola
            int anchoConsola = Console.WindowWidth;
            int espacioParaAmbos = (anchoConsola - (anchoMaximoPersonaje + anchoMaximoEnemigo + 11)) / 2; // 11 es la suma de espacios y barras

            string lineaSeparadoraPersonaje = new string('-', anchoMaximoPersonaje + 4);
            string lineaSeparadoraEnemigo = new string('-', anchoMaximoEnemigo + 4);

            // Centramos la línea separadora
            Console.WriteLine(new string(' ', espacioParaAmbos) + $"{lineaSeparadoraPersonaje}     {lineaSeparadoraEnemigo}");

            for (int i = 0; i < lineasMaximas; i++)
            {
                string lineaPersonaje = i < estadisticasPersonaje.Length ? estadisticasPersonaje[i] : "";
                string lineaEnemigo = i < estadisticasEnemigo.Length ? estadisticasEnemigo[i] : "";

                // Centramos las líneas de estadísticas
                Console.WriteLine(new string(' ', espacioParaAmbos) + $"| {lineaPersonaje.PadRight(anchoMaximoPersonaje)} |     | {lineaEnemigo.PadRight(anchoMaximoEnemigo)} |");
            }

            // Centramos la línea separadora inferior
            Console.WriteLine(new string(' ', espacioParaAmbos) + $"{lineaSeparadoraPersonaje}     {lineaSeparadoraEnemigo}");
        }

        public static void mostrarEstadisticasPersonaje(Personaje personaje)
        {
            string[] estadisticasPersonaje = {
                $"Nombre: {personaje.Dato.Nombre}",
                $"Salud: {personaje.Caracteristica.Salud}",
                $"Fuerza: {personaje.Caracteristica.Fuerza}",
                $"Armadura: {personaje.Caracteristica.Armadura}",
                $"Destreza: {personaje.Caracteristica.Destreza}",
                $"Velocidad: {personaje.Caracteristica.Velocidad}",
                $"Nivel: {personaje.Caracteristica.Nivel}"
            };

            int anchoMaximoPersonaje = estadisticasPersonaje.Max(linea => linea.Length);
            string lineaSeparadoraPersonaje = new string('-', anchoMaximoPersonaje + 4);

            int anchoConsola = Console.WindowWidth;
            int espaciosIzquierda = (anchoConsola - lineaSeparadoraPersonaje.Length) / 2;

            // Imprimir la línea separadora y las estadísticas centradas
            Console.WriteLine(new string(' ', espaciosIzquierda) + lineaSeparadoraPersonaje);
            foreach (var linea in estadisticasPersonaje)
            {
                Console.WriteLine(new string(' ', espaciosIzquierda) + $"| {linea.PadRight(anchoMaximoPersonaje)} |");
            }
            Console.WriteLine(new string(' ', espaciosIzquierda) + lineaSeparadoraPersonaje);
        }


    }