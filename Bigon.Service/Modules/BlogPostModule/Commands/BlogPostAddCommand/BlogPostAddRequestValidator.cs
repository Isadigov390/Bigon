using FluentValidation;

namespace Bigon.Application.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
     class BlogPostAddRequestValidator : AbstractValidator<BlogAddRequest>
    {
        public BlogPostAddRequestValidator()
        {
            RuleFor(m => m.Title)
            .NotNull().WithMessage("Title must not be empty")
            .NotEmpty().WithMessage("Title must not be empty")
            .MinimumLength(5).WithMessage("Enter at least 5 characters");

            RuleFor(m=>m.Body)
                .NotEmpty().WithMessage("Body must not empty")
                .NotNull().WithMessage("Body must not empty")
                .MinimumLength(5).WithMessage("Enter at least 5 characters");

            RuleFor(m => m.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must greater than 0");

            RuleFor(m => m.Image)
                .NotNull().WithMessage("Image must not be empty,upload image,please.");
        }
    }
}
