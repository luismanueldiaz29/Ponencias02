using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Ponencias02.Models
{
    public class Administrador
    {
        [JsonProperty("id")][Key]
        public string id {get; set;}

        [JsonProperty("Nombres")][Required]
        public string Nombres {get; set;}

        [JsonProperty("Apellidos")][Required]
        public string Apellidos {get; set;}

        [JsonProperty("Usuario")][Required]
        public string Usuario {get; set;}

        [JsonProperty("Pass")][Required]
        public string Pass {get; set;}

    }
}