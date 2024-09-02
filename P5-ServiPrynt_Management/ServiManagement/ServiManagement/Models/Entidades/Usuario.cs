namespace ServiManagement.Models.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public bool EsAdmin { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public List<Orden> Ordenes { get; set; }
    }
}
