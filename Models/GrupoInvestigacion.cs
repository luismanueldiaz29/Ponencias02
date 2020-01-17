using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Ponencias02.Models
{
    public class GrupoInvestigacion
    {
          
        [JsonProperty("id")]
        public int id {get; set;}

        [JsonProperty("NombreGrupo")]
        [Required]
        public string NombreGrupo {get; set;}

        public List<Docente> Docentes { get; } = new List<Docente>();
    
        public List<Semillero> Semillero { get; } = new List<Semillero>();

    }
}