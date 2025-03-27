using MediatR;

namespace PruebaMicroservicios.Libro.Application.UseCases.Features.Libros.Queries.GetAllLibros
{
    public class GetAllLibrosQuery : IRequest<List<GetAllLibrosResponseDTO>>
    {
    }
}
