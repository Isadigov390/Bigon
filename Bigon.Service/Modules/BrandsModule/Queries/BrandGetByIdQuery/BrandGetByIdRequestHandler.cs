using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    class BrandGetByIdRequestHandler : IRequestHandler<BrandGetByIdRequest, BrandGetByIdRequestDto>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetByIdRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public async Task<BrandGetByIdRequestDto> Handle(BrandGetByIdRequest request, CancellationToken cancellationToken)
        {
            Brand entity;

            if (request.OnlyAvailable)
            {
                entity=await brandRepository.GetAsync(m=>m.Id==request.Id && m.DeletedBy==null, cancellationToken);
            }
            else
            {
                entity=await brandRepository.GetAsync(m=>m.Id==request.Id,cancellationToken);
            }

            var dto = new BrandGetByIdRequestDto
            {
                Id= entity.Id,
                Name=entity.Name,
            };

            return dto;
        }
    }
}
