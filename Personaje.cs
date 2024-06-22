namespace personajes;
public class Personaje
{
    //utilizo los datos y las caracteristicas como objetos con la finalidad de tener todo mas ordenado
   Datos dato;
   Caracteristicas caracteristica;
     //creacion de los constructores 
    public Personaje(Datos dato)
    {
        this.Dato = dato;
        this.Caracteristica= caracteristica;
    }

    public Caracteristicas Caracteristica { get => caracteristica; set => caracteristica = value; }
    public Datos Dato { get => dato; set => dato = value; }
}