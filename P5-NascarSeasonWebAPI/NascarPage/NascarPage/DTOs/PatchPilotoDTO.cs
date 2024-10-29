using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class PatchPilotoDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "El Campo {0} no puede ser mayor a {1}")]
        public string Nombre { get; set; } = null!;
        [StringLength(maximumLength: 3, ErrorMessage = "El Campo {0} no puede ser mayor a {1}")]
        public string? Numero { get; set; }
        [Required]
        public int CarrerasGanadas { get; set; }
        [Required]
        public int Poles { get; set; }
        [Required]
        public int Top5s { get; set; }
        [Required]
        public int Top10s { get; set; }
        [Required]
        public int Campeonatos { get; set; }
        [Required]
        public bool EnActivo { get; set; }
        [Required]
        public int NacionalidadId { get; set; }
        [Required]
        public int Edad { get; set; }
    }
}
