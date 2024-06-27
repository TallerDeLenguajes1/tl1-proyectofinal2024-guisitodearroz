using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using clasesApi;
using personajes;
using System.Security.Cryptography.X509Certificates;

public class ApiService
{
    //utilizar 1 sola api la otra hacerla con un num
    private static readonly string urlProvincias = "https://apis.datos.gob.ar/georef/api/provincias";
    private static readonly HttpClient client = new HttpClient();
    await GetNombreApi();
    Apodo apo= new Apodo();
    private static async Task<Persona> GetNombreApi()
    {
        private static readonly string urlApi = "https://random-data-api.com/api/v2/users?size=1";
        HttpResponseMessage response = await client.GetAsync(urlApi);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        PersonaDatos persona = JsonSerializer.Deserialize<Persona>(responseBody);
        persona.apodo= apo.obtenerApodo();
        persona.provincia=;
        return Persona;
    }
}




