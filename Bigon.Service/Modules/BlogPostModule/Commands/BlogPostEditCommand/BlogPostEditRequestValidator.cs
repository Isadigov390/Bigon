using FluentValidation;

namespace Bigon.Application.Modules.BlogPostModule.Commands.BlogPostEditCommand
{
     class BlogPostEditRequestValidator : AbstractValidator<BlogPostEditRequest>
    {
        public BlogPostEditRequestValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThan(0).WithMessage("Id must greater than 0");

            RuleFor(m => m.Title)
                .NotNull().WithMessage("Title must not be empty")
                .NotEmpty().WithMessage("Title must not be empty")
                .MinimumLength(5).WithMessage("Enter at least 5 characters");

            RuleFor(m => m.Body)
                .Empty().WithMessage("Body must not empty")
                .NotNull().WithMessage("Body must not empty")
                .MinimumLength(5).WithMessage("Enter at least 5 characters");

            RuleFor(m => m.Image)
                .NotNull().WithMessage("Image must not be empty,upload image,please.");

            RuleFor(m => m.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must greater than 0.");
        }
    }
}
