using FluentValidation;

namespace Bigon.Application.Modules.BrandsModule.Commands.ContactPostApplyCommand
{
     class ContactPostApplyRequestValidator : AbstractValidator<ContactPostApplyRequest>
    {
        public ContactPostApplyRequestValidator()
        {
            RuleFor(m => m.FullName)
                .NotNull().WithMessage("FullName must not be empty")
                .NotEmpty().WithMessage("FullName must not be empty")
                .MinimumLength(2).WithMessage("Enter at least 2 characters");

            RuleFor(m => m.Email)
                .NotNull().WithMessage("Email must not be empty")
                .NotEmpty().WithMessage("Email must not be empty")
                .EmailAddress().WithMessage("Invalid email");

            RuleFor(m => m.Subject)
                .NotNull().WithMessage("Subject must not be empty")
                .NotEmpty().WithMessage("Subject must not be empty")
                .MinimumLength(2).WithMessage("Enter at least 2 characters");

            RuleFor(m => m.Message)
                .NotNull().WithMessage("Message must not be empty")
                .NotEmpty().WithMessage("Message must not be empty")
                .MinimumLength(2).WithMessage("Enter at least 2 characters");
        }
    }
}
