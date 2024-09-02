using NascarPage.Entitys;
using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class LecturaCampeonDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string AutoCampeon { get; set; } = null!;
        public LecturaPilotoDTO Piloto { get; set; } = null!;
    }
}
