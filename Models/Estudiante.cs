using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ponencias02.Models
{
    public class Estudiante
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("NombreEstudiante")]
        public string NombreEstudiante { get; set; }

        [JsonProperty("ApellidoEstudiante")]
        public string ApellidoEstudiante { get; set; }

        [JsonProperty("SemilleroId")]
        public int SemilleroId {get; set;}

        [JsonProperty("Semillero")]
        public Semillero Semillero {get; set;}

    }
}