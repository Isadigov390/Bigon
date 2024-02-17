using FluentValidation;

namespace Bigon.Application.Modules.BrandsModule.Commands.BrandAddCommand
{
     class BrandAddRequestValidator :AbstractValidator<BrandAddRequest>   
    {
        public BrandAddRequestValidator()
        {
            RuleFor(m => m.Name)
                .NotNull().WithMessage("Name must not empty ")
                .NotEmpty().WithMessage("Name must not empty ")
                .MinimumLength(2).WithMessage("Enter at least 2 characters");
        }
    }
}
