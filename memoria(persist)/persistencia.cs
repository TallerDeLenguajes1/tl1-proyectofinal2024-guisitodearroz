using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace personajes;
    public class Persistencia
    {
       private string rutaPersonajes = "json/personajes.json";
        private string rutaDerrotas = "json/derrotas.json";
        private string rutaSalonDeLaFama="json/salonDeLaFama.json";

        public void GuardarPersonajes(List<Personaje> personajes)
        {
            string jsonString = JsonSerializer.Serialize(personajes);
            //Console.WriteLine(jsonString); // Control para ver si está funcionando

            File.WriteAllText(rutaPersonajes, jsonString); // Guarda en el archivo, si no existe se crea
        }

        public List<Personaje> LeerPersonajes()
        {
            if (File.Exists(rutaPersonajes) && new FileInfo(rutaPersonajes).Length > 0)
            {
                string jsonString = File.ReadAllText(rutaPersonajes);
                return JsonSerializer.Deserialize<List<Personaje>>(jsonString);
            }
            return new List<Personaje>();
        }

        // Leer derrotas
        public List<Personaje> LeerDerrotas()
        {
            if (File.Exists(rutaDerrotas))
            {
                string json = File.ReadAllText(rutaDerrotas);
                return JsonSerializer.Deserialize<List<Personaje>>(json);
            }
            return new List<Personaje>();
        }

        // Guardar derrotas
        public void GuardarDerrotas(List<Personaje> derrotas)
        {
            string json = JsonSerializer.Serialize(derrotas);
            File.WriteAllText(rutaDerrotas, json);
        }

        // Mover personaje a derrotas
        public void MoverADerrotas(Personaje personaje)
        {
            // Leer personajes guardados
            List<Personaje> personajes = LeerPersonajes();

            // Eliminar personaje de la lista de personajes
            personajes.RemoveAll(p => p.Dato.Nombre == personaje.Dato.Nombre && p.Dato.Apodo == personaje.Dato.Apodo);

            // Guardar lista actualizada de personajes
            GuardarPersonajes(personajes);

            // Leer derrotas guardadas
            List<Personaje> derrotas = LeerDerrotas();

            // Agregar personaje a la lista de derrotas
            derrotas.Add(personaje);

            // Guardar lista actualizada de derrotas
            GuardarDerrotas(derrotas);
        }
         // Método para leer ganadores del salón de la fama
        public List<Personaje> LeerGanadores()
        {
            if (File.Exists(rutaSalonDeLaFama))
            {
                string json = File.ReadAllText(rutaSalonDeLaFama);
                return JsonSerializer.Deserialize<List<Personaje>>(json);
            }
            return new List<Personaje>();
        }

    // Método para guardar ganadores en el salón de la fama
        public void GuardarGanadores(List<Personaje> ganadores)
        {
            string json = JsonSerializer.Serialize(ganadores);
            File.WriteAllText(rutaSalonDeLaFama, json);
        }

        // Método para mover un personaje al salón de la fama
        public void MoverAGanadores(Personaje personaje)
        {
            List<Personaje> ganadores = LeerGanadores();
            ganadores.Add(personaje);
            GuardarGanadores(ganadores);
        }
}
    


