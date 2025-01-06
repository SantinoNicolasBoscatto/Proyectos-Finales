using FluentValidation;
using NotesApp.Application.Features.Categorys.Commands.CreateCategory;

namespace NotesApp.PresentationController.Validations.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator() 
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(CommonMessages.noVacio)
                    .MaximumLength(50).WithMessage("El maximo de caracteres son 50");
        }
    }
}
