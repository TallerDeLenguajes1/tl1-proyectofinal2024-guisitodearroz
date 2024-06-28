using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using personajes;

public class ApiService
{
    private static readonly HttpClient client = new HttpClient();

    public class Provincia
    {
        public string nombre { get; set; }
    }
    public static async Task<PersonaDatos> GetNombreApi()
    {
        try
        {
            private static readonly string urlApi = "https://random-data-api.com/api/v2/users?size=1";
            HttpResponseMessage response = await client.GetAsync(urlApi);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializa el JSON en un objeto de tipo PersonaDatos
            PersonaDatos personaDatos = JsonSerializer.Deserialize<PersonaDatos>(responseBody);

            // Asigna un apodo usando el json
            string rutaApodo= "Apodo.json";
            List<string>apodos= ArchivoReader.LeerDesdeArchivoJson<string>(rutaApodo,"apodos");
            //genero apodos al azar
            Random random = new Random();
            int indiceAleatorioApodo= random.Next(apodos.Count);
            personaDatos.apodo= apodos[indiceAleatorioApodo].apodos;
            // Leer las provincias desde el archivo
            string rutaArchivoProvincias = "provincias.json"; 
            List<Provincia> provincias = ArchivoReader.LeerDesdeArchivoJson<Provincia>(rutaArchivoProvincias,"provincias");
            // Asignar una provincia al azar
            int indiceAleatorioProvincia = random.Next(provincias.Count);
            personaDatos.provincia = provincias[indiceAleatorioProvincia].nombre;

            // Devuelve el objeto personaDatos
            return personaDatos;
        }
        catch (Exception ex)
        {
            // Maneja cualquier excepción que ocurra
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}





