using FluentValidation;
using NotesApp.Application.Features.Statuses.Commands.CreateStatus;

namespace NotesApp.PresentationController.Validations.Status
{
    public class CreateStatusValidator : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(CommonMessages.noVacio)
                    .MaximumLength(30).WithMessage("El maximo de caracteres son 30");
        }
    }
}
