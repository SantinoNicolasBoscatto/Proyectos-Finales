using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class PatchPistaDTO
    {
        [Required]
        [StringLength(maximumLength: 75, ErrorMessage = "El Campo {0} no debe ser mayor a {1} caracteres")]
        public string Nombre { get; set; } = null!;
        [Required]
        [StringLength(maximumLength: 10, ErrorMessage = "El Campo {0} no debe ser mayor a {1} caracteres")]
        public string Distancia { get; set; } = null!;
        [Required]
        public int Vueltas { get; set; }

        public int? Orden { get; set; }
        [Required]
        public bool Disputada { get; set; }
        [Required]
        public bool EnElCalendario { get; set; }
    }
}
