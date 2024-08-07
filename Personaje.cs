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
    public void SubirAtributoAleatorio()
{
    Random random = new Random();
    int atributo = random.Next(1, 6); // Suponiendo que hay 5 atributos
    
    switch (atributo)
    {
        case 1:
            Caracteristica.Velocidad++;
            break;
        case 2:
            Caracteristica.Destreza++;
            break;
        case 3:
            Caracteristica.Fuerza++;
            break;
        case 4:
            Caracteristica.Nivel++;
            break;
        case 5:
            Caracteristica.Armadura++;
            break;
    }
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