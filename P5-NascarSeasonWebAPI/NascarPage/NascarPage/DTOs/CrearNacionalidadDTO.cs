using NascarPage.Validaciones;

namespace NascarPage.DTOs
{
    public class CrearNacionalidadDTO
    {
        public string Nombre { get; set; } = null!;
        [PesoArchivoValidation(20)]
        [ExtensionArchivoValidation(GruposExtensiones.Imagen)]
        public IFormFile? Bandera { get; set; }
    }
}
