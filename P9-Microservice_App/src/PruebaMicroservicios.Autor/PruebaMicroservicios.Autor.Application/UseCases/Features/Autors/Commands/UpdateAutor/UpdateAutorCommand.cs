using MediatR;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.UpdateAutor
{
    public class UpdateAutorCommand : IRequest<bool>
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime Born { get; set; }
    }
}
