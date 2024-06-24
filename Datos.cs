namespace personajes;

public class Datos
{
    public string Tipo{get;set; }
    public string Nombre{get;set; }
    public string Apodo{get;set; }
    public DateTime FechaNacimiento{get;set; }
    public int Edad{get;set;}
    public Datos(string tipo, string nombre, string apodo, DateTime fechaNacimiento, int edad){
        this.Tipo= tipo;
        this.Nombre= nombre;
        this.Apodo= apodo;
        this.FechaNacimiento= fechaNacimiento;
        this.Edad= edad;
    }
 }