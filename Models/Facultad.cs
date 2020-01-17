using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Ponencias02.Models
{
    public class Facultad
    {
          
        [JsonProperty("id")]
        public int id {get; set;}

        [JsonProperty("NombreFacultad")]
        [Required]
        public string NombreFacultad {get; set;}
        
        public List<Docente> Docentes { get; } = new List<Docente>();
    }
}