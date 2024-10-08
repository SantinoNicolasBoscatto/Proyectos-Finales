using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class LecturaCarreraDTO
    {
        public int Finish { get; set; }
        public int Start { get; set; }
        public int Laps { get; set; }
        public int Led { get; set; }
        public int Puntos { get; set; }
        public string Numero { get; set; } = null!;
        public string Piloto { get; set; } = null!;
        public string Interval { get; set; } = null!;
        public string Qual { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
