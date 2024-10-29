namespace NascarPage.Entitys
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Foto { get; set; } = null!;
        public string? Detalles { get; set; }
    }
}
