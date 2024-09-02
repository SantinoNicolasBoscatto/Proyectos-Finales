namespace NascarPage.DTOs
{
    public class LecturaGaleriaDTO
    {
        public int Id { get; set; }
        public int Ronda { get; set; }
        public string FotoUno { get; set; } = null!;
        public string FotoDos { get; set; } = null!;
        public string FotoTres { get; set; } = null!;
    }
}
