using FluentValidation;
using NotesApp.Application.Features.Priorities.Commands.CreatePriority;

namespace NotesApp.PresentationController.Validations.Priority
{
    public class CreatePriorityValidator : AbstractValidator<CreatePriorityCommand>
    {
        public CreatePriorityValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(CommonMessages.noVacio)
                    .MaximumLength(25).WithMessage("El maximo de caracteres son 25");
        }
    }
}
