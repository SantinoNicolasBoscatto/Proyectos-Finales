namespace NascarPage.Entitys
{
    public class Nacionalidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Bandera { get; set; } = null!;
        public List<Piloto>? ListaPilotos { get; set; }
    }
}
