using Bigon.Application.Repositories;
using MediatR;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorRemoveCommand
{
    class ColorRemoveRequestHandler : IRequestHandler<ColorRemoveRequest>
    {
        private readonly IColorRepository colorRepository;

        public ColorRemoveRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task Handle(ColorRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await colorRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);
            colorRepository.Remove(entity);
            await colorRepository.SaveAsync(cancellationToken);
        }
    }
}
