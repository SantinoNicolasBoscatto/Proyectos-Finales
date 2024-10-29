using System.ComponentModel.DataAnnotations;

namespace NascarPage.DTOs
{
    public class LecturaMarcaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Foto { get; set; } = null!;
        public List<LecturaAutoDTO> ListaAutos { get; set; } = null!;
    }

    public class LecturaMarcaNombreDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Foto { get; set; } = null!;
    }
}
