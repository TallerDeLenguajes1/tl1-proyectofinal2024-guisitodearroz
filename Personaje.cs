namespace personajes;
public class Personaje
{
    //utilizo los datos y las caracteristicas como objetos con la finalidad de tener todo mas ordenado
    public Caracteristicas Caracteristica { get; set; }
    public Datos Dato { get; set; }
     //creacion de los constructores 
    public Personaje(){}
    public Personaje(Datos dato, Caracteristicas caracteristica)
    {
        Dato = dato;
        Caracteristica= caracteristica;
    }
        public override string ToString()
    {
        return $"Nombre: {Dato.Nombre}, Apodo: {Dato.Apodo}, " +
               $"Fecha de Nacimiento: {Dato.FechaNacimiento}, " +
               $"Edad: {Dato.Edad}, Tipo: {Dato.Tipo}, " +
               $"Provincia: {Dato.LugarNacimiento}, " +
               $"Velocidad: {Caracteristica.Velocidad}, Destreza: {Caracteristica.Destreza}, " +
               $"Fuerza: {Caracteristica.Fuerza}, Nivel: {Caracteristica.Nivel}, " +
               $"Armadura: {Caracteristica.Armadura}, Salud: {Caracteristica.Salud}";
    }

}