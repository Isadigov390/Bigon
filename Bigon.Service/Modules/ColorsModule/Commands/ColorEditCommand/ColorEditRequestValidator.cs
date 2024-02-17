using FluentValidation;
using Microsoft.AspNetCore.Rewrite;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    public class ColorEditRequestValidator : AbstractValidator<ColorEditRequest>
    {
        public ColorEditRequestValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0");

            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name bos buraxila bilmez")
                .NotNull().WithMessage("Name bos buraxila bilmez")
                .MinimumLength(2).WithMessage("Min 2 herf daxil edin");

            RuleFor(m => m.HexCode)
                .NotEmpty().WithMessage("Hex code bos buraxila bilmez")
                .NotNull().WithMessage("HexCode bos buraxila bilmez")
                .MinimumLength(2).WithMessage("En az 2 herf daxil edin.")
                .Matches("^#(([0-9a-fA-F]{6})|([0-9a-fA-F]{8}))$").WithMessage("Reng kodu standartlari odemir.");
        }
    }
}
