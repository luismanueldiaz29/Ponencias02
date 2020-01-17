using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Ponencias02.Models
{
    public class Transporte
    {
      [JsonProperty("id")]
      public int id {get; set;}

    //  [JsonProperty("SolicitudId")]
      //[Required]
      //public int id {get; set;}

      [JsonProperty("TipoTransporte")]
      public string TipoTransporte {get; set;}

      [JsonProperty("ValorTrasporte")]
      [Required]
      public decimal ValorTrasporte {get; set;}
      
      [JsonProperty("SolicitudId")]
      public int SolicitudId {get; set;}

      [JsonProperty("Solicitud")]
      public Solicitud Solicitud {get; set;}

    }
}