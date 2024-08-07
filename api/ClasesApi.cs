 namespace clasesApi;
//clases para deserializar los json ya creados
public class ApodoJson{
    public List<string> Apodos{ get; set;}
}
public class ProvinciasJson{
    public List<string> provincias{ get; set;}
}
public class TipoEnemigos
{
    public List<string> Tipo{ get; set;} 
}
public class nombrePersonaje
{
    public List<string> Nombres{ get; set;}
}













// //clases para la api que me trae nombre, apellido y fecha de nacimiento
//  public class Address
//     {
//         public string city { get; set; }
//         public string street_name { get; set; }
//         public string street_address { get; set; }
//         public string zip_code { get; set; }
//         public string estado { get; set; }
//         public string pas { get; set; }
//         public Coordenadas coordenadas { get; set; }
//     }

//     public class Coordenadas
//     {
//         public double lat { get; set; }
//         public double lng { get; set; }
//     }

//     public class CreditCard
//     {
//         [JsonProperty("cc_number ")]
//         public string cc_number { get; set; }
//     }

//     public class Empleo
//     {
//         public string title { get; set; }
//         public string key_skill { get; set; }
//     }

//     public class PersonaDatos
//     {
//         public int id { get; set; }
//         public string uid { get; set; }
//         public string contrasea { get; set; }
//         public string first_name { get; set; }
//         public string last_name { get; set; }
//         public string apodo {get; set;}
//         public string provincia {get; set;}

//         [JsonProperty("nombre de usuario")]
//         public string nombredeusuario { get; set; }
//         public string email { get; set; }
//         public string avatar { get; set; }
//         public string gender { get; set; }
//         public string phone_number { get; set; }
//         public string social_insurance_number { get; set; }
//         public string date_of_birth { get; set; }
//         public Empleo empleo { get; set; }
//         public Address address { get; set; }
//         public CreditCard credit_card { get; set; }
//         public Suscripción suscripcin { get; set; }
//     }

//     public class Suscripción
//     {
//         public string plan { get; set; }
//         public string status { get; set; }
//         public string mtodo_pago { get; set; }
//         public string term { get; set; }
//     }
