using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.BrandsModule.Queries.BrandsGetAllQuery
{
    class BrandGetAllQueryRequestHandler : IRequestHandler<BrandGetAllQueryRequest, IEnumerable<BrandGetAllQueryRequestDto>>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetAllQueryRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public  async Task<IEnumerable<BrandGetAllQueryRequestDto>> Handle(BrandGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            var query =  brandRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedBy == null);
            }
            var response= await query.Select(m=>new BrandGetAllQueryRequestDto
            {
                Id= m.Id,   
                Name=m.Name,
            }).ToListAsync(cancellationToken);
            return response;
        }
    }
}
