using FluentValidation;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorAddCommand
{
    class ColorAddRequestValidator : AbstractValidator<ColorAddRequest>
    {
        public ColorAddRequestValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty().WithMessage("Name bos buraxila bilmez")
                .NotNull().WithMessage("Name bos buraxila bilmez")
                .MinimumLength(2).WithMessage("En az 2 herf daxil edin  ");

            RuleFor(m => m.HexCode)
                .NotEmpty().WithMessage("HexCode bos buraxila bilmez")
                .NotNull().WithMessage("HexCode bos buraxila bilmez")
                .MinimumLength(2).WithMessage("En az 2 herf daxil edin  ")
                .Matches("^#(([0-9a-fA-F]{6})|([0-9a-fA-F]{8}))$").WithMessage("Reng kodu standartlari odemir");


        }
    }
}
