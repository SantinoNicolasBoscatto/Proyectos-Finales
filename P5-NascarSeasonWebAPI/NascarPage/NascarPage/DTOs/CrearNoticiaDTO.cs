using NascarPage.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearNoticiaDTO
    {
        [Required]
        [MaxLength(80)]
        public string Titulo { get; set; } = null!;
        [PesoArchivoValidation(10)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? Foto { get; set; }
        [MaxLength(1000)]
        public string? Detalles { get; set; }
    }
}
