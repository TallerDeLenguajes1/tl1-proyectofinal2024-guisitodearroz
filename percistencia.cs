using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace personajes
{
    public class Persistencia
    {
        private readonly string rutaGuardado = "personajes.json";

        public void GuardarPersonajes(List<Personaje> personajes)
        {
            string jsonString = JsonSerializer.Serialize(personajes, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString); // Control para ver si está funcionando

            File.WriteAllText(rutaGuardado, jsonString); // Guarda en el archivo, si no existe se crea
        }

        public List<Personaje> LeerPersonajes()
        {
            if (File.Exists(rutaGuardado) && new FileInfo(rutaGuardado).Length > 0)
            {
                string jsonString = File.ReadAllText(rutaGuardado);
                return JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            }
            return new List<Personaje>();
        }
    }
}

