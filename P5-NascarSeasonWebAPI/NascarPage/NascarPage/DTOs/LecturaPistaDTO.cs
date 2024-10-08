using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class LecturaPistaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Distancia { get; set; } = null!;
        public string FotoPrimaria { get; set; } = null!;
        public string FotoSecundaria { get; set; } = null!;
        public string FotoTerciaria { get; set; } = null!;
        public int Vueltas { get; set; }
        public int? Orden { get; set; }
        public bool Disputada { get; set; }
        public bool EnElCalendario { get; set; }
    }
}
