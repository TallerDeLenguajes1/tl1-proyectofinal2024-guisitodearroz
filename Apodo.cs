namespace personajes;
public static class Apodo
{
    private static readonly List<string> apodos = new List<string>
    {
        "El picante", "El pollo", "La bestia", "Facha", "trabajont"
    };
    private static readonly Random random= new Random();
    public static string obtenerApodo(){
        int index= random.Next(apodos.Count);
        return apodos[index];
    }
}