using MediatR;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Commands.CreateLibro
{
    public class CreateLibroCommand : IRequest<bool>
    {
        public string? Id { get; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? AutorId { get; set; }
    }
}
