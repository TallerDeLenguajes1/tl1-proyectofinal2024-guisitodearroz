namespace personajes;
public class Personaje
{
    //utilizo los datos y las caracteristicas como objetos con la finalidad de tener todo mas ordenado
    public Caracteristicas Caracteristica { get; set; }
    public Datos Dato { get; set; }
     //creacion de los constructores 
    public Personaje(Datos dato, Caracteristicas Caracteristica)
    {
        Dato = dato;
        Caracteristica= caracteristica;
    }

}