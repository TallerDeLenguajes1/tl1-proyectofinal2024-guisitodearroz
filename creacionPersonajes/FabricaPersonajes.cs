using System;
using System.Text.Json;
using clasesApi;
namespace personajes;
public class fabricaDePersonajes
{
    // traer datos de la api y ponerlos en un texto plano
    public static async Task<Personaje> crearPersonaje(){
        //deserializacion del json apodo.json
        string rutaJsonApodo="json/Apodo.json";
        string contJson= File.ReadAllText(rutaJsonApodo);
        ApodoJson apodoJson= JsonSerializer.Deserialize<ApodoJson>(contJson);
        Random random= new Random();
        int indiceRandom= random.Next(apodoJson.Apodos.Count);
        string apodoAleatoreo= apodoJson.Apodos[indiceRandom];

        // Deserialización del JSON nombre.json
        string rutaJsonNombre = "json/nombresPersonajes.json";
        string contNombreJson = File.ReadAllText(rutaJsonNombre);
        nombrePersonaje nombreJson = JsonSerializer.Deserialize<nombrePersonaje>(contNombreJson);
        // Selección aleatoria de nombre
        int indiceNombre = random.Next(nombreJson.Nombres.Count);
        string NombreAleatoreo = nombreJson.Nombres[indiceNombre];
        
    
        //deserealizo provincia.json
        string rutaJsonProvincia="json/provincias.json";
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
        Datos datos=new Datos("Humano",NombreAleatoreo,apodoAleatoreo,fechaAleatoria,edad,provinciaAleatoria);
        //cargarCaracteristicas
        int velocidad=numAleatorio(1,10);
        int destreza= numAleatorio(1,5);
        int fuerza= numAleatorio(1,10);
        int nivel= numAleatorio(1,10);
        int armadura= numAleatorio(1,10);
        int salud= 100;
        Caracteristicas nuevasCaracteristicas= new Caracteristicas(velocidad,destreza,fuerza,nivel,armadura,salud);
        Personaje nuevoPersonaje= new Personaje(datos,nuevasCaracteristicas);
        return nuevoPersonaje;

    }
    public static async Task<Personaje> crearEnemigo()
    {
        // Crear objeto Random
        Random random = new Random();
        // Creación de los enemigos 
        // Deserialización del JSON apodo.json
        string rutaJsonApodo = "json/nombreEnemigos.json";
        string contJson = File.ReadAllText(rutaJsonApodo);
        nombrePersonaje apodoJson = JsonSerializer.Deserialize<nombrePersonaje>(contJson);
        // Selección aleatoria de apodo
        int indiceApodo = random.Next(apodoJson.Nombres.Count);
        string apodoAleatoreo = apodoJson.Nombres[indiceApodo];
        
        // Deserialización del JSON tipo.json
        string rutaJsonTipo = "json/TiposEnemigos.json";
        string contTJson = File.ReadAllText(rutaJsonTipo);
        TipoEnemigos tipoJson = JsonSerializer.Deserialize<TipoEnemigos>(contTJson);
        // Selección aleatoria de tipo
        int indiceTipo = random.Next(tipoJson.Tipo.Count);
        string TipoAleatoreo = tipoJson.Tipo[indiceTipo];
        
        // Deserialización del JSON nombre.json
        string rutaJsonNombre = "json/nombreEnemigos.json";
        string contNombreJson = File.ReadAllText(rutaJsonNombre);
        nombrePersonaje nombreJson = JsonSerializer.Deserialize<nombrePersonaje>(contNombreJson);
        // Selección aleatoria de nombre
        int indiceNombre = random.Next(nombreJson.Nombres.Count);
        string NombreAleatoreo = nombreJson.Nombres[indiceNombre];

        // Deserialización del JSON provincias.json
        string rutaJsonProvincia = "json/provincias.json";
        string contJsonProv = File.ReadAllText(rutaJsonProvincia);
        ProvinciasJson provinciasjson = JsonSerializer.Deserialize<ProvinciasJson>(contJsonProv);
        // Selección aleatoria de provincia
        int indiceProvincia = random.Next(provinciasjson.provincias.Count);
        string provinciaAleatoria = provinciasjson.provincias[indiceProvincia];

        
        // Traer los datos de la API
        List<string> fechaNac = await ApiServicio.GetFechaApi();
        string fechaAleatoriaStr = fechaNac[random.Next(fechaNac.Count)];
        DateTime fechaAleatoria = DateTime.ParseExact(fechaAleatoriaStr, "dd/MM/yyyy", null);

        // Contar los años que tiene
        int edad = DateTime.Now.Year - fechaAleatoria.Year;
        if (DateTime.Now.Year < fechaAleatoria.Year)
        {
            edad--; // Si es que aún no cumplió años durante el corriente año
        }

        // Cargar datos
        Datos datos = new Datos(TipoAleatoreo, NombreAleatoreo, apodoAleatoreo, fechaAleatoria, edad, provinciaAleatoria);
        
        // Cargar características
        int velocidad = numAleatorio(1, 10);
        int destreza = numAleatorio(1, 5);
        int fuerza = numAleatorio(1, 10);
        int nivel = numAleatorio(1, 10);
        int armadura = numAleatorio(1, 10);
        int salud = 100;

        Caracteristicas nuevasCaracteristicas = new Caracteristicas(velocidad, destreza, fuerza, nivel, armadura, salud);
        Personaje nuevoPersonaje = new Personaje(datos, nuevasCaracteristicas);
        
        return nuevoPersonaje;
    }
    
public static int numAleatorio(int min, int max)
{
    Random random = new Random(); // Utiliza el objeto Random ya creado
    return random.Next(min, max + 1);
}

    } 