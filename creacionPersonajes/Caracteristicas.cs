namespace personajes;
public class Caracteristicas
{
    public int Velocidad{get;set;}//1 al 10
    public int Destreza{get; set;}// 1 al 5
    public int Fuerza{get;set;}//1 al 10
    public int Nivel{get; set;}//1 al 10
    public int Armadura{get; set;}//1 al 10
    public int Salud{get; set;}//100 fijo luego se resta con el daño
    public Caracteristicas(){}
    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        Velocidad= velocidad;
        Destreza=destreza;
        Fuerza=fuerza;
        Nivel=nivel;
        Armadura=armadura;
        Salud=salud;
    }
    public override string ToString()
    {
        return $"Velocidad: {Velocidad}, Destreza: {Destreza}, Fuerza: {Fuerza}, " +
               $"Nivel: {Nivel}, Armadura: {Armadura}, Salud: {Salud}";
    }
}
