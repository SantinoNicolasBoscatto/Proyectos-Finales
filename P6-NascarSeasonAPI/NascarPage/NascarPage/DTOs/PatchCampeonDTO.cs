using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class PatchCampeonDTO
    {
        [Required]
        [Range(1948, 9999, ErrorMessage = "El Valor ingresado esta fuera de rango")]
        public int Year { get; set; }
        [Required]
        public int PilotoId { get; set; }
    }
}
