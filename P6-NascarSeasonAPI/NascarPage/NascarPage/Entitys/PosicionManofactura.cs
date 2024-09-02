namespace NascarPage.Entitys
{
    public class PosicionManofactura
    {
        public int Id { get; set; }
        public Marca Marca { get; set; } = null!;
        public int MarcaId { get; set; }
        public int Puntos { get; set; }
    }
}
