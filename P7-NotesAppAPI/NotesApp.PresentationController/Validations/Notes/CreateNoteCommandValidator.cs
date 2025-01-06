using FluentValidation;
using NotesApp.Application.Features.Notes.Commands.CreateNote;
using NotesApp.PresentationController.Validations;

namespace NotesApp.Presentation.Validations.Notes
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(CommonMessages.noVacio)
                .MaximumLength(50).WithMessage("El maximo de caracteres son 50");
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("El maximo de caracteres son 150");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage(CommonMessages.valorValido);
        }
    }
}
