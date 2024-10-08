using NascarPage.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearGaleriaDTO
    {
        [Required]
        public int Ronda { get; set; }
        [PesoArchivoValidation(50)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? FotoUno { get; set; }
        [PesoArchivoValidation(50)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? FotoDos { get; set; }
        [PesoArchivoValidation(50)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? FotoTres { get; set; }
    }
}
