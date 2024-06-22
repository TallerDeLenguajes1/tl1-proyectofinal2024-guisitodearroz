namespace personajes;
public class Caracteristicas
{
    int velocidad; //1 al 10
    int destreza;// 1 al 5
    int fuerza;//1 a 10
    int nivel; //1a10
    int armadura;//1 a 10
    int salud;//100 fijo luego se resta con el daño
    public Caracteristicas(int velocidad, int destreza, int fuerza, int nivel, int armadura, int salud)
    {
        this.Velocidad= velocidad;
        this.Destreza=destreza;
        this.Fuerza=fuerza;
        this.Nivel=nivel;
        this.Armadura=armadura;
        this.Salud=salud;
    }

    public int Velocidad
    {
        get=> velocidad; 
        set
        { 
            if (velocidad < 1 || velocidad > 10)
            {
                throw new ArgumentOutOfRangeException("Velocidad debe estar entre 1 y 10.");
                }else{
                    velocidad= value;
                    }        
        }
    }
    public int Destreza{get=> destreza; set => destreza= value;}
    public int Fuerza{get=> fuerza; set => fuerza= value;}
    public int Nivel{get=> nivel; set => nivel= value;}
    public int Armadura{get=> armadura; set => armadura= value;}
    public int Salud{get=> salud; set => salud= value;}

}