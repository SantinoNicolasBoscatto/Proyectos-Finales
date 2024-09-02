using NascarPage.Entitys;

namespace NascarPage.DTOs
{
    public class LecturaManofacturaDTO
    {
        public int Id { get; set; }
        public int Puntos { get; set; }
        public MarcaRegularTablaDTO Marca { get; set; } = null!;
    }
}
