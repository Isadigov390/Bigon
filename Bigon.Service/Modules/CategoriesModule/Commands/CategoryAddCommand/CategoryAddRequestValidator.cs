using FluentValidation;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryAddCommand
{
     class CategoryAddRequestValidator : AbstractValidator<CategoryAddRequest>
    {
        public CategoryAddRequestValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be empty")
                .MinimumLength(0).WithMessage("Enter at least 2 characters");

            //RuleFor(m=>m.ParentId)
            //    .Must


            RuleFor(m => m.Type)
                .NotNull().WithMessage("Type must not be empty");
        }
    }
}
