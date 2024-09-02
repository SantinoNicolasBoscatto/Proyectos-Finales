namespace ServiPryntWeb.Models.Entidades
{
    public class TypeProduct
    {
        public int TypeId { get; set; }
        public string? TypeName { get; set; }
        public ICollection<Productos>? ProductosTypeCollection { get; set; }
    }
}
