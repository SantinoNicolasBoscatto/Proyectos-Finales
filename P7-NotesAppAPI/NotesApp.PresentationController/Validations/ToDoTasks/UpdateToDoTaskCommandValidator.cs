using FluentValidation;
using NotesApp.Application.Features.ToDoTasks.Commands.UpdateToDoTask;
using NotesApp.PresentationController.Validations;

namespace NotesApp.Presentation.Validations.ToDoTasks
{
    public class UpdateToDoTaskCommandValidator : AbstractValidator<UpdateToDoTaskCommand>
    {
        public UpdateToDoTaskCommandValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage(CommonMessages.noVacio)
               .MaximumLength(50).WithMessage("El maximo de caracteres son 50");
            RuleFor(x => x.StatusId).GreaterThan(0).WithMessage(CommonMessages.valorValido);
            RuleFor(x => x.PriorityId).GreaterThan(0).WithMessage(CommonMessages.valorValido);
            RuleFor(x => x.NoteId).GreaterThan(0).WithMessage(CommonMessages.valorValido);
        }
    }
}
