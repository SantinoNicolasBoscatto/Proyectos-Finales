using NascarPage.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearPilotoDTO : PatchPilotoDTO
    {
        [PesoArchivoValidation(15)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? FotoPiloto { get; set; }
    }
}
