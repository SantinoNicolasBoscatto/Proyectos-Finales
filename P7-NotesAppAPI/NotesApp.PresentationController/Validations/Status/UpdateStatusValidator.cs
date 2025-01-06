using FluentValidation;
using NotesApp.Application.Features.Statuses.Commands.UpdateStatus;

namespace NotesApp.PresentationController.Validations.Status
{
    public class UpdateStatusValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(CommonMessages.noVacio)
                    .MaximumLength(30).WithMessage("El maximo de caracteres son 30");
        }
    }
}
