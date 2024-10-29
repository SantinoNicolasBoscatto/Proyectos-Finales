namespace NascarPage.DTOs
{
    public class LecturaNoticiaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Foto { get; set; } = null!;
        public string? Detalles { get; set; }
    }
}
