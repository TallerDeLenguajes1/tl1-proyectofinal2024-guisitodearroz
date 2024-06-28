using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace personajes
{
    public static class ArchivoReader
    {
        public static List<T> LeerDesdeArchivoJson<T>(string rutaArchivo, string clave)
        {
            string json = File.ReadAllText(rutaArchivo);
            var datos = JsonSerializer.Deserialize<Dictionary<string, List<T>>>(json);
            return datos[clave];
        }
    }
}