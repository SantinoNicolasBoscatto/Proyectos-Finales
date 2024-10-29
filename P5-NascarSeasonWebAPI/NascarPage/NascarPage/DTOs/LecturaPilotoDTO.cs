using NascarPage.Entitys;

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
        public int Top5s { get; set; }
        public int Top10s { get; set; }
        public int Campeonatos { get; set; }
        public bool enActivo { get; set; }
        public int Edad { get; set; }
        public LecturaAutoDTO Auto { get; set; } = null!;
        public LecturaNacionalidadDTO Nacionalidad { get; set; } = null!;
    }

    public class LecturaNombrePilotoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Numero { get; set; }
    }
}
