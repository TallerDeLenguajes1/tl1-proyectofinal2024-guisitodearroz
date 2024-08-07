using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiServicio
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly string archivoLocal = "fechas.json"; // Asegúrate de que esta ruta sea correcta

    public static async Task<List<string>> GetFechaApi()
    {
        var url = "https://api.generadordni.es/v2/misc/birthdate";
        int intentos = 5;
        int segundoEspera = 1000;

        for (int i = 0; i < intentos + 1; i++)
        {
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
            catch (HttpRequestException ex) when ((int)ex.StatusCode == 429)
            {
                Console.WriteLine($"Se intentará nuevamente en {segundoEspera / 1000} segundos debido a: {ex.Message}");
                await Task.Delay(segundoEspera);
                segundoEspera = Math.Min(segundoEspera * 2, 30000); // Asegurarse de que no exceda 30 segundos
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar la respuesta: {ex.Message}");
                if (i == intentos - 1)
                {
                    return LeerFechasDesdeArchivo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (i == intentos - 1)
                {
                    return LeerFechasDesdeArchivo();
                }
                throw;
            }
        }

        throw new HttpRequestException("Excedidos los intentos máximos.");
    }

   private static List<string> LeerFechasDesdeArchivo()
{
    try
    {
        Console.WriteLine($"Leyendo el archivo desde: {archivoLocal}");
        
        if (!File.Exists(archivoLocal))
        {
            throw new FileNotFoundException($"El archivo '{archivoLocal}' no se encuentra.");
        }

        string json = File.ReadAllText(archivoLocal);
        Console.WriteLine($"Contenido del archivo: {json}");

        List<string> fechas = JsonSerializer.Deserialize<List<string>>(json);

        if (fechas == null || fechas.Count == 0)
        {
            throw new InvalidOperationException("El archivo local no contiene fechas válidas.");
        }

        return fechas;
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine($"Error al encontrar el archivo: {ex.Message}");
        throw;
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Error al deserializar el archivo: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al leer el archivo: {ex.Message}");
        throw;
    }
}

}
