using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SizesModule.Commands.SizeAddCommand
{
    class SizeAddRequestHandler : IRequestHandler<SizeAddRequest, Size>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeAddRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }
        public async Task<Size> Handle(SizeAddRequest request, CancellationToken cancellationToken)
        {
            var size = new Size();
            size.Name=request.Name;
            size.SmallName=request.SmallName;   
            size = await sizeRepository.AddAsync(size, cancellationToken);
            await sizeRepository.SaveAsync(cancellationToken);
            return size;
        }
    }
}
