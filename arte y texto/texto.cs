namespace personajes;
public class Texto
{
    public static void ImprimirTextoCentrado(string texto)
    {
        int anchoConsola = Console.WindowWidth;
        int espaciosIzquierda = (anchoConsola - texto.Length) / 2;
        Console.WriteLine(new string(' ', espaciosIzquierda) + texto);
    }
    public static void ImprimirTituloResaltado(string titulo)
    {
        int anchoConsola = Console.WindowWidth;
        string borde = new string('*', titulo.Length + 4);
        int espaciosIzquierda = (anchoConsola - borde.Length) / 2;

        Console.WriteLine(new string(' ', espaciosIzquierda) + borde);
        Console.WriteLine(new string(' ', espaciosIzquierda) + $"* {titulo} *");
        Console.WriteLine(new string(' ', espaciosIzquierda) + borde);
    }

}