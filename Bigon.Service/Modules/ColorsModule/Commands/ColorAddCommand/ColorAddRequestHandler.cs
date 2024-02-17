using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorAddCommand
{
    class ColorAddRequestHandler : IRequestHandler<ColorAddRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorAddRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            var color = new Color();
            color.Name = request.Name;
            color.HexCode = request.HexCode;
            await colorRepository.AddAsync(color, cancellationToken);
            await colorRepository.SaveAsync(cancellationToken);
            return color;
        }
    }
}
