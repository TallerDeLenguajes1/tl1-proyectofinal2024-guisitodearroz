namespace personajes;

public class Datos
{
    string tipo;
    string nombre;
    string apodo;
    DateTime fechaNacimiento;
    int edad;
    public Datos(string tipo, string nombre, string apodo, DateTime fechaNacimiento, int edad){
        this.Tipo= tipo;
        this.Nombre= nombre;
        this.Apodo= apodo;
        this.FechaNacimiento= fechaNacimiento;
        this.Edad= edad;
    }
    public string Tipo{get=> tipo;set=>tipo=value; }
    public string Nombre{get=> nombre;set=>nombre=value; }
    public string Apodo{get=> apodo;set=>apodo=value; }
    public DateTime FechaNacimiento{get=> fechaNacimiento;set=>fechaNacimiento=value; }
    public int Edad
    {
        get=> edad;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException("Edad debe estar entre 0 y 100");
            }
            edad= value; 
        }

}}