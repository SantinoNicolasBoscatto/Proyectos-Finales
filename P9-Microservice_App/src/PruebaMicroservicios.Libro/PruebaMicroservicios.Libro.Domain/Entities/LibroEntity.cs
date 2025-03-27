using PruebaMicroservicios.Libro.Domain.Base;

namespace PruebaMicroservicios.Libro.Domain.Entities
{
    public class LibroEntity : BaseEntity
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? AutorId { get; set; }
    }
}
