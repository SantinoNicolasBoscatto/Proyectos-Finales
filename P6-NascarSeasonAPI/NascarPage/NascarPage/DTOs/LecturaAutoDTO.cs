using NascarPage.Entitys;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class LecturaAutoDTO
    {
        public int Id { get; set; }
        public int? PilotoId { get; set; }
        public string Foto { get; set; } = null!;
        public int MarcaId { get; set; }
    }
}
