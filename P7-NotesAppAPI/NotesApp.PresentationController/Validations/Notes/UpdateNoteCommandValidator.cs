using FluentValidation;
using NotesApp.Application.Features.Notes.Commands.UpdateNote;
using NotesApp.PresentationController.Validations;

namespace NotesApp.Presentation.Validations.Notes
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(CommonMessages.noVacio)
                .MaximumLength(50).WithMessage("El maximo de caracteres son 50");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage(CommonMessages.valorValido);
        }
    }
}
