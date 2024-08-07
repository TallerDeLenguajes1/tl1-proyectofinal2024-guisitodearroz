namespace personajes;

public class Datos
{
    public string Tipo{get;set; }
    public string Nombre{get;set; }
    public string Apodo{get;set; }
    public string LugarNacimiento{get; set;}
    public DateTime FechaNacimiento{get;set; }
    public int Edad{get;set;}
    public Datos(){}
    public Datos(string tipo, string nombre, string apodo, DateTime fechaNacimiento, int edad, string lugarNacimiento)
    {
        Tipo = tipo;
        Nombre = nombre;
        Apodo = apodo;
        FechaNacimiento = fechaNacimiento;
        Edad = edad;
        LugarNacimiento = lugarNacimiento;
    }
    public override string ToString()
    {
        return $"Nombre: {Nombre}, Apodo: {Apodo}, Provincia: {LugarNacimiento} ,Fecha de Nacimiento: {FechaNacimiento.ToShortDateString()}, Edad: {Edad}, Provincia: {Tipo}";
    }
 }