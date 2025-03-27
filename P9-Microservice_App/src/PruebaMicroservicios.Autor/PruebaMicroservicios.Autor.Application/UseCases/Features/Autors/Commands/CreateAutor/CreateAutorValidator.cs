using FluentValidation;

namespace PruebaMicroservicios.Autor.Application.UseCases.Features.Autors.Commands.CreateAutor
{
    public class CreateAutorValidator : AbstractValidator<CreateAutorCommand>
    {
        public CreateAutorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.Born).NotEmpty().NotNull();
        }
    }
}
