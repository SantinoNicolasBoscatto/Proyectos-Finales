using System.ComponentModel.DataAnnotations;

namespace NascarPage.Entitys
{
    public class Campeon
    {
        public int Id { get; set; }
        [Required]
        [Range(1948, 9999, ErrorMessage = "El Valor ingresado esta fuera de rango")]
        public int Year { get; set; }
        public string AutoCampeon { get; set; } = null!;
        public int PilotoId { get; set; }
        public Piloto Piloto { get; set; } = null!;
    }
}
