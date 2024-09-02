using System.ComponentModel.DataAnnotations;

namespace NascarPage.Entitys
{
    public class Carrera
    {
        [Required]
        public int Id { get; set; }
        public int Evento { get; set; }
        [Required]
        public int Finish { get; set; }
        [Required]
        public int Start { get; set; }
        [Required]
        public int Laps { get; set; }
        [Required]
        public int Led { get; set; }
        [Required]
        public int Puntos { get; set; }
        [Required]
        public string Numero { get; set; } = null!;
        [Required]
        public string Piloto { get; set; } = null!;
        [Required]
        public string Interval { get; set; } = null!;
        [Required]
        public string Qual { get; set; } = null!;
        [Required]
        public string Status { get; set; } = null!;
    }
}
