using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Ponencias02.Models
{
    public class Investigacion
    {
          
        [JsonProperty("id")]
        public int id {get; set;}

        [JsonProperty("NombreInvestigacion")]
        [Required]
        public string NombreInvestigacion {get; set;}
        
        [JsonProperty("SolicitudId")]
        public int SolicitudId {get; set;}

        [JsonProperty("Solicitud")]
        public Solicitud Solicitud {get; set;}
    }
}