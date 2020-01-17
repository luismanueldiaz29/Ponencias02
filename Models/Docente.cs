using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ponencias02.Models
{
    public class Docente
    {
        [JsonProperty("id")][Key]
        public string id {get; set;}

        [JsonProperty("Nombres")]
        [Required]
        public string Nombres {get; set;}

        [JsonProperty("Apellidos")]
        [Required]
        public string Apellidos {get; set;}

        [JsonProperty("Telefono")]
        public string Telefono {get; set;}

        [JsonProperty("VinculoInst")]
        public string VinculoInst {get; set;}

        [JsonProperty("direccion")]
        public string direccion {get; set;}
        
        [JsonProperty("Email")]
        public string Email {get; set;}

        [JsonProperty("Pass")]
        public string Pass {get; set;}

        [JsonProperty("FacultadId")]
        public int FacultadId {get; set;}

        [JsonProperty("Facultad")]
        public Facultad Facultad {get; set;}

        [JsonProperty("GrupoInvestigacionId")]
        public int GrupoInvestigacionId {get; set;}

        [JsonProperty("GrupoInvestigacion")]
        public GrupoInvestigacion GrupoInvestigacion {get; set;}
        
        public List<Solicitud> Solicitud { get; } = new List<Solicitud>();
    }
}