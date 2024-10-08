namespace ServiPryntWeb.Models.Entidades
{
    public class Marcas
    {
        public int IdMarca { get; set; }
        public string? NombreMarca { get; set; }
        public ICollection<Productos>? ProductosCollection { get; set; }
    }
}
