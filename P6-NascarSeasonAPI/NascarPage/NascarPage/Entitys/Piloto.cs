using System.ComponentModel.DataAnnotations;

namespace NascarPage.Entitys
{
    public class Piloto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "El Campo {0} no puede ser mayor a {1}")]
        public string Nombre { get; set; } = null!;
        [StringLength(maximumLength: 3, ErrorMessage = "El Campo {0} no puede ser mayor a {1}")]
        public string? Numero { get; set; }
        [Required]
        public string FotoPiloto { get; set; } = null!;
        [Required]
        public int CarrerasGanadas { get; set; }
        [Required]
        public int Poles { get; set; }
        [Required]
        public int Top5s { get; set; }
        [Required]
        public int Top10s { get; set; }
        [Required]
        public int Campeonatos { get; set; }
        [Required]
        public bool EnActivo { get; set; }
        [Required]
        public int NacionalidadId { get; set; }
        [Required]
        public int Edad { get; set; }

         
        public Auto Auto { get; set; } = null!;
        public Nacionalidad Nacionalidad { get; set; } = null!;
    }
}
