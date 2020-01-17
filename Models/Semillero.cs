using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Ponencias02.Models
{
    public class Semillero
    {
          
        [JsonProperty("id")]
        public int id {get; set;}
        
        [JsonProperty("NombreSemillero")]
        public string NombreSemillero {get; set;}

        [JsonProperty("GrupoInvestigacionId")]
        public int GrupoInvestigacionId {get; set;}

        [JsonProperty("GrupoInvestigacion")]
        public GrupoInvestigacion GrupoInvestigacion {get; set;}

        public List<Estudiante> Estudiantes { get; } = new List<Estudiante>();

    }
}     
