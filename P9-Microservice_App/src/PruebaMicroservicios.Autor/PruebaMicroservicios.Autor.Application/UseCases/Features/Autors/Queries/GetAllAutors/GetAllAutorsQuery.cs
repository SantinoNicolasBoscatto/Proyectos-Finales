using MediatR;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Queries.GetAllAutors
{
    public class GetAllAutorsQuery : IRequest<List<GetAllAutorsResponseDTO>>
    {
    }
}
