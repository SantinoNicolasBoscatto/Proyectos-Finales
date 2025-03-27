using MediatR;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.CreateAutor
{
    public class CreateAutorCommand : IRequest<bool>
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public DateTime Born { get; set; }
    }


}
