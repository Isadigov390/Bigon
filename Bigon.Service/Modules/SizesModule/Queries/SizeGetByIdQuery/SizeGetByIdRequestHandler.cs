using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SizesModule.Queries.SizeGetByIdQuery
{
    class SizeGetByIdRequestHandler : IRequestHandler<SizeGetByIdRequest, SizeGetByIdRequesDto>
    {
        private readonly ISizeRepository sizeRepository;

        public SizeGetByIdRequestHandler(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }
        public async Task<SizeGetByIdRequesDto> Handle(SizeGetByIdRequest request, CancellationToken cancellationToken)
        {
            Size size;
            if (request.OnlyAvailable)
            {
                size = await sizeRepository.GetAsync(m => m.Id == request.Id && m.DeletedBy == null, cancellationToken);

            }
            else
            {
                 size = await sizeRepository.GetAsync(m=>m.Id==request.Id, cancellationToken);
            }
            var dto=new SizeGetByIdRequesDto();
            dto.Id= size.Id;
            dto.Name= size.Name;
            dto.SmallName = size.SmallName;
            return dto;
        }
    }
}
