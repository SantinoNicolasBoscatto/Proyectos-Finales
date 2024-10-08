using NascarPage.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearAutoDTO : PatchAutoDTO
    {
        [PesoArchivoValidation(25)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? Foto { get; set; }
    }
}
