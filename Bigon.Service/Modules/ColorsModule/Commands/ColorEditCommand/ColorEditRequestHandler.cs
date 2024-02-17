using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;
using System.Net.Http.Headers;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    class ColorEditRequestHandler : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorEditRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await colorRepository.GetAsync(m => m.Id == request.Id);
            entity.Name = request.Name;
            entity.HexCode = request.HexCode;
            await colorRepository.EditAsync(entity);
            await colorRepository.SaveAsync(cancellationToken);
            return entity;
        }
    }
}
