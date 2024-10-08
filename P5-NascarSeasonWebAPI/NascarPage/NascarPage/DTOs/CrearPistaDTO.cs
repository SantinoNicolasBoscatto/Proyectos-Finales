using NascarPage.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearPistaDTO : PatchPistaDTO
    {
        [PesoArchivoValidation(25)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? FotoPrimaria { get; set; }
        [PesoArchivoValidation(25)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? FotoSecundaria { get; set; }
        [PesoArchivoValidation(25)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? FotoTerciaria { get; set; }
    }
}
