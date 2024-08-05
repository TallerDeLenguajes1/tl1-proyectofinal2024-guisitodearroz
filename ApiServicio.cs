using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using personajes;
using System.Runtime.CompilerServices;
using clasesApi;
namespace personajes;
public class ApiServicio
{
    private static readonly HttpClient client= new HttpClient();
    
    public static async Task<List<string>> GetFechaApi(){
        try
        {
            var url= "https://api.generadordni.es/v2/misc/birthdate";
            HttpResponseMessage response= await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody= await response.Content.ReadAsStringAsync();
            //deserealizo
            List<string> fechNac= JsonSerializer.Deserialize<List<string>>(responseBody); //la api trae la info como cadena de caracteres
            return fechNac;

        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"Error:{ex.Message}");
            throw;
        }
    } 
}

//         try
//         {
//             private static readonly string urlApi = "https://random-data-api.com/api/v2/users?size=1";
//             HttpResponseMessage response = await client.GetAsync(urlApi);
//             response.EnsureSuccessStatusCode();
//             string responseBody = await response.Content.ReadAsStringAsync();

//             // Deserializa el JSON en un objeto de tipo PersonaDatos
//             PersonaDatos personaDatos = JsonSerializer.Deserialize<PersonaDatos>(responseBody);

//             // Asigna un apodo usando el json
//             string rutaApodo= "Apodo.json";
//             List<string>apodos= ArchivoReader.LeerDesdeArchivoJson<string>(rutaApodo,"apodos");
//             //genero apodos al azar
//             Random random = new Random();
//             int indiceAleatorioApodo= random.Next(apodos.Count);
//             personaDatos.apodo= apodos[indiceAleatorioApodo].apodos;
//             // Leer las provincias desde el archivo
//             string rutaArchivoProvincias = "provincias.json"; 
//             List<Provincia> provincias = ArchivoReader.LeerDesdeArchivoJson<Provincia>(rutaArchivoProvincias,"provincias");
//             // Asignar una provincia al azar
//             int indiceAleatorioProvincia = random.Next(provincias.Count);
//             personaDatos.provincia = provincias[indiceAleatorioProvincia].nombre;

//             // Devuelve el objeto personaDatos
//             return personaDatos;
//         }
//         catch (Exception ex)
//         {
//             // Maneja cualquier excepción que ocurra
//             Console.WriteLine($"Error: {ex.Message}");
//             return null;
//         }
//     }
// }





