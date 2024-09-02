using System.ComponentModel.DataAnnotations;

namespace NascarPage.Validaciones
{
    public class ExtensionArchivoValidation : ValidationAttribute
    {
        private readonly string[]? extensionesArchivo;

        public ExtensionArchivoValidation(GruposExtensiones gruposExtensiones)
        {
            if(gruposExtensiones == GruposExtensiones.Imagen) extensionesArchivo = new string[] { "image/jpeg", "image/png", "image/gif" };
            else if(gruposExtensiones == GruposExtensiones.Video) extensionesArchivo = new string[] { "video/mp4", "video/avi" };
            else extensionesArchivo = new string[] { "text/html", "text/json" };
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value == null) return ValidationResult.Success;
           IFormFile? formFile = value as IFormFile;
           if(formFile == null) return ValidationResult.Success;

            if (!extensionesArchivo!.Contains(formFile.ContentType))
                return new ValidationResult($"El archivo enviado es de formato incorrecto, porfavor ingrese un archivo con las siguientes Extensiones: {string.Join(",", extensionesArchivo!)}");

            return ValidationResult.Success;
        }
    }

    public enum GruposExtensiones
    {
        Imagen,
        Video,
        DocumentoTexto
    }
}
