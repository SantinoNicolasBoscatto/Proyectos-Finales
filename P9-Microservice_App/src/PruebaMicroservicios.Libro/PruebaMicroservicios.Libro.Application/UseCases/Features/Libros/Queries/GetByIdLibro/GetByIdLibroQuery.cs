using MediatR;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetByIdLibro
{
    public class GetByIdLibroQuery : IRequest<GetByIdLibroResposeDTO?>
    {
        public string? Id { get; set; }
    }
}
