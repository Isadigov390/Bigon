using Bigon.Application.Repositories;
using MediatR;

namespace Bigon.Application.Modules.SizesModule.Commands.SizeRemoveCommand
{
    class SizeRemoveRequestHandler : IRequestHandler<SizeRemoveRequest>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeRemoveRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }
        public async  Task Handle(SizeRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await sizeRepository.GetAsync(m=>m.Id==request.Id && m.DeletedBy==null,cancellationToken);
            sizeRepository.Remove(entity);
            await sizeRepository.SaveAsync(cancellationToken);
                
        }
    }
}
