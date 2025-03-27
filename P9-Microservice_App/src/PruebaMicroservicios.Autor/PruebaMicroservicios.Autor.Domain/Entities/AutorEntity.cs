using PruebaMicroservicios.Autor.Domain.BaseEntities;

namespace PruebaMicroservicios.Autor.Domain.Entities
{
    public class AutorEntity : BaseEntity
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime Born { get; set; }
    }
}
