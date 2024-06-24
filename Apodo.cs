namespace personajes;
public static class Apodo
{
    private static readonly List<string> apodos = new List<string>
    {
        "El picante", "El pollo", "La bestia", "Facha", "trabajo'nt ";
    }
    private static readonly Ramdom ramdon= new Ramdom();
    public static string obtenerApodo(){
        int index= random.Next(apodos.Count);
        return apodos[index];
    }
}