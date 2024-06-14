using personajes;
namespace fabricaPersonajes;
class fabricaDePersonajes
{
    public static Personaje crearPersonaje(){
        //instancio un nuevo personaje, crea 1.
        Personaje nuevoPersonaje= new Personaje();
        DateTime fechaNac= new DateTime(2000, 31, 02);
        nuevoPersonaje.Apodo= "pepe";
        nuevoPersonaje.Armadura=10;
        nuevoPersonaje.Nombre="Rosendo";
        nuevoPersonaje.Tipo="Hincha de boca";
        nuevoPersonaje.FechaNacimiento= fechaNac;
        nuevoPersonaje.Edad= 23;
        nuevoPersonaje.Velocidad= 1; //esta gordito
        nuevoPersonaje.Fuerza= 10;
        nuevoPersonaje.Destreza=0;
        nuevoPersonaje.Nivel= 10;
        nuevoPersonaje.Armadura=10;
        nuevoPersonaje.salud= -1;
        return nuevoPersonaje;
    }
} 