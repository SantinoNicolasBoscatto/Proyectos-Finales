using System.ComponentModel.DataAnnotations;

namespace NascarPage.Entitys
{
    public class Galeria
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Ronda { get; set; }
        public string FotoUno { get; set; } = null!;
        public string FotoDos { get; set; } = null!;
        public string FotoTres { get; set; } = null!;
    }
}
