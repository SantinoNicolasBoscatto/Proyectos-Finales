using NascarPage.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class CrearCampeonDTO : PatchCampeonDTO
    {
        [PesoArchivoValidation(25)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? AutoCampeon { get; set; }
    }
}
