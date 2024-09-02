using NascarPage.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearMarcaDTO
    {
        [Required]
        public string Nombre { get; set; } = null!;
        [PesoArchivoValidation(10)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? Foto { get; set; }
    }
}
