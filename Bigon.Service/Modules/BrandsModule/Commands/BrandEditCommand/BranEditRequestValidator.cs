using FluentValidation;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandEditCommand
{
     class BranEditRequestValidator : AbstractValidator<BrandEditRequest>
    {
        public BranEditRequestValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be empty")
                .MinimumLength(2).WithMessage("Enter at least 2 characters");
        }
    }
}
