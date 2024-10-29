using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class PatchAutoDTO
    {
        public int? PilotoId { get; set; }
        [Required]
        public int MarcaId { get; set; }
    }
}
