using System.ComponentModel.DataAnnotations;

namespace NascarPage.Validaciones
{
    public class PesoArchivoValidation : ValidationAttribute
    {
        private readonly int maxPesoMB;

        public PesoArchivoValidation(int maxPesoMB)
        {
            this.maxPesoMB = maxPesoMB;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null) return ValidationResult.Success;  
            IFormFile? formFile = value as IFormFile;
            if(formFile == null) return ValidationResult.Success;

            if(formFile.Length > maxPesoMB *1024 *1024)
            {
                return new ValidationResult($"El archivo excede el peso maximo de {maxPesoMB} Mb");
            }

            return ValidationResult.Success;
        }
    }
}
