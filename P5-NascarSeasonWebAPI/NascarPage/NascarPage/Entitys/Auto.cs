using System.ComponentModel.DataAnnotations;

namespace NascarPage.Entitys
{
    public class Auto
    {
        public int Id { get; set; }
        public int? PilotoId { get; set; }
        public string? Foto { get; set; }
        public int MarcaId { get; set; }
        public Piloto Piloto { get; set; } = null!;
        public Marca Marca { get; set; } = null!;
    }
}
