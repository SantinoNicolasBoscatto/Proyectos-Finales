using NascarPage.Entitys;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class LecturaPilotoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Numero { get; set; }
        public string FotoPiloto { get; set; } = null!;
        public int CarrerasGanadas { get; set; }
        public int Poles { get; set; }
        public int Campeonatos { get; set; }
        public bool enActivo { get; set; }
        //public int? AutoId { get; set; }
        public LecturaAutoDTO Auto { get; set; } = null!;
        public LecturaNacionalidadDTO Nacionalidad { get; set; } = null!;
    }
}
