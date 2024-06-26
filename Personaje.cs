namespace personajes;
public class Personaje
{
    //utilizo los datos y las caracteristicas como objetos con la finalidad de tener todo mas ordenado
    Caracteristicas Caracteristica { get; set; }
    Datos Dato { get; set; }
     //creacion de los constructores 
    public Personaje(Datos dato, Caracteristicas caracteristica)
    {
        Dato = dato;
        Caracteristica= caracteristica;
    }
        public override string ToString()
    {
        return $"Nombre: {Dato.Nombre}, Apodo: {Dato.Apodo}, " +
               $"Fecha de Nacimiento: {Dato.FechaNacimiento.ToShortDateString()}, " +
               $"Edad: {Dato.Edad}, Provincia: {Dato.Tipo}, " +
               $"Velocidad: {Caracteristica.Velocidad}, Destreza: {Caracteristica.Destreza}, " +
               $"Fuerza: {Caracteristica.Fuerza}, Nivel: {Caracteristica.Nivel}, " +
               $"Armadura: {Caracteristica.Armadura}, Salud: {Caracteristica.Salud}";
    }

}