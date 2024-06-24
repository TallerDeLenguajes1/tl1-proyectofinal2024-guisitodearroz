public class ApiService
{
    private var urlApi = "https://random-data-api.com/api/v2/users?size=1&country=Argentina";

    public static async Task<(string Nombre, string Provincia, DateTime fechaNacimiento)> ObtenerDatosAsync()
    {
        HttpClient client = new HttpClient()
        {
            HttpResponseMessage response = await client.GetAsync(urlApi);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JsonDocument doc = JsonDocument.Parse(jsonResponse);

                // segun yo el json viene con estructura de array
                JsonElement root = doc.RootElement; //uso funciones para leer el json
                JsonElement user = root[0];  // Tomamos el primer elemento del array

                string nombre = $"{user.GetProperty("first_name").GetString()}{user.GetProperty("last_name").GetString()}"; //concateno nombre y apellido 
                string provincia = user.GetProperty("address").GetProperty("state").GetString(); //concateno provincia con el pais pero estoy seguro que no lo usare 
                DateTime fechaNacimiento = DateTime.Parse(user.GetProperty("date_of_birth").GetString());

                return (nombre, provincia, fechaNacimiento);
            }
            else
            {
                throw new Exception("Error al obtener datos de la API.");
            }
        }
    }
}