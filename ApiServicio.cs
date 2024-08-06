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
        var url= "https://api.generadordni.es/v2/misc/birthdate";
        int intentos=5;
        int segundoEspera= 1000;
        for (int i = 0; i < intentos; i++)
        {
            try
            {
                HttpResponseMessage response= await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody= await response.Content.ReadAsStringAsync();
                //deserealizo
                List<string> fechNac= JsonSerializer.Deserialize<List<string>>(responseBody); //la api trae la info como cadena de caracteres
                return fechNac;

            }catch(HttpRequestException ex) when ((int)ex.StatusCode==429)
            {
                    Console.WriteLine($"se intento en {segundoEspera/1000} segundos");
                    await Task.Delay(segundoEspera);
                    segundoEspera*= 5;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
                throw;
            }
            
        }
            throw new HttpRequestException("Excedidos los intentos máximos.");
            return new List<string>();
    } 
}
