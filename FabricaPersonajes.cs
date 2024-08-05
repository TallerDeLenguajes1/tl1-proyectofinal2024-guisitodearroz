using System;
using System.Text.Json;
using clasesApi;
namespace personajes;
public class fabricaDePersonajes
{
    // traer datos de la api y ponerlos en un texto plano
    public static async Task<Personaje> crearPersonaje(){
        //deserializacion del json apodo.json
        string rutaJsonApodo="Apodo.json";
        string contJson= File.ReadAllText(rutaJsonApodo);
        ApodoJson apodoJson= JsonSerializer.Deserialize<ApodoJson>(contJson);
        Random random= new Random();
        int indiceRandom= random.Next(apodoJson.Apodos.Count);
        string apodoAleatoreo= apodoJson.Apodos[indiceRandom];
            
        //deserealizo provincia.json
        string rutaJsonProvincia="provincias.json";
        string contJsonProv= File.ReadAllText(rutaJsonProvincia);
        ProvinciasJson provinciasjson=JsonSerializer.Deserialize<ProvinciasJson>(contJsonProv);
        int indiceRandomProv= random.Next(provinciasjson.provincias.Count);
        string provinciaAleatoria= provinciasjson.provincias[indiceRandomProv];

        //traigo los datos de la api
        List<string> fechaNac= await ApiServicio.GetFechaApi();
        string fechaAleatoriaStr= fechaNac[random.Next(fechaNac.Count)];
        DateTime fechaAleatoria = DateTime.ParseExact(fechaAleatoriaStr, "dd/MM/yyyy", null);

        //cuento los años que tiene
        int edad= DateTime.Now.Year - fechaAleatoria.Year;
        if (DateTime.Now.Year < fechaAleatoria.Year)
        {
            edad--; //si es que aun no cumplio años durante el corriente año
        }

        //Cargo datos
        Datos datos=new Datos("Humano","Juan",apodoAleatoreo,fechaAleatoria,edad,provinciaAleatoria);
        Caracteristicas nuevasCaracteristicas= new Caracteristicas(1,2,3,4,5,6);
        Personaje nuevoPersonaje= new Personaje(datos,nuevasCaracteristicas);
        return nuevoPersonaje;

    }
    
    
    
    
    
    
    // private List<DatosDePersonaje> datos;

    // public fabricaDePersonajes(List<DatosDePersonaje>datos)
    // {
    //     this.datos = datos;
    // }
    // public static Personaje crearPersonaje(){
    //     Datos nuevosDatos= new Datos("caballo","juan","cachorrita",1999/01/21,12);
    //     Caracteristicas nuevasCaracteristicas= new Caracteristicas(1,2,3,4,5,6);
    //     Personaje nuevoPersonaje=new Personaje(nuevosDatos,nuevasCaracteristicas);
    //     return nuevoPersonaje;        
    // }
    // public static async Task<Personaje> crearPersonaje()
    // {
    //     //traigo los datos de la api
    //     var (nombre, provincia, fechaNacimiento)= await ApiService.ObtenerDatosAsync();
    //     //hago el calculo para la edad
    //     int edad= DateTime.Now.Year - fechaNacimiento.Year;
    //     if (DateTime.Now.DayOfYear < fechaNacimiento.DayOfYear)
    //     {
    //         edad--; //controlo si es que ya cumplio años para que el calculo que hago anteriormente sea exacto, si es false le resta un año
    //     }
    //     //obtengo un apodo aleatorio desde el archivo apodos
    //     string apodo= Apodo.obtenerApodo();
    //     //creo los datos
    //     Datos datos= new Datos(provincia,nombre,apodo,fechaNacimiento,edad);//lo paso en el orden que esta declarado en la clase
    //     //se crea las caracteristicas aleatorias
    //     Caracteristicas caracteristica= new Caracteristicas(
    //         velocidad: obtenerValorAleatorio(1,10),
    //         destreza:obtenerValorAleatorio(1,5),
    //         fuerza:obtenerValorAleatorio(1,10),
    //         nivel:obtenerValorAleatorio(1,10),
    //         armadura:obtenerValorAleatorio(1,10),
    //         salud:100
    //     );
    //     Personaje personaje=new Personaje(datos, caracteristica);
    //     return personaje;
    // }
    // //metodo para los aleatorios
    // public static int obtenerValorAleatorio(int min, int max)
    // {
    //     Random ran=new Random();
    //     return ran.Next(min, max+1);
    // }
} 