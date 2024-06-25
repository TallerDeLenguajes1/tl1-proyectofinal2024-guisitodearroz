using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

public class ApiService
{
    private static readonly string urlApi = "https://random-data-api.com/api/v2/users?size=1";
    private static readonly string urlProvincias = "https://apis.datos.gob.ar/georef/api/provincias";

    public static async Task<(string Nombre, string Provincia, DateTime FechaNacimiento)> ObtenerDatosAsync()
    {
        using HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(urlApi);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JsonDocument doc = JsonDocument.Parse(jsonResponse);

            JsonElement user = doc.RootElement;
            string nombre = $"{user.GetProperty("first_name").GetString()} {user.GetProperty("last_name").GetString()}";
            string provincia = await ObtenerProvinciaAleatoria();
            DateTime fechaNacimiento = DateTime.Parse(user.GetProperty("date_of_birth").GetString());

            return (nombre, provincia, fechaNacimiento);
        }
        else
        {
            throw new Exception("Error al obtener datos de la API.");
        }
    }

    private static async Task<string> ObtenerProvinciaAleatoria()
    {
        using HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(urlProvincias);
        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            JsonDocument doc = JsonDocument.Parse(jsonResponse);

            JsonElement root = doc.RootElement.GetProperty("provincias");
            Random rnd = new Random();
            int index = rnd.Next(root.GetArrayLength());
            string nombreProvincia = root[index].GetProperty("nombre").GetString();

            return nombreProvincia;
        }
        else
        {
            throw new Exception("Error al obtener las provincias de la API.");
        }
    }
}
