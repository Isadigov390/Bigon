using FluentValidation;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryEditCommand
{
     class CategoryEditRequestValidator : AbstractValidator<CategoryEditRequest>
    {
        public CategoryEditRequestValidator()
        {
            RuleFor(m => m.Id)
              .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be empty")
                .MinimumLength(0).WithMessage("Enter at least 2 characters");

            RuleFor(m => m.Type)
                .NotNull().WithMessage("Type must not be empty");


        }
    }
}
