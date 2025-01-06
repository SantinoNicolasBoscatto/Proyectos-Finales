using FluentValidation;
using NotesApp.Application.Features.Categorys.Commands.UpdateCategory;

namespace NotesApp.PresentationController.Validations.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(CommonMessages.noVacio)
                    .MaximumLength(50).WithMessage("El maximo de caracteres son 50");
        }
    }
}
