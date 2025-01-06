using FluentValidation;
using NotesApp.Application.Features.Priorities.Commands.UpdatePriority;

namespace NotesApp.PresentationController.Validations.Priority
{
    public class UpdatePriorityValidator : AbstractValidator<UpdatePriorityCommand>
    {
        public UpdatePriorityValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(CommonMessages.noVacio)
                    .MaximumLength(25).WithMessage("El maximo de caracteres son 25");
        }
    }
}
