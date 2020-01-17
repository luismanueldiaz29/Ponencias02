using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Ponencias02.Models
{
    public class Programa
    {
          
        [JsonProperty("id")]
        public int id {get; set;}

        [JsonProperty("NombrePrograma")]
        [Required]
        public string NombrePrograma {get; set;}

        [JsonProperty("FacultadId")]
        public int FacultadId {get; set;}

        [JsonProperty("Facultad")]
        public Facultad Facultad {get; set;}
        
    }
}