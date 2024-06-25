using System;
namespace personajes;
public class fabricaDePersonajes
{
    public static async Task<Personaje> crearPersonaje()
    {
        //traigo los datos de la api
        var (nombre, provincia, fechaNacimiento)= await ApiService.ObtenerDatosAsync();
        //hago el calculo para la edad
        int edad= DateTime.Now.Year - fechaNacimiento.Year;
        if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
        {
            edad--; //controlo si es que ya cumplio años para que el calculo que hago anteriormente sea exacto, si es false le resta un año
        }
        //obtengo un apodo aleatorio desde el archivo apodos
        string apodo= Apodo.obtenerApodo();
        //creo los datos
        Datos datos= new Datos(provincia,nombre,apodo,fechaNacimiento,edad);//lo paso en el orden que esta declarado en la clase
        //se crea las caracteristicas aleatorias
        Caracteristicas caracteristica= new Caracteristicas(
            velocidad: obtenerValorAleatorio(1,10),
            destreza:obtenerValorAleatorio(1,5),
            fuerza:obtenerValorAleatorio(1,10),
            nivel:obtenerValorAleatorio(1,10),
            armadura:obtenerValorAleatorio(1,10),
            salud:100
        );
        Personaje personaje=new Personaje(datos, caracteristica);
        return personaje;
    }
    //metodo para los aleatorios
    public static int obtenerValorAleatorio(int min, int max)
    {
        Random ran=new Random();
        return ran.Next(min, max+1);
    }
} 