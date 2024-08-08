using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiServicio
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly string archivoLocal = "json/fechas.json"; // Asegúrate de que esta ruta sea correcta
    private static bool errorMostrado= false;

    public static async Task<List<string>> GetFechaApi()
    {
        var url = "https://api.generadordni.es/v2/misc/birthdate";
        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializar la respuesta de la API
            List<string> fechasNac = JsonSerializer.Deserialize<List<string>>(responseBody);
            if (fechasNac == null || fechasNac.Count == 0)
            {
                throw new InvalidOperationException("La respuesta de la API no contiene fechas válidas.");
            }
            return fechasNac;
        }
        catch (HttpRequestException)
        {
            mostrarErrorUnaVez($"Error de solicitud HTTP: Se intentará leer desde el archivo local.");
            return LeerFechasDesdeArchivo();
        }
        catch (JsonException ex)
        {
            mostrarErrorUnaVez($"Error al deserializar la API: {ex.Message}. Se intentará leer desde el archivo local.");
            return LeerFechasDesdeArchivo();
        }
        catch (Exception ex)
        {
            mostrarErrorUnaVez($"Error general: {ex.Message}. Se intentará leer desde el archivo local.");
            return LeerFechasDesdeArchivo();
        }
    }

    private static List<string> LeerFechasDesdeArchivo()
    {
        try
        {
            //Console.WriteLine($"Leyendo el archivo desde: {archivoLocal}");

            if (!File.Exists(archivoLocal))
            {
                throw new FileNotFoundException($"El archivo '{archivoLocal}' no se encuentra.");
            }

            string json = File.ReadAllText(archivoLocal);
            //Console.WriteLine($"Contenido del archivo: {json}"); //aqui controlo el archivo no dar importancia

            List<string> fechas = JsonSerializer.Deserialize<List<string>>(json);

            if (fechas == null || fechas.Count == 0)
            {
                throw new InvalidOperationException("El archivo local no contiene fechas válidas.");
            }

            return fechas;
        }
        catch (FileNotFoundException ex)
        {
            mostrarErrorUnaVez($"Error al encontrar el archivo: {ex.Message}");
            throw;
        }
        catch (JsonException ex)
        {
            mostrarErrorUnaVez($"Error al deserializar el archivo: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            mostrarErrorUnaVez($"Error al leer el archivo: {ex.Message}");
            throw;
        }
    }
    public static void mostrarErrorUnaVez(string mesaje){
        if (!errorMostrado)
        {
            Console.WriteLine(mesaje);
            errorMostrado=true;
        }
    }
}
