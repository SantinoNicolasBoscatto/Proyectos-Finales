using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearCarreraDTO
    {
        [Required]
        public string Finish { get; set; } = null!;
        [Required]
        public string Start { get; set; } = null!;
        [Required]
        public string Laps { get; set; } = null!;
        [Required]
        public string Led { get; set; } = null!;
        [Required]
        public string Puntos { get; set; } = null!;
        [Required]
        public string Numero { get; set; } = null!;
        [Required]
        public string Piloto { get; set; } = null!;
        [Required]
        public string Interval { get; set; } = null!;
        [Required]
        public string Qual { get; set; } = null!;
        [Required]
        public string Status { get; set; } = null!;
    }
}
