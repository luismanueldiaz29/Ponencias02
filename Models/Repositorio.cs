using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace Ponencias02.Models
{
    public class Repositorio
    {
          
        [JsonProperty("id")]
        public int id {get; set;}
        
        [JsonProperty("SolicitudId")]
        public int SolicitudId {get; set;}

        [JsonProperty("Solicitud")]
        public Solicitud Solicitud {get; set;}

        public byte[] Sustentacion {get; set;}

        public byte[] CitasBibliograficas {get; set;}
        
        public byte[] DocValorInscripcion {get; set;}

        public byte[] ContizacionHospedaje {get; set;}

        public byte[] DocInfoEvento {get; set;}

        public byte[] FormatoOriginal {get; set;}

        public byte[] FormatoCesionDerecho {get; set;}
    }
}