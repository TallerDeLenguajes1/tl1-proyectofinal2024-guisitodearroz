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
} 